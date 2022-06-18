using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    class NTSSWithHints : NonogramToSolveSession
    {
        SortedSet<int> failedCells;
        SortedSet<int>[,] zerosCanBeFound;

        public NTSSWithHints(Nonogram n_, bool isFromLocal) : base(n_, isFromLocal)
        {
            SolveEntire();
            failedCells = new SortedSet<int>();
            zerosCanBeFound = new SortedSet<int>[NGram.RowCount, NGram.ColumnCount];
        }

        public NTSSWithHints(Nonogram n_) : base(n_)
        {
            SolveEntire();
            failedCells = new SortedSet<int>();
            zerosCanBeFound = new SortedSet<int>[NGram.RowCount, NGram.ColumnCount];
        }

        public int[] OpenCell()
        {
            Random rnd = new Random();
            if (nonogram.Type == NonogramType.OnlyILL)
            {
                int lineCount = nonogram.Lines[0].Length;
                int lineNum = rnd.Next(0, lineCount);
                for (int i = lineNum; i < lineCount; i++)
                {
                    int[] row = new int[nonogram.ColumnCount];
                    for (int j1 = 0; j1 < nonogram.ColumnCount; j1++)
                    {
                        row[j1] = nonogram.Picture[i, j1];
                    }
                    int ind = AutoSolve.AnalyzeLine(row, nonogram.Lines, 0, i, true);
                    if (ind != -1)
                    {
                        return new int[2] { i, ind };
                    }
                }
                for (int i = 0; i < lineNum; i++)
                {
                    int[] row = new int[nonogram.ColumnCount];
                    for (int j1 = 0; j1 < nonogram.ColumnCount; j1++)
                    {
                        row[j1] = nonogram.Picture[i, j1];
                    }
                    int ind = AutoSolve.AnalyzeLine(row, nonogram.Lines, 0, i, true);
                    if (ind != -1)
                    {
                        return new int[2] { i, ind };
                    }
                }
                lineCount = nonogram.Lines[1].Length;
                lineNum = rnd.Next(0, lineCount);
                for (int j = lineNum; j < lineCount; j++)
                {
                    int[] col = new int[nonogram.RowCount];
                    for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                    {
                        col[i1] = nonogram.Picture[i1, j];
                    }
                    int ind = AutoSolve.AnalyzeLine(col, nonogram.Lines, 1, j, true);
                    if (ind != -1)
                    {
                        return new int[2] { ind, j };
                    }
                }
                for (int j = 0; j < lineNum; j++)
                {
                    int[] col = new int[nonogram.RowCount];
                    for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                    {
                        col[i1] = nonogram.Picture[i1, j];
                    }
                    int ind = AutoSolve.AnalyzeLine(col, nonogram.Lines, 1, j, true);
                    if (ind != -1)
                    {
                        return new int[2] { ind, j };
                    }
                }
                return new int[2] { -1, -1 };
            }
            else
            {
                int i1 = rnd.Next(0, nonogram.RowCount);
                int j1 = rnd.Next(0, nonogram.ColumnCount);
                for (int i = i1; i < nonogram.RowCount; i++)
                {
                    for (int j = j1; j < nonogram.ColumnCount; j++)
                    {
                        if (nonogram.CorrectPicture[i, j] == 1 && nonogram.Picture[i, j] != 1) return new int[2] { i, j };
                    }
                }
                for (int i = 0; i < i1; i++)
                {
                    for (int j = j1; j < nonogram.ColumnCount; j++)
                    {
                        if (nonogram.CorrectPicture[i, j] == 1 && nonogram.Picture[i, j] != 1) return new int[2] { i, j };
                    }
                }
                for (int i = 0; i < i1; i++)
                {
                    for (int j = 0; j < j1; j++)
                    {
                        if (nonogram.CorrectPicture[i, j] == 1 && nonogram.Picture[i, j] != 1) return new int[2] { i, j };
                    }
                }
                for (int i = i1; i < nonogram.RowCount; i++)
                {
                    for (int j = 0; j < j1; j++)
                    {
                        if (nonogram.CorrectPicture[i, j] == 1 && nonogram.Picture[i, j] != 1) return new int[2] { i, j };
                    }
                }
                return new int[2] { -1, -1 };
            }
        }

        public override int ChangeCell(int i, int j, int newVal)
        {
            if (newVal == 1)
            {
                if (CheckCell(i, j))
                {
                    base.ChangeCell(i, j, newVal);
                    if (nonogram.Type == NonogramType.OnlyILL)
                    {
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
                        AutoSolve.AnalyzeLine(col, nonogram.Lines, 1, j, false);
                        for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                        {
                            if (col[i1] == 0)
                            {
                                nonogram.Picture[i1, j] = 0;
                                if (zerosCanBeFound[i1, j] == null)
                                {
                                    zerosCanBeFound[i1, j] = new SortedSet<int>();
                                }
                                zerosCanBeFound[i1, j].Add(i * NGram.ColumnCount + j);
                            }
                        }
                        for (int j1 = 0; j1 < nonogram.ColumnCount; j1++)
                        {
                            if (row[j1] == 0)
                            {
                                nonogram.Picture[i, j1] = 0;
                                if (zerosCanBeFound[i, j1] == null)
                                {
                                    zerosCanBeFound[i, j1] = new SortedSet<int>();
                                }
                                zerosCanBeFound[i, j1].Add(i * NGram.ColumnCount + j);
                            }
                        }
                    }
                }
                else
                {
                    failedCells.Add(i * nonogram.ColumnCount + j);
                }
            }
            else
            {
                if (CheckCell(i, j))
                {
                    base.ChangeCell(i, j, newVal);
                    for (int i1 = 0; i1 < nonogram.RowCount; i1++)
                    {
                        if (nonogram.Picture[i1, j] == 0)
                        {
                            zerosCanBeFound[i1, j].Remove(i * nonogram.ColumnCount + j);
                            if (zerosCanBeFound[i1, j].Count == 0)
                            {
                                nonogram.Picture[i1, j] = 2;
                            }
                        }
                    }
                    for (int j1 = 0; j1 < nonogram.ColumnCount; j1++)
                    {
                        if (nonogram.Picture[i, j1] == 0)
                        {
                            zerosCanBeFound[i, j1].Remove(i * nonogram.ColumnCount + j);
                            if (zerosCanBeFound[i, j1].Count == 0)
                            {
                                nonogram.Picture[i, j1] = 2;
                            }
                        }
                    }

                }
                else
                {
                    failedCells.Remove(i * nonogram.ColumnCount + j);
                }
            }
            return 3;
        }

        public override bool CheckByLines(int[,] pictToCheck)
        {
            return base.CheckByLines(pictToCheck) && failedCells.Count == 0;
        }

        public SortedSet<int> FailedCells
        {
            get
            {
                return failedCells;
            }
        }
    }
}
