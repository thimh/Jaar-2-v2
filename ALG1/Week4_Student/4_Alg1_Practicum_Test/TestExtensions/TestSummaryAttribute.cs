using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class TestSummaryAttribute : System.Attribute
    {
        public string Summary { get; set; }

        public TestSummaryAttribute(String summary)
        {
            this.Summary = summary;
        }
    }
}
