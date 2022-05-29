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
    public partial class ModVarsForm : Form
    {
        const int cellSize = 25;
        FormCreateN fcn;
        int currVar;
        List<Nonogram> vars;

        public ModVarsForm(FormCreateN fcn_)
        {
            fcn = fcn_;
            InitializeComponent();
            ResizeDgvs(fcn.ses.NGram.ColumnCount, fcn.ses.NGram.RowCount);
            currVar = 0;
            buttonPrev.Enabled = false;
            vars = fcn.ses.ModVariants;
            if (vars.Count < 2) buttonNext.Enabled = false;
            DisplayVar(currVar);
        }

        private void DisplayVar(int num)
        {
            ClearDgvs();
            int rowC = fcn.ses.NGram.RowCount;
            int colC = fcn.ses.NGram.ColumnCount;
            for (int i = 0; i < rowC; i++)
            {
                for (int j = 0; j < colC; j++)
                {
                    if (vars[currVar].InitialPicture[i, j] == 1)
                    {
                        dgv[j, i].Style.BackColor = Color.Black;
                    }
                }
            }
            dgv[0, 0].Style.SelectionBackColor = dgv[0, 0].Style.BackColor;
            dgv.ClearSelection();
            labelTypeInfo.Text = "*" + (vars[currVar].Type == NonogramType.OnlyILL ? "" : "не") + "можливо розв'язати без використання перебору.";
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
            this.Height = Math.Max(dgv.Top + dgv.Height + 60, 109);
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

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            currVar--;
            DisplayVar(currVar);
            CheckButtons();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currVar++;
            DisplayVar(currVar);
            CheckButtons();
        }

        private void CheckButtons()
        {
            if (currVar == 0)
            {
                buttonPrev.Enabled = false;
            }
            else
            {
                buttonPrev.Enabled = true;
            }
            if (currVar == vars.Count - 1)
            {
                buttonNext.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            fcn.ses.ModifyNonogram(vars[currVar]);
            this.DialogResult = DialogResult.OK;
        }
    }
}
