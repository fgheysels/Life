using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Domain
{
   public abstract class Creature
    {       
        public Cell[,] Cells
        {
            get;
            protected set;
        }
    }
}
