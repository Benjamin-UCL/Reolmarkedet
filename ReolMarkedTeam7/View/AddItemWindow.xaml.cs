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
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            InitializeComponent();
            // TODO: udfyld ShelfCombo ItemsSource fra VM/repository
            // ShelfCombo.ItemsSource = ...;  ShelfCombo.DisplayMemberPath = "...";
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: valider + gem (kald VM/repository)
            MessageBox.Show("Vare gemt (stub).");
            DialogResult = true;
        }

        private void ImportCsv_Click(object sender, RoutedEventArgs e)
        {
            // TODO: åbn filvælger og håndtér import (senere)
            MessageBox.Show("CSV import (stub).");
        }

        // Simpel numerisk filter til prisfelt (komma og tal)
        private static readonly Regex priceRegex = new Regex(@"^[0-9]|,?$");
        private void PriceBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !priceRegex.IsMatch(e.Text);
        }
    }
}

