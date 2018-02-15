using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Alg1_Practicum_Test.TestExtensions;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Utils.Models;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum;
using Alg1_Practicum_Utils.Exceptions;


namespace Alg1_Practicum_Test
{
    [TestClass]
    [MSTestExtensionsTest]
    public class BinarySearchNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void BinarySearchNawArray_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void BinarySearchNawArray_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }
        #endregion

        #region BinarySearch

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(2,1.0)]
        [PrintCode("NawArrayOrdered", "FindBinary")]
        [TestSummary(@"We maken een lege NawArrayOrdered aan gaan hier binair in zoeken.
We testen of er geen zoekstappen zijn uitgevoerd aangezien er geen items zijn.")]
        public void NawArrayOrdered_FindBinary_EmptyArray_ShouldHaveNoSteps()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(10), expectedLength, out testSet);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;
            array.FindBinary(new NAW("Naam", "Adres", "Woonplaats"));

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(0, Logger.Instance.LogItems.Count(), "\n\nNawArrayOrdered.FindBinary(): Er wordt onnodig gezocht in een lege array.\n");
        }

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(2,1.0)]
        [PrintCode("NawArrayOrdered", "FindBinary")]
        [TestSummary(@"We maken een NawArrayOrdered aan gaan een item op plek 99 (van de 100) binair zoeken.
We testen dat er maximaal Log(100), ongeveer 7, stappen zijn gemaakt om te zoeken.")]
        public void NawArrayOrdered_FindBinary_LastItem_ShouldNotTakeMoreThanLogN()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var expectedSearches = Math.Ceiling(Math.Log(expectedLength));
            var expectedIndex = 99;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            var actualIndex = array.FindBinary(testSet[expectedIndex]);

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(expectedIndex, actualIndex, "Je hebt niet de juiste index gevonden.");
            var actualSearches = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count();
            Assert.IsTrue(actualSearches <= expectedSearches + 2, "\n\nNawArrayOrdered.FindBinary(): De implementatie gebruikt teveel stappen om het laatste element te vinden middels binair zoeken.\n");
        }

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(2,1.0)]
        [PrintCode("NawArrayOrdered", "FindBinary")]
        [TestSummary(@"We maken een NawArrayOrdered aan gaan een item op plek 1 (van de 100) binair zoeken.
We testen dat er maximaal Log(100), ongeveer 7, stappen zijn gemaakt om te zoeken.")]
        public void NawArrayOrdered_FindBinary_FirstItem_ShouldNotTakeMoreThanLogN()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var expectedSearches = Math.Ceiling(Math.Log(expectedLength));
            var expectedIndex = 0;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            var actualIndex = array.FindBinary(testSet[expectedIndex]);

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(expectedIndex, actualIndex, "Je hebt niet de juiste index gevonden.");
            var actualSearches = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count();
            Assert.IsTrue(actualSearches <= expectedSearches + 2, "\n\nNawArrayOrdered.FindBinary(): De implementatie gebruikt teveel stappen om het eerste element te vinden middels binair zoeken.\n");
        }

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS2 - Array - Binary Search")]
        [AantalPuntenAlsSlaagt(2,1.0)]
        [PrintCode("NawArrayOrdered", "FindBinary")]
        [TestSummary(@"We maken een NawArrayOrdered aan gaan een item op plek 50 (van de 100) binair zoeken.
We testen dat er maximaal Log(100), ongeveer 7, stappen zijn gemaakt om te zoeken.")]
        public void NawArrayOrdered_FindBinary_MiddleItem_ShouldNotTakeMoreThanLogN()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var expectedSearches = Math.Ceiling(Math.Log(expectedLength));
            var expectedIndex = 50;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            var actualIndex = array.FindBinary(testSet[expectedIndex]);

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.AreEqual(expectedIndex, actualIndex, "Je hebt niet de juiste index gevonden.");
            var actualSearches = Logger.Instance.LogItems.Where(li => li.ArrayAction == ArrayAction.GET).Count();
            Assert.IsTrue(actualSearches <= expectedSearches + 2, "\n\nNawArrayOrdered.FindBinary(): De implementatie gebruikt teveel stappen om het middelste element te vinden middels binair zoeken.\n");
        }

        #endregion BinarySearch

    }

}
