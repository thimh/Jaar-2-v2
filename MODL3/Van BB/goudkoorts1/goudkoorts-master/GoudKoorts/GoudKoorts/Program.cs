using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts
{
    class Program
    {
        public Controller.Controller Controller
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        static void Main(string[] args)
        {
            new Controller.Controller().Go();
        }
    }
}
