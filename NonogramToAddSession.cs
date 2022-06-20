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
            int elsInComb = 4;
            if (cellToMod.Count > 50) elsInComb = 1;
            else if (cellToMod.Count > 30) elsInComb = 2;
            else if (cellToMod.Count > 20) elsInComb = 3;
            if (nonogram.RowCount * nonogram.ColumnCount < 100 && elsInComb == 4) elsInComb = 3;
            if (nonogram.RowCount * nonogram.ColumnCount < 30 && elsInComb == 3) elsInComb = 2;

            for (int i = 0; i < elsInComb; i++)
            {
                RecVars(i + 1, 0, cellToMod, 0);
            }           
        }

        private void RecVars(int num, int startInd, List<int> cellToMod, int posInd)
        {
            for (int i = posInd; i < cellToMod.Count - (num - (startInd + 1)); i++)
            {
                nonogram.InitialPicture[cellToMod[i] / nonogram.ColumnCount, cellToMod[i] % nonogram.ColumnCount] =
                    nonogram.InitialPicture[cellToMod[i] / nonogram.ColumnCount, cellToMod[i] % nonogram.ColumnCount] * (-1) + 1;
                if (num - (startInd + 1) == 0)
                {
                    bool causesProblem = false;
                    for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                    {
                        bool hasOne = false;
                        for (int j = 0; j < nonogram.ColumnCount; j++)
                        {
                            if (nonogram.InitialPicture[i1, j] == 1)
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
                                if (nonogram.InitialPicture[i1, j] == 1)
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
                        int[,] newPict = new int[nonogram.RowCount, nonogram.ColumnCount];
                        Array.Copy(nonogram.InitialPicture, newPict, nonogram.InitialPicture.Length);
                        modVariants.Add(new Nonogram(newPict));
                        SolveEntire(modVariants[modVariants.Count - 1]);
                        if (modVariants[modVariants.Count - 1].Type == NonogramType.FewSolutions)
                        {
                            modVariants.Remove(modVariants.Last());
                        }
                    }
                }
                else
                {
                    RecVars(num, startInd + 1, cellToMod, i + 1);
                }
                nonogram.InitialPicture[cellToMod[i] / nonogram.ColumnCount, cellToMod[i] % nonogram.ColumnCount] =
                    nonogram.InitialPicture[cellToMod[i] / nonogram.ColumnCount, cellToMod[i] % nonogram.ColumnCount] * (-1) + 1;
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
            modVariants = new List<Nonogram>();
        }

        protected void SolveEntire(Nonogram non)
        {
            AutoSolve.Solve(non);
        }
    }
}