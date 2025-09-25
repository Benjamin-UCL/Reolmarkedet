using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Database_Connection.Repository;
using Model;
using ReolMarkedTeam7.Utility;

namespace ReolMarkedTeam7.ViewModel;

public class ItemViewModel : BaseViewModel
{
    private ItemRepository itemRepository;

    public ObservableCollection<Item> Items { get; } = new();

    // backing fields 
    private string newName = "";
    private decimal newPrice;
    private int newShelvingUnitId;
    private string newBarcodeNo = "";
    private bool newIsSold;
    private int deleteItemId;

    // Public properties til XAML-binding
    public string NewName
    {
        get => newName;
        set { if (newName != value) { newName = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); } }
    }
    public decimal NewPrice
    {
        get => newPrice;
        set { if (newPrice != value) { newPrice = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); } }
    }
    public int NewShelvingUnitId
    {
        get => newShelvingUnitId;
        set { if (newShelvingUnitId != value) { newShelvingUnitId = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); } }
    }
    public string NewBarcodeNo
    {
        get => newBarcodeNo;
        set { if (newBarcodeNo != value) { newBarcodeNo = value; OnPropertyChanged(); } }
    }
    public bool NewIsSold
    {
        get => newIsSold;
        set { if (newIsSold != value) { newIsSold = value; OnPropertyChanged(); } }
    }
    public int DeleteItemId
    {
        get => deleteItemId;
        set { if (deleteItemId != value) { deleteItemId = value; OnPropertyChanged(); CommandManager.InvalidateRequerySuggested(); } }
    }

    // Commands
    public ICommand AddItemCommand { get; }
    public ICommand RefreshItemsCommand { get; }
    public ICommand ClearFormCommand { get; }
    public ICommand DeleteByIdCommand { get; }

    public ItemViewModel(string connectionString)
    {
        itemRepository = new ItemRepository(connectionString);

        LoadItems();

        AddItemCommand = new RelayCommand(AddItem, CanAddItem);
        RefreshItemsCommand = new RelayCommand(_ => LoadItems());
        ClearFormCommand = new RelayCommand(_ => ClearForm());
        DeleteByIdCommand = new RelayCommand(DeleteById, () => DeleteItemId > 0);
    }

    private void LoadItems()
    {
        Items.Clear();
        foreach (var it in itemRepository.GetAll())
            Items.Add(it);
    }

    private bool CanAddItem() =>
        !string.IsNullOrWhiteSpace(NewName) && NewPrice >= 0 && NewShelvingUnitId > 0;

    private void AddItem(object? _)
    {
        var barcode = string.IsNullOrWhiteSpace(NewBarcodeNo) ? Guid.NewGuid().ToString("N")[..12] : NewBarcodeNo;

        var entity = new Item(
            name: NewName,
            price: NewPrice,
            barcodeNo: barcode,
            shelvingUnitId: NewShelvingUnitId)
        { IsSold = NewIsSold };

        var id = itemRepository.Add(entity);
        entity.ItemId = id;

        Items.Add(entity);
        ClearForm();
    }

    private void DeleteById(object? _)
    {
        itemRepository.Delete(DeleteItemId);
        var toRemove = Items.FirstOrDefault(i => i.ItemId == DeleteItemId);
        if (toRemove != null) Items.Remove(toRemove);
        DeleteItemId = 0;
    }

    private void ClearForm()
    {
        NewName = "";
        NewPrice = 0;
        NewShelvingUnitId = 0;
        NewBarcodeNo = "";
        NewIsSold = false;
    }
}