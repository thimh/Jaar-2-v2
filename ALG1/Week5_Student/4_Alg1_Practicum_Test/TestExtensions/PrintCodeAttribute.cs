using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class PrintCodeAttribute : System.Attribute
    {
        public string TargetClass { get; set; }
        public string TargetMethod { get; set; }
        public bool PrintOnSuccess { get; set; }
        public bool PrintOnFail { get; set; }

        public PrintCodeAttribute(string targetClass, string targetMethod, bool printOnSuccess = true, bool printOnFail = true)
        {
            this.TargetClass = targetClass;
            this.TargetMethod = targetMethod;
            this.PrintOnFail = printOnFail;
            this.PrintOnSuccess = printOnSuccess;
        }
    }
}
