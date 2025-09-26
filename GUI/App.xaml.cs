using System.Configuration;
using System.Data;
using System.Windows;
using GUI.Store;
using GUI.ViewModel;
using Microsoft.Extensions.Configuration;

namespace GUI;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string? ConnectionString = config.GetConnectionString("DefaultConnection");

        NavigationStore navigationStore = new NavigationStore();
        navigationStore.CurrentViewModel = new TenantViewModel(navigationStore, ConnectionString);

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }
}
