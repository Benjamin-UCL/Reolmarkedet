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

namespace ReolMarkedTeam7.View
{
    public partial class TenantView : UserControl
    {
        public TenantView() => InitializeComponent();

        private void AddTenant_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Åbn tom formular / kald VM-kommando
        }

        private void SaveTenant_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Gem via VM (NameBox.Text, PhoneBox.Text, ...)
        }

        private void DeleteTenant_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Slet valgt lejer i TenantsGrid
        }

        private void AddShelf_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddShelfWindow
            {
                Owner = Window.GetWindow(this)  // sæt MainWindow som owner
            };

            if (dlg.ShowDialog() == true)
            {
                // Eksempel på at vise resultatet midlertidigt i listen
                ShelvesList.Items.Add($"{dlg.SelectedShelfNumber}  ({dlg.StartDate:dd-MM-yyyy})");
            }
        }
    }
}

