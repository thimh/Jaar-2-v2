using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Logging;

namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class NawDoublyLinkedListTest : ContextBoundObject
    {
        private NawDoublyLinkedList lijst { get; set; }

        private NAW naw0 = new NAW("Paul", "De Remise", "Eindhoven");
        private NAW naw1 = new NAW("Martijn", "Dorpstraat", "Oss");
        private NAW naw2 = new NAW("Koen", "Kerkstraat", "Veldhoven");

        private NAW new_naw = new NAW("Bart", "Parklaan", "Tilburg");

        [TestInitialize]
        public void NawDoublyDoublyLinkedList_Initialize()
        {
            lijst = new NawDoublyLinkedList();
            lijst.First = new DoubleLink() { Naw = naw0 };
            lijst.First.Next = new DoubleLink() { Naw = naw1 };
            lijst.First.Next.Previous = lijst.First;

            lijst.First.Next.Next = lijst.Last = new DoubleLink() { Naw = naw2 };
            lijst.First.Next.Next.Previous = lijst.First.Next;
        }

        #region InsertHead
        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(5,1.5)]
        [PrintCode("NawDoublyLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void DoublyLinkedList_InsertInBeginning_FilledList_ChangesList()
        {
            DoubleLink oldFirst = lijst.First;
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.First.Naw, "Het nieuwe element is nu niet het eerste element geworden.");
            Assert.AreEqual(lijst.First.Previous, null, "De previous van de nieuwe Link wijst niet naar null.");
            Assert.AreEqual(lijst.First.Next, oldFirst, "De next van de nieuwe link wijst niet naar de Link die de eerste in de lijst was.");

        }


        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(5,1.5)]
        [PrintCode("NawDoublyLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void DoublyLinkedList_InsertInBeginning_EmptyList_ChangesList()
        {
            NawDoublyLinkedList lijst = new NawDoublyLinkedList();
            lijst.InsertHead(new_naw);

            Assert.AreEqual(new_naw, lijst.First.Naw, "Het nieuwe element is nu niet het eerste element geworden.");
            Assert.AreEqual(new_naw, lijst.Last.Naw, "Het nieuwe element is ingevoegd in een lege lijst maar niet het laatste element geworden.");
            Assert.AreEqual(lijst.First.Previous, null, "De previous van de nieuwe Link wijst niet naar null wanneer een eerste link aan een lege lijst wordt toegevoegd.");
            Assert.AreEqual(lijst.First.Next, null, "De next van de nieuwe link wijst niet naar null wanneer een eerste link aan een lege lijst wordt toegevoegd.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - InsertHead")]
        [AantalPuntenAlsSlaagt(5,1.0)]
        [PrintCode("NawDoublyLinkedList", "InsertHead")]
        [TestSummary(@"")]
        public void DoublyLinkedList_InsertInBeginning_FilledList_LastStillValid()
        {
            DoubleLink oldTail = lijst.Last;
            lijst.InsertHead(new_naw);

            Assert.AreEqual(oldTail, lijst.Last, "Door het invoegen van het nieuwe element aan het begin van de lijst is de waarde van _last onterecht gewijzigd.");
        }

        #endregion

        #region SwapLinkWithNext

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - SwapLinkWithNext")]
        [AantalPuntenAlsSlaagt(5,1.5)]
        [PrintCode("NawDoublyLinkedList", "SwapLinkWithNext")]
        [TestSummary(@"")]
        public void DoublyLinkedList_SwapLinkWithNext_ItemsSwapped()
        {
            // Arrange
            lijst.First = new DoubleLink() { Naw = new NAW() { Naam = "naam", Adres = "adres", Woonplaats = "woonplaats" }, Next = lijst.First };
            lijst.First.Next.Previous = lijst.First;

            DoubleLink first = lijst.First;
            DoubleLink second = lijst.First.Next;
            DoubleLink third = second.Next;
            DoubleLink fourth = lijst.Last;

            // Act
            lijst.SwapLinkWithNext(second);

            Assert.AreEqual(first, lijst.First, "De eerste is gewijzigd. Dit was niet de bedoeling.");
            Assert.AreEqual(fourth, lijst.Last, "De laatste is gewijzigd. Dit was niet de bedoeling.");

            Assert.AreEqual(third, lijst.First.Next, "De eerste zou nu naar de derde moeten wijzen, dit doet hij niet.");
            Assert.AreEqual(lijst.First, third.Previous, "De derde zou nu naar de eerste terug moeten wijzen, dit doet hij niet.");

            Assert.AreEqual(second, third.Next, "De derde zou nu naar de tweede moeten wijzen, dit doet hij niet.");
            Assert.AreEqual(third, second.Previous, "De tweede zou nu naar de derde terug moeten wijzen, dit doet hij niet.");

            Assert.AreEqual(second, fourth.Previous, "De tweede zou nu naar de vierde moeten wijzen, dit doet hij niet.");
            Assert.AreEqual(fourth, second.Next, "De vierde zou nu naar de tweede terug moeten wijzen, dit doet hij niet.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - SwapLinkWithNext")]
        [AantalPuntenAlsSlaagt(5,1.5)]
        [PrintCode("NawDoublyLinkedList", "SwapLinkWithNext")]
        [TestSummary(@"")]
        public void DoublyLinkedList_SwapLinkWithNext_FirstSwapped_FirstIsStillValid()
        {
            // Arrange

            DoubleLink first = lijst.First;
            DoubleLink second = first.Next;

            // Act
            lijst.SwapLinkWithNext(first);

            Assert.AreEqual(lijst.First, second, "Na het omdraaien van de eerste met de tweede link in een lijst wijst first niet naar de juiste link.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - SwapLinkWithNext")]
        [AantalPuntenAlsSlaagt(5,1.5)]
        [PrintCode("NawDoublyLinkedList", "SwapLinkWithNext")]
        [TestSummary(@"")]
        public void DoublyLinkedList_SwapLinkWithNext_LastSwapped_LastIsStillValid()
        {
            // Arrange

            DoubleLink second = lijst.Last;
            DoubleLink first = second.Previous;

            // Act
            lijst.SwapLinkWithNext(first);

            Assert.AreEqual(lijst.Last, first, "Na het omdraaien van de een na laatste met de laatste link in een lijst wijst last niet naar de juiste link.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Double Linked List - SwapLinkWithNext")]
        [AantalPuntenAlsSlaagt(5,1.5)]
        [PrintCode("NawDoublyLinkedList", "SwapLinkWithNext")]
        [TestSummary(@"")]
        public void DoublyLinkedList_SwapLinkWithNext_ReturnsCorrectLink()
        {
            // Arrange

            DoubleLink second = lijst.Last;
            DoubleLink first = second.Previous;

            // Act
            DoubleLink result = lijst.SwapLinkWithNext(first);

            Assert.AreEqual(result, second, "De return-waarde is niet gelijk aan de Link waarmee geswapt is.");
        }

        #endregion SwapLinkWithNext

    }
}