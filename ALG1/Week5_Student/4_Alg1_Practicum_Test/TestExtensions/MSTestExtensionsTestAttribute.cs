using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MSTestExtensionsTestAttribute : ContextAttribute
    {
        #region Constructors

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public MSTestExtensionsTestAttribute()
            : base("MSTestExtensionsTest")
        {
        }

        #endregion // Constructors

        #region Methods

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override void GetPropertiesForNewContext(IConstructionCallMessage msg)
        {
            msg.ContextProperties.Add(new TestProperty<TestSummaryAspect>());
            msg.ContextProperties.Add(new TestProperty<AantalPuntenAlsSlaagtAspect>());
            msg.ContextProperties.Add(new TestProperty<PrintCodeAspect>());
        }

        #endregion // Methods
    }
}
