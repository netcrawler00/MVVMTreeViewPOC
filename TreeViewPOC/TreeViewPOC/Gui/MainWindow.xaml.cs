using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeViewPOC.Model;

namespace TreeViewPOC.Gui
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private static TreeViewItemModelToViewModelConverter _v2vm = new TreeViewItemModelToViewModelConverter();
    public MainWindow()
    {
      InitializeComponent();

      //treeView.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
    }
    /*
    private void ItemContainerGenerator_ItemsChanged(object sender, ItemsChangedEventArgs e)
    {
      var items = treeView.ItemContainerGenerator.Items;
      for (int i = 0; i <  items.Count; i++)
      { 
        items[i] = _v2vm.Convert((sender as TreeViewItem)?.DataContext, typeof(object), null, CultureInfo.CurrentCulture);
      }
    }
    */
  }
}
