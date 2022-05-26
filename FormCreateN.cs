using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Qualifying_work
{
    public partial class FormCreateN : Form
    {
        const int cellSize = 25;
        Npg npg;
        NonogramToAddSession ses;

        public FormCreateN(Npg npg_)
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                dgv, new object[] { true });
            npg = npg_;
            ResizeDgvs(4, 10);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgv[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Black)
            {
                dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Black;
                dgv[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.White;
            }
            else
            {
                dgv[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                dgv[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Black;
            }
            dgv.ClearSelection();
        }

        private void ResizeDgvs(int newCC, int newRC)
        {
            int oldRC = dgv.RowCount;
            int oldCC = dgv.ColumnCount;
            for (int i = oldCC - 1; i >= newCC; i--)
            {
                dgv.Columns.RemoveAt(i);
            }
            for (int i = oldRC - 1; i >= newRC; i--)
            {
                dgv.Rows.RemoveAt(i);
            }
            for (int i = oldCC; i < newCC; i++)
            {
                dgv.Columns.Add(i.ToString(), i.ToString());
                dgv.Columns[i].Width = cellSize;
            }
            for (int i = oldRC; i < newRC; i++)
            {
                dgv.Rows.Add();
            }
            dgv.Width = newCC * cellSize + 4;
            dgv.Height = newRC * cellSize + 4;

            this.Width = dgv.Left + dgv.Width + 40;
            this.Height = Math.Max(dgv.Top + dgv.Height + 50, 289);
            dgv.ClearSelection();
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            ResizeDgvs(Convert.ToInt32(colCountTB.Text), Convert.ToInt32(rowCountTB.Text));
        }

        private void insertNButton_Click(object sender, EventArgs e)
        {
            List<int> bD = new List<int>();
            bD.Add(dgv.RowCount);
            bD.Add(dgv.ColumnCount);
            for (int i = 0; i < dgv.RowCount; i++)
            {
                List<int> blocksLengths = new List<int>();
                int blockNum = -1;
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (dgv[j, i].Style.BackColor == Color.Black)
                    {
                        blockNum++;
                        blocksLengths.Add(1);
                        while (j < dgv.ColumnCount - 1)
                        {
                            j++;
                            if (dgv[j, i].Style.BackColor == Color.Black)
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
            for (int j = 0; j < dgv.ColumnCount; j++)
            {
                List<int> blocksLengths = new List<int>();
                int blockNum = -1;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv[j, i].Style.BackColor == Color.Black)
                    {
                        blockNum++;
                        blocksLengths.Add(1);
                        while (i < dgv.RowCount - 1)
                        {
                            i++;
                            if (dgv[j, i].Style.BackColor == Color.Black)
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
            ses = new NonogramToAddSession(new Nonogram(bD.ToArray()));
            MessageBox.Show(ses.NonType.ToString());
            /*npg.StartWork();
            npg.Query("insert into nonograms(blocks_descriptions) values(array[" + ses.NGram.ToString() + "])");
            npg.FinishWork();*/
        }

        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Black)
            {
                dgv[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Black;
            }
            else
            {
                dgv[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.White;
            }
        }

        private void dgv_MouseEnter(object sender, EventArgs e)
        {
            dgv.ClearSelection();
        }
    }
}
