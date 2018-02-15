using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestExtensions
{
    /// <remarks />
    public class PrintCodeAspect : TestAspect<PrintCodeAttribute>, IMessageSink, ITestAspect
    {
        #region Fields

        /// <remarks />
        private IMessageSink _nextSink;

        public PrintCodeAspect()
        {
        }

        #endregion // Fields

        #region IMessageSink Members

        /// <remarks />
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public IMessage SyncProcessMessage(IMessage msg)
        {
            PrintCodeAttribute printCodeAttribute = GetAttribute(msg);
            var returnMethod = _nextSink.SyncProcessMessage(msg);

            if (printCodeAttribute != null)
            {
                var returnMessage = returnMethod as ReturnMessage;
                // Success!
                if ((returnMessage == null || returnMessage.Exception == null) && printCodeAttribute.PrintOnSuccess)
                {
                    PrintMethod(printCodeAttribute.TargetClass, printCodeAttribute.TargetMethod);
                } // Fail
                else if (printCodeAttribute.PrintOnFail)
                {
                    PrintMethod(printCodeAttribute.TargetClass, printCodeAttribute.TargetMethod);
                }

            }

            return returnMethod;
        }

        private void PrintMethod(string targetClass, string targetMethod)
        {
            try
            {
                var currentFilePath = Assembly.GetExecutingAssembly().Location;

                DirectoryInfo currentDirectory = new DirectoryInfo(currentFilePath);
                DirectoryInfo targetDirectory = null;

                while (targetDirectory == null)
                {
                    currentDirectory = currentDirectory.Parent;
                    targetDirectory = currentDirectory.GetDirectories("2_Alg1_Practicum").FirstOrDefault();

                    // There is no such directory, we quit.
                    if (currentDirectory.Name == "Results") { return; }
                }

                var classFile = targetDirectory.GetFiles(targetClass + ".cs").First();

                string line;
                bool found = false;
                using (var reader = new StreamReader(classFile.FullName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        var lowerLine = line.ToLowerInvariant();

                        if (found && (lowerLine.Contains("public ") || lowerLine.Contains("private ") || lowerLine.Contains("protected")))
                        {
                            break;
                        }

                        if (lowerLine.Contains("public ") &&
                            (lowerLine.Contains(targetMethod.ToLowerInvariant() + "(") ||
                             lowerLine.Contains(targetMethod.ToLowerInvariant() + " (")))
                        {
                            found = true;
                        }

                        if (found)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not get method body.");
                Console.WriteLine(ex);
            }
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
