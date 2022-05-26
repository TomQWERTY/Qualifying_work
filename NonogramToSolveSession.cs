using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class NonogramToSolveSession : NonogramSession
    {
        public NonogramToSolveSession(Nonogram n_) : base(n_) { }

        public bool CheckByLines(int[,] pictToCheck)
        {
            bool ok = true;
            int rowC = nonogram.RowCount;
            int colC = nonogram.ColumnCount;
            int i = -1;
            int rowNum = -1;
            while (rowNum < rowC - 1)
            {
                i++;
                rowNum++;
                if (!ok)
                {
                    continue;
                }
                int k = -1;
                int rowBlockCount = nonogram.Lines[0][i].BlockCount;
                for (int j = 0; j < rowBlockCount; j++)
                {
                    int currBlockLength = nonogram.Lines[0][i].BlocksLengths[j];
                    int blackCount = 0;
                    while (blackCount < currBlockLength)
                    {
                        k++;
                        if (k >= colC)
                        {
                            break;
                        }
                        if (pictToCheck[rowNum, k] == 1)
                        {
                            blackCount++;
                        }
                    }
                    if (blackCount != currBlockLength)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            i = -1;
            int colNum = -1;
            while (colNum < colC - 1)
            {
                i++;
                colNum++;
                if (!ok)
                {
                    continue;
                }
                int k = -1;
                int colBlockCount = nonogram.Lines[1][i].BlockCount;
                for (int j = 0; j < colBlockCount; j++)
                {
                    int currBlockLength = nonogram.Lines[1][i].BlocksLengths[j];
                    int blackCount = 0;
                    while (blackCount < currBlockLength)
                    {
                        k++;
                        if (k >= rowC)
                        {
                            break;
                        }
                        if (pictToCheck[k, colNum] == 1)
                        {
                            blackCount++;
                        }
                    }
                    if (blackCount != currBlockLength)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            return ok;
        }

        public virtual int ChangeCell(int i, int j, int newVal)
        {
            nonogram.Picture[i, j] = newVal;
            return 3;
        }
    }
}
