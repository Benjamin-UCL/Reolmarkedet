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
using System.Windows.Shapes;

namespace ReolMarkedTeam7.View
{
    public partial class AddShelvingUnitWindow : Window
    {
        public string? SelectedUnitNumber => UnitCombo.SelectedItem as string;
        public DateTime? StartDate => StartDatePicker.SelectedDate;

        public AddShelvingUnitWindow(IEnumerable<string> unitNumbers)
        {
            InitializeComponent();
            UnitCombo.ItemsSource = unitNumbers;
            StartDatePicker.SelectedDate = DateTime.Today;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (UnitCombo.SelectedItem == null)
            {
                MessageBox.Show("Vælg et reolnummer.", "Manglende valg", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;
    }
}


