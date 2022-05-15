using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public static class AutoSolve
    {
        public static int[,] Solve(int[] blocksDescs)
        {
            int rowC = blocksDescs[0];
            int colC = blocksDescs[1];
            bool[,] res = new bool[rowC, colC];
            Line[][] lines = new Line[2][];
            lines[0] = new Line[rowC];
            lines[1] = new Line[colC];
            int blocksCount = 0;
            for (int i = 2, currLine = 0; currLine < rowC + colC; i += blocksCount + 1, currLine++)
            {
                blocksCount = blocksDescs[i];
                int[] blL = new int[blocksCount];
                Array.Copy(blocksDescs, i + 1, blL, 0, blocksCount);
                if (currLine < rowC)
                {
                    lines[0][currLine] = new Line(blocksCount, blL);
                }
                else
                {
                    lines[1][currLine - rowC] = new Line(blocksCount, blL);
                }
            }

            bool[][] needRefresh = new bool[2][];
            needRefresh[0] = Enumerable.Repeat(true, rowC).ToArray();
            needRefresh[1] = Enumerable.Repeat(true, colC).ToArray();

            int[,] pict = new int[rowC, colC];
            for (int i = 0; i < rowC; i++)
                for (int j = 0; j < colC; j++)
                    pict[i, j] = 2;

            bool linesToAnalyze = false;
            do
            {
                linesToAnalyze = false;
                for (int i = 0; i < rowC; i++)
                {
                    if (needRefresh[0][i])
                    {
                        AnalyzeLine(pict, lines, needRefresh, 0, i);
                        linesToAnalyze = true;
                        
                    }
                }
                for (int i = 0; i < colC; i++)
                {
                    if (needRefresh[1][i])
                    {
                        AnalyzeLine(pict, lines, needRefresh, 1, i);
                        linesToAnalyze = true;
                    }
                }
            }
            while (linesToAnalyze);

            return pict;
        }

        private static bool AnalyzeLine(int[,] pict, Line[][] lines, bool[][] needRefresh, int kind, int lineNum)
        {
            const int nondef = -1;
            int lineLength = lines[kind * (-1) + 1].Length;
            int[] cells = new int[lineLength];
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

            int posCount = posI + 1;
            int freeZeros = lineLength - blockLenghtsSum - (blockCount - 1);
            int[,] map = new int[freeZeros + 1, posCount];//+1 because situation when no zeros was read is possible too
            map[0, 0] = 2;
            for (int i = 1; i <= lineLength; i++)
            {
                int jMin = i - freeZeros;
                if (jMin < 0) jMin = 0;
                int jMax = i;
                if (jMax >= posCount) jMax = posCount - 1;
                for (int j = jMin; j <= jMax; j++)
                {
                    if (i > j)//stay in the same position
                    {
                        if (map[i - j - 1, j] != 0 && next[j, 0] == j && cells[i - 1] % 2 == 0)
                        {
                            map[i - j, j] += 4;
                        }
                    }
                    if (j > 0)
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

            if (map[freeZeros, posCount - 1] == 0) return false;//cant reach last position
            for (int i = lineLength; i >= 1; i--)
            {
                int jMin = i - freeZeros;
                if (jMin < 0) jMin = 0;
                int jMax = i;
                if (jMax >= posCount) jMax = posCount - 1;
                for (int j = jMin; j <= jMax; j++)//zero elements from which last position is unreachable
                {
                    if (map[i - j, j] != 0)
                    {
                        if (j == posCount - 1 && i - j < freeZeros && map[i - j + 1, j] < 4)
                        {
                            map[i - j, j] = 0;
                        }
                        if (j < posCount - 1 && i - j == freeZeros && map[i - j, j + 1] % 4 == 0)
                        {
                            map[i - j, j] = 0;
                        }
                        if (j < posCount - 1 && i - j < freeZeros && map[i - j + 1, j] < 4 && map[i - j, j + 1] % 4 == 0)
                        {
                            map[i - j, j] = 0;
                        }
                    }
                }
                if (cells[i - 1] == 2)
                {
                    bool canOne = false, canZero = false;
                    for (int j = jMin; j <= jMax; j++)
                    {
                        if (map[i - j, j] > 1)
                        {
                            canZero = true;
                        }
                        if (map[i - j, j] % 2 != 0)
                        {
                            canOne = true;
                        }
                    }
                    if (canOne != canZero)
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
    }
}