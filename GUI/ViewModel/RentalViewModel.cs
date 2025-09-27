using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Store;

namespace GUI.ViewModel;

public class RentalViewModel : BaseViewModel
{
    private readonly string _connectionString;
    public RentalViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        this._connectionString = connectionString;
    }
}
