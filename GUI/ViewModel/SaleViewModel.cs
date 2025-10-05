using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Connection.Repository;
using GUI.Store;
using Model;

namespace GUI.ViewModel;

public class SaleViewModel : BaseViewModel
{
    private readonly string _connectionString;
    private SaleRepository _saleRepository;

    public ObservableCollection<Item> Cart;


    public SaleViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        this._connectionString = connectionString;
        this._saleRepository = new SaleRepository(connectionString);
        Cart = new ObservableCollection<Item>();
    }

    // find item matching barcode
    public Item FindItem()
    {
        return new Item();
    }

    public void AddToCart(Item item)
    {
        Cart.Add(item);
    }

    public void ScanItem() 
    {
        this.AddToCart(this.FindItem());
    }


    public void ProcessCart()
    {
        foreach (var item in Cart)
        {
            // add sale to db
            
        }
    }

    // 

}
