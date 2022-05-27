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
                bool causesProblem = false;
                for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                {
                    bool hasOne = false;
                    for (int j = 0; j < nonogram.ColumnCount; j++)
                    {
                        if (newPict[i1, j] == 1)
                        {
                            hasOne = true;
                            break;
                        }
                    }
                    if (!hasOne)
                    {
                        causesProblem = true;
                        break;
                    }
                }
                if (!causesProblem)
                {
                    for (int j = 0; j < nonogram.ColumnCount; j++)
                    {
                        bool hasOne = false;
                        for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                            {
                            if (newPict[i1, j] == 1)
                            {
                                hasOne = true;
                                break;
                            }
                        }
                        if (!hasOne)
                        {
                            causesProblem = true;
                            break;
                        }
                    }
                }
                if (!causesProblem)
                {
                    modVariants.Add(new Nonogram(newPict));
                    SolveEntire(modVariants[modVariants.Count - 1]);
                    if (modVariants[modVariants.Count - 1].Type == NonogramType.FewSolutions)
                    {
                        modVariants.Remove(modVariants.Last());
                    }
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

        public void ModifyNonogram(Nonogram newN)
        {
            nonogram = newN;
        }

        protected void SolveEntire(Nonogram non)
        {
            AutoSolve.Solve(non);
        }
    }
}
