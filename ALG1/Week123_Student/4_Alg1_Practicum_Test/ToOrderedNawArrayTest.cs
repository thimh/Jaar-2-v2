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
    public class ToOrderedNawArrayTest : ContextBoundObject
    {
        #region Setup and Teardown
        [TestInitialize]
        public void ToOrderedNawArray_TestInitialize()
        {
            Logger.Instance.ClearLog();
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void ToOrderedNawArray_TestCleanup()
        {
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }
        #endregion

        #region ToNawOrdered

        [TestMethod]
        [Timeout(30000)]
        [TestCategory("WS2 - Array - ToNawArrayOrdered")]
        [AantalPuntenAlsSlaagt(2,1.0)]
        [TestSummary(@"We maken een NawArrayUnordered aan en hier voegen we willekeurige items aan toe.
We roepen vervolgens ToNawArrayOrdered aan en testen of de NawArrayOrdered dezelfde items heeft en of het er evenveel zijn.")]
        public void NawArrayUnordered_ToNawOrdered_OrderedArray_ShouldHaveSameItems()
        {
            // Arrange
            NAW[] testSet;

            var expectedLength = 10;
            var itemsRemoved = 0;

            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;
            var orderedArray = array.ToNawArrayOrdered();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            // Act

            for (var i = 0; i < orderedArray.ItemCount(); i++ )
            {
                var indexToRemove = FindNaw(array, orderedArray.Array[i], expectedLength-itemsRemoved );
                array.RemoveAtIndex(indexToRemove);
                itemsRemoved++;
            }

            // Assert
            Assert.IsTrue(orderedArray.ItemCount() == expectedLength, "\n\nNawArrayUnordered.ToNawArrayOrdered(): De geordende array die wordt teruggegeven heeft een andere itemCount ({0}) dan de oorspronkelijke ongesorteerde array ({1}).\n", orderedArray.ItemCount(), expectedLength);
            Assert.IsTrue(array.ItemCount() == 0, "\n\nNawArrayUnordered.ToNawArrayOrdered(): De geordende array die wordt teruggegeven bevat niet alle elementen van de oorspronkelijke ongesorteerde array.\n");
        }

        int FindNaw(NawArrayUnordered array, NAW item, int maxIndex)
        {
            for (int i=0; i<maxIndex; i++)
            {
                if (array.Array[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        [TestMethod]
        [Timeout(30000)]
        [TestCategory("WS2 - Array - ToNawArrayOrdered")]
        [AantalPuntenAlsSlaagt(2,1.0)]
        [TestSummary(@"We maken een NawArrayUnordered aan en hier voegen we willekeurige items aan toe.
We roepen vervolgens ToNawArrayOrdered aan en testen of de NawArrayOrdered geordend is.")]
        public void NawArrayUnordered_ToNawOrdered_OrderedArray_ShouldBeOrdered()
        {
            // Arrange
            NAW[] testSet;

            var expectedLength = 10;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);

            // Act
            Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled = false;

            var orderedArray = array.ToNawArrayOrdered();

            // Assert
            Assert.IsFalse(Alg1_Practicum_Utils.Globals.Alg1NawArrayMethodCalled, "\n\nEr wordt een methode van Alg1NawArray gebruikt!\n\n");

            Assert.IsTrue(orderedArray.CheckIsGesorteerd(), "\n\nNawArrayUnordered.ToNawArrayOrdered(): De geordende array die wordt teruggegeven is niet correct geordend.\n");
        }

        #endregion ToNawOrdered
    }
    
}
