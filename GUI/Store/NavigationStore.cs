using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.ViewModel;

namespace GUI.Store;

public class NavigationStore
{
    public event Action CurrentViewModelChanged;

    private BaseViewModel _currentViewModel;
    public BaseViewModel CurrentViewModel 
    { 
        get => _currentViewModel; 
        set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        } 
    }
}
