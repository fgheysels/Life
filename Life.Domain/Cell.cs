using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Domain
{
    public class Cell
    {
        private readonly int _xPos;
        private readonly int _yPos;
        private readonly CellState _state;

        public Cell( int x, int y, CellState state )
        {
            _xPos = x;
            _yPos = y;
            _state = state;
        }

        public int xPos
        {
            get { return _xPos; }
        }

        public int yPos
        {
            get { return _yPos; }
        }

        public CellState State
        {
            get { return _state; }
        }

        public Cell Transite( Universe universe )
        {
            var neighbourCount = universe.GetNeighbours (this).Count ();

            if( State == CellState.Alive )
            {
                if( neighbourCount < 2 || neighbourCount > 3 )
                {
                    return new Cell (_xPos, _yPos, CellState.Dead);
                }
            }
            else
            {
                if( neighbourCount == 3 )
                {
                    return new Cell (_xPos, _yPos, CellState.Alive);
                }
            }

            return new Cell (_xPos, _yPos, State);
        }
    }
}
