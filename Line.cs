using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class Line : IComparable<Line>
    {
        int[] blL;

        public Line(int[] blL_)
        {
            blL = blL_;
        }

        public int BlockCount
        {
            get
            {
                return blL.Length;
            }
        }

        public int[] BlocksLengths
        {
            get
            {
                return blL;
            }
        }

        public int CompareTo(Line that)
        {
            if (that == null) return 1;
            return this.BlockCount.CompareTo(that.BlockCount);
        }
    }
}
