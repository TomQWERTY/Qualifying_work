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
        Form1 form1;
        public NonogramToAddSession ses;

        public FormCreateN(Form1 f1)
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                dgv, new object[] { true });
            form1 = f1;
            npg = form1.npg;
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

        private void DisplayNonogram()
        {
            ClearDgvs();
            int rowC = ses.NGram.RowCount;
            int colC = ses.NGram.ColumnCount;
            for (int i = 0; i < rowC; i++)
            {
                for (int j = 0; j < colC; j++)
                {
                    if (ses.NGram.InitialPicture[i, j] == 1)
                    {
                        dgv[j, i].Style.BackColor = Color.Black;
                    }
                }
            }
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
            this.Height = Math.Max(dgv.Top + dgv.Height + 50, 245);
            dgv.ClearSelection();
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeDgvs(Convert.ToInt32(colCountTB.Text), Convert.ToInt32(rowCountTB.Text));
            }
            catch (FormatException)
            {
                MessageBox.Show("Розміри кросворду мають бути числами!");
            }
        }

        private void insertNButton_Click(object sender, EventArgs e)
        {
            int[,] pict = new int[dgv.RowCount, dgv.ColumnCount];
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    pict[i, j] = dgv[j, i].Style.BackColor == Color.Black ? 1 : 0;
                }
            }
            bool causesProblem = false;//check if all rows&cols has at least one one
            for (int i = 0; i < dgv.RowCount; i++)
            {
                bool hasOne = false;
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (pict[i, j] == 1)
                    {
                        hasOne = true;
                        break;
                    }
                }
                if (!hasOne)
                {
                    causesProblem = true;
                    break;
                }
            }
            if (!causesProblem)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    bool hasOne = false;
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        if (pict[i, j] == 1)
                        {
                            hasOne = true;
                            break;
                        }
                    }
                    if (!hasOne)
                    {
                        causesProblem = true;
                        break;
                    }
                }
            }
            if (!causesProblem)
            {
                if (ses == null) ses = new NonogramToAddSession(new Nonogram(pict));
                else
                {
                    ses.ModifyNonogram(new Nonogram(pict));

                }
                //MessageBox.Show(ses.NonType.ToString());
                if (ses.NonType == NonogramType.FewSolutions)
                {
                    if (MessageBox.Show("Запропоноване зображення неможливо конвертувати в кросворд з єдиним розв'язком. Спробувати модифікувати " + 
                        "зображення?", "Невдача!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ses.BuildModVariants();
                        if (ses.ModVariants.Count > 0)
                        {
                            ModVarsForm mvForm = new ModVarsForm(this);
                            if (mvForm.ShowDialog() == DialogResult.OK)
                            {
                                DisplayNonogram();
                            }
                        }
                        else
                        {
                            MessageBox.Show("На жаль, дане зображення не вдається модифікувати.");
                        }
                    }
                }
                else if (MessageBox.Show("Даний кросворд є " + (ses.NonType == NonogramType.OnlyILL ? "" : "не") +
                    "розв'язним без використання перебору. Додати в базу?", "Тип кросворду", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    npg.StartWork();
                    npg.Query("insert into nonograms(blocks_descriptions, need_backtracking, author_id, verified) " +
                        "values(array[" + ses.NGram.ToString() + "], " +
                        (ses.NonType == NonogramType.NeedBacktracking ? true : false) + ", " + form1.user.Id + ", false)");
                    MessageBox.Show("Кросворд відправлено на перевірку адміністратором. Після проходження перевірки він буде доступний по ID " +
                        npg.Query("select max(id) from nonograms").Rows[0][0].ToString());
                    npg.FinishWork();
                }
            }
            else
            {
                MessageBox.Show("Помилка! Кожен рядок та кожен стовпчик обов'язково має містити хоча б одну зафарбовану клітинку.");
            }
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearDgvs();
        }
    }
}
