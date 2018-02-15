using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    /// <remarks />
    public class TestProperty<T> : IContextProperty, IContributeObjectSink where T : IMessageSink, ITestAspect, new()
    {
        #region Fields

        /// <remarks />
        private readonly string _name = typeof(T).AssemblyQualifiedName;

        #endregion // Fields

        #region IContextProperty Members

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public bool IsNewContextOK(Context newCtx)
        {
            return true;
        }

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public void Freeze(Context newContext)
        {
        }

        /// <remarks />
        public string Name
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
            get { return _name; }
        }

        #endregion // IContextProperty Members

        #region IContributeObjectSink Members

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            T testAspect = new T();
            testAspect.AddMessageSink(nextSink);
            
            return testAspect;
        }

        #endregion // IContributeObjectSink Members
    }
}
