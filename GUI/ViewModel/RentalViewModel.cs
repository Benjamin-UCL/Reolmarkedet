using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Database_Connection.Repository;
using GUI.Store;
using GUI.Utility;
using Model;

namespace GUI.ViewModel;

public class RentalViewModel : BaseViewModel
{
    private readonly RentalRepository _rentalRepository;
    private readonly string _connectionString;

    //RentalCollection 
    //SelectedRental
    //RentalRepository
    //UpdateConfiguration

    private decimal _newPrice;
    public decimal NewPrice { get => _newPrice; set { _newPrice = value; OnPropertyChanged(); } }

    private Rental _selectedRental;

    public Rental SelectedRental { get => _selectedRental; set { _selectedRental = value; OnPropertyChanged(); } }

    public ObservableCollection<Tenant> Tenants { get; set; }

    private Tenant _selectedTenant;
    public Tenant SelectedTenant
    {
        get => _selectedTenant;
        set { _selectedTenant = value; OnPropertyChanged(); }
    }

    public ObservableCollection<Rental> Rentals { get; set; }


    public ICommand UpdateRentalCommand { get; }
    public ICommand DeleteRentalCommand { get; }
    public ICommand DeselectRentalCommand { get; }
    


    public RentalViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        this._connectionString = connectionString;

        _rentalRepository = new RentalRepository(connectionString);

        Rentals = new ObservableCollection<Rental>(_rentalRepository.GetAllWithDetails());

        NewPrice = 50;

        UpdateRentalCommand = new RelayCommand(Update, CanUpdate);

        DeleteRentalCommand = new RelayCommand(Delete, CanDelete);

        DeselectRentalCommand = new RelayCommand(Deselect, CanDeselect);
    }

    //private void UpdateTenant(object? parameter)   ?????????
    //{
    //    if (SelectedRental != null)
    //    {
    //        SelectedRental.Tenant = SelectedTenant; // Gem valgt lejer
    //        MessageBox.Show($"Opdateret udlejning med {SelectedRental.Tenant.Name}");
    //    }
    //}

    public void Update(object? parameter)
    {
        MessageBox.Show("Update method call");
    }

    public bool CanUpdate()
    { return true; }


    public void Delete(object? parameter)
    {
        MessageBox.Show("Delete method call");
    }
    public bool CanDelete()
        { return true; }

    public void Deselect(object? parameter)
    {
        MessageBox.Show("Deselect method call");
    }

    public bool CanDeselect()
        { return true; }
}
