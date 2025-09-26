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
using Microsoft.Extensions.Configuration;

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
    }
}