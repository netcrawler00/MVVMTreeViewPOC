using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TreeViewPOC.Model;

namespace TreeViewPOC.Gui
{
  public class TreeViewItemModelToViewModelConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if(value is Constellation)
      {
        var vm = new ConstellationTreeViewModel();
        vm.Constellation = value as Constellation;
        return vm;
      }
      else if (value is Entity)
      {
        var vm = new EntityTreeViewModel();
        vm.Entity = value as Entity;
        return vm;
      }

      return Binding.DoNothing;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return Binding.DoNothing;
    }
  }
}
