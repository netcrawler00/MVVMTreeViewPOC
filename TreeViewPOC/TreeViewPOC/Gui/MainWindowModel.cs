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
    private RootViewModel _rootVM;

    public MainWindowModel()
    {
      ExitAppCommand = new DelegateCommand(OnExitApp) { IsActive = true };
      CreateUniverseCommand = new DelegateCommand(OnCreateUniverse, CanCreateUniverse) { IsActive = true };
      JustABreakpointCommand = new DelegateCommand(OnJustABreakpoint) { IsActive = true };
      RootVM = new RootViewModel();
      RootVM.Root = new RootObject();
    }

    public RootViewModel RootVM
    {
      get
      {
        return _rootVM;
      }
      set
      {
        // no crap
        if (value == null)
        {
          throw new ArgumentNullException(nameof(RootVM));
        }
        // real change
        else if (!value.Equals(_rootVM))
        {
          _rootVM = value;
          NotifyPropertyChanged();
        }
      }
    }


    #region Commands
    #region CreateUniverseCommand
    public DelegateCommand CreateUniverseCommand { get; }

    private bool CanCreateUniverse()
    {
      return _rootVM != null && _rootVM.Constellations.Count == 0;
    }

    private void OnCreateUniverse()
    {
      _rootVM.Root.CreateUniverse();
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

    #region JustABreakpointCommand
    public DelegateCommand JustABreakpointCommand { get; }

    private void OnJustABreakpoint()
    {
      Console.WriteLine((App.Current.MainWindow.Content as System.Windows.Controls.Grid).Children[0].ToString());
    }
    #endregion

    #endregion


  }
}
