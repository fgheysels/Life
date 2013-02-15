using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Life.Domain;

namespace Life.Tests
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void CanGetAliveNeighbours()
        {
            Cell[,] world = new Cell[,]  
            {
                {new Cell(0, 0, CellState.Dead), new Cell(0, 1, CellState.Dead), new Cell(0, 2, CellState.Dead), new Cell(0,3, CellState.Dead)},
                {new Cell(1, 0, CellState.Dead), new Cell(1, 1, CellState.Alive), new Cell(1, 2, CellState.Alive), new Cell(1,3, CellState.Dead)},
                {new Cell(2, 0, CellState.Dead), new Cell(2, 1, CellState.Dead), new Cell(2, 2, CellState.Alive), new Cell(2,3, CellState.Dead)},
                {new Cell(3, 0, CellState.Dead), new Cell(3, 1, CellState.Alive), new Cell(3, 2, CellState.Alive), new Cell(3,3, CellState.Dead)},
                {new Cell(4, 0, CellState.Dead), new Cell(4, 1, CellState.Dead), new Cell(4, 2, CellState.Dead), new Cell(4,3, CellState.Dead)}
            };


            var u = new Universe (world);

            var neighbours = u.GetNeighbours (world[0, 2]);

            Assert.AreEqual (2, neighbours.Count ());

            Assert.IsTrue (neighbours.Contains (world[1, 1]));
            Assert.IsTrue (neighbours.Contains (world[1, 2]));

        }

        [TestMethod]
        public void CanTransiteToCorrectState()
        {
            Cell[,] world = new Cell[,]  
            {
                {new Cell(0, 0, CellState.Dead), new Cell(0, 1, CellState.Dead), new Cell(0, 2, CellState.Dead), new Cell(0,3, CellState.Dead)},
                {new Cell(1, 0, CellState.Dead), new Cell(1, 1, CellState.Alive), new Cell(1, 2, CellState.Alive), new Cell(1,3, CellState.Dead)},
                {new Cell(2, 0, CellState.Dead), new Cell(2, 1, CellState.Dead), new Cell(2, 2, CellState.Alive), new Cell(2,3, CellState.Dead)},
                {new Cell(3, 0, CellState.Dead), new Cell(3, 1, CellState.Dead), new Cell(3, 2, CellState.Alive), new Cell(3,3, CellState.Dead)},
                {new Cell(4, 0, CellState.Dead), new Cell(4, 1, CellState.Dead), new Cell(4, 2, CellState.Dead), new Cell(4,3, CellState.Dead)}
            };

            var u = new Universe (world);

            // Any dead cell with less then 3 live neighbours stays dead
            Assert.AreEqual (CellState.Dead, world[0, 2].Transite (u).State);

            // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            Assert.AreEqual (CellState.Dead, world[3, 2].Transite (u).State);

            // Any live cell with two or three live neighbours lives on to the next generation.
            Assert.AreEqual (CellState.Alive, world[2, 2].Transite (u).State);

            // Any live cell with more than three live neighbours dies, as if by overcrowding.

        }
    }
}
