using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public static class AutoSolve
    {
        private static Stack<int[,]> copies = new Stack<int[,]>();
        private static int[,] solutionStorage;

        public static void Solve(Nonogram nonogram)
        {
            nonogram.Type = NonogramType.OnlyILL;
            bool[][] needRefresh = new bool[2][];
            needRefresh[0] = Enumerable.Repeat(true, nonogram.RowCount).ToArray();
            needRefresh[1] = Enumerable.Repeat(true, nonogram.ColumnCount).ToArray();
            bool solFound = false;
            solutionStorage = null;
            Try(nonogram, 0, 0, needRefresh, ref solFound);
            if (solutionStorage != null) Array.Copy(solutionStorage, nonogram.CorrectPicture, solutionStorage.Length);
            else
            {
                Array.Copy(nonogram.Picture, nonogram.CorrectPicture, nonogram.Picture.Length);
            }
            for (int i = 0; i < nonogram.RowCount; i++)
                for (int j = 0; j < nonogram.ColumnCount; j++)
                    nonogram.Picture[i, j] = 2;
        }

        private static void Try(Nonogram nonogram, int i, int j, bool[][] needRefresh, ref bool solFound)
        {
            if (!IterateLineLook(nonogram, needRefresh)) return;
            while (i < nonogram.RowCount && nonogram.Picture[i, j] != 2)
            {
                if (j == nonogram.ColumnCount - 1)//line has ended
                {
                    //go to the next line
                    j = 0;
                    i++;
                }
                else
                {
                    j++;//go to the next element in line
                }
            }
            if (i >= nonogram.RowCount)//all cells have known states
            {
                if (solFound) nonogram.Type = NonogramType.FewSolutions;
                else
                {
                    solFound = true;
                    if (nonogram.Type == NonogramType.NeedBacktracking)
                    {
                        solutionStorage = new int[nonogram.RowCount, nonogram.ColumnCount];
                        Array.Copy(nonogram.Picture, solutionStorage, nonogram.Picture.Length);//becaues pict will be changed while looking for other sols
                    }
                }
                return;
            }
            else//[i, j] is unknown
            {
                if (nonogram.Type == NonogramType.OnlyILL) nonogram.Type = NonogramType.NeedBacktracking;
                copies.Push(new int[nonogram.RowCount, nonogram.ColumnCount]);
                Array.Copy(nonogram.Picture, copies.Peek(), nonogram.Picture.Length);//to check 0 and 1 with the same pict
                nonogram.Picture[i, j] = 0;//maybe it is 0
                needRefresh[0][i] = true;
                needRefresh[1][j] = true;
                Try(nonogram, i, j, needRefresh, ref solFound);
                if (nonogram.Type == NonogramType.FewSolutions) return;//because nonograms with few solutions banned
                Array.Copy(copies.Peek(), nonogram.Picture, copies.Peek().Length);
                copies.Pop();
                nonogram.Picture[i, j] = 1;//maybe it is 1
                needRefresh[0][i] = true;
                needRefresh[1][j] = true;
                Try(nonogram, i, j, needRefresh, ref solFound);
            }
        }

        private static bool IterateLineLook(Nonogram nonogram, bool[][] needRefresh)
        {
            int rowC = nonogram.RowCount;
            int colC = nonogram.ColumnCount;

            bool wasError = false;
            bool linesToAnalyze = false;
            do
            {
                linesToAnalyze = false;
                for (int i = 0; i < rowC; i++)
                {
                    if (needRefresh[0][i])
                    {
                        wasError = AnalyzeLine(nonogram, needRefresh, 0, i);
                        linesToAnalyze = true;
                    }
                }
                for (int i = 0; i < colC; i++)
                {
                    if (needRefresh[1][i])
                    {
                        wasError = AnalyzeLine(nonogram, needRefresh, 1, i);
                        linesToAnalyze = true;
                    }
                }
            }
            while (linesToAnalyze);
            return wasError;
        }

        private static bool AnalyzeLine(Nonogram nonogram, bool[][] needRefresh, int kind, int lineNum)
        {
            Line[][] lines = nonogram.Lines;
            int[,] pict = nonogram.Picture;
            const int nondef = -1;
            int lineLength = lines[kind * (-1) + 1].Length;
            int[] cells = new int[lineLength];//here will be lines elements
            if (kind == 0)
            {
                for (int i = 0; i < lineLength; i++)
                {
                    cells[i] = pict[lineNum, i];
                }
            }
            else
            {
                for (int i = 0; i < lineLength; i++)
                {
                    cells[i] = pict[i, lineNum];
                }
            }
            needRefresh[kind][lineNum] = false;
            int blockCount = lines[kind][lineNum].BlockCount;
            int[] blL = new int[blockCount];
            Array.Copy(lines[kind][lineNum].BlocksLengths, blL, blockCount);
            int blockLenghtsSum = blL.Sum();
            int[,] next = new int[blockLenghtsSum + blockCount, 2];//one "ready for the next block" before every block

            //filling the transition table (next)

            int posI = -1;
            for (int i = 0; i < blockCount; i++)
            {
                posI++;//go to "ready for the next block" state
                next[posI, 0] = posI;
                next[posI, 1] = posI + 1;
                posI++;//go to the start of block
                for (int j = 0; j < blL[i] - 1; j++)//all blocks cells except the last one
                {
                    next[posI + j, 0] = nondef;
                    next[posI + j, 1] = posI + j + 1;
                }
                posI += blL[i] - 1;
                if (i < blockCount - 1)
                {
                    next[posI, 0] = posI + 1;
                }
                else
                {
                    next[posI, 0] = posI;
                }
                next[posI, 1] = nondef;
            }

            //building a map with pathes (variants of how blocks can be placed)

            int posCount = posI + 1;
            int freeZeros = lineLength - blockLenghtsSum - (blockCount - 1);
            int[,] map = new int[freeZeros + 1, posCount];//+1 because situation when no zeros was read is possible too
            map[0, 0] = 2;//first element can be reached
            for (int i = 1; i <= lineLength; i++)//check all input symbols
            {
                int jMin = i - freeZeros;//minimal position that can be reached by reading symbol [i]
                if (jMin < 0) jMin = 0;//if too close to the start
                int jMax = i;//maximal position that can be reached by reading symbol [i]
                if (jMax >= posCount) jMax = posCount - 1;//if too close to the finish
                for (int j = jMin; j <= jMax; j++)//check all positions which can be reached by reading symbol [i]
                {
                    if (i > j)//impossible to get to point [i-j,j] by staying in j when current point is in the first row
                    {
                        if (map[i - j - 1, j] != 0 && next[j, 0] == j && cells[i - 1] % 2 == 0)
                        {
                            map[i - j, j] += 4;//stay in the same position
                        }
                    }
                    if (j > 0)//impossible to get to point [i-j,j] by changing position when current point is in the first column
                    {
                        if (map[i - j, j - 1] != 0)
                        {
                            if (next[j - 1, 0] == j && cells[i - 1] % 2 == 0)//go by zero from the previous
                            {
                                map[i - j, j] += 2;
                            }
                            if (next[j - 1, 1] == j && cells[i - 1] > 0)//go by one from the previous
                            {
                                map[i - j, j] += 1;
                            }
                        }
                    }
                }
            }

            //backway to get know states of some *2* symbols

            if (map[freeZeros, posCount - 1] == 0) return false;//cant reach last position
            for (int i = lineLength; i >= 1; i--)//check all input symbols
            {
                int jMin = i - freeZeros;//the same
                if (jMin < 0) jMin = 0;
                int jMax = i;
                if (jMax >= posCount) jMax = posCount - 1;
                for (int j = jMin; j <= jMax; j++)//make zero elements from which last position is unreachable
                {
                    if (map[i - j, j] != 0)
                    {
                        if (j == posCount - 1 && i - j < freeZeros && map[i - j + 1, j] < 4)//last column; check if possible to go down
                        {
                            map[i - j, j] = 0;
                        }
                        if (j < posCount - 1 && i - j == freeZeros && map[i - j, j + 1] % 4 == 0)//last row; check if possible to go right
                        {
                            map[i - j, j] = 0;
                        }
                        if (j < posCount - 1 && i - j < freeZeros && map[i - j + 1, j] < 4 && map[i - j, j + 1] % 4 == 0)//recent; check both
                        {
                            map[i - j, j] = 0;
                        }
                    }
                }
                if (cells[i - 1] == 2)
                {
                    bool canOne = false, canZero = false;
                    for (int j = jMin; j <= jMax; j++)//check if can be reached by...
                    {
                        if (map[i - j, j] > 1)//...zero
                        {
                            canZero = true;
                        }
                        if (map[i - j, j] % 2 != 0)//...one
                        {
                            canOne = true;
                        }
                    }
                    if (canOne != canZero)//if can be reached only by one of them
                    {
                        needRefresh[kind * (-1) + 1][i - 1] = true;
                        if (canOne)
                        {
                            cells[i - 1] = 1;
                        }
                        else
                        {
                            cells[i - 1] = 0;
                        }
                        if (kind == 0)
                        {
                            pict[lineNum, i - 1] = cells[i - 1];
                        }
                        else
                        {
                            pict[i - 1, lineNum] = cells[i - 1];
                        }
                    }
                }
            }
            return true;
        }

        public static int AnalyzeLine(int[] cells, Line[][] lines, int kind, int lineNum)
        {
            const int nondef = -1;
            int lineLength = lines[kind * (-1) + 1].Length;
            int blockCount = lines[kind][lineNum].BlockCount;
            int[] blL = new int[blockCount];
            Array.Copy(lines[kind][lineNum].BlocksLengths, blL, blockCount);
            int blockLenghtsSum = blL.Sum();
            int[,] next = new int[blockLenghtsSum + blockCount, 2];//one "ready for the next block" before every block

            //filling the transition table (next)

            int posI = -1;
            for (int i = 0; i < blockCount; i++)
            {
                posI++;//go to "ready for the next block" state
                next[posI, 0] = posI;
                next[posI, 1] = posI + 1;
                posI++;//go to the start of block
                for (int j = 0; j < blL[i] - 1; j++)//all blocks cells except the last one
                {
                    next[posI + j, 0] = nondef;
                    next[posI + j, 1] = posI + j + 1;
                }
                posI += blL[i] - 1;
                if (i < blockCount - 1)
                {
                    next[posI, 0] = posI + 1;
                }
                else
                {
                    next[posI, 0] = posI;
                }
                next[posI, 1] = nondef;
            }

            //building a map with pathes (variants of how blocks can be placed)

            int posCount = posI + 1;
            int freeZeros = lineLength - blockLenghtsSum - (blockCount - 1);
            int[,] map = new int[freeZeros + 1, posCount];//+1 because situation when no zeros was read is possible too
            map[0, 0] = 2;//first element can be reached
            for (int i = 1; i <= lineLength; i++)//check all input symbols
            {
                int jMin = i - freeZeros;//minimal position that can be reached by reading symbol [i]
                if (jMin < 0) jMin = 0;//if too close to the start
                int jMax = i;//maximal position that can be reached by reading symbol [i]
                if (jMax >= posCount) jMax = posCount - 1;//if too close to the finish
                for (int j = jMin; j <= jMax; j++)//check all positions which can be reached by reading symbol [i]
                {
                    if (i > j)//impossible to get to point [i-j,j] by staying in j when current point is in the first row
                    {
                        if (map[i - j - 1, j] != 0 && next[j, 0] == j && cells[i - 1] % 2 == 0)
                        {
                            map[i - j, j] += 4;//stay in the same position
                        }
                    }
                    if (j > 0)//impossible to get to point [i-j,j] by changing position when current point is in the first column
                    {
                        if (map[i - j, j - 1] != 0)
                        {
                            if (next[j - 1, 0] == j && cells[i - 1] % 2 == 0)//go by zero from the previous
                            {
                                map[i - j, j] += 2;
                            }
                            if (next[j - 1, 1] == j && cells[i - 1] > 0)//go by one from the previous
                            {
                                map[i - j, j] += 1;
                            }
                        }
                    }
                }
            }

            //backway to get know states of some *2* symbols

            //if (map[freeZeros, posCount - 1] == 0) return false;//cant reach last position
            for (int i = lineLength; i >= 1; i--)//check all input symbols
            {
                int jMin = i - freeZeros;//the same
                if (jMin < 0) jMin = 0;
                int jMax = i;
                if (jMax >= posCount) jMax = posCount - 1;
                for (int j = jMin; j <= jMax; j++)//make zero elements from which last position is unreachable
                {
                    if (map[i - j, j] != 0)
                    {
                        if (j == posCount - 1 && i - j < freeZeros && map[i - j + 1, j] < 4)//last column; check if possible to go down
                        {
                            map[i - j, j] = 0;
                        }
                        if (j < posCount - 1 && i - j == freeZeros && map[i - j, j + 1] % 4 == 0)//last row; check if possible to go right
                        {
                            map[i - j, j] = 0;
                        }
                        if (j < posCount - 1 && i - j < freeZeros && map[i - j + 1, j] < 4 && map[i - j, j + 1] % 4 == 0)//recent; check both
                        {
                            map[i - j, j] = 0;
                        }
                    }
                }
                if (cells[i - 1] == 2)
                {
                    bool canOne = false, canZero = false;
                    for (int j = jMin; j <= jMax; j++)//check if can be reached by...
                    {
                        if (map[i - j, j] > 1)//...zero
                        {
                            canZero = true;
                        }
                        if (map[i - j, j] % 2 != 0)//...one
                        {
                            canOne = true;
                        }
                    }
                    if (canOne != canZero)//if can be reached only by one of them
                    {
                        if (canOne)
                        {
                            cells[i - 1] = 1;
                            return i - 1;
                        }
                        else
                        {
                            cells[i - 1] = 0;
                        }
                    }
                }
            }
            return -1;
        }
    }
}