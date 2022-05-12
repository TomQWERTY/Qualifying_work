using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Qualifying_work
{
    public partial class Form1 : Form
    {
        const int cellSize = 25;
        Npg npg;
        DataTable currSol;
        int solTime;
        int cNum;
        string time;
        int[] blocksDescs;

        public Form1(string username_)
        {
            InitializeComponent();
            npg = new Npg();
            ResizeDgvs(2, 2, 5, 5);
            cNum = 0;
            time = "";
            labelUser.Text = username_;
            comboBoxPMode.SelectedIndex = 0;
        }

        private void ResizeDgvs(int maxRowB, int maxColB, int newCC, int newRC)
        {
            int oldRowB = dgvRowDesc.ColumnCount;
            int oldColB = dgvColDesc.RowCount;
            int oldRC = dgvRowDesc.RowCount;
            int oldCC = dgvColDesc.ColumnCount;
            for (int i = oldCC - 1; i >= newCC; i--)
            {
                dgvColDesc.Columns.RemoveAt(i);
                dgvMain.Columns.RemoveAt(i);
            }
            for (int i = oldColB - 1; i >= maxColB; i--)
            {
                dgvColDesc.Rows.RemoveAt(i);
            }
            for (int i = oldRowB - 1; i >= maxRowB; i--)
            {
                dgvRowDesc.Columns.RemoveAt(i);
            }
            for (int i = oldRC - 1; i >= newRC; i--)
            {
                dgvRowDesc.Rows.RemoveAt(i);
                dgvMain.Rows.RemoveAt(i);
            }
            for (int i = oldCC; i < newCC; i++)
            {
                dgvColDesc.Columns.Add(i.ToString(), i.ToString());
                dgvColDesc.Columns[i].Width = cellSize;
                dgvMain.Columns.Add(i.ToString(), i.ToString());
                dgvMain.Columns[i].Width = cellSize;
            }
            for (int i = oldColB; i < maxColB; i++)
            {
                dgvColDesc.Rows.Add();
            }
            for (int i = oldRowB; i < maxRowB; i++)
            {
                dgvRowDesc.Columns.Add(i.ToString(), i.ToString());
                dgvRowDesc.Columns[i].Width = cellSize;
            }
            for (int i = oldRC; i < newRC; i++)
            {
                dgvRowDesc.Rows.Add();
                dgvMain.Rows.Add();
            }
            dgvColDesc.Width = newCC * cellSize + 4;
            dgvRowDesc.Width = maxRowB * cellSize + 4;
            dgvMain.Width = newCC * cellSize + 4;
            
            dgvColDesc.Height = maxColB * cellSize + 4;
            dgvRowDesc.Height = newRC * cellSize + 4;
            dgvMain.Height = newRC * cellSize + 4;

            dgvRowDesc.Top = dgvColDesc.Top + dgvColDesc.Height + 5;
            dgvColDesc.Left = dgvRowDesc.Left + dgvRowDesc.Width + 5;
            dgvMain.Left = dgvColDesc.Left;
            dgvMain.Top = dgvRowDesc.Top;
            this.Width = dgvMain.Left + dgvMain.Width + 40;
            this.Height = Math.Max(dgvMain.Top + dgvMain.Height + 50, 289);
        }

        private void ClearDgvs()
        {
            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                for (int j = 0; j < dgvMain.ColumnCount; j++)
                {
                    dgvMain[j, i].Style.BackColor = Color.Empty;
                }
            }
            for (int i = 0; i < dgvRowDesc.RowCount; i++)
            {
                for (int j = 0; j < dgvRowDesc.ColumnCount; j++)
                {
                    dgvRowDesc[j, i].Value = "";
                }
            }
            for (int i = 0; i < dgvColDesc.RowCount; i++)
            {
                for (int j = 0; j < dgvColDesc.ColumnCount; j++)
                {
                    dgvColDesc[j, i].Value = "";
                }
            }
        }

            private void InitializeDgvs()
        {
            //if (main.ColumnCount > 0)
            //{
            //    for (int i = main.ColumnCount - 1; i >= 0; i--)
            //    {
            //        main.Columns.RemoveAt(i);
            //        add.Columns.RemoveAt(i);
            //    }
            //}
           
            //if (main.RowCount > 0)
            //{
            //    for (int i = main.RowCount - 1; i >= 0; i--)
            //    {
            //        main.Rows.RemoveAt(i);
            //        add.Rows.RemoveAt(i);
            //    }
            //}
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            Download();
            if (comboBoxPMode.SelectedIndex == 1)
            {
                solTime = 0;
                timer1.Interval = 1000;
                timer1.Start();
                timerLabel.Text = "00:00:00";
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Black)
            {
                dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Black;
            }
            else
            {
                dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Empty;
            }
            dgvMain.ClearSelection();
        }

        private void CheckIfCorrect()
        {
            bool ok = true;
            int rowC = Convert.ToInt32(blocksDescs[0]);
            int colC = Convert.ToInt32(blocksDescs[1]);
            int i = 1;
            int rowNum = -1;
            while (rowNum < rowC - 1)
            {
                i++;
                rowNum++;
                if (!ok)
                {
                    continue;
                }
                int k = -1;
                int rowBlockCount = Convert.ToInt32(blocksDescs[i]);
                for (int j = 0; j < rowBlockCount; j++)
                {
                    i++;
                    int currBlockLength = Convert.ToInt32(blocksDescs[i]);
                    int blackCount = 0;

                    while (blackCount < currBlockLength)
                    {
                        k++;
                        if (k >= colC)
                        {
                            break;
                        }
                        if (dgvMain[k, rowNum].Style.BackColor == Color.Black)
                        {
                            blackCount++;
                        }
                    }
                    if (blackCount != currBlockLength)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            int colNum = -1;
            while (colNum < rowC - 1)
            {
                i++;
                colNum++;
                if (!ok)
                {
                    continue;
                }
                int k = -1;
                int colBlockCount = Convert.ToInt32(blocksDescs[i]);
                for (int j = 0; j < colBlockCount; j++)
                {
                    i++;
                    int currBlockLength = Convert.ToInt32(blocksDescs[i]);
                    int blackCount = 0;
                    while (blackCount < currBlockLength)
                    {
                        k++;
                        if (k >= rowC)
                        {
                            break;
                        }
                        if (dgvMain[colNum, k].Style.BackColor == Color.Black)
                        {
                            blackCount++;
                        }
                    }
                    if (blackCount != currBlockLength)
                    {
                        ok = false;
                        break;
                    }
                }                
            }
            if (ok)
            {
                if (comboBoxPMode.SelectedIndex == 0)
                {
                    MessageBox.Show("Кросворд розв'язано правильно!");
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Кросворд розв'язано правильно! Ваш час - " + time);
                    npg.StartWork();
                    string readTime = npg.Query("select r_time from records where n_name = \'" + cNum + "\'").Rows[0][0].ToString();
                    int[] currRec = Array.ConvertAll(readTime.Split(':'), Convert.ToInt32);
                    if (solTime < currRec[0] * 3600 + currRec[1] * 60 + currRec[2])
                    {
                        npg.Query("update records set r_time = \'" + time + "\', username = \'" + labelUser.Text + "\' where n_name = \'" + cNum + "\'");
                        MessageBox.Show("Вітаємо, Ви встановили новий рекорд! Колишній рекорд: " + readTime);
                    }
                    npg.FinishWork();
                }
            }
            else
            {
                MessageBox.Show("Кросворд розв'язано неправильно!");
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            CheckIfCorrect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            solTime++;
            time = (solTime / 3600).ToString().PadLeft(2, '0') + ":";
            solTime %= 3600;
            time += (solTime / 60).ToString().PadLeft(2, '0') + ":" + (solTime % 60).ToString().PadLeft(2, '0');
            timerLabel.Text = time;
        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            //FormRecords formR = new FormRecords(npg);
            //formR.ShowDialog();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string address = saveFileDialog1.FileName;
                StreamWriter strwr = new StreamWriter(address);
                strwr.WriteLine(cNum);
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    for (int j = 0; j < dgvMain.ColumnCount; j++)
                    {
                        strwr.Write(dgvMain[j, i].Style.BackColor == Color.Black ? '1' : '0');
                    }
                    strwr.WriteLine();
                }
                strwr.Close();
            }
        }

        private void Download()
        {
            npg.StartWork();
            ClearDgvs();
            //blocksDescs = npg.Query("select * from n" + ++cNum);
            var temp_ = npg.Query("select blocks_descriptions from nonograms where idK=" + ++cNum).Rows[0].ItemArray[0];
            blocksDescs = (int[])temp_;
            var loh = AutoSolve.Solve(blocksDescs);
            currSol = npg.Query("select * from n" + cNum + "_s");
            npg.FinishWork();
            int rowC = Convert.ToInt32(blocksDescs[0]);
            int colC = Convert.ToInt32(blocksDescs[1]);
            int maxRowB = 0;
            int maxColB = 0;
            int i = 2;
            for (int j = 0; j < rowC; i++, j++)//find a row with the biggest count of blocks
            {
                int temp = Convert.ToInt32(blocksDescs[i]);
                if (temp > maxRowB) maxRowB = temp;
                i += temp;//jump to the next rows block count
            }
            for (int j = 0; j < colC; i++, j++)//the same with columns
            {
                int temp = Convert.ToInt32(blocksDescs[i]);
                if (temp > maxColB) maxColB = temp;
                i += temp;
            }
            ResizeDgvs(maxRowB, maxColB, colC, rowC);

            i = 2;
            for (int j = 0; j < rowC; j++)
            {
                int blockCount = Convert.ToInt32(blocksDescs[i]);
                i++;
                for (int t = 0; t < blockCount; t++, i++)
                {
                    dgvRowDesc[maxRowB - blockCount + t, j].Value = Convert.ToInt32(blocksDescs[i]);
                }
            }
            for (int j = 0; j < colC; j++)
            {
                int blockCount = Convert.ToInt32(blocksDescs[i]);
                i++;
                for (int t = 0; t < blockCount; t++, i++)
                {
                    dgvColDesc[j, maxColB - blockCount + t].Value = Convert.ToInt32(blocksDescs[i]);
                }
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string address = openFileDialog1.FileName;
                StreamReader strrd = new StreamReader(address);
                cNum = Convert.ToInt32(strrd.ReadLine()) - 1;
                Download();
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    string line = strrd.ReadLine();
                    for (int j = 0; j < dgvMain.ColumnCount; j++)
                    {
                        dgvMain[j, i].Style.BackColor = line[j] == '1' ?  Color.Black : Color.Empty;
                    }
                }
                strrd.Close();
                timer1.Stop();
                timerLabel.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i1 = 0; i1 < dgvMain.RowCount; i1++)
            {
                for (int j1 = 0; j1 < dgvMain.ColumnCount; j1++)
                {
                    if (Convert.ToBoolean(currSol.Rows[i1][j1]))
                    {
                        dgvMain[j1, i1].Style.BackColor = Color.Black;
                    }
                }
            }
            CheckIfCorrect();
        }

        /*private void ChangeTableColCount(DataGridView dgvColDesc, DataGridView dgvMain, int newCount)
        {
            if (newCount < 2)
            {
                throw new Exception("Кількість стовпців не може бути меншою за 1.");
            }
            int oldCount = main.ColumnCount;
            for (int i = oldCount; i < newCount; i++)
            {
                main.Columns.Add(i.ToString(), i.ToString());
                main.Columns[i].Width = 50;
                main[i, 0].Value = s + (i - 1);
                main[i, 0].ReadOnly = true;
                add.Columns.Add(i.ToString(), i.ToString());
                add.Columns[i].Width = 50;
            }
            for (int i = 0; i < oldCount - newCount; i++)
            {
                main.Columns.RemoveAt(oldCount - i - 1);
                add.Columns.RemoveAt(oldCount - i - 1);
            }
            main.Width = newCount * 50 + 4;
            add.Width = newCount * 50 + 4;
        }

        private void ChangeTableRowCount(DataGridView main, DataGridView add, int newCount, string s, bool isInput)
        {
            if (newCount < 2)
            {
                throw new Exception("Кількість рядків не може бути меншою за 1.");
            }
            int oldCount;
            if (automaton is MealyAut)
            {
                oldCount = add.RowCount;
                if (isInput)
                {
                    for (int i = oldCount; i < newCount - 1; i++)
                    {
                        add.Rows.Add();
                        add[0, i].Value = s + i;
                        add[0, i].ReadOnly = true;
                    }
                }
                else
                {
                    for (int i = oldCount - 1; i < newCount - 1; i++)
                    {
                        add.Rows.Add();
                        add[0, i].Value = addTableIn[0, i].Value;
                    }
                    add.Rows.RemoveAt(add.RowCount - 1);
                }
                for (int i = 0; i < oldCount - newCount + 1; i++)
                {
                    add.Rows.RemoveAt(oldCount - i - 1);
                }
                add.Height = (newCount - 1) * 22 + 4;
            }
            oldCount = main.RowCount;
            for (int i = oldCount; i < newCount; i++)
            {
                main.Rows.Add();
                if (isInput)
                {
                    main[0, i].Value = s + (i - 1);
                }
                else
                {
                    main[0, i].Value = mainTableIn[0, i].Value;
                }
            }
            for (int i = 0; i < oldCount - newCount; i++)
            {
                main.Rows.RemoveAt(oldCount - i - 1);
            }
            main.Height = newCount * 22 + 4;
            if (automaton is MooreAut)
            {
                add.Top = 48;
                main.Top = add.Top + add.Height + 5;
            }
            else
            {
                main.Top = 48;
                add.Top = main.Top + main.Height + 5;
            }
        }*/
    }
}
