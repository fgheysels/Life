using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Life.Domain.Creatures;

namespace Life.Domain
{
    public class Universe
    {
        private Cell[,] _matrix;

        public Universe( Cell[,] matrix )
        {
            _matrix = matrix;

            DimensionX = _matrix.GetUpperBound (1);
            DimensionY = _matrix.GetUpperBound (0);
        }

        public int DimensionX
        {
            get;
            private set;
        }

        public int DimensionY
        {
            get;
            private set;
        }

        public static Universe Generate( int rows, int columns )
        {
            var r = new Random (DateTime.Now.Second);

            var world = new Cell[columns, rows];

            for( int i = 0; i < columns; i++ )
            {
                for( int j = 0; j < rows; j++ )
                {
                    world[i, j] = new Cell (i, j, ( ( r.Next (10) % 2 ) == 0 ) ? CellState.Alive : CellState.Dead);
                }
            }

            return new Universe (world);
        }

        public static Universe GenerateWithOneGlider( int rows, int columns )
        {
            var world = new Cell[rows, columns];

            for( int i = 0; i < rows; i++ )
            {
                for( int j = 0; j < columns; j++ )
                {
                    world[i, j] = new Cell (i, j, CellState.Dead);
                }
            }

            var u = new Universe (world);

            u.InsertCreatureAt (new Glider (), 2, 5);            
            u.InsertCreatureAt (new LightSpaceShip (), 15, 9);

            return new Universe (world);
        }

        public void InsertCreatureAt( Creature c, int row, int column )
        {
            for( int y = 0; y <= c.Cells.GetUpperBound (0); y++ )
            {
                for( int x = 0; x <= c.Cells.GetUpperBound (1); x++ )
                {
                    _matrix[row + y, column + x] = new Cell (row + y, column + x, c.Cells[y, x].State);
                }
            }
        }

        public Universe Evolve()
        {
            var newWorld = new Cell[_matrix.GetUpperBound (0) + 1, _matrix.GetUpperBound (1) + 1];

            bool stable = true;

            Parallel.For<bool> (fromInclusive: 0,
                                toExclusive: _matrix.GetUpperBound (1) + 1,
                                localInit: () => true,
                                body: ( row, loop, localState ) =>
                                {
                                    for( int i = 0; i <= _matrix.GetUpperBound (0); i++ )
                                    {
                                        newWorld[i, row] = _matrix[i, row].Transite (this);
                                        if( newWorld[i, row].State != _matrix[i, row].State )
                                        {
                                            localState = false;
                                        }
                                    }
                                    return localState;
                                },
                                localFinally: ( localState ) =>
                                {
                                    if( localState == false )
                                    {
                                        stable = false;
                                    }
                                }
            );

            var newUniverse = new Universe (newWorld);

            newUniverse.Stable = stable;

            return newUniverse;
        }

        public bool Stable
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the alive neighbour cells of the specified cell.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public IEnumerable<Cell> GetNeighbours( Cell cell )
        {
            int leftNeighbourX = ( cell.xPos > 0 ) ? cell.xPos - 1 : _matrix.GetUpperBound (0);
            int rightNeighbourX = ( cell.xPos < _matrix.GetUpperBound (0) ) ? cell.xPos + 1 : 0;
            int upperNeighbourY = ( cell.yPos > 0 ) ? cell.yPos - 1 : _matrix.GetUpperBound (1);
            int lowerNeighbourY = ( cell.yPos < _matrix.GetUpperBound (1) ) ? cell.yPos + 1 : 0;

            var left1 = _matrix[leftNeighbourX, cell.yPos];
            var left2 = _matrix[leftNeighbourX, upperNeighbourY];
            var left3 = _matrix[leftNeighbourX, lowerNeighbourY];

            if( left1.State == CellState.Alive )
            {
                yield return left1;
            }

            if( left2.State == CellState.Alive )
            {
                yield return left2;
            }

            if( left3.State == CellState.Alive )
            {
                yield return left3;
            }

            var right1 = _matrix[rightNeighbourX, cell.yPos];
            var right2 = _matrix[rightNeighbourX, upperNeighbourY];
            var right3 = _matrix[rightNeighbourX, lowerNeighbourY];

            if( right1.State == CellState.Alive )
            {
                yield return right1;
            }

            if( right2.State == CellState.Alive )
            {
                yield return right2;
            }

            if( right3.State == CellState.Alive )
            {
                yield return right3;
            }

            var upper = _matrix[cell.xPos, upperNeighbourY];

            if( upper.State == CellState.Alive )
            {
                yield return upper;
            }

            var lower = _matrix[cell.xPos, lowerNeighbourY];

            if( lower.State == CellState.Alive )
            {
                yield return lower;
            }
        }

        public Cell GetCellAt( int row, int column )
        {
            return _matrix[row, column];
        }
    }
}
