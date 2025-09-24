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
    public partial class ShelvingUnitView : UserControl
    {
        public ShelvingUnitView()
        {
            InitializeComponent();
        }

        private void ShelvesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: bind valgte reol ind i formularen (VM eller manuel udfyldning)
        }

        private void NewShelf_Click(object sender, RoutedEventArgs e)
        {
            // TODO: ryd formularen for at oprette ny
            ShelfIdBox.Text = string.Empty;
            LocationBox.Text = string.Empty;
            ShelfCountBox.Text = string.Empty;
            HangerBarCheck.IsChecked = false;
            StatusFree.IsChecked = true;
            TenantCombo.SelectedIndex = -1;
        }

        private void SaveShelf_Click(object sender, RoutedEventArgs e)
        {
            // TODO: gem (kald VM/repository)
            MessageBox.Show("Gem reol (stub).");
        }

        private void DeleteShelf_Click(object sender, RoutedEventArgs e)
        {
            // TODO: slet (kald VM/repository)
            MessageBox.Show("Slet reol (stub).");
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AddItemWindow();
            dlg.Owner = Window.GetWindow(this);
            dlg.ShowDialog(); // returnerer når brugeren lukker
        }
    }
}

