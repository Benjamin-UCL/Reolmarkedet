using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GUI.Store;
using GUI.Utility;

namespace GUI.ViewModel;

public class BaseViewModel : INotifyPropertyChanged
{
    // navigation
    private NavigationStore _navigationStore;

    public BaseViewModel(NavigationStore navigationStore)
    {
        this._navigationStore = navigationStore;
        //ChangeViewCommand = new RelayCommand<object>(ChangeView, CanChangeView);
        ChangeViewCommand = new RelayCommand(ChangeView, CanChangeView);
    }

    public ICommand ChangeViewCommand { get; }

    //v1
    //public void ChangeView(object obj)
    //{
    //    this._navigationStore.CurrentViewModel = new RentalViewModel(this._navigationStore);
    //}

    //v2
    //public void ChangeView<TViewModel>() where TViewModel : BaseViewModel
    //{
    //    this._navigationStore.CurrentViewModel = Activator.CreateInstance(typeof(TViewModel), _navigationStore) as BaseViewModel;
    //}

    //v3
    //public void ChangeView(object obj)
    //{
    //    if (obj is Type viewModelType && typeof(BaseViewModel).IsAssignableFrom(viewModelType))
    //    {
    //        var viewModel = Activator.CreateInstance(viewModelType, _navigationStore) as BaseViewModel;
    //        _navigationStore.CurrentViewModel = viewModel;
    //    }
    //}

    //v4
    public void ChangeView(object obj)
    {
        if (obj is Type viewModelType && typeof(BaseViewModel).IsAssignableFrom(viewModelType))
        {
            var viewModel = Activator.CreateInstance(viewModelType, _navigationStore, _navigationStore.ConnectionString) as BaseViewModel;
            _navigationStore.CurrentViewModel = viewModel;
        }
    }


    public bool CanChangeView()
    {
        return true;
    }

    // On property change implementation
    public event PropertyChangedEventHandler? PropertyChanged;
protected void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

