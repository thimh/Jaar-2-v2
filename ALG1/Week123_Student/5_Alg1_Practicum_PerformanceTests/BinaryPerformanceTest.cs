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
    public class BinaryPerformanceTest
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
        [TestCategory("WS2 - Array - Performance Binary Search")]

        public void BinarySearchNawArray_BinarySearchPerformance()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var runs = 1000000;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            var random = new Random();

            // generate NAW that is not in the testset
            NAW nonExistingNaw;
            do
            {
                nonExistingNaw = RandomNawGenerator.New();

            } while (testSet.Contains(nonExistingNaw));

            Assert.IsTrue(array.FindBinary(nonExistingNaw) == -1);

            Stopwatch stopwatch_BR100 = new Stopwatch();
            Stopwatch stopwatch_BW100 = new Stopwatch();

            // Act
            stopwatch_BR100.Start();

            for (int i = 0; i < runs; i++)
            {
                var expectedIndex = random.Next(0, expectedLength);
                var actualIndex = array.FindBinary(testSet[expectedIndex]);
            }

            stopwatch_BR100.Stop();

            stopwatch_BW100.Start();

            for (int i = 0; i < runs; i++)
            {
                var actualIndex = array.FindBinary(nonExistingNaw);
            }

            stopwatch_BW100.Stop();

 
            // Re-Arrange

            var expectedLength2 = 1000;
            var array2 = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength2), expectedLength2, out testSet, orderAscending: true);

            // generate NAW that is not in the testset
            do
            {
                nonExistingNaw = RandomNawGenerator.New();

            } while (testSet.Contains(nonExistingNaw));

            Assert.IsTrue(array.FindBinary(nonExistingNaw) == -1);

             Stopwatch stopwatch_BR1000 = new Stopwatch();
             Stopwatch stopwatch_BW1000 = new Stopwatch();

            // Act
            stopwatch_BR1000.Start();

            for (int i = 0; i < runs; i++)
            {
                var expectedIndex = random.Next(0, expectedLength2);
                var actualIndex = array2.FindBinary(testSet[expectedIndex]);
            }

            stopwatch_BR1000.Stop();

            stopwatch_BW1000.Start();

            for (int i = 0; i < runs; i++)
            {
                var actualIndex = array2.FindBinary(nonExistingNaw);
            }

            stopwatch_BW1000.Stop();

            // Re-Arrange

            var expectedLength3 = 10000;
            var array3 = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength3), expectedLength3, out testSet, orderAscending: true);

            // generate NAW that is not in the testset
            do
            {
                nonExistingNaw = RandomNawGenerator.New();

            } while (testSet.Contains(nonExistingNaw));

            Assert.IsTrue(array3.FindBinary(nonExistingNaw) == -1);

            Stopwatch stopwatch_BR10000 = new Stopwatch();
            Stopwatch stopwatch_BW10000 = new Stopwatch();

            // Act
            stopwatch_BR10000.Start();

            for (int i = 0; i < runs; i++)
            {
                var expectedIndex = random.Next(0, expectedLength3);
                var actualIndex = array3.FindBinary(testSet[expectedIndex]);
            }

            stopwatch_BR10000.Stop();

            stopwatch_BW10000.Start();

            for (int i = 0; i < runs; i++)
            {
                var actualIndex = array3.FindBinary(nonExistingNaw);
            }

            stopwatch_BW10000.Stop();

            // Assert
            //           Assert.AreEqual(expectedIndex, actualIndex);
            Console.WriteLine("\nPerformed {0} random Binary searches in Array with length {1}", runs, expectedLength);
            PrintOutput(expectedLength, stopwatch_BR100);
            Console.WriteLine("\nPerformed {0} random Binary searches in Array with length {1}", runs, expectedLength2);
            PrintOutput(expectedLength2, stopwatch_BR1000);
            Console.WriteLine("\nPerformed {0} random Binary searches in Array with length {1}", runs, expectedLength3);
            PrintOutput(expectedLength3, stopwatch_BR10000);

            Console.WriteLine("\nPerformed {0} Binary searches on non existing NAW in Array with length {1}", runs, expectedLength);
            PrintOutput(expectedLength, stopwatch_BW100);
            Console.WriteLine("\nPerformed {0} Binary searches on non existing NAW in Array with length {1}", runs, expectedLength2);
            PrintOutput(expectedLength2, stopwatch_BW1000);
            Console.WriteLine("\nPerformed {0} Binary searches on non existing NAW in Array with length {1}", runs, expectedLength3);
            PrintOutput(expectedLength3, stopwatch_BW10000);

        }

        [TestMethod]
        [TestCategory("WS2 - Array - Performance Linear Search")]

        public void BinarySearchNawArray_LinearSearchPerformance()
        {
            // Arrange
            NAW[] testSet;
            var expectedLength = 100;
            var runs = 10000;
            var array = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength), expectedLength, out testSet, orderAscending: true);

            var random = new Random();

            // generate NAW that is not in the testset
            var nonExistingNaw = new NAW();
            do
            {
                nonExistingNaw = RandomNawGenerator.New();

            } while (testSet.Contains(nonExistingNaw));

            Assert.IsTrue(array.FindLinear(nonExistingNaw, expectedLength) == -1);

            Stopwatch stopwatch_LR100 = new Stopwatch();
            Stopwatch stopwatch_LW100 = new Stopwatch();

            // Act
            stopwatch_LR100.Start();

            for (int i = 0; i < runs; i++)
            {
                var expectedIndex = random.Next(0, expectedLength);
                var actualIndex = array.FindLinear(testSet[expectedIndex],expectedLength);
            }

            stopwatch_LR100.Stop();

            stopwatch_LW100.Start();

            for (int i = 0; i < runs; i++)
            {
                var actualIndex = array.FindLinear(nonExistingNaw,expectedLength);
            }

            stopwatch_LW100.Stop();


            // Re-Arrange

            var expectedLength2 = 1000;
            var array2 = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength2), expectedLength2, out testSet, orderAscending: true);

            // generate NAW that is not in the testset
            do
            {
                nonExistingNaw = RandomNawGenerator.New();

            } while (testSet.Contains(nonExistingNaw));

            Assert.IsTrue(array.Find(nonExistingNaw) == -1);

            Stopwatch stopwatch_LR1000 = new Stopwatch();
            Stopwatch stopwatch_LW1000 = new Stopwatch();

            // Act
            stopwatch_LR1000.Start();

            for (int i = 0; i < runs; i++)
            {
                var expectedIndex = random.Next(0, expectedLength2);
                var actualIndex = array2.FindLinear(testSet[expectedIndex],expectedLength2);
            }

            stopwatch_LR1000.Stop();

            stopwatch_LW1000.Start();

            for (int i = 0; i < runs; i++)
            {
                var actualIndex = array2.FindLinear(nonExistingNaw,expectedLength2);
            }

            stopwatch_LW1000.Stop();

            // Re-Arrange

            var expectedLength3 = 10000;
            var array3 = ArrayExtensions.InitializeTestSubject(new NawArrayOrdered(expectedLength3), expectedLength3, out testSet, orderAscending: true);

            // generate NAW that is not in the testset
            do
            {
                nonExistingNaw = RandomNawGenerator.New();

            } while (testSet.Contains(nonExistingNaw));

            Assert.IsTrue(array3.Find(nonExistingNaw) == -1);

            Stopwatch stopwatch_LR10000 = new Stopwatch();
            Stopwatch stopwatch_LW10000 = new Stopwatch();

            // Act
            stopwatch_LR10000.Start();

            for (int i = 0; i < runs; i++)
            {
                var expectedIndex = random.Next(0, expectedLength3);
                var actualIndex = array3.FindLinear(testSet[expectedIndex],expectedLength3);
            }

            stopwatch_LR10000.Stop();

            stopwatch_LW10000.Start();

            for (int i = 0; i < runs; i++)
            {
                var actualIndex = array3.FindLinear(nonExistingNaw,expectedLength3);
            }

            stopwatch_LW10000.Stop();

            // Assert
            //           Assert.AreEqual(expectedIndex, actualIndex);
            Console.WriteLine("\nPerformed {0} random Linear searches in Array with length {1}", runs, expectedLength);
            PrintOutput(expectedLength, stopwatch_LR100);
            Console.WriteLine("\nPerformed {0} random Linear searches in Array with length {1}", runs, expectedLength2);
            PrintOutput(expectedLength2, stopwatch_LR1000);
            Console.WriteLine("\nPerformed {0} random Linear searches in Array with length {1}", runs, expectedLength3);
            PrintOutput(expectedLength3, stopwatch_LR10000);

            Console.WriteLine("\nPerformed {0} Linear searches on non existing NAW in Array with length {1}", runs, expectedLength);
            PrintOutput(expectedLength, stopwatch_LW100);
            Console.WriteLine("\nPerformed {0} Linear searches on non existing NAW in Array with length {1}", runs, expectedLength2);
            PrintOutput(expectedLength2, stopwatch_LW1000);
            Console.WriteLine("\nPerformed {0} Linear searches on non existing NAW in Array with length {1}", runs, expectedLength3);
            PrintOutput(expectedLength3, stopwatch_LW10000);

        }


  
 
        private static void PrintOutput(int expectedLength, Stopwatch stopwatch)
        {
            Console.WriteLine("Elapsed time with {0} items: {1:ss\\.fffffff} seconds", expectedLength, stopwatch.Elapsed);
        }    
    }

    public static class ExtensionMethods
    {
        public static int FindLinear(this NawArrayOrdered array, NAW item, int maxIndex)
        {
            // doorzoek array
            for (int i = 0; i < maxIndex; i++)
            {
                if (array.Array[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }

}
