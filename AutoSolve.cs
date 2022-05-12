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

            bool linesToAnalyze = false;
            do
            {
                for (int i = 0; i < rowC; i++)
                {
                    if (needRefresh[0][i])
                    {
                        //AnalyzeLine();
                        linesToAnalyze = true;
                    }
                }
                for (int i = 0; i < colC; i++)
                {
                    if (needRefresh[1][i])
                    {
                        //AnalyzeLine();
                        linesToAnalyze = true;
                    }
                }
            }
            while (linesToAnalyze);

            return res;
        }

        
    }
}
