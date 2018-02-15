using Alg1_Practicum;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Models;
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
    public class UndoableNawArrayTest : ContextBoundObject
    {
        private NAW naw0 = new NAW("Paul", "De Remise", "Eindhoven");
        private NAW naw1 = new NAW("Martijn", "Dorpstraat", "Oss");
        private NAW naw2 = new NAW("Koen", "Kerkstraat", "Veldhoven");

        private static void SetFirstLink(UndoableNawArray list, UndoLink first, bool setCurrentUndoLink = true)
        {
            var firstProp = list.GetType().GetField("_first", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            firstProp.SetValue(list, first);

            if (setCurrentUndoLink)
            {
                SetCurrentUndoLink(list, first);
            }
        }

        private static void SetCurrentUndoLink(UndoableNawArray list, UndoLink currentUndoLink)
        {
            var currentProp = list.GetType().GetField("_currentUndoLink", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            currentProp.SetValue(list, currentUndoLink);
        }

        #region Add

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - Add")]
        [PrintCode("UndoableNawArray", "Add")]
        public void Add_SingleItem()
        {
            // Arrange
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw1);

            // Assert
            Assert.AreEqual(1, list.Count, "Na het toevoegen in een lege lijst verwachten we dat de count 1 is.");
            Assert.AreEqual(0, list.Find(naw1), "Het nieuwe item moet gevonden kunnen worden in de lijst.");
            Assert.AreEqual(-1, list.Find(naw0), "Een item dat niet is toegevoegd moet niet gevonden kunnen worden in de lijst.");
        }

        #endregion Add

        #region remove

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - Remove")]
        [PrintCode("UndoableNawArray", "Remove")]
        public void Remove_SingleItem()
        {
            // Arrange
            UndoableNawArray list = new UndoableNawArray(10);
            list.Array[0] = naw0;
            list.Array[1] = naw1;
            list.Count = 2;

            // Act
            list.Remove(naw0);

            // Assert
            Assert.AreEqual(1, list.Count, "Na het verwijderen uit een lijst met 2 items verwachten we dat de count 1 is.");
            Assert.AreEqual(0, list.Find(naw1), "We verwachten dat het item dat niet verwijderd is nog steed in de lijst zit.");
            Assert.AreEqual(-1, list.Find(naw0), "We verwachten dat het item dat verwijderd is niet meer in de lijst zit.");
        }

        #endregion remove

        #region AddOperation

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(5,1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_LinkContainsOperation()
        {
            // Arrange
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw1);

            // Assert
            Assert.AreEqual(list.First.Operation, Operation.ADD, "De Link die aan de Undo-lijst is toegevoegd geeft niet aan dat er een Add operatie heeft plaatsgevonden.");
            Assert.AreEqual(list.First.Naw, naw1, "De Link die aan de Undo-lijst is toegevoegd geeft niet het juiste Naw-object aan waarop een Add operatie heeft plaatsgevonden.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(5,1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Remove_AddOperation_LinkContainsOperation()
        {
            // Arrange
            UndoableNawArray list = new UndoableNawArray(10);
            list.Array[0] = naw1;
            list.Count = 1;

            // Act
            list.Remove(naw1);

            // Assert
            Assert.AreEqual(list.First.Operation, Operation.REMOVE, "De Link die aan de Undo-lijst is toegevoegd geeft niet aan dat er een Remove operatie heeft plaatsgevonden.");
            Assert.AreEqual(list.First.Naw, naw1, "De Link die aan de Undo-lijst is toegevoegd geeft niet het juiste Naw-object aan waarop een Remove operatie heeft plaatsgevonden.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(5,1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_BothNextAndPreviousSet()
        {
            // Arrange
            UndoableNawArray list = new UndoableNawArray(10);
            list.Array[0] = naw0;
            list.Count = 1;
            SetFirstLink(list, new UndoLink() { Naw = naw0, Operation = Operation.ADD });

            // Act
            list.Add(naw1);

            // Assert
            Assert.AreEqual(list.First.Next.Naw, naw1, "Er wordt geen juiste referentie naar de Link die aan de Undo-lijst is toegevoegd gelegd vanuit de voorgaande link.");
            Assert.AreEqual(list.First.Next.Previous.Naw, naw0, "Er wordt geen juiste referentie van de Link die aan de Undo-lijst is toegevoegd gelegd naar de voorgaande link.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(5,1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_CurrentIsUpdated()
        {
            UndoableNawArray list = new UndoableNawArray(10);
            list.Array[0] = naw1;
            list.Count = 1;
            SetFirstLink(list, new UndoLink() { Operation = Operation.ADD, Naw = naw1 });

            // Act
            list.Remove(naw1);

            Assert.AreEqual(list.First.Next.Operation, Operation.REMOVE, "De Link die aan de Undo-lijst is toegevoegd geeft niet aan dat er een Remove operatie heeft plaatsgevonden.");
            Assert.AreEqual(list.First.Next.Naw, naw1, "De Link die aan de Undo-lijst is toegevoegd geeft niet het juiste Naw-object aan waarop een Remove operatie heeft plaatsgevonden.");
        }

        [TestMethod]
        [Timeout(10000)]
        [TestCategory("WS5 - Undoable Naw Array - AddOperation")]
        [AantalPuntenAlsSlaagt(5,1.0)]
        [PrintCode("UndoableNawArray", "AddOperation")]
        public void Add_AddOperation_EmptyList_ListIsCorrect()
        {
            UndoableNawArray list = new UndoableNawArray(10);

            // Act
            list.Add(naw0);

            Assert.AreEqual(list.First.Naw, naw0, "In het geval dat een eerste Undo-Link aan een lege lijst wordt toegevoegd wordt de First niet goed bijgewerkt.");
            Assert.AreEqual(list.Current.Naw, naw0, "In het geval dat een eerste Undo-Link aan een lege lijst wordt toegevoegd wordt deze niet de currentUndoLink gemaakt.");
        }


        #endregion AddOperation

    }
}
