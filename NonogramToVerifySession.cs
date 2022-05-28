using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    class NonogramToVerifySession : NonogramSession
    {
        public NonogramToVerifySession(Nonogram n_) : base(n_)
        {
            SolveEntire();
        }
    }
}
