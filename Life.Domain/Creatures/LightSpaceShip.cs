using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Domain.Creatures
{
    class LightSpaceShip : Creature
    {
        public LightSpaceShip()
        {
            Cells = new Cell[,] {
                                    { new Cell(0,0, CellState.Dead), new Cell(0, 1, CellState.Alive), new Cell(0,2, CellState.Dead), new Cell(0, 3, CellState.Dead), new Cell(0, 4, CellState.Alive)},
                                    { new Cell(1, 0, CellState.Alive), new Cell(1, 1, CellState.Dead), new Cell(1, 2, CellState.Dead), new Cell(1, 3, CellState.Dead), new Cell(1, 4, CellState.Dead)},
                                    { new Cell(2, 0, CellState.Alive), new Cell(2, 1, CellState.Dead), new Cell(2, 2, CellState.Dead), new Cell(2, 3, CellState.Dead), new Cell(2,4, CellState.Alive)},
                                    { new Cell(3, 0, CellState.Alive), new Cell(3, 1, CellState.Alive), new Cell(3, 2, CellState.Alive), new Cell(3, 3, CellState.Alive), new Cell(3, 4, CellState.Dead)}
                                };

        }
    }
}
