using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Life.Domain;

namespace Life.Tests
{
    [TestClass]
    public class UniverseTests
    {
        [TestMethod]
        public void CanGenerateNewGeneration()
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

            var newUniverse = u.Evolve ();


        }
    }
}
