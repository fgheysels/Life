using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Domain.Creatures
{
    class Repeater : Creature
    {
        public Repeater()
        {
            Cells = new Cell[2, 3];

            for( int i = 0; i < 2; i++ )
            {
                for( int j = 0; j < 3; j++ )
                {
                    Cells[i, j] = new Cell (i, j, j == 1 || i == 1 ? CellState.Alive : CellState.Dead);
                }
            }
        }
    }
}
