using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewPOC.Model;

namespace TreeViewPOC.Gui
{
  public class MainWindowModel : ObservableObject
  {
    private RootObject _root;

    public RootObject Root
    {
      get
      {
        return _root;
      }
      set
      {
        // no crap
        if(value == null)
        {
          throw new ArgumentNullException(nameof(Root));
        }
        // real change
        else if(!value.Equals(_root))
        {
          _root = value;
          NotifyPropertyChanged();
          NotifyPropertyChanged(nameof(Constellations));
        }
      }
    }

    /// <summary>
    /// Gives direct access to the constellations (may be useless)
    /// </summary>
    public ObservableCollection<Constellation> Constellations => _root.Constellations;
  }
}
