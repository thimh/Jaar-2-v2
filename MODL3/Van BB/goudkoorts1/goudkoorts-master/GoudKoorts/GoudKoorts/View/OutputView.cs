using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace View
{   
	public class OutputView
	{
        public void showStart()
        {
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|--------- Welkom bij Goudkoorts ---------|");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|-- Tim van der Linde & Joost Vermeulen --|");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine();
            Console.WriteLine("|--------------- Toelichting--------------|");
            Console.WriteLine("|- Door op de toetsen 1 t/m 5 te drukken  |");
            Console.WriteLine("|- Kun je de rails verwisselen van standen|");
            Console.WriteLine("|-----------------------------------------|");

            Console.WriteLine();
            Console.WriteLine("Druk op een toets om te beginnen.");
            Console.ReadKey();
        }

        public void showGameOver(Model.GameBoard game)
        {
            Console.Clear();
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|--------------- GAMEOVER ----------------|");
            Console.WriteLine("|-----------------------------------------|");

            
            Console.WriteLine("|- Je score was: " + game.TotalScore.ToString() + "      -|");
            Console.WriteLine();
            Console.WriteLine("Druk op een toets om te stoppen.");
            Console.ReadKey();
        }

        internal void UpdateBoard(Model.GameBoard game)
        {
            Console.Clear();            
            int nRows = game.Height;
            int nCols = game.Width;

            Model.Field current = game.Origin;
            Model.Field neighbourBelow = current.FieldBelow;
              
            for (int r = 0; r < nRows; r++)
            {
                for (int c = 0; c < nCols; c++)
                {
                    Console.Write(current.ToChar());
                    current = current.FieldToRight;
                }
                current = neighbourBelow;
                if (neighbourBelow != null)
                {
                    neighbourBelow = current.FieldBelow;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------ > gebruik de toetsen 1 t/m 5 ------");
            Console.WriteLine("- Jouw score:    "+game.TotalScore.ToString()+"   ---------------------");          

        }
    }
}

