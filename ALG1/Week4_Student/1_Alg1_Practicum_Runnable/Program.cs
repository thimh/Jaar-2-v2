using Alg1_Practicum;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Runnable
{
    class Program
    {

        private static void week4_LinkedList_TestAanroepen() 
        {
            // Aanmaken testlijst:

            LinkedList lijst = new LinkedList();
            lijst.InsertHead(new NAW("Persoon 10", "Adres 10", "Woonplaats 2"));
            lijst.InsertHead(new NAW("Persoon 9", "Adres 9", "Woonplaats 1"));
            lijst.InsertHead(new NAW("Persoon 2", "Adres 8", "Woonplaats 2"));
            lijst.InsertHead(new NAW("Persona non grata", "Adres 7", "Woonplaats 3"));
            lijst.InsertHead(new NAW("Persoon 2", "Adres 6", "Woonplaats 2"));
            lijst.InsertHead(new NAW("Persoon 1", "Adres 5", "Woonplaats 1"));
            lijst.InsertHead(new NAW("Persoon 4", "Adres 4", "Woonplaats 2"));
            lijst.InsertHead(new NAW("Persona non grata", "Adres 3", "Woonplaats 3"));
            lijst.InsertHead(new NAW("Persoon 2", "Adres 2", "Woonplaats 2"));
            lijst.InsertHead(new NAW("Persoon 1", "Adres 1", "Woonplaats 1"));

            System.Console.WriteLine("\n\nDe lijst na initialisatie maar voor bewerkingen is:");
            lijst.Show();

            /*
            lijst.RemoveHead();

            System.Console.WriteLine("\n\nDe lijst na aanroep RemoveHead:");
            lijst.Show();
            */

            /*
            System.Console.WriteLine("\n\nCountCalculated telt {0} elementen.", lijst.CountCalculated());
            System.Console.WriteLine("\n\nCountStored telt {0} elementen.", lijst.CountStored());
            */

            /*
            NAW persoon4 = new NAW("Persoon 4", "Adres 4", "Woonplaats 2");
            int persoon4Index = lijst.FindNaw(persoon4);
            System.Console.WriteLine("\n\nFindNaw vindt Persoon 4 op index {0}.", persoon4Index);
            */

            /*
            System.Console.WriteLine("\n\nDe lijst voor aanroep InsertTail:");
            lijst.Show();

            lijst.InsertTail(persoon4);

            System.Console.WriteLine("\n\nDe lijst na aanroep InsertTail:");
            lijst.Show();
            */

            /*
            System.Console.WriteLine("\n\nDe lijst voor aanroep RemoveTail:");
            lijst.Show();

            lijst.RemoveTail();

            System.Console.WriteLine("\n\nDe lijst na aanroep RemoveTail:");
            lijst.Show();
            */

            /*
            NAW dubbeleNaw = new NAW("Persoon dubbel", "adres dubbel", "woonplaats dubbel");
            lijst.InsertTail(dubbeleNaw);           
            lijst.InsertTail(dubbeleNaw);

            System.Console.WriteLine("\n\nDe lijst voor aanroep van RemoveAllNaw:");
            lijst.Show();

            lijst.RemoveAllNaw(dubbeleNaw);

            System.Console.WriteLine("\n\nDe lijst na aanroep van RemoveAllNaw:");
            lijst.Show();
            */

            /*
            NAW personaNonGrata = lijst.GetNawAt(2);
            System.Console.WriteLine("\n\nGetNawAt(2): Element op index 2 is: ");
            personaNonGrata.Show();
            */

            /*
            lijst.SetNawAt(2, dubbeleNaw);
            System.Console.WriteLine("\n\nDe lijst na SetNawAt(2, dubbelNaw) aanroep:");
            lijst.Show();
            */

            /*
            System.Console.WriteLine("\n\nDe lijst voor aanroep van BubbleSort:");
            lijst.Show();

            lijst.BubbleSort();

            System.Console.WriteLine("\n\nDe lijst na aanroep van BubbleSort:");
            lijst.Show();
            */
        }

        static void Main(string[] args)
        {

            week4_LinkedList_TestAanroepen();

            System.Console.ReadKey();
           
        }
    }
}
