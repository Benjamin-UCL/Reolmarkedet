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
    public partial class TenantView
    {
        public TenantView() => InitializeComponent();

        private void AddShelf_Click(object sender, RoutedEventArgs e)
        {
            var allUnits = new[] { "R26", "R27", "R28", "R31" }; // TODO: hent fra DB/VM
            var dlg = new AddShelvingUnitWindow(allUnits)
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true)
            {
                // Midlertidigt: vis resultatet i listen
                ShelvesList.Items.Add($"{dlg.SelectedUnitNumber}  (fra {dlg.StartDate:d})");

                // TODO: Kald din ViewModel for at tilføje reolen til den valgte lejer.
            }
        }

        // (valgfrit) stubs til de andre knapper:
        private void AddTenant_Click(object s, RoutedEventArgs e) { /* TODO */ }
        private void SaveTenant_Click(object s, RoutedEventArgs e) { /* TODO */ }
        private void DeleteTenant_Click(object s, RoutedEventArgs e) { /* TODO */ }
        private void TenantsGrid_SelectionChanged(object s, System.Windows.Controls.SelectionChangedEventArgs e) { /* TODO */ }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


