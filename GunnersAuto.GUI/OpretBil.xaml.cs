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
using System.Windows.Shapes;
using GunnersAuto.DataAccess;
using GunnersAuto.Entities;

namespace GunnersAuto.GUI
{
    /// <summary>
    /// Interaction logic for OpretBil.xaml
    /// </summary>
    public partial class OpretBil : Window
    {
        //static string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GunnersCars.Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        Dbhandler handler;

        Car car;
        public OpretBil(Dbhandler handler)
        {
            InitializeComponent();
            this.handler = handler;
        }

        public Car Car
        {
            get
            {
                return car;
            }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxlabel.Text) && string.IsNullOrEmpty(tbxmodel.Text) && string.IsNullOrEmpty(tbxregristrationnumber.Text) && string.IsNullOrEmpty(tbxsteeringnumber.Text) && string.IsNullOrEmpty(tbxneworused.Text))
            {
                MessageBox.Show("du mangler at udfylde et felt");
                DialogResult = false;
            }
            else
            {
                //Dbhandler handler = new Dbhandler(ConString);

                car = new Car(tbxlabel.Text, tbxmodel.Text, tbxsteeringnumber.Text, tbxregristrationnumber.Text, tbxneworused.Text);

                //handler.MakeCar(p);

                tbxlabel.Text = "";
                tbxmodel.Text = "";
                tbxsteeringnumber.Text = "";
                tbxregristrationnumber.Text = "";
                tbxneworused.Text = "";                
                DialogResult = true;
            }
        }
    }
}
