using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TreeViewPOC.Model;

namespace TreeViewPOC.Gui
{
  public class MainWindowModel : ObservableObject
  {
    private RootObject _root;

    public MainWindowModel()
    {
      ExitAppCommand = new DelegateCommand(OnExitApp) { IsActive = true };
      CreateUniverseCommand = new DelegateCommand(OnCreateUniverse, CanCreateUniverse) { IsActive = true };
      Root = new Model.RootObject();
    }

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
        }
      }
    }

    #region CreateUniverseCommand
    public DelegateCommand CreateUniverseCommand { get; }

    private bool CanCreateUniverse()
    {
      return _root.Constellations.Count == 0;
    }

    private void OnCreateUniverse()
    {
      _root.CreateUniverse();
      CreateUniverseCommand.RaiseCanExecuteChanged();
    }
    #endregion

    #region ExitAppCommand
    public DelegateCommand ExitAppCommand { get; }

    private void OnExitApp()
    {
      Application.Current.Shutdown();
    }

    #endregion


  }
}
