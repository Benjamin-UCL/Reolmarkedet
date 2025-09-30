using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Database_Connection;
using Database_Connection.Repository;
using Microsoft.Extensions.Configuration;
using Model;

namespace GUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string? ConnectionString = config.GetConnectionString("DefaultConnection");
        

        DbBuilder DB = new DbBuilder(ConnectionString);
        DB.RunSchema();

        TenantRepository tenantRepository = new TenantRepository(ConnectionString);
        tenantRepository.Add(new Tenant("Alice Johnson", "12345678", "alice@example.com", 1));
        tenantRepository.Add(new Tenant("Bob Smith", "87654321", "bob@jkd.com", 2));
        tenantRepository.Add(new Tenant("Charlie Brown", "55555555", "charlie@jdlk.com", 3));

        ShelvingUnitRepository shelvingRepository = new ShelvingUnitRepository(ConnectionString);

        for (int i = 0; i < 70; i++)
        {
            shelvingRepository.Add(new ShelvingUnit());
        }
    }
}