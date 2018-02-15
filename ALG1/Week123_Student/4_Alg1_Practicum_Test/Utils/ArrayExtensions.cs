using Alg1_Practicum;
using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Logging;
using Alg1_Practicum_Utils.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alg1_Practicum_Utils.Exceptions;

namespace Alg1_Practicum_Test.Utils
{
    public static class ArrayExtensions
    {
        public static bool CheckIsGesorteerd(this INawArray array, bool descending = false)
        {
            for (int i = 1; i < array.Count; i++)
            {
                if (array.Array[i] != null && array.Array[i - 1] != null)
                {
                    if (descending && array.Array[i].CompareTo(array.Array[i - 1]) > 0)
                    {
                        return false;
                    }
                    else if (!descending && array.Array[i].CompareTo(array.Array[i - 1]) < 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static T InitializeTestSubject<T>(T testSubject, int initialFilledSize, out NAW[] testSet, int? maxStringLenght = null, bool orderAscending = false, bool orderDescending = false)
            where T : INawArray
        {
            testSet = RandomNawGenerator.NewArray(initialFilledSize);

            if (orderAscending)
            {
                testSet = OrderAscending(testSet);
            }
            else if (orderDescending)
            {
                testSet = OrderDescending(testSet);
            }

            testSubject.Array.SetValues((NAW[])testSet.Clone());
            testSubject.Count = initialFilledSize;

            // We have to clear the log because adding to the array will cause the logger to log as well.
            Logger.Instance.ClearLog();
            return testSubject;
        }

        public static NAW[] OrderDescending(this NAW[] testSet)
        {
            testSet = testSet.OrderByDescending(naw => naw.Woonplaats)
                    .ThenByDescending(naw => naw.Naam)
                    .ThenByDescending(naw => naw.Adres)
                    .ToArray();
            return testSet;
        }

        public static NAW[] OrderAscending(this NAW[] testSet)
        {
            return testSet.OrderBy(naw => naw.Woonplaats)
                    .ThenBy(naw => naw.Naam)
                    .ThenBy(naw => naw.Adres)
                    .ToArray();
        }

        public static void AssertAreEqual(this LogItem logItem, int expectedIndex1, string expectedWoonplaats, string message)
        {
            Assert.AreEqual(expectedIndex1, logItem.Index1);
            Assert.AreEqual(expectedWoonplaats, logItem.NewNaw1.Woonplaats, message);
        }
    }
}