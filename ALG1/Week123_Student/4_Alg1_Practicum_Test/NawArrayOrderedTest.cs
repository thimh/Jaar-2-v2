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
    public class NawArrayOrderedTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void NawArrayOrdered_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void NawArrayOrdered_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }
        #endregion

        #region Constructor
        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS1 - Array - Ordered")]
        [TestSummary(@"We roepen de constructor van NawArrayOrdered aan met een initial size van 0.
Dit moet een NawArrayOrderedInvalidSizeException opleveren omdat de initial size tussen 1 en 1000000 moet liggen.")]
        public void NawArrayOrdered_Constructor_Size0_ThrowsException()
        {
            try
            {
                INawArrayOrdered array = new NawArrayOrdered(0);
                Assert.Fail("\n\nNawArrayOrdered: De constructor accepteert ten onrechte een initialSize van 0. \nTIP: De minimale grootte waarop de NawArrayOrdered geinitialiseerd mag worden zou 1 moeten zijn.\n");
            }
            catch (NawArrayOrderedInvalidSizeException) { }
        }

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS1 - Array - Ordered")]
        [TestSummary(@"We roepen de constructor van NawArrayOrdered aan met een initial size van 10000001.
Dit moet een NawArrayOrderedInvalidSizeException opleveren omdat de initial size tussen 1 en 1000000 moet liggen.")]
        public void NawArrayOrdered_Constructor_Size1000001_ThrowsException()
        {
            try
            {
                INawArrayOrdered array = new NawArrayOrdered(1000001);
                Assert.Fail("\n\nNawArrayOrdered: De constructor accepteert ten onrechte een te grote initialSize.\nTIP: De maximale grootte waarop de NawArrayOrdered geinitialiseerd mag worden zou 1.000.000 moeten zijn.\n");
            }
            catch (NawArrayOrderedInvalidSizeException) { }
        }
        #endregion

        #region Add
        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,0.5)]
        [PrintCode("NawArrayOrdered", "Add")]
        [TestCategory("WS1 - Array - Ordered")]
        [TestSummary(@"We maken een NawArrayOrdered aan met een grootte van 10, hier voegen we 10 items aan toe. Dit mag geen foutmelding opleveren.")]
        public void NawArrayOrdered_Add_FillWholeArray_ShouldFit()
        {
            // Arrange
            var expectedSize = 10;
            var expectedNaws = RandomNawGenerator.NewArray(expectedSize);

            var array = new NawArrayOrdered(expectedSize);

            // Act

            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;
            for (int i = 0; i < expectedSize; i++)
            {
                try
                {
                    array.Add(expectedNaws[i]);
                    Assert.AreEqual(i + 1, array.Count, "\n\nNawArrayOrdered.Add(): Het aantal elementen in de array komt niet overeen met het aantal toegevoegde items.");
                }
                catch (NawArrayOrderedOutOfBoundsException)
                {
                    // Assert
                    Assert.Fail("\n\nNawArrayOrdered.Add(): Er konden maar {0} NAW-objecten aan een array die met omvang {1} is geinitialiseerd worden toegevoegd", i, expectedSize);
                }
            }
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,0.5)]
        [PrintCode("NawArrayOrdered", "Add")]
        [TestCategory("WS1 - Array - Ordered")]
        [TestSummary(@"We maken een NawArrayOrdered aan met een grootte van 3, hier voegen we 4 items aan toe. 
Dit moet een NawArrayOrderedOutOfBoundsException opleveren.")]
        public void NawArrayOrdered_Add_OneTooMany_ShouldThrowException()
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
                Assert.IsInstanceOfType(ex, typeof(NawArrayOrderedOutOfBoundsException),
                    "\n\nNawArrayOrdered.Add(): Toevoegen van 11e element aan array met omvang van 10 geeft geen exceptie");
            }

            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");
        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,1.0)]
        [TestCategory("WS1 - Array - Ordered")]
        [PrintCode("NawArrayOrdered", "Add")]
        [TestSummary(@"We maken een NawArrayOrdered aan en hier voegen we willekeurige items aan toe. 
De array moet elke keer bij het toevoegen in de juiste volgorde blijven staan.")]
        public void NawArrayOrdered_Add_Valid_ShouldAddInOrder()
        {
            // Arrange
            char[] woonplaatsen = "abcde".ToCharArray();
            NAW[] testSet = RandomNawGenerator.NewArray(5);
            testSet[0].Woonplaats = woonplaatsen[3].ToString();
            testSet[1].Woonplaats = woonplaatsen[2].ToString();
            testSet[2].Woonplaats = woonplaatsen[4].ToString();
            testSet[3].Woonplaats = woonplaatsen[0].ToString();
            testSet[4].Woonplaats = woonplaatsen[1].ToString();

            var array = new NawArrayOrdered(20);

            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            for (int i = 0; i < testSet.Length; i++)
            {
                // Act
                array.Add(testSet[i]);

                // Assert
                Assert.IsTrue(array.CheckIsGesorteerd(), "NawArrayOrdered.Add(): Na het toevoegen van het element is de array niet langer goed gesorteerd.");
            }
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

        }

        [TestMethod]
        [Timeout(3000)]
        [AantalPuntenAlsSlaagt(1,1.0)]
        [TestCategory("WS1 - Array - Ordered")]
        [PrintCode("NawArrayOrdered", "Add")]
        [TestSummary(@"We maken een NawArrayOrdered aan en hier voegen we willekeurige items aan toe. 
De array moet elke keer ruimte maken om het nieuwe item in te voegen. Hij mag niet te veel items verschuiven.")]
        public void NawArrayOrdered_Add_Valid_ShouldMoveTheRightNumberOfItems()
        {
            // Arrange
            char[] woonplaatsen = "acegi".ToCharArray();
            NAW[] testSet = RandomNawGenerator.NewArray(5);
            testSet[0].Woonplaats = woonplaatsen[3].ToString();
            testSet[1].Woonplaats = woonplaatsen[2].ToString();
            testSet[2].Woonplaats = woonplaatsen[4].ToString();
            testSet[3].Woonplaats = woonplaatsen[0].ToString();
            testSet[4].Woonplaats = woonplaatsen[1].ToString();

            var array = new NawArrayOrdered(20);

            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            for (int i = 0; i < testSet.Length; i++)
            {
                // Act
                array.Add(testSet[i]);
            }

            Logger.Instance.ClearLog();
            array.Add(new NAW() { Woonplaats = "f" });

            var setters = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.SET);
            Assert.AreEqual(3, setters.Count(), "\n\nNawArrayOrdered.Add(): Er worden te veel of te weinig elementen verschoven ({0}, i.p.v. {1}) om ruimte te maken voor het nieuwe element.", setters.Count(), 3);
            Assert.IsTrue(setters.Any(li => li.NewNaw1.Woonplaats == "f"), "Naw met woonplaats f had verplaatst moeten worden, dit is niet gebeurd.");
            Assert.IsTrue(setters.Any(li => li.NewNaw1.Woonplaats == "g"), "Naw met woonplaats g had verplaatst moeten worden, dit is niet gebeurd.");
            Assert.IsTrue(setters.Any(li => li.NewNaw1.Woonplaats == "i"), "Naw met woonplaats i had verplaatst moeten worden, dit is niet gebeurd.");
            //     Assert.IsTrue(array.CheckIsGesorteerd()); Wordt al bij andere testcase beoordeeld.
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");
        }

        #endregion

        private static NawArrayOrdered InitializeTestsubject(int maxSize, int initialFilledSize, out NAW[] testSet, int? maxStringLenght = null)
        {
            testSet = RandomNawGenerator.NewArray(initialFilledSize).OrderAscending();
            var array = new NawArrayOrdered(maxSize);

            Array.ForEach(testSet, naw => array.Add(naw));

            // We have to clear the log because adding to the array will cause the logger to log as well.
            Logger.Instance.ClearLog();
            return array;
        }
    }
}
