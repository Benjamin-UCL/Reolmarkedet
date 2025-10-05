using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Database_Connection.Repository;
using GUI.Store;
using GUI.Utility;
using Model;

namespace GUI.ViewModel;

public class ItemViewModel : BaseViewModel
{
    private readonly ItemRepository _itemRepository;

    private readonly string _connectionString;

    private string _newName = "";
    public string newName { get => _newName; set { _newName = value; OnPropertyChanged(); } }

    private decimal _newPrice;
    public decimal newPrice { get => _newPrice; set { _newPrice = value; OnPropertyChanged(); } }

    public ObservableCollection<Item> Items { get; set; }
    private Item _selectedItem;
    public Item SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            this.newName = _selectedItem != null ? _selectedItem.Name : string.Empty;
            this.newPrice = _selectedItem != null ? _selectedItem.Price : 0;
            OnPropertyChanged();
        }
    }

    //Commands 
    public ICommand UpdateItemCommand { get; }
    public ICommand DeleteItemCommand { get; }

    public ItemViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        this._connectionString = connectionString;

        Items = new ObservableCollection<Item>();
        Items.Add(new Item("Tallerken", 20, "563483059285", 5));
        Items.Add(new Item("Skål", 15, "53464353059285", 5));
        Items.Add(new Item("Ske", 10, "32532583059285", 5));

        UpdateItemCommand = new RelayCommand(UpdateItem, CanUpdateItem);
        DeleteItemCommand = new RelayCommand(DeleteItem, CanDeleteItem);
    }

    private void UpdateItem(object? parameter)
    {
        MessageBox.Show("Gem funktion kaldt");
    }

    private bool CanUpdateItem()
    {
        if (SelectedItem == null)
            return false;

        if (SelectedItem.Name == newName)
            return false;

        if (newPrice < 0)
            return false;

        if (newName == null && newPrice == null)
            return false;

        return true;
    }
    private void DeleteItem(object? parameter)
    {
        MessageBox.Show("Slet funktion kaldt");
    }
    private bool CanDeleteItem()
    {
        if (SelectedItem == null)
            return false;

        return true;
    }
}
