using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    class NTSSWithChecks : NonogramToSolveSession
    {
        public NTSSWithChecks(Nonogram n_) : base(n_) { }

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
    }
}
