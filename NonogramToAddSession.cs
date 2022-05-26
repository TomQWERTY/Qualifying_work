using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    class NonogramToAddSession : NonogramSession
    {
        public NonogramToAddSession(Nonogram n_) : base(n_) { }

        public NonogramType NonType
        {
            get
            {
                if (nonogram.Type == NonogramType.Unknown)
                {
                    SolveEntire();
                }
                return nonogram.Type;
            }
        }
    }
}
