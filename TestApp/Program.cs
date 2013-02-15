using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Life.Domain;

namespace TestApp
{
    class Program
    {
        static void Main( string[] args )
        {
            var world = Universe.Generate (5, 6);

            DisplayUniverse (world, 5, 6);

            while( Console.ReadKey ().Key != ConsoleKey.Escape )
            {
                world = world.Evolve ();
                DisplayUniverse (world, 5, 6);
            }

            Console.ReadKey ();
        }

        public static void DisplayUniverse( Universe w, int rows, int cols )
        {
            for( int i = 0; i < cols; i++ )
            {
                for( int j = 0; j < rows; j++ )
                {
                    Console.Write (w.GetCellAt (i, j).State == CellState.Alive ? "X" : " " );
                }
                Console.WriteLine ();
            }

            Console.WriteLine ();
        }

    }
}
