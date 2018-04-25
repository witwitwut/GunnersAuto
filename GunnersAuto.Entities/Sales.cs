using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnersAuto.Entities
{
    public class Sales
    {
        private Car car;
        private int carID;
        private SalesPerson salesPerson;
        private int salesPersonID;
        private string typeoftransaktion;
        private int price;
        private int id;




        public Sales(int carID, int salesPersonID, string typeoftransaktion, int price)
        {
            CarID = carID;
            SalesPersonID = salesPersonID;
            TypeofTransaktion = typeoftransaktion;
            Price = price;
        }

        public Sales(int carID, int salesPersonID, string typeoftransaktion, int price, int id)
        {
            CarID = carID;
            SalesPersonID = salesPersonID;
            TypeofTransaktion = typeoftransaktion;
            Price = price;
            ID = id;
        }

        public SalesPerson SalesPerson
        {
            get { return salesPerson; }
            set { salesPerson = value; }
        }


        public Car Car
        {
            get { return car; }
            set { car = value; }
        }

        public int SalesPersonID
        {
            get { return salesPersonID; }
            set { salesPersonID = value; }
        }

        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }


        public string TypeofTransaktion
        {
            get { return typeoftransaktion; }
            set { typeoftransaktion = value; }
        }
        public override string ToString()
        {
            return $"Bilen: {car} er {TypeofTransaktion} af {salesPerson} for {price} kr.";
        }
    }
}
