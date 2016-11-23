using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TreeViewPOC
{
  class ConvertingCollection<Tin, Tout> : ObservableCollection<Tout>
  {
    private IValueConverter _converter;
    private bool _isObservableCollection;
    private IEnumerable<Tin> _originalCollection;
    private Dictionary<Tin, Tout> _mapping = new Dictionary<Tin, Tout>();


    public ConvertingCollection(IValueConverter converter)
    {
      // save parameters
      _converter = converter;
    }

    public ConvertingCollection(IEnumerable<Tin> originalCollection, IValueConverter converter)
    {
      // save parameters
      _converter = converter;
      OriginalCollection = originalCollection;
    }

    #region Properties
    public IEnumerable<Tin> OriginalCollection
    {
      get
      {
        return _originalCollection;
      }
      set
      {
        if (!value.Equals(_originalCollection))
        {
          // manage older collection
          if (_originalCollection != null && _isObservableCollection)
          {
            (_originalCollection as ObservableCollection<Tin>).CollectionChanged -= originalCollection_CollectionChanged;
            this.Clear();
          }

          _originalCollection = value;

          // setup original collection information.
          _isObservableCollection = _originalCollection is INotifyCollectionChanged;
          if (_originalCollection != null && _isObservableCollection)
          {
            (_originalCollection as INotifyCollectionChanged).CollectionChanged += originalCollection_CollectionChanged;
            foreach (Tin item in _originalCollection)
            {
              AddConverted(item);
            }
          }
        }
      }
    }

    #endregion
    /// <summary>
    /// Indicates the time in milliseconds between two refreshes.
    /// </summary>
    /// <notes>
    /// When the original collection isn't observable, it must be explored to reflect changes in the converted collection.
    /// </notes>
    // TODO
    //public int RefreshRate { get; set; } = 1000;

    /// <summary>
    /// Flushes the collection.
    /// </summary>
    public new void Clear()
    {
      _mapping.Clear();
      base.Clear();
    }

    #region Events management

    private void originalCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      switch (e.Action)
      {
        case NotifyCollectionChangedAction.Add:
          foreach (Tin item in e.NewItems)
          {
            AddConverted(item);
          }
          break;

        case NotifyCollectionChangedAction.Remove:
          foreach (Tin item in e.OldItems)
          {
            RemoveConverted(item);
          }
          break;
      }
    }
    #endregion

    #region Helpers
    /// <summary>
    /// Converts an item and adds it to the collection.
    /// </summary>
    /// <param name="item">The original item.</param>
    private void AddConverted(Tin item)
    {
      Tout converted = (Tout) _converter.Convert(item, typeof(Tout), null, CultureInfo.CurrentCulture);
      _mapping.Add(item, converted);
      this.Add(converted);
    }

    /// <summary>
    /// Removes a converted itemfrom the collection based on its original value.
    /// </summary>
    /// <param name="item">The original item.</param>
    private void RemoveConverted(Tin item)
    {
      this.Remove(_mapping[item]);
      _mapping.Remove(item);
    }
    #endregion
  }
}
