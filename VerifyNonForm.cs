using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qualifying_work
{
    public partial class VerifyNonForm : Form
    {
        const int cellSize = 25;
        NonogramToVerifySession ses;
        int nonId;

        public VerifyNonForm(int[] blocksDescs, int nonId_)
        {
            InitializeComponent();
            nonId = nonId_;
            ses = new NonogramToVerifySession(new Nonogram(blocksDescs));
            DisplayNon();
        }

        private void DisplayNon()
        {
            ClearDgvs();
            int rowC = ses.NGram.RowCount;
            int colC = ses.NGram.ColumnCount;
            ResizeDgvs(colC, rowC);
            for (int i = 0; i < rowC; i++)
            {
                for (int j = 0; j < colC; j++)
                {
                    if (ses.NGram.CorrectPicture[i, j] == 1)
                    {
                        dgv[j, i].Style.BackColor = Color.Black;
                    }
                }
            }
            dgv[0, 0].Style.SelectionBackColor = dgv[0, 0].Style.BackColor;
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

            this.Width = Math.Max(dgv.Left + dgv.Width + 40, 322);
            this.Height = Math.Max(dgv.Top + dgv.Height + 50, 289);
            dgv.ClearSelection();
        }

        private void ClearDgvs()
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    dgv[j, i].Style.BackColor = Color.Empty;
                }
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void buttonDecline_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
