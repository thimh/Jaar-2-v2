using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog5_telephone_thimh
{
    class Program
    {
        static void Main(string[] args)
        {
            TelephoneBook telephoneBook = new TelephoneBook();

            Console.WriteLine("## All persons ordered by last name:");
            Console.WriteLine("");
            telephoneBook.GetAllPersons();

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("--> Please enter the letter which you want the first names to start with and press Enter.");
            string input = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("## All persons whose first name start with the letter " + input + ", ordered by last name:");
            Console.WriteLine("");
            telephoneBook.GetPersonsFirstNameStartWith(input);

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("--> Please enter the number which you want the last name to be longer than and press Enter.");
            string length = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("## All persons with a last name longer than " + length + ":");
            Console.WriteLine("");
            telephoneBook.GetPersonsLastNameLongerThan(length);

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("## All persons ordered by last name length (ascending):");
            Console.WriteLine("");
            telephoneBook.GetPersonsSortByLastNameLength();

            Console.ReadLine();
        }
    }
}
