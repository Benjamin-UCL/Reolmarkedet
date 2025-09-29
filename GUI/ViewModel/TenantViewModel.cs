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

public class TenantViewModel : BaseViewModel
{
    private readonly TenantRepository _tenantRepository;
    private readonly string _connectionString;

    private string _newName;
    public string newName { get => _newName; set { _newName = value; OnPropertyChanged(); } }
    
    private string _newPhoneNo;
    public string newPhoneNo { get => _newPhoneNo; set { _newPhoneNo = value; OnPropertyChanged(); } }
    
    private string _newEmail;
    public string newEmail { get => _newEmail; set { _newEmail = value; OnPropertyChanged(); } }
    
    private int _newAccountNo;
    public int newAccountNo { get => _newAccountNo; set { _newAccountNo = value; OnPropertyChanged(); } }

    private Tenant _selectedTenant;
    public Tenant SelectedTenant { get => _selectedTenant; set { _selectedTenant = value; OnPropertyChanged(); } }

    public ObservableCollection<Tenant> Tenants { get; }

    // Commands
    public ICommand AddTenantCommand { get; }
    public ICommand UpdateTenantCommand { get; }
    public ICommand DeleteTenantCommand { get; }

    public TenantViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        _connectionString = connectionString;
        _tenantRepository = new TenantRepository(connectionString);

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

        AddTenantCommand = new RelayCommand(AddTenant, CanAddTenant);
        UpdateTenantCommand = new RelayCommand(UpdateTenant, CanUpdateTenant);
        DeleteTenantCommand = new RelayCommand(DeleteTenant, CanDeleteTenant);
    }


    private void AddTenant(object? parameter)
    {        
        // Example of adding a new tenant
        Tenant newTenant = new Tenant(this.newName, this.newPhoneNo, this.newEmail, this.newAccountNo);
        int newId = _tenantRepository.Add(newTenant);
        newTenant.TenantId = newId;
        Tenants.Add(newTenant);
        ClearForm();
    }

    private bool CanAddTenant()
    {
        return true;
        //return !string.IsNullOrWhiteSpace(newName) &&
        //       !string.IsNullOrWhiteSpace(newPhoneNo) &&
        //       !string.IsNullOrWhiteSpace(newEmail);

    }
    private void UpdateTenant(object? parameter)
    {
        MessageBox.Show("Update Tenant functionality is not implemented yet.");
        //if (SelectedTenant == null)
        //    return;

        //// Update selected tenant's properties
        //SelectedTenant.Name = newName;
        //SelectedTenant.PhoneNo = newPhoneNo;
        //SelectedTenant.Email = newEmail;
        //SelectedTenant.AccountNo = newAccountNo;

        //if (SelectedTenant.AccountNo == 0)
        //{
        //    // New tenant: add and set returned id
        //    int newId = _tenantRepository.Add(SelectedTenant);
        //    SelectedTenant.AccountNo = newId;
        //}
        //else
        //{
        //    // Existing tenant: update repository (implement Update in repository)
        //    _tenantRepository.Update(SelectedTenant);
        //}

        //LoadTenants();
    }

    private bool CanUpdateTenant()
    {
        return true;
        //return !string.IsNullOrWhiteSpace(newName) &&
        //       !string.IsNullOrWhiteSpace(newPhoneNo) &&
        //       !string.IsNullOrWhiteSpace(newEmail);
    }

    private void DeleteTenant(object? parameter)
    {
        MessageBox.Show("Delete Tenant functionality is not implemented yet.");
        //if (SelectedTenant == null)
        //    return;

        //_tenantRepository.Delete(SelectedTenant.AccountNo);
        //Tenants.Remove(SelectedTenant);
    }

    private bool CanDeleteTenant()
    {
        return true;
        //return SelectedTenant != null;
    }

    public void ClearForm()
    {
        newName = string.Empty;
        newPhoneNo = string.Empty;
        newEmail = string.Empty;
        newAccountNo = 0;
    }


    /*
    

    private Tenant _selectedTenant;
    private string _searchTerm;

    public ICommand SearchTenantCommand { get; }

    public Tenant_ViewModel(string connectionString)
    {
        

        Tenants = new ObservableCollection<Tenant>();
        LoadTenants();

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
