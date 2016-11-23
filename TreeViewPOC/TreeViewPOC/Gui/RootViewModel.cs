using System;
using System.Collections.ObjectModel;
using TreeViewPOC.Model;

namespace TreeViewPOC.Gui
{
  public class RootViewModel : ObservableObject
  {
    private RootObject _root;
    private ConvertingCollection<Constellation, ConstellationTreeViewModel> _convertedConstellations 
      = new ConvertingCollection<Constellation, ConstellationTreeViewModel>(new TreeViewItemModelToViewModelConverter());

    public RootViewModel()
    {
    }

    #region Properties
    public ObservableCollection<ConstellationTreeViewModel> Constellations => _convertedConstellations;

    public RootObject Root
    {
      get
      {
        return _root;
      }
      set
      {
        // no crap
        if (value == null)
        {
          throw new ArgumentNullException(nameof(Root));
        }
        // real change
        else if (!value.Equals(_root))
        {
          _root = value;
          NotifyPropertyChanged();
          _convertedConstellations.OriginalCollection = _root.Constellations; 
        }
      }
    }
    #endregion
  }
}