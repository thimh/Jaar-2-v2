using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Utils.Models;
using Alg1_Practicum_Test.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class LinkedListTest : ContextBoundObject
    {
        private LinkedList lijst { get; set; }

        private NAW naw0 = new NAW("Koen", "Kerkstraat", "Veldhoven");
        private NAW naw1 = new NAW("Paul", "De Remise", "Eindhoven");
        private NAW naw2 = new NAW("Martijn", "Dorpstraat", "Oss");

        private NAW new_naw = new NAW("Bart", "Parklaan", "Tilburg");

        [TestInitialize]
        public void LinkedList_Initialize()
        {
            var tmpLijst = new TestableLinkedList();
            tmpLijst.First = new Link() { Naw = naw0 };
            tmpLijst.First.Next = new Link() { Naw = naw1 };
            tmpLijst.First.Next.Next = tmpLijst.Last = new Link() { Naw = naw2 };
            tmpLijst.Length = 3;

            Logger.Instance.ClearLog();

            lijst = tmpLijst;
        }

        #region Count
        [TestMethod]
        [Timeout(10000)]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountCalculated")]
        [TestSummary(@"We maken een lege lijst aan en kijken of de calculated count 0 teruggeeft op basis van een berekening.")]
        public void LinkedList_CountCalculated_EmptyList_Returns0()
        {
            LinkedList legeLijst = new LinkedList();
            Assert.AreEqual(0, legeLijst.CountCalculated(), "Bij een lege lijst retourneert CountCalculated geen 0.");
        }

        [TestMethod]
        [Timeout(10000)]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountCalculated")]
        [TestSummary(@"We maken een lege lijst aan en kijken of de calculated count 0 teruggeeft op basis van een berekening.")]
        public void LinkedList_CountCalculated_FilledList_Returns3()
        {
            var expected = 3;
            var actual = lijst.CountCalculated();
            Assert.AreEqual(expected, actual, "CountCalculated retourneert {0}, dit is niet het juiste aantal elementen {1}.", actual, 2);

            var getNextLinks = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GETNEXTLINK).ToList();
            Assert.AreEqual(naw0, getNextLinks[0].CurrentLink.Naw, "Je bent niet door je lijst gelopen om te tellen");
            Assert.AreEqual(naw1, getNextLinks[1].CurrentLink.Naw, "Je bent niet door je lijst gelopen om te tellen");
            Assert.AreEqual(naw2, getNextLinks[2].CurrentLink.Naw, "Je bent niet door je lijst gelopen om te tellen");
        }

        [TestMethod]
        [Timeout(10000)]
        [AantalPuntenAlsSlaagt(4,0.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountStored")]
        [TestSummary(@"")]

        public void LinkedList_CountStored_EmptyList_Returns0()
        {
            LinkedList legeLijst = new LinkedList();
            Assert.AreEqual(0, legeLijst.CountStored(), "Bij een lege lijst retourneert CountStored geen 0.");
        }

        [TestMethod]
        [Timeout(10000)]
        [AantalPuntenAlsSlaagt(4,0.0)]
        [TestCategory("WS4 - Linked List - Count")]
        [PrintCode("NawLinkedList", "CountStored")]
        [TestSummary(@"")]
        public void LinkedList_CountStored_FilledList_Returns2()
        {
            Assert.AreEqual(3, lijst.CountStored(), "CountStored retourneert {0}, dit is niet het juiste aantal elementen {1}.", lijst.CountStored(), 2);
            var getNextLinks = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GETNEXTLINK).ToList();
            Assert.AreEqual(0, getNextLinks.Count, "Je bent door je lijst heen gelopen om te tellen, dit was niet de bedoeling.");
        }

        #endregion

        #region InsertHead
        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_FilledList_ChangesList()
        {
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.Head().Naw, "Het nieuwe element is nu niet het eerste element geworden.");
            Assert.AreEqual(4, lijst.CountStored(), "Na toevoegen van het element geeft CountStored() niet het juiste aantal elementen. Zorg dat _length up to date blijft.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_EmptyList_ChangesList()
        {
            LinkedList lijst = new LinkedList();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.Head().Naw, "Het nieuwe element is nu niet het eerste element geworden.");
            Assert.AreEqual(1, lijst.CountStored(), "Na toevoegen van het element geeft CountStored() niet het juiste aantal elementen. Zorg dat _length up to date blijft.");
        }


        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_EmptyList_LastUpdatedCorrectly()
        {
            LinkedList lijst = new LinkedList();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.Tail().Naw, "Na invoegen van 1 nieuwe element in de lege lijst, wijst _last niet naar dit nieuwe element.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void LinkedList_InsertInBeginning_FilledList_LastUpdatedCorrectly()
        {
            Link oldTail = lijst.Tail();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(oldTail, lijst.Tail(), "Door het invoegen van het nieuwe element aan het begin van de lijst is de waarde van _last onterecht gewijzigd.");
        }

        #endregion

        #region RemoveHead
        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_FilledList_ChangesList()
        {
            Link secondLink = lijst.Head().Next;
            Link oldLast = lijst.Tail();
            lijst.RemoveHead();

            Assert.AreEqual(secondLink, lijst.Head(), "Het tweede element in de oorspronkelijke lijst is na het verwijderen niet het eerste element geworden. Werk je _first wel bij ?");
            Assert.AreEqual(oldLast, lijst.Tail(), "Bij het verwijderen van het eerste element is de waarde van _last onterecht gewijzigd.");
            Assert.AreEqual(2, lijst.CountStored(), "Na verwijderen van het element geeft CountStored() niet het juiste aantal elementen. Zorg dat _length up to date blijft.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_EmptyList_DoesNothing()
        {
            LinkedList lijst = new LinkedList();
            lijst.RemoveHead();

            Assert.AreEqual(0, lijst.CountStored(), "Bij verwijderen uit een lege lijst krijgt _length onterecht de waarde {0}", lijst.CountStored());
            Assert.AreEqual(null, lijst.Head(), "Bij verwijderen uit een lege lijst krijgt _first onterecht de waarde {0}", lijst.Head());
            Assert.AreEqual(null, lijst.Tail(), "Bij verwijderen uit een lege lijst krijgt _last onterecht de waarde {0}", lijst.Tail());
        }


        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_OneItemList_LastUpdatedCorrectly()
        {
            LinkedList lijst = new LinkedList();

            lijst.InsertHead(new_naw);
            lijst.RemoveHead();

            Assert.AreEqual(null, lijst.Tail(), "Na verwijderen van laatste element in de lijst wijst _last niet naar null.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - RemoveHead")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "RemoveHead")]
        [TestSummary(@"")]
        public void LinkedList_RemoveAtBeginning_FilledList_LastRetainedCorrectly()
        {
            Link oldTail = lijst.Tail();
            lijst.RemoveHead();

            Assert.AreEqual(oldTail, lijst.Tail(), "Na verwijderen van element in de lijst wijst _last niet meer naar juiste Link.");
        }

        #endregion

        #region FindNaw
        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(4, 1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_IsInList_ReturnsIndex()
        {
            Assert.AreEqual(0, lijst.FindNaw(naw0), "Het eerste item in de lijst wordt niet gevonden.");
            Assert.AreEqual(1, lijst.FindNaw(naw1), "Een item in de lijst wordt niet gevonden.");
            Assert.AreEqual(2, lijst.FindNaw(naw2), "Het laatste item in de lijst wordt niet gevonden.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(4, 1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_NotInList_ReturnsMinusOne()
        {
            Assert.AreEqual(-1, lijst.FindNaw(new_naw), "Bij zoeken naar een niet bestaand element is de return-waarde {0} ipv -1.", lijst.FindNaw(new_naw));
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - FindNaw")]
        [AantalPuntenAlsSlaagt(4, 1.0)]
        [PrintCode("NawLinkedList", "FindNaw")]
        [TestSummary(@"")]
        public void LinkedList_FindNaw_EmptyList_ReturnsMinusOne()
        {
            LinkedList lijst = new LinkedList();
            Assert.AreEqual(-1, lijst.FindNaw(new_naw), "Bij zoeken in een lege lijst is de return-waarde {0} ipv -1.", lijst.FindNaw(new_naw));
        }
        #endregion

        #region Show

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS4 - Linked List - Show")]
        [AantalPuntenAlsSlaagt(4,1.0)]
        [PrintCode("NawLinkedList", "Show")]
        [TestSummary(@"")]
        public void LinkedList_Show_ShouldLoopAllItems()
        {
            lijst.Show();

            var testLijst = lijst as TestableLinkedList;
            var getNexts = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GETNEXTLINK).ToList();

            Assert.AreEqual(naw0, getNexts[0].CurrentLink.Naw, "Je bent niet door je lijst heen gelopen");
            Assert.AreEqual(naw1, getNexts[1].CurrentLink.Naw, "Je bent niet door je lijst heen gelopen");
            Assert.AreEqual(naw2, getNexts[2].CurrentLink.Naw, "Je bent niet tot het einde van je lijst doorgelopen");
            Assert.AreEqual(3, getNexts.Count, "Je bent door te veel of te weinig items heen gelopen.");
        }
        #endregion


        private int countLinks(Link link)
        {
            int count = 0;

            while (link != null)
            {
                link = link.Next;
                count++;
            }

            return count;

        }



    }
}
