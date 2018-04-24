using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunnersAuto.Entities
{
    public class SalesPerson
    {

        private string name;
        private string lastName;
        private string initials;
        private int id;

        public SalesPerson(string name, string lastName, string intials)
        {
            Name = name;
            LastName = lastName;
            Initials = initials;
        }

        public SalesPerson(string name, string lastName, string initials, int id)
        {
            Name = name;
            LastName = lastName;
            Initials = initials;
            ID = id;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Initials
        {
            get { return initials; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("du skal angive initialer");
                }
                initials = value;
            }
        }


        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Du skal angive efternavn");
                }
                lastName = value;
            }
        }


        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Du skal angive navn");
                }
                name = value;
            }
        }
        public override string ToString()
        {
            return $"Salgs Person {name} {lastName} {initials}";
        }
    }
}
