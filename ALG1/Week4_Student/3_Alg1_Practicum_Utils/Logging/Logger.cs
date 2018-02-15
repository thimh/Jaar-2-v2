using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils.Logging
{
    public sealed class Logger
    {
        private static volatile Logger instance;
        private static object syncRoot = new Object();

        private List<LogItem> _logItems;
        public IEnumerable<LogItem> LogItems { get { return _logItems; } }

        private Logger()
        {
            _logItems = new List<LogItem>();
            Enabled = true;
        }

        public bool Enabled { get; set; }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }

                return instance;
            }
        }

        public void Log(LogItem message)
        {
            if (Enabled)
            {
                var last = _logItems.LastOrDefault();
                if (last == null || last.Index1 != message.Index1 || last.CurrentLink != message.CurrentLink || last.ArrayAction != message.ArrayAction)
                {
                    _logItems.Add(message);
                }
            }
        }

        public void Print()
        {
            foreach (var item in _logItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        public void Print(string header)
        {
            Console.WriteLine(header);
            Print();
        }

        public void ClearLog()
        {
            _logItems.Clear();
        }

        public IEnumerable<LogItem> RealSwaps
        {
            get { return LogItems.Where(li => li.ArrayAction == ArrayAction.SWAP && li.Index1 != li.Index2); }
        }
    }
}
