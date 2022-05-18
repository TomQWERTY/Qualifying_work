using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class Nonogram
    {
        protected int[] blocksDescriptions;
        protected int[,] pict;
        protected int rowC, colC;
        protected Line[][] lines;
        protected NonogramType nType;

        public Nonogram(int[] blocksDescs)
        {
            blocksDescriptions = blocksDescs;
            rowC = blocksDescriptions[0];
            colC = blocksDescriptions[1];
            pict = new int[rowC, colC];
            for (int i = 0; i < rowC; i++)
                for (int j = 0; j < colC; j++)
                    pict[i, j] = 2;
            lines = new Line[2][];
            lines[0] = new Line[rowC];
            lines[1] = new Line[colC];
            int blocksCount = 0;
            for (int i = 2, currLine = 0; currLine < rowC + colC; i += blocksCount + 1, currLine++)
            {
                blocksCount = blocksDescs[i];
                int[] blL = new int[blocksCount];
                Array.Copy(blocksDescs, i + 1, blL, 0, blocksCount);
                if (currLine < rowC)
                {
                    lines[0][currLine] = new Line(blL);
                }
                else
                {
                    lines[1][currLine - rowC] = new Line(blL);
                }
            }
            nType = NonogramType.OnlyILL;
        }

        public int[,] Picture
        {
            get
            {
                return pict;
            }
        }

        public int RowCount
        {
            get
            {
                return rowC;
            }
        }

        public int ColumnCount
        {
            get
            {
                return colC;
            }
        }

        public Line[][] Lines
        {
            get
            {
                return lines;
            }
        }

        public NonogramType NonType
        {
            get
            {
                return nType;
            }
            set
            {
                nType = value;
            }
        }
    }

    public enum NonogramType
    {
        OnlyILL, NeedBacktracking, FewSolutions
    }
}
