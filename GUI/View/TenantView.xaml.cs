using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.View;

public partial class TenantView : UserControl
{
    public TenantView()
    {
        InitializeComponent();
    }

    private void OpenNewWindow_Click(object sender, RoutedEventArgs e)
    {
        //MessageBox.Show("This would open a new window to add a shelving unit.");
        AddShelfUnitWindow addShelfUnitWindow = new AddShelfUnitWindow();
        var vm = this.DataContext as ViewModel.TenantViewModel;
        addShelfUnitWindow.DataContext = vm;
        addShelfUnitWindow.Show();
    }

}
