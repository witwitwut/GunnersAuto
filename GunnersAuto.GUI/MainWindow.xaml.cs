using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GunnersAuto.DataAccess;
using GunnersAuto.Entities;

namespace GunnersAuto.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GunnersCars.Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

     
        public MainWindow()
        {
            InitializeComponent();

            Dbhandler handler = new Dbhandler(ConString);            
            handler.GetAllSales();
            CbbxSalesPerson.ItemsSource = handler.GetAllSalesPersons();
        }

        private void CbbxSalesPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMakeCar_Click(object sender, RoutedEventArgs e)
        {
            OpretBil newCar = new OpretBil();

            if (newCar.ShowDialog() == true)
            {

            }
        }
    }
}
