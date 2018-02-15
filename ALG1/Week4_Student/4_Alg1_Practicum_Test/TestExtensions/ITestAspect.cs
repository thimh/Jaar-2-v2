using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    /// <remarks />
    public interface ITestAspect
    {
        /// <remarks />
        void AddMessageSink(IMessageSink messageSink);
    }
}
