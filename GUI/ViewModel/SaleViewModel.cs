using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Store;

namespace GUI.ViewModel;

public class SaleViewModel : BaseViewModel
{
    private readonly string _connectionString;
    public SaleViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        this._connectionString = connectionString;
    }
}
