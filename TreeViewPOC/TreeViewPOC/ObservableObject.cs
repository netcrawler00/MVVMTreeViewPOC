using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewPOC
{
  /// <summary>
  /// The ObservableObject lovely class that eases PropertyChanged notifications.
  /// </summary>
  public class ObservableObject : INotifyPropertyChanged
  {
    #region NotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged([CallerMemberName]string info = "")
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }
    #endregion
  }
}
