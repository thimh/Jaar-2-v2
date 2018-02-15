using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    /// <remarks />
    public class TestSummaryAspect : TestAspect<TestSummaryAttribute>, IMessageSink, ITestAspect
    {
        #region Fields

        /// <remarks />
        private IMessageSink _nextSink;

        public TestSummaryAspect()
        {
        }

        #endregion // Fields

        #region IMessageSink Members

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessage SyncProcessMessage(IMessage msg)
        {
            TestSummaryAttribute testSummaryAttribute = GetAttribute(msg);
            if (testSummaryAttribute != null)
            {
                Console.WriteLine("Testscenario:");
                Console.Write(testSummaryAttribute.Summary);
                Console.WriteLine();
                Console.WriteLine();
            }
            return _nextSink.SyncProcessMessage(msg);
        }

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            throw new InvalidOperationException();
        }

        /// <remarks />
        public IMessageSink NextSink
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
            get { return _nextSink; }
        }

        #endregion // IMessageSink Members

        #region ITestAspect

        /// <remarks />
        public void AddMessageSink(IMessageSink messageSink)
        {
            _nextSink = messageSink;
        }

        #endregion // ITestAspect
    }
}
