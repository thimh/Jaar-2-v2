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
    public class AantalPuntenAlsSlaagtAspect : TestAspect<AantalPuntenAlsSlaagtAttribute>, IMessageSink, ITestAspect
    {
        #region Fields

        /// <remarks />
        private IMessageSink _nextSink;

        public AantalPuntenAlsSlaagtAspect()
        {
        }

        #endregion // Fields

        #region IMessageSink Members

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessage SyncProcessMessage(IMessage msg)
        {
            AantalPuntenAlsSlaagtAttribute aantalPuntenAlsSlaagtAttribute = GetAttribute(msg);
            IMessage returnMethod;
            if (aantalPuntenAlsSlaagtAttribute != null)
            {
                returnMethod = _nextSink.SyncProcessMessage(msg);
                var returnMessage = returnMethod as ReturnMessage;
                if (returnMessage == null || returnMessage.Exception == null)
                {
                    Console.WriteLine("{{ PointsScored: {0}, MaxScore: {0} }}", aantalPuntenAlsSlaagtAttribute.Score);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("{{ PointsScored: 0, MaxScore: {0} }}", aantalPuntenAlsSlaagtAttribute.Score);
                    Console.WriteLine();
                }
            }
            else
            {
                returnMethod = _nextSink.SyncProcessMessage(msg);
            }
            return returnMethod;
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
