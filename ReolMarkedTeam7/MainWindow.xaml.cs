using System.Windows;

namespace ReolMarkedTeam7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Standard-side ved start
            MainHost.Content = new View.TenantView();
        }

        private void ShowItems(object s, RoutedEventArgs e) => MainHost.Content = new View.ItemView();
        private void ShowShelves(object s, RoutedEventArgs e) => MainHost.Content = new View.ShelvingUnitView();
        private void ShowTenants(object s, RoutedEventArgs e) => MainHost.Content = new View.TenantView();
        private void ShowSales(object s, RoutedEventArgs e)
        {
            // Brug kun hvis I har en SaleView
            // MainHost.Content = new View.SaleView();
            MessageBox.Show("Salg (kommer senere)");
        }
    }
}

//using System.Data;
//using System.Data;
//using System.Data.SqlClient; // Til at arbejde med SQL Server via ADO.NET
//using System.Data.SqlClient;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using Model; // Til at arbejde med SQL Server via ADO.NET
//using Database_Connection;

//namespace ReolMarkedTeam7;

///// <summary>
///// Interaction logic for MainWindow.xaml
///// </summary>
//public partial class MainWindow : Window
//{
//    public MainWindow()
//    {
//        InitializeComponent();
//        // Ved ikke helt hvor vi skal gøre af dette??
//        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//        string? ConnectionString = config.GetConnectionString("DefaultConnection");
//        // end


//        DbBuilder DB = new DbBuilder(ConnectionString);
//        DB.RunSchema();


//    // Eksemple / test - kan bruges i andre filer, når connection string er lavet og rette using statments er defineret.
//        // init repo
//        //IRepository<TestModel> TestRepo = new TestRepository(ConnectionString);
//        // run schema

//        // add test objects
//        //TestRepo.Add(new TestModel("Hello"));
//        //TestRepo.Add(new TestModel("World!"));
//        //TestRepo.Add(new TestModel("2"));
//        // End

//    }
//}

