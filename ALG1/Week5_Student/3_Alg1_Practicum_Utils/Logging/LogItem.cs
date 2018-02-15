using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils.Logging
{
    public class LogItem
    {
        public NAW OldNaw1 { get; set; }
        public NAW NewNaw1 { get; set; }
        public NAW OldNaw2 { get; set; }
        public NAW NewNaw2 { get; set; }
        public ArrayAction ArrayAction { get; set; }
        public int Index1 { get; set; }
        public int Index2 { get; set; }

        public Link CurrentLink { get; set; }
        public Link NextLink { get; set; }
        public Link PreviousLink { get; set; }

        public override string ToString()
        {
            string output = "";
            if (NewNaw1 != null)
            {
                output = String.Format("{0} index {1}, item: \r\n{2}", ArrayAction, Index1, NewNaw1.ToString());

                if (ArrayAction == ArrayAction.SET && OldNaw1 != null)
                {
                    output += String.Format("\r\n\tOverwritten item: {0}", OldNaw1.ToString());
                }

                if (NewNaw2 != null)
                {
                    output += String.Format("\r\n\tindex {0}, item: \r\n{1}", Index2, NewNaw2.ToString());
                }
            }

            return output;
        }
    }

    public enum ArrayAction
    {
        GET, SET, SWAP, GETNEXTLINK, GETPREVIOUSLINK, SETNEXTLINK, SETPREVIOUSLINK, COMPARE
    }
}
