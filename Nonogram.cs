using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qualifying_work
{
    public class Nonogram
    {
        protected int[] blocksDescriptions;
        protected int[,] pict;
        protected int[,] correctPict;
        protected int[,] initialPict;
        protected int rowC, colC;
        protected Line[][] lines;
        protected NonogramType nType;
        protected int id;
        protected int blackCount;

        public Nonogram(string blocksDescsInStr)
        {
            string[] str1 = blocksDescsInStr.Split(' ');
            for (int i = 0; i < str1.Length; i++)
            {
                str1[i] = str1[i].TrimEnd(',');
            }
            int[] blocksDescs = Array.ConvertAll(str1, Convert.ToInt32);
            ConstructorCommon(blocksDescs);
        }

        public Nonogram(int[] blocksDescs)
        {
            ConstructorCommon(blocksDescs);
        }

        public Nonogram(int[] blocksDescs, int id_)
        {
            id = id_;
            ConstructorCommon(blocksDescs);
        }

        public Nonogram(int[,] pict)
        {
            initialPict = pict;
            List<int> bD = new List<int>();
            int rowC = pict.GetLength(0);
            int colC = pict.GetLength(1);
            bD.Add(rowC);
            bD.Add(colC);
            for (int i = 0; i < rowC; i++)
            {
                List<int> blocksLengths = new List<int>();
                int blockNum = -1;
                for (int j = 0; j < colC; j++)
                {
                    if (pict[i, j] == 1)
                    {
                        blockNum++;
                        blocksLengths.Add(1);
                        while (j < colC - 1)
                        {
                            j++;
                            if (pict[i, j] == 1)
                            {
                                blocksLengths[blockNum]++;
                            }
                            else break;
                        }
                    }
                }
                bD.Add(blockNum + 1);
                foreach (int blLen in blocksLengths)
                {
                    bD.Add(blLen);
                }
            }
            for (int j = 0; j < colC; j++)
            {
                List<int> blocksLengths = new List<int>();
                int blockNum = -1;
                for (int i = 0; i < rowC; i++)
                {
                    if (pict[i, j] == 1)
                    {
                        blockNum++;
                        blocksLengths.Add(1);
                        while (i < rowC - 1)
                        {
                            i++;
                            if (pict[i, j] == 1)
                            {
                                blocksLengths[blockNum]++;
                            }
                            else break;
                        }
                    }
                }
                bD.Add(blockNum + 1);
                foreach (int blLen in blocksLengths)
                {
                    bD.Add(blLen);
                }
            }
            ConstructorCommon(bD.ToArray());
        }

        private void ConstructorCommon(int[] blocksDescs)
        {
            blackCount = 0;
            blocksDescriptions = blocksDescs;
            rowC = blocksDescriptions[0];
            colC = blocksDescriptions[1];
            pict = new int[rowC, colC];
            PictRestart();
            lines = new Line[2][];
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
                    lines[0][currLine] = new Line(blL);
                    blackCount += blL.Sum();
                }
                else
                {
                    lines[1][currLine - rowC] = new Line(blL);
                }
            }
            nType = NonogramType.Unknown;
            correctPict = new int[rowC, colC];
        }

        public void PictRestart()
        {
            for (int i = 0; i < rowC; i++)
                for (int j = 0; j < colC; j++)
                    pict[i, j] = 2;
        }

        public int BlackCount
        {
            get
            {
                return blackCount;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public int[,] Picture
        {
            get
            {
                return pict;
            }
        }

        public int[,] CorrectPicture
        {
            get
            {
                return correctPict;
            }
        }

        public int[,] InitialPicture
        {
            get
            {
                return initialPict;
            }
        }

        public int RowCount
        {
            get
            {
                return rowC;
            }
        }

        public int ColumnCount
        {
            get
            {
                return colC;
            }
        }

        public Line[][] Lines
        {
            get
            {
                return lines;
            }
        }

        public NonogramType Type
        {
            get
            {
                return nType;
            }
            set
            {
                nType = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in blocksDescriptions)
            {
                sb.Append(i);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }

    public enum NonogramType
    {
        OnlyILL, NeedBacktracking, FewSolutions, Unknown
    }
}