using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GUI.Store;
using GUI.Utility;
using Model;

namespace GUI.ViewModel;

public class TenantViewModel : BaseViewModel
{
    
    private string _newName;
    public string newName { get => _newName; set { _newName = value; OnPropertyChanged(); } }
    
    private string _newPhoneNo;
    public string newPhoneNo { get => _newPhoneNo; set { _newPhoneNo = value; OnPropertyChanged(); } }
    
    private string _newEmail;
    public string newEmail { get => _newEmail; set { _newEmail = value; OnPropertyChanged(); } }
    
    private int _newAccountNo;
    public int newAccountNo { get => _newAccountNo; set { _newAccountNo = value; OnPropertyChanged(); } }

    public ObservableCollection<Tenant> Tenants { get; }

    public TenantViewModel(NavigationStore navigationStore) : base(navigationStore)
    {
        //dummie data
        this.newName = "Default Name";
        this.newPhoneNo = "00000000";
        this.newEmail = "jlkjæ@.com";
        this.newAccountNo = 0;

        Tenants = new ObservableCollection<Tenant>
        {
            new Tenant("Alice Johnson", "12345678", "alice@example.com", 1),
            new Tenant("Bob Smith", "87654321", "bob@jkd.com", 2),
            new Tenant("Charlie Brown", "55555555", "charlie@jdlk.com", 3)
        };

    }

    // Commands



    /*
    private readonly string _connectionString;
    private readonly TenantRepository _tenantRepository;

    private Tenant _selectedTenant;
    private string _searchTerm;

    public ICommand AddTenantCommand { get; }
    public ICommand SaveTenantCommand { get; }
    public ICommand DeleteTenantCommand { get; }
    public ICommand SearchTenantCommand { get; }

    public Tenant_ViewModel(string connectionString)
    {
        _connectionString = connectionString;
        _tenantRepository = new TenantRepository(connectionString);

        Tenants = new ObservableCollection<Tenant>();
        LoadTenants();

        AddTenantCommand = new RelayCommand(AddTenant);
        SaveTenantCommand = new RelayCommand(SaveTenant, CanSaveTenant);
        DeleteTenantCommand = new RelayCommand(DeleteTenant, CanDeleteTenant);
        SearchTenantCommand = new RelayCommand(SearchTenant, CanSearchTenant);
    }


    public Tenant SelectedTenant
    {
        get { return _selectedTenant; }
        set
        {
            _selectedTenant = value;
            OnPropertyChanged();
            if (_selectedTenant != null)
            {
                newName = _selectedTenant.Name;
                newPhoneNo = _selectedTenant.PhoneNo;
                newEmail = _selectedTenant.Email;
                newAccountNo = _selectedTenant.AccountNo;
            }
        }
    }
    public string searchTerm { get => _searchTerm; set { _searchTerm = value; OnPropertyChanged(); } }


    private void LoadTenants()
    {
        var tenants = _tenantRepository.GetAll();
        Tenants.Clear();
        foreach (var tenant in tenants)
            Tenants.Add(tenant);
    }

    private void AddTenant(object? parameter)
    {
        // Example of adding a new tenant
        var newTenant = new Tenant(this.newName, this.newPhoneNo, this.newEmail, this.newAccountNo);
        Tenants.Add(newTenant);
        SelectedTenant = newTenant;
    }

    private void SaveTenant(object? parameter)
    {
        if (SelectedTenant == null)
            return;

        // Update selected tenant's properties
        SelectedTenant.Name = newName;
        SelectedTenant.PhoneNo = newPhoneNo;
        SelectedTenant.Email = newEmail;
        SelectedTenant.AccountNo = newAccountNo;

        if (SelectedTenant.AccountNo == 0)
        {
            // New tenant: add and set returned id
            int newId = _tenantRepository.Add(SelectedTenant);
            SelectedTenant.AccountNo = newId;
        }
        else
        {
            // Existing tenant: update repository (implement Update in repository)
            _tenantRepository.Update(SelectedTenant);
        }

        LoadTenants();
    }

    private bool CanSaveTenant()
    {
        return !string.IsNullOrWhiteSpace(newName) &&
               !string.IsNullOrWhiteSpace(newPhoneNo) &&
               !string.IsNullOrWhiteSpace(newEmail);
    }

    private void DeleteTenant(object? parameter)
    {
        if (SelectedTenant == null)
            return;

        _tenantRepository.Delete(SelectedTenant.AccountNo);
        Tenants.Remove(SelectedTenant);
    }

    private bool CanDeleteTenant()
    {
        return SelectedTenant != null;
    }

    private void SearchTenant(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return;

        var tenant = Tenants.FirstOrDefault(t => t.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));

        if (tenant != null)
            SelectedTenant = tenant;
        else
            SelectedTenant = null;
    }

    private bool CanSearchTenant()
    {
        return !string.IsNullOrWhiteSpace(searchTerm);
    }
    */
}
