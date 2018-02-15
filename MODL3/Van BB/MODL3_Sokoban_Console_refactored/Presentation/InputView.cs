using Sokoban.Domain;
using System;

namespace Sokoban.Presentation
{
    public class InputView
    {
        public int AskForMove()
        {
            int returnValue = 0;
            bool proceed = true;
            ConsoleKeyInfo input;
            ConsoleKey k = ConsoleKey.Escape;
            while(proceed)
            {
                Console.WriteLine("> gebruik pijljestoetsen (s = stop, r = reset)");
                input = Console.ReadKey();
                k = input.Key;
                if(k != ConsoleKey.RightArrow && k != ConsoleKey.LeftArrow && k != ConsoleKey.UpArrow && k != ConsoleKey.DownArrow && k != ConsoleKey.S && k != ConsoleKey.R)
                {
                    Console.WriteLine("> ?");
                }
                else
                {
                    proceed = false;
                }
            }


            switch(k)
            {
                case ConsoleKey.DownArrow:
                    returnValue =(int)Direction.Down;
                    break;

                case ConsoleKey.LeftArrow:
                    returnValue = (int)Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    returnValue = (int)Direction.Right;
                    break;

                case ConsoleKey.UpArrow:
                    returnValue = (int)Direction.Up;
                    break;

                case ConsoleKey.R:
                    returnValue = Controller.KeyReset;
                    break;

                case ConsoleKey.S:
                    returnValue = Controller.KeyCancel;
                    break;


                default:
                    throw new NotImplementedException();
                  
            }

            return returnValue;
        }


        public int AskForMazeNumber()
        {
            int id = 0;
            string s = "?";
            ConsoleKeyInfo input;
            char x = '?';
            while((id < 1 || id > 4) && (x != 's'))
            {
                Console.WriteLine("> Kies een doolhof (1 - 4), s = stop");
                input = Console.ReadKey();
                x = input.KeyChar;
                Console.WriteLine();
                if(x >= '1' && x <= '4')
                {
                    s = Char.ToString(input.KeyChar);
                    id = Convert.ToInt32(s);

                }
                else if(x != 's')
                {
                    Console.WriteLine("> ?");
                }
            }
            if(x == 's')
            {
                id = Controller.KeyCancel;
            }
            return id;
        }


    }
}
