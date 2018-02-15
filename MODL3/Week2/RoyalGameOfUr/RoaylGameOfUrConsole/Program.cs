using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalGameOfUrConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            ShowField(game.Board.StartWhite);
        }

        private static void ShowField(Field f)
        {
            var theString = "[";

            if(f.Pawn != null)
            {
                theString += "x";
            }
            else
            {
                theString += " ";
            }

            if(f.NextField != null)
            {
                Console.WriteLine("I'm a " + f.Type + " field yay :D");
                ShowField(f.NextFIeld);
            }

            
            Console.ReadLine();
        }
    }
}
