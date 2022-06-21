using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class NonogramToSolveSession : NonogramSession
    {
        public int SolTime { get; set; }
        public int Score { get; set; }
        public bool IsFromLocal { get; }
        private List<int> stepHistory;

        public NonogramToSolveSession(Nonogram n_) : base(n_)
        {
            IsFromLocal = false;
            stepHistory = new List<int>();
        }

        public NonogramToSolveSession(Nonogram n_, bool isFromLocal) : this(n_)
        {
            IsFromLocal = isFromLocal;
        }

        public virtual bool CheckByLines(int[,] pictToCheck)
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
            AddStep(i * NGram.ColumnCount + j);
            return 3;
        }

        public bool CheckByPict(int[,] pictToCheck)
        {
            bool ok = true;
            for (int i = 0; i < nonogram.RowCount; i++)
            {
                for (int j = 0; j < nonogram.ColumnCount; j++)
                {
                    if (pictToCheck[i, j] != nonogram.CorrectPicture[i, j])
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok) break;
            }
            return ok;
        }

        public bool CheckCell(int i, int j)
        {
            bool ok = true;
            if (nonogram.CorrectPicture[i, j] == 0)
            {
                ok = false;
            }
            return ok;
        }

        protected virtual void AddStep(int cellNum)
        {
            stepHistory.Add(cellNum);
            if (stepHistory.Count > 40)
            {
                stepHistory.RemoveAt(0);
            }
        }

        public virtual void UndoStep(int oldVal)
        {
            int cellNum = stepHistory.Last();
            stepHistory.RemoveAt(SavedStepsCount - 1);
            ChangeCell(cellNum / NGram.ColumnCount, cellNum % NGram.ColumnCount, oldVal == 1 ? 2 : 1);
            stepHistory.RemoveAt(SavedStepsCount - 1);
        }

        public int LastStep
        {
            get
            {
                return stepHistory.Last();
            }
        }

        public int SavedStepsCount
        {
            get
            {
                return stepHistory.Count;
            }
        }
    }
}