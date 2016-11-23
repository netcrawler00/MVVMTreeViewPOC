using System;
using System.Collections.ObjectModel;
using TreeViewPOC.Model;

namespace TreeViewPOC.Gui
{
  public class ConstellationTreeViewModel : ObservableObject
  {
    private ConvertingCollection<Entity, EntityTreeViewModel> _convertedEntities
      = new ConvertingCollection<Entity, EntityTreeViewModel>(new TreeViewItemModelToViewModelConverter());
    private bool _isSelected;
    private Constellation _constellation;

    public ConstellationTreeViewModel()
    {
    }

    public Constellation Constellation {
      get
      {
        return _constellation;
      }
      set
      {
        // no crap
        if (value == null)
        {
          throw new ArgumentNullException(nameof(Constellation));
        }
        // real change
        else if (!value.Equals(_constellation))
        {
          _constellation = value;
          NotifyPropertyChanged();
          _convertedEntities.OriginalCollection = _constellation.Entities;
        }
      }
    }

    public string FontWeight { get; } = "Bold";

    public bool IsSelected
    {
      get
      {
        return _isSelected;
      }
      set
      {
        if(_isSelected != value)
        {
          _isSelected = value;
          NotifyPropertyChanged();
        }
      }
    }

    public ObservableCollection<EntityTreeViewModel> Entities => _convertedEntities;

  }
}