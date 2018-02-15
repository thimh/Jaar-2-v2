using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alg1_Practicum;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System.Linq;
using System.Diagnostics;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils;


namespace Alg1_Practicum_Test
{

    [TestClass]
    [MSTestExtensionsTest]
    public class NawArrayUnorderedTest : ContextBoundObject
    {

        #region Setup and Teardown
        [TestInitialize]
        public void NawArrayUnordered_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void NawArrayUnordered_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }

        #endregion

        #region Constructor
        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS1 - Array - Unordered")]
        [TestSummary(@"We roepen de constructor van NawArrayUnordered aan met een initial size van 0.
Dit moet een NawArrayUnorderedInvalidSizeException opleveren omdat de initial size tussen 1 en 1000000 moet liggen.")]
        public void NawArrayUnordered_Constructor_Size0_ThrowsException()
        {
            try
            {
                INawArrayUnordered array = new NawArrayUnordered(0);
                Assert.Fail("\n\nNawArrayUnordered: De constructor accepteert ten onrechte een initialSize van 0. \nTIP: De minimale grootte waarop de NawArrayUnordered geinitialiseerd mag worden zou 1 moeten zijn.\n");
            }
            catch (NawArrayUnorderedInvalidSizeException) { }
        }

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS1 - Array - Unordered")]
        [TestSummary(@"We roepen de constructor van NawArrayUnordered aan met een initial size van 10000001.
Dit moet een NawArrayUnorderedInvalidSizeException opleveren omdat de initial size tussen 1 en 1000000 moet liggen.")]
        public void NawArrayUnordered_Constructor_Size1000001_ThrowsException()
        {
            try
            {
                INawArrayUnordered array = new NawArrayUnordered(1000001);
                Assert.Fail("\n\nNawArrayUnordered: De constructor accepteert ten onrechte een te grote initialSize.\nTIP: De maximale grootte waarop de NawArrayUnordered geinitialiseerd mag worden zou 1.000.000 moeten zijn.\n");
            }
            catch (NawArrayUnorderedInvalidSizeException) { }
        }
        #endregion

        #region Add
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1, 1.0)]
        [PrintCode("NawArrayUnordered", "Add")]
        [TestCategory("WS1 - Array - Unordered")]
        [TestSummary(@"We maken een NawArrayUnordered aan met een grootte van 10, hier voegen we 10 items aan toe. Dit mag geen foutmelding opleveren.")]
        public void NawArrayUnordered_Add_FillWholeArray_ShouldFit()
        {
            // Arrange
            var expectedSize = 10;
            var expectedNaws = RandomNawGenerator.NewArray(expectedSize);

            var array = new NawArrayUnordered(expectedSize);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            for (int i = 0; i < expectedSize; i++)
            {
                try
                {
                    array.Add(expectedNaws[i]);
                    Assert.AreEqual(i + 1, array.Count, "\n\nNawArrayUnordered.Add(): Het aantal elementen in de array komt niet overeen met het aantal toegevoegde items.");
                }
                catch (NawArrayUnorderedOutOfBoundsException)
                {
                    // Assert
                    Assert.Fail("\n\nNawArrayUnordered.Add(): Er konden maar {0} NAW-objecten aan een array die met omvang {1} is geinitialiseerd worden toegevoegd", i, expectedSize);
                }
            }
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,1.0)]
        [PrintCode("NawArrayUnordered", "Add")]
        [TestCategory("WS1 - Array - Unordered")]
        [TestSummary(@"We maken een NawArrayUnordered aan met een grootte van 3, hier voegen we 4 items aan toe. 
Dit moet een NawArrayOrderedOutOfBoundsException opleveren.")]
        public void NawArrayUnordered_Add_OneTooMany_ShouldThrowException()
        {
            // Arrange
            NAW[] testSet;
            var array = InitializeTestsubject(3, 3, out testSet);
            var oneTooMany = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            try
            {
                array.Add(oneTooMany);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsInstanceOfType(ex, typeof(NawArrayUnorderedOutOfBoundsException),
                    "\n\nNawArrayUnordered.Add(): Toevoegen van 11e element aan array met omvang van 10 geeft geen exceptie. Controleer je wel of het array nog ruimte heeft ?");
            }
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,1.0)]
        [PrintCode("NawArrayUnordered", "Add")]
        [TestCategory("WS1 - Array - Unordered")]
        [TestSummary(@"We maken een NawArrayUnordered aan en gaan hier items aan toevoegen
De array moet deze nieuwe items elke keer aan het eind invoegen zonder rekening te houden met de ordening.")]
        public void NawArrayUnordered_Add_Valid_ShouldAddAtTheEnd()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 5;
            var array = InitializeTestsubject(10, expectedLength, out testSet);
            var newNaw = RandomNawGenerator.New();

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            array.Add(newNaw);
 
            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(expectedLength + 1, array.Count, "Na het toevoegen is de ItemCount() niet opgehoogd.");

            // Niets is overschreven
            for (var i = 0; i < testSet.Length; i++)
            {
                Assert.AreEqual(testSet[i], array.Array[i], "\n\nNawArrayUnordered.Add(): Bij het toevoegen aan de array is item {0} onterecht overschreven.", i);
            }
            // Aan het einde toegevoegd
            Assert.AreEqual(newNaw, array.Array[expectedLength], "\n\nNawArrayUnordered.Add(): Bij het toevoegen aan de array is de nieuwe item niet aan het einde ingevoegd.");
        }

        #endregion

        #region FindNaam
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,1.0)]
        [PrintCode("NawArrayUnordered", "FindNaam")]
        [TestCategory("WS1 - Array - Unordered")]
        [TestSummary(@"We maken een NawArrayUnordered aan en zoeken een item dat niet in de array voorkomt.
De array moet de items doorlopen tot de gebruikte index om er achter te komen dat hij er niet in zit, vervolgens moet de array -1 retourneren.")]
        public void NawArrayUnordered_FindNaam_NaamNotInArray_ReturnsMin1()
        {
            // Arrange
            var expectedNaam = "ExpectedNaam";
            NAW[] testSet;
            var array = InitializeTestsubject(5, 5, out testSet, maxStringLenght: 5);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            var result = array.FindNaam(expectedNaam);

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(-1, result, "\n\nNawArrayUnordered.FindNaam(): Naam \"{0}\" zit niet in de array dus moet bij FindNaam -1 teruggeven", expectedNaam);
            Assert.AreEqual(array.Count, Logger.Instance.LogItems.Count(), "De methode Findnaam heeft niet alle elementen in de array gecontrolleerd.");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,1.0)]
        [TestCategory("WS1 - Array - Unordered")]
        [PrintCode("NawArrayUnordered", "FindNaam")]
        [TestSummary(@"We maken een NawArrayUnordered aan en zoeken een item dat 2 keer in de array voorkomt.
De array moet de items doorlopen tot de eerste match en deze index retourneren. De array mag hierna niet verder zoeken.")]
        public void NawArrayUnordered_FindNaam_NaamTwiceInArray_ReturnsFirstIndex()
        {
            // Arrange
            var expectedNaam = "ExpectedNaam";
            var expectedIndex = 2;
            NAW[] testSet;
            var array = InitializeTestsubject(5, 5, out testSet, maxStringLenght: 5);

            testSet[expectedIndex].Naam = expectedNaam;
            testSet[testSet.Length - 1].Naam = expectedNaam;

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            var result = array.FindNaam(expectedNaam);

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(expectedIndex, result, "NawArrayUnordered.FindNaam(): Naam \"{0}\" zit op index {1} in de array dus moet bij FindNaam {1} teruggeven", expectedNaam, expectedIndex);
            Assert.AreEqual(expectedIndex + 1 /* + 1 because arrays are zero based */, Logger.Instance.LogItems.Count(),
                        "Na het vinden van het eerste item dat matcht moet je stoppen met zoeken.");
        }

        #endregion

 
        private static INawArrayUnordered InitializeTestsubject(int maxSize, int initialFilledSize, out NAW[] testSet, int? maxStringLenght = null)
        {
            testSet = RandomNawGenerator.NewArray(initialFilledSize);
            var array = new NawArrayUnordered(maxSize);

            Array.ForEach(testSet, naw => array.Add(naw));

            // We have to clear the log because adding to the array will cause the logger to log as well.
            Logger.Instance.ClearLog();
            return array;
        }
    }
}
