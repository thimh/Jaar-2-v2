using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog5_telephone_thimh
{
    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long TelephoneNumber { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public Person(string firstName, string lastName, long telephoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TelephoneNumber = telephoneNumber;
        }
    }
}
