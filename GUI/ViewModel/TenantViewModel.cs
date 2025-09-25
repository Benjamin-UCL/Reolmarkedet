using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GUI.Store;

namespace GUI.ViewModel;

public class TenantViewModel : BaseViewModel
{
    public string title { get; set; } = "Tenant";
    

    public TenantViewModel(NavigationStore navigationStore) : base(navigationStore)
    {
        
    }


}
