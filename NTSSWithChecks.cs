using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    class NTSSWithChecks : NonogramToSolveSession
    {
        public NTSSWithChecks(Nonogram n_, bool isFromLocal) : base(n_, isFromLocal)
        {
            SolveEntire();
        }

        public NTSSWithChecks(Nonogram n_) : base(n_)
        {
            SolveEntire();
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
            AutoSolve.AnalyzeLine(row, nonogram.Lines, 0, i, false);
            if (row[j] == 1)
            {
                col[i] = 1;
                AutoSolve.AnalyzeLine(col, nonogram.Lines, 1, j, false);
            }
            else
            {
                AutoSolve.AnalyzeLine(col, nonogram.Lines, 1, j, false);
                if (col[i] == 1)
                {
                    row[j] = 1;
                    AutoSolve.AnalyzeLine(row, nonogram.Lines, 0, i, false);
                }
            }
            for (int i1 = 0; i1 < nonogram.RowCount; i1++)
            {
                if (col[i1] == 0) nonogram.Picture[i1, j] = 0;
            }
            for (int j1 = 0; j1 < nonogram.ColumnCount; j1++)
            {
                if (row[j1] == 0) nonogram.Picture[i, j1] = 0;
            }
            base.ChangeCell(i, j, newVal);
            return (row[j] == 1 || col[i] == 1) ? 0 : 1;
        }

        protected override void AddStep(int cellNum)
        {
            return;
        }

        public override void UndoStep(int oldVal)
        {
            throw new NotImplementedException();
        }
    }
}
