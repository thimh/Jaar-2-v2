using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;

namespace Alg1_Practicum_Test.TestExtensions
{
    /// <summary />
    /// <typeparam name="TAttribute">The <see cref="Attribute"/> associated with the Aspect.</typeparam>
    /// <remarks />
    public abstract class TestAspect<TAttribute> where TAttribute : Attribute
    {
        #region Methods

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        protected TAttribute GetAttribute(IMessage message)
        {
            string typeName = (string)message.Properties[MessageKeys.TypeName];
            string methodName = (string)message.Properties[MessageKeys.MethodName];
            Type callingType = Type.GetType(typeName);
            MethodInfo methodInfo = callingType.GetMethod(methodName);
            object[] attributes = methodInfo.GetCustomAttributes(typeof(TAttribute), true);
            TAttribute attribute = null;
            if (attributes.Length > 0)
            {
                attribute = attributes[0] as TAttribute;
            }
            return attribute;
        }

        /// <remarks />
        protected IMessage FakeTargetResponse(IMessage message)
        {
            IMethodCallMessage methodCallMessage = new MethodCall(message);
            return new MethodResponse(new Header[0], methodCallMessage);
        }

        #endregion // Methods

        #region Structs

        /// <remarks />
        private struct MessageKeys
        {
            /// <remarks />
            public const string TypeName = "__TypeName";

            /// <remarks />
            public const string MethodName = "__MethodName";
        }

        #endregion // Structs
    }
}