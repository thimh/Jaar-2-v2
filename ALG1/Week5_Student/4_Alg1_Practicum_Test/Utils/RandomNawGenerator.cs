using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.Utils
{
    public static class RandomNawGenerator
    {
        public static NAW New(int? maxStringLength = null)
        {
            var naam = RandomStringGenerator.New(maxStringLength);
            var adres = RandomStringGenerator.New(maxStringLength);
            var woonplaats = RandomStringGenerator.New(maxStringLength);

            return new NAW(naam, adres, woonplaats);
        }

        public static NAW[] NewArray(int length, int? maxStringLength = null)
        {
            var result = new NAW[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = New(maxStringLength);
            }

            return result;
        }
    }
}
