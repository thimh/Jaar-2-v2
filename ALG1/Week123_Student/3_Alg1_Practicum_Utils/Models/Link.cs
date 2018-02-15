using Alg1_Practicum_Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils.Models
{
    public class Link
    {
        private Link _next;

        public NAW Naw { get; set; }
        public Link Next
        {
            get
            {
                Logger.Instance.Log(new LogItem()
                {
                    CurrentLink = this,
                    NextLink = _next,
                    ArrayAction = ArrayAction.GETNEXTLINK
                });
                return _next;
            }
            set
            {
                Logger.Instance.Log(new LogItem()
                {
                    CurrentLink = this,
                    NextLink = _next,
                    ArrayAction = ArrayAction.SETNEXTLINK
                });
                _next = value;
            }
        }
    }
}
