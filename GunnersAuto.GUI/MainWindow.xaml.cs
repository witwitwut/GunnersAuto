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

        Dbhandler handler;
     
        public MainWindow()
        {
            InitializeComponent();

            handler = new Dbhandler(ConString);            
            handler.GetAllSales();
            CbbxSalesPerson.ItemsSource = handler.GetAllSalesPersons();
            DGSales.ItemsSource = handler.GetAllCars();
            lbxAllSales.ItemsSource = handler.GetAllSales();
        }

        private void CbbxSalesPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMakeCar_Click(object sender, RoutedEventArgs e)
        {
            OpretBil newCar = new OpretBil(handler);

            if (newCar.ShowDialog() == true)
            {
                MessageBox.Show(newCar.ToString());
                handler.MakeCar(newCar.Car);
                DGSales.ItemsSource = handler.GetAllCars();
            }

        }

        private void btnsale_Click(object sender, RoutedEventArgs e)
        {
            if (DGSales.SelectedItem == null && CbbxSalesPerson.SelectedItem == null && string.IsNullOrWhiteSpace(tbxTypeofTransaction.Text) && string.IsNullOrWhiteSpace(tbxPrice.Text))
            {
                MessageBox.Show("Du mangler at udfylde et felt");
            }
            else
            {
                handler.MakeSale((Car)DGSales.SelectedItem, (SalesPerson)CbbxSalesPerson.SelectedItem, tbxTypeofTransaction.Text, int.Parse(tbxPrice.Text));
                tbxTypeofTransaction.Text = "";
                tbxPrice.Text = "";
                lbxAllSales.ItemsSource = handler.GetAllSales();
            }
        }
    }
}
