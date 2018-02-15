using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class AantalPuntenAlsSlaagtAttribute : System.Attribute
    {
        public double Score { get; set; }
        private double[] weekPunten = { 0.0, 21.0, 18.0, 28.0, 32.0, 32.0, 28.0, 40.0 };

        public AantalPuntenAlsSlaagtAttribute(int week, double score)
        {
            this.Score = 10.0 * (score / weekPunten[week]);
        }
    }
}
