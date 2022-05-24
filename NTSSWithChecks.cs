using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    class NTSSWithChecks : NonogramToSolveSession
    {
        public NTSSWithChecks(Nonogram n_) : base(n_)
        {
            SolveEntire();
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

        public override int ChangeCell(int i, int j, int newVal)
        {
            if (newVal != 1)
            {
                return 4;
            }
            if (!CheckCell(i, j))
            {
                return 2;
            }
            int[] row = new int[nonogram.ColumnCount];
            int[] col = new int[nonogram.RowCount];
            for (int i1 = 0; i1 < nonogram.RowCount; i1++)
            {
                col[i1] = nonogram.Picture[i1, j];
            }
            for (int j1 = 0; j1 < nonogram.ColumnCount; j1++)
            {
                row[j1] = nonogram.Picture[i, j1];
            }
            AutoSolve.AnalyzeLine(row, nonogram.Lines, 0, i);
            AutoSolve.AnalyzeLine(col, nonogram.Lines, 1, j);
            base.ChangeCell(i, j, newVal);
            return (row[j] == 1 || col[i] == 1) ? 0 : 1;
        }

        private void SolveEntire()
        {
            AutoSolve.Solve(nonogram);
        }
    }
}
