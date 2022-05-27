using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class NonogramToAddSession : NonogramSession
    {
        private List<Nonogram> modVariants;

        public NonogramToAddSession(Nonogram n_) : base(n_)
        {
            modVariants = new List<Nonogram>();
        }

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

        public void BuildModVariants()
        {
            List<int> cellToMod = AutoSolve.GetCellsForMod(nonogram);
            for (int i = 0; i < cellToMod.Count; i++)
            {
                int[,] newPict = new int[nonogram.RowCount, nonogram.ColumnCount];
                Array.Copy(nonogram.InitialPicture, newPict, nonogram.InitialPicture.Length);
                newPict[cellToMod[i] / nonogram.ColumnCount, cellToMod[i] % nonogram.ColumnCount] = 
                    newPict[cellToMod[i] / nonogram.ColumnCount, cellToMod[i] % nonogram.ColumnCount] * (-1) + 1;
                modVariants.Add(new Nonogram(newPict));
                if (modVariants.Last().Type == NonogramType.FewSolutions)
                {
                    modVariants.Remove(modVariants.Last());
                }
            }
        }

        public List<Nonogram> ModVariants
        {
            get
            {
                return modVariants;
            }
        }
    }
}
