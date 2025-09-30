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
using System.ComponentModel;
using System.Windows.Data;

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
    public Tenant SelectedTenant
    {
        get => _selectedTenant;
        set
        {
            _selectedTenant = value;
            this.newName = _selectedTenant != null ? _selectedTenant.Name : string.Empty;
            this.newPhoneNo = _selectedTenant != null ? _selectedTenant.PhoneNo : string.Empty;
            this.newEmail = _selectedTenant != null ? _selectedTenant.Email : string.Empty;
            this.newAccountNo = _selectedTenant != null ? _selectedTenant.AccountNo : 0;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Tenant> Tenants { get; set; }
    public ICollectionView TenantsView { get; } 

    private string _searchText;
    public string SearchText { get => _searchText; set { _searchText = value; OnPropertyChanged(); TenantsView.Refresh(); } }

    // Commands
    public ICommand AddTenantCommand { get; }
    public ICommand UpdateTenantCommand { get; }
    public ICommand DeleteTenantCommand { get; }
    public ICommand DeselectTenantCommand { get; }

    public TenantViewModel(NavigationStore navigationStore, string connectionString) : base(navigationStore)
    {
        _connectionString = connectionString;
        _tenantRepository = new TenantRepository(connectionString);

        Tenants =  new ObservableCollection<Tenant>(_tenantRepository.GetAll().ToList<Tenant>());

        TenantsView = CollectionViewSource.GetDefaultView(Tenants);
        TenantsView.Filter = FilterTenants;

        AddTenantCommand = new RelayCommand(AddTenant, CanAddTenant);
        UpdateTenantCommand = new RelayCommand(UpdateTenant, CanUpdateTenant);
        DeleteTenantCommand = new RelayCommand(DeleteTenant, CanDeleteTenant);
        DeselectTenantCommand = new RelayCommand((obj) => SelectedTenant = null);
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
        if (SelectedTenant != null)
            return false;

        if (string.IsNullOrWhiteSpace(newName) &&
            string.IsNullOrWhiteSpace(newPhoneNo) &&
            string.IsNullOrWhiteSpace(newEmail) )
            return false;

        return true;

    }

    private bool FilterTenants(object obj)
    {
        if (obj is Tenant tenant)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            return tenant.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)  ||
                   tenant.Email.Contains(SearchText, StringComparison.OrdinalIgnoreCase)  ||
                   tenant.PhoneNo.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }
    private void UpdateTenant(object? parameter)
    {
        if (SelectedTenant == null)
            return;
        SelectedTenant.Name = newName;
        SelectedTenant.PhoneNo = newPhoneNo;
        SelectedTenant.Email = newEmail;
        SelectedTenant.AccountNo = newAccountNo;

        _tenantRepository.Update(SelectedTenant);

        TenantsView.Refresh();
    }

    private bool CanUpdateTenant()
    {
        if (SelectedTenant == null)
            return false;

        if (SelectedTenant.Name == newName &&
            SelectedTenant.PhoneNo == newPhoneNo &&
            SelectedTenant.Email == newEmail &&
            SelectedTenant.AccountNo == newAccountNo)
            return false;

        if (newName == null && newPhoneNo == null && newEmail == null)
            return false;

        return true;
    }

    private void DeleteTenant(object? parameter)
    {
        if (SelectedTenant == null)
            return;

        _tenantRepository.Delete(SelectedTenant.TenantId);
        Tenants.Remove(SelectedTenant);
    }

    private bool CanDeleteTenant()
    {
        if (SelectedTenant == null)
            return false;

        return true;
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
