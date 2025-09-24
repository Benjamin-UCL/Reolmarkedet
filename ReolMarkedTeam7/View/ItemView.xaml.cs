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
    public partial class ItemView : UserControl
    {
        public ItemView() => InitializeComponent();

        // --- Tomme handlers så UI kan køre uden logik endnu ---

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Ryd formularen / åbn dialog / skift til “ny vare”-tilstand
        }

        private void SaveItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Valider felter og gem via ViewModel/Repository
            // TitleBox.Text, PriceBox.Text, ShelfCombo.SelectedItem ...
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Slet valgt vare (ItemsGrid.SelectedItem)
        }

        private void ItemsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Bind valgte række over i formularen
        }
    }
}
