using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Domain.Creatures
{
    public class Glider : Creature
    {
        public Glider()
        {
            Cells = new Cell[3, 3];

            for( int i = 0; i < 3; i++ )
            {
                for( int j = 0; j < 3; j++ )
                {
                    Cells[i, j] = new Cell (i, j, ( i == 0 && j == 1 ) || ( i == 1 && j == 2 ) || ( i == 2 && j == 0 ) || ( i == 2 && j == 1 ) || ( i == 2 && j == 2 ) ? CellState.Alive : CellState.Dead);
                }
            }
        }
    }
}
