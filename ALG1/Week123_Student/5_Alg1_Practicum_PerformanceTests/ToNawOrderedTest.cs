using Alg1_Practicum;
using Alg1_Practicum_Test.Utils;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Alg1_Practicum_PerformanceTests
{
    [TestClass]
    public class ToNawOrderedTest
    {
        #region Initialize
        
        [TestInitialize]
        public void TestInitialize()
        {
            Logger.Instance.Enabled = false;
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = false;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Logger.Instance.Enabled = true;
            Alg1_Practicum_Utils.Globals.ShowAlg1NawArrayAlerts = true;
        }

        #endregion Initialize

        [TestMethod]
        [TestCategory("WS2 - Array - Performance ToNawOrdered")]

        public void ToNawOrdered_100Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            var result = array.ToNawArrayOrdered();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(result.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        [TestMethod]
        [Timeout(3000)]
        [TestCategory("WS2 - Array - Performance ToNawOrdered")]

        public void ToNawOrdered_1000Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 1000;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            var result = array.ToNawArrayOrdered();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(result.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        [TestMethod]
        [Timeout(90000)]
        [TestCategory("WS2 - Array - Performance ToNawOrdered")]

        public void ToNawOrdered_10000Items()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 10000;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet);
            Stopwatch stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            var result = array.ToNawArrayOrdered();
            stopwatch.Stop();

            // Assert
            Assert.IsTrue(result.CheckIsGesorteerd());
            PrintOutput(expectedLength, stopwatch);
        }

        private static void PrintOutput(int expectedLength, Stopwatch stopwatch)
        {
            Console.WriteLine("Elapsed time with {0} items: {1:ss\\.fffffff} seconds", expectedLength, stopwatch.Elapsed);
        }
    }
}
