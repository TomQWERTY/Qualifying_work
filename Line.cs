using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class Line
    {
        int blN;
        int[] blL;

        public Line(int blN_, int[] blL_)
        {
            blN = blN_;
            blL = blL_;
        }

        public int BlockCount
        {
            get
            {
                return blN;
            }
        }

        public int[] BlocksLengths
        {
            get
            {
                return blL;
            }
        }
    }
}
