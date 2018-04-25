using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GunnersAuto.Entities;
using System.Data;
using System.Data.SqlClient;

namespace GunnersAuto.DataAccess
{
    public class Dbhandler
    {

        private String conString;

        public Dbhandler(string conString)
        {
            this.conString = conString;
        }

        public String ConString
        {
            get { return conString; }
            private set { conString = value; }
        }
        public List<Car> GetAllCars()
        {
            List<Car> Cars = new List<Car>();
            string q = "SELECT * FROM CAR";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using(SqlCommand command = new SqlCommand(q, connection))
                {
                    connection.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Cars.Add(new Car(row.Field<string>("label"), row.Field<string>("model"), row.Field<string>("SteeringNumber"), row.Field<string>("regristration"), row.Field<string>("newOrUsed"),row.Field<int>("ID")));
                    }
                }
            }
            return Cars;
        }
        public List<SalesPerson> GetAllSalesPersons()
        {
            List<SalesPerson> salespersons = new List<SalesPerson>();
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                string q = "SELECT * FROM SalesPerson";
                using (SqlCommand command = new SqlCommand(q, connection))
                {
                    connection.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        salespersons.Add(new SalesPerson(row.Field<string>("Name"), row.Field<string>("LastName"), row.Field<string>("Initials"),row.Field<int>("ID")));
                    }
                }
            }
            return salespersons;
        }
        public List<Sales> GetAllSales()
        {
            List<Sales> sales = new List<Sales>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string q = "SELECT * FROM Sales";
                using(SqlCommand command = new SqlCommand(q, connection))
                {
                    connection.Open();

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(command);

                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        sales.Add(new Sales(row.Field<int>("CarID"), row.Field<int>("salesPersonID"), row.Field<string>("TypeOfTransaction"), row.Field<int>("Price")));
                    }
                }
                List<Car> cars = GetAllCars();
                List<SalesPerson> persons = GetAllSalesPersons();

                foreach (var sale in sales)
                {
                    foreach (var car in cars)
                    {
                        if (sale.CarID == car.ID)
                        {
                            sale.Car = car;
                        }
                    }
                    foreach (var person in persons)
                    {
                        if (sale.SalesPersonID == person.ID)
                        {
                            sale.SalesPerson = person;
                        }
                    }
                }
                return sales;
            }
        }
        public void MakeCar(Car c)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string q = "INSERT INTO CAR(Label, Model, SteeringNumber, Regristration, NewOrUsed)" +
                    $"Values('{c.Label}', '{c.Model}', '{c.SteeringNumber}', '{c.RegristrationNumber}', '{c.NewOrUsed}')";
                using (SqlCommand command = new SqlCommand(q, connection))
                {
                    connection.Open();
                    int rowsaffected = command.ExecuteNonQuery();
                }
            }
        }
        public void MakeSale(Car c, SalesPerson p, string TypeofTransaction, int Price)
        {
            using(SqlConnection connection = new SqlConnection(conString))
            {
                string q = "INSERT INTO Sales(CARID, SalesPersonID, TypeOfTransaction, Price)" +
                    $"values ('{c.ID}','{p.ID}','{TypeofTransaction}','{Price}')";
                using (SqlCommand command = new SqlCommand(q, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
