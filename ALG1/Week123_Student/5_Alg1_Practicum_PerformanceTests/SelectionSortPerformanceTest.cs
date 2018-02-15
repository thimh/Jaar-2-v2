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
    public class SelectionSortPerformanceTest
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
        [TestCategory("WS3 - Array - Performance SelectionSort vs BubbleSort")]
        public void SelectionSort_vs_BubbleSort_10_000Items()
        {
            // Arrange
            NAW[] testSet1; NAW[] testSet2; NAW[] testSet3;

            var expectedLength = 10000;
            var arrayb1 = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet1);
            var arrayb2 = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet2);
            var arrayb3 = ArrayExtensions.InitializeTestSubject(new NawArrayUnordered(expectedLength), expectedLength, out testSet3);
            var arrays1 = new NawArrayUnordered(expectedLength);
            var arrays2 = new NawArrayUnordered(expectedLength);
            var arrays3 = new NawArrayUnordered(expectedLength);
            for (int i = 0; i < expectedLength; i++)
            {
                arrays1.Add(arrayb1.Array[i]);
                arrays2.Add(arrayb2.Array[i]);
                arrays3.Add(arrayb3.Array[i]);
            }

            Stopwatch stopwatchB1 = new Stopwatch();
            Stopwatch stopwatchB2 = new Stopwatch();
            Stopwatch stopwatchB3 = new Stopwatch();
            Stopwatch stopwatchS1 = new Stopwatch();
            Stopwatch stopwatchS2 = new Stopwatch();
            Stopwatch stopwatchS3 = new Stopwatch();


            // Act

            stopwatchS1.Start();
            arrays1.SelectionSort();
            stopwatchS1.Stop();
            Console.Write("SelectionSort Array 1 :");
            PrintOutput(expectedLength, stopwatchS1);
            Console.WriteLine("");

            stopwatchS2.Start();
            arrays2.SelectionSort();
            stopwatchS2.Stop();
            Console.Write("SelectionSort Array 2 :");
            PrintOutput(expectedLength, stopwatchS2);
            Console.WriteLine("");

            stopwatchS3.Start();
            arrays3.SelectionSort();
            stopwatchS3.Stop();
            Console.Write("SelectionSort Array 3 :");
            PrintOutput(expectedLength, stopwatchS3);
            Console.WriteLine("");

            stopwatchB1.Start();
            arrayb1.BubbleSort();
            stopwatchB1.Stop();
            Console.Write("BubbleSort Array 1 : ");
            PrintOutput(expectedLength, stopwatchB1);
            Console.WriteLine("");

            stopwatchB2.Start();
            arrayb2.BubbleSort();
            stopwatchB2.Stop();
            Console.Write("BubbleSort Array 2 : ");
            PrintOutput(expectedLength, stopwatchB2);
            Console.WriteLine("");

            stopwatchB3.Start();
            arrayb3.BubbleSort();
            stopwatchB3.Stop();
            Console.Write("BubbleSort Array 3 : ");
            PrintOutput(expectedLength, stopwatchB3);

        }

        private static void PrintOutput(int expectedLength, Stopwatch stopwatch)
        {
            Console.WriteLine("Elapsed time with {0} items: {1:ss\\.fffffff} seconds", expectedLength, stopwatch.Elapsed);
        }
    }
}
