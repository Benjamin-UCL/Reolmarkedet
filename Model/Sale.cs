using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class Sale
{

    private Item _item;

    private double _price;
    public double Price 
    { 
        get { return _price; } 
    }
    private DateTime _salesDate;
    public DateTime SalesDate 
    { 
        get { return _salesDate; }
    }
    private bool _isSetteled;
    public bool IsSetteled 
    { 
        get { return _isSetteled; }
    }
    

    public Sale(Item item, double adjustedPrice = null) 
    { 
        this._item = item;
        if (adjustedPrice != null)
        {
            this._price = adjustedPrice;
        }
        else
        {
            this._price = item.Price;
        }

    }


    // create sale from sales terminal
        // Item is scanned to "cart"
        // cart is paid
        // items are recorded as sales and commited to DB

    // Sales is retrived from DB


}
