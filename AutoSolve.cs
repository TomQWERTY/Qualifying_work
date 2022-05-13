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
            int[,] res = new int[rowC, colC];
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

            return res;
        }

        private static void AnalyzeLine(int[,] pict, Line[][] lines, bool[][] needRefresh, int kind, int lineNum)
        {
            const int nondef = -1;
            int lineLength = lines[kind].Length;
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
            int[,] next = new int[blL.Sum() + blockCount, 2];

            int posI = 0;
            for (int i = 0; i < blockCount; i++)
            {
                next[posI, 0] = posI;
                next[posI, 1] = posI + 1;
                posI++;
                for (int j = 0; j < blL[i] - 1; j++)
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
                posI++;
            }
            posI--;
        }
    }
}