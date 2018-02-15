using Sokoban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Presentation
{
    public class OutputView
    {
        public void ShowBoardState(Sokoban.Domain.Maze maze)
        {
            Console.Clear();
            Console.WriteLine("┌──────────┐   ");
            Console.WriteLine("| Sokoban  |   ");
            Console.WriteLine("└──────────┘   ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");
            Show(maze);
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────");

        }



        public void ShowGameStart()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij Sokoban                                 |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("| betekenis van de symbolen   |   doel van het spel  |");
            Console.WriteLine("|                             |                      |");
            Console.WriteLine("| spatie : outerspace         |   duw met de truck   |");
            Console.WriteLine("|      █ : muur               |   de krat(ten)       |");
            Console.WriteLine("|      · : vloer              |   naar de bestemming |");
            Console.WriteLine("|      O : krat               |                      |");
            Console.WriteLine("|      0 : krat op bestemming |                      |");
            Console.WriteLine("|      x : bestemming         |                      |");
            Console.WriteLine("|      @ : truck              |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.WriteLine("");
        }

        public void ShowMazeSolved()
        {
            ConsoleKeyInfo input;
            Console.WriteLine();
            Console.WriteLine("=== HOERA OPGELOST ===");
            Console.WriteLine("> press key to continue");
            input = Console.ReadKey();
        }


        private void Show(Sokoban.Domain.Maze mazeModel)
        {
            int nRows = mazeModel.Height;
            int nCols = mazeModel.Width;

            BaseField current = mazeModel.Origin;
            BaseField neighbourBelow = current.FieldBelow;

            for(int r = 0; r < nRows; r++)
            {
                for(int c = 0; c < nCols; c++)
                {
                    Console.Write(current.ToChar());
                    current = current.FieldToRight;
                }
                current = neighbourBelow;
                if(neighbourBelow != null)
                {
                    neighbourBelow = current.FieldBelow;
                }
                Console.WriteLine();
            }

        }

        public void ShowError(string message)
        {

            ConsoleKeyInfo input;
            Console.WriteLine();
            Console.WriteLine("> " + message);
            Console.WriteLine("> press key to continue");
            input = Console.ReadKey();

        }

    }
}
