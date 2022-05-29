using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    abstract public class NonogramSession
    {
        protected Nonogram nonogram;

        public NonogramSession(Nonogram n_)
        {
            nonogram = n_;
        }

        public Nonogram NGram
        {
            get
            {
                return nonogram;
            }
        }

        protected void SolveEntire()
        {
            nonogram.Type = NonogramType.Unknown;
            AutoSolve.Solve(nonogram);
        }
    }
}
