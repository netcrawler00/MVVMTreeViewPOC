using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewPOC.Model
{
  /// <summary>
  /// The constellation is a top level item in the hierarchy
  /// </summary>
  public class Constellation : ObservableObject
  {
    private string _name;

    /// <summary>
    /// Gets or sets the constellation name.
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        if(!string.Equals(_name, value))
        {
          _name = value;
          NotifyPropertyChanged();
        }
      }
    }

    /// <summary>
    /// The collection of entities in this constellation
    /// </summary>
    public ObservableCollection<Entity> Entities { get; } = new ObservableCollection<Entity>();
  }
}
