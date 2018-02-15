using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog5_telephone_thimh
{
    class TelephoneBook
    {
        List<Person> telephoneBook = new List<Person>();

        public int personsInTelephoneBook { get { return telephoneBook.Count; } }

        public TelephoneBook()
        {
            FillTelephoneBook();
        }

        public void FillTelephoneBook()
        {
            telephoneBook.Add(new Person("Thim", "Heider", 06123456780));
            telephoneBook.Add(new Person("Jan", "Janssen", 06123456781));
            telephoneBook.Add(new Person("Klaas", "Klaassen", 06123456782));
            telephoneBook.Add(new Person("Piet", "Pietersen", 06123456783));
            telephoneBook.Add(new Person("Jet", "Jetters", 06123456784));
            telephoneBook.Add(new Person("Anne", "Albers", 06123456785));
            telephoneBook.Add(new Person("Bep", "Bevers", 06123456786));
            telephoneBook.Add(new Person("Ad", "Alders", 06123456787));
            telephoneBook.Add(new Person("Minnie", "Mouse", 06123456788));
            telephoneBook.Add(new Person("Donald", "Duck", 06123456789));
        }

        public void GetAllPersons()
        {
            IEnumerable<Person> allPersonsLinq = telephoneBook.OrderBy(t => t.LastName);
            int i = 0;
            foreach (Person person in allPersonsLinq)
            {
                i++;
                Console.WriteLine(i + ". " + person.FullName + " - " + person.TelephoneNumber);
            }
        }

        public void GetPersonsFirstNameStartWith(string input)
        {
            IEnumerable<Person> personsFirstNameStartWithLinq = telephoneBook.Where(t => t.FirstName.StartsWith(input)).OrderBy(t => t.LastName);
            int i = 0;
            foreach (Person person in personsFirstNameStartWithLinq)
            {
                i++;
                Console.WriteLine(i + ". " + person.FullName + " - " + person.TelephoneNumber);
            }
        }

        public void GetPersonsLastNameLongerThan(string Length)
        {
            int length;
            Int32.TryParse(Length, out length);
            IEnumerable<Person> personsLastNameLongerThanLinq = telephoneBook.Where(t => t.LastName.Length > length);
            int i = 0;
            foreach (Person person in personsLastNameLongerThanLinq)
            {
                i++;
                Console.WriteLine(i + ". " + person.FullName + " - " + person.TelephoneNumber);
            }
        }

        public void GetPersonsSortByLastNameLength()
        {
            IEnumerable<Person> personsSortByLastNameLengthLinq = telephoneBook.OrderBy(t => t.LastName.Length);
            int i = 0;
            foreach (Person person in personsSortByLastNameLengthLinq)
            {
                i++;
                Console.WriteLine(i + ". " + person.FullName + " - " + person.TelephoneNumber);
            }
        }
    }
}
