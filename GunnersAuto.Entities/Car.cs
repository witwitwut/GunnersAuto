using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnersAuto.Entities
{
    public class Car
    {
        private string label;
        private string model;
        private string steeringNumber;
        private string regristrationNumber;
        private string newOrUsed;
        private int id;
        public Car(string label, string model, string steeringNumber, string regristrationNumber, string newOrUsed)
        {
            Label = label;
            Model = model;
            SteeringNumber = steeringNumber;
            RegristrationNumber = regristrationNumber;
            NewOrUsed = newOrUsed;
        }

        public Car(string label, string model, string steeringNumber, string regristrationNumber, string newOrUsed, int id)
        {
            Label = label;
            Model = model;
            SteeringNumber = steeringNumber;
            RegristrationNumber = regristrationNumber;
            NewOrUsed = newOrUsed;
            ID = id;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }




        public string NewOrUsed
        {
            get { return newOrUsed; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Der er brug for at vide om den er ny eller brugt");
                }
                newOrUsed = value; }
        }





        public string RegristrationNumber
        {
            get { return regristrationNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Du skal give en regristerings nummer");
                }
                regristrationNumber = value;
            }
        }


        public string SteeringNumber
        {
            get { return steeringNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Du skal give et Styretøjs nummer");
                }
                steeringNumber = value;
            }
        }


        public string Model
        {
            get { return model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Bilen Skal have model");
                }
                model = value;
            }
        }


        public string Label
        {
            get { return label; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Bilen skal have et mærke");
                }
                label = value;
            }
        }
        public override string ToString()
        {
            return $"Mærke: {label}  Model: {Model}  Styringsnummer: {steeringNumber}  Regristraringsnummer:  {RegristrationNumber}   {NewOrUsed}";
        }
    }
}
