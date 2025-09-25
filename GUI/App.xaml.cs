using System.Configuration;
using System.Data;
using System.Windows;
using GUI.Store;
using GUI.ViewModel;

namespace GUI;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        NavigationStore navigationStore = new NavigationStore();
        navigationStore.CurrentViewModel = new TenantViewModel(navigationStore);

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }
}
