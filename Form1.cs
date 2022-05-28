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
using System.Reflection;

namespace Qualifying_work
{
    public partial class Form1 : Form
    {
        const int cellSize = 25;
        public Npg npg;
        int solTime;
        int cNum;
        string time;
        public NonogramToSolveSession ses;
        public User user;

        public Form1(string username_)
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null,
                dgvMain, new object[] { true });
            
            npg = new Npg();
            ResizeDgvs(2, 2, 5, 5);
            cNum = 0;
            time = "";
            //labelUser.Text = username_;
            comboBoxPMode.SelectedIndex = 0;
            comboBoxDiff.SelectedIndex = 2;
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
            ResizeForm();
        }

        private void ResizeForm()
        {
            this.Width = Math.Max(dgvMain.Left + dgvMain.Width + 25, 175 + accountToolStripMenuItem.Width +
                (createToolStripMenuItem.Visible ? createToolStripMenuItem.Width : 0));
            this.Height = Math.Max(dgvMain.Top + dgvMain.Height + 70, groupBox2.Top + groupBox2.Height + 70);
        }

        private void ClearDgvs()
        {
            ClearGameField();
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

        private void MakeGameFieldInactive()
        {
            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                for (int j = 0; j < dgvMain.ColumnCount; j++)
                {
                    if (dgvMain[j, i].Style.BackColor == Color.Black)
                    {
                        dgvMain[j, i].Style.BackColor = Color.DarkGray;
                    }
                }
            }
        }

        private void ClearGameField()
        {
            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                for (int j = 0; j < dgvMain.ColumnCount; j++)
                {
                    dgvMain[j, i].Style.BackColor = Color.Empty;
                }
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int newVal = dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Black ? 1 : 2;
            int opStatus = ses.ChangeCell(e.RowIndex, e.ColumnIndex, newVal);
            if (opStatus == 3 || opStatus == 0 || opStatus == 1)
            {
                if (newVal == 1)
                {
                    dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Black;
                    dgvMain[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.White;
                }
                else
                {
                    dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    dgvMain[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Black;
                }
            }
            dgvMain.ClearSelection();
            if (ses.GetType() == typeof(NTSSWithChecks))
            {
                if (opStatus == 1) MessageBox.Show("you loh");
                if (opStatus == 2) MessageBox.Show("you very loh");
            }
        }

        private void CheckIfCorrect()
        {
            bool ok = ses.CheckByLines(ses.NGram.Picture);
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
                        //npg.Query("update records set r_time = \'" + time + "\', username = \'" + labelUser.Text + "\' where n_name = \'" + cNum + "\'");
                        MessageBox.Show("Вітаємо, Ви встановили новий рекорд! Колишній рекорд: " + readTime);
                    }
                    npg.FinishWork();
                }
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                dgvMain.Enabled = false;
                dgvColDesc.ForeColor = Color.Silver;
                dgvRowDesc.ForeColor = Color.Silver;
                MakeGameFieldInactive();
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

        private void MatchDgvs()
        {
            int maxRowB = ses.NGram.Lines[0].Max().BlockCount;
            int maxColB = ses.NGram.Lines[1].Max().BlockCount;
            ClearDgvs();
            ResizeDgvs(maxRowB, maxColB, ses.NGram.ColumnCount, ses.NGram.RowCount);
            for (int i = 0; i < ses.NGram.RowCount; i++)
            {
                int blockCount = ses.NGram.Lines[0][i].BlockCount;
                for (int t = 0; t < blockCount; t++)
                {
                    dgvRowDesc[maxRowB - blockCount + t, i].Value = ses.NGram.Lines[0][i].BlocksLengths[t];
                }
            }
            for (int j = 0; j < ses.NGram.ColumnCount; j++)
            {
                int blockCount = ses.NGram.Lines[1][j].BlockCount;
                for (int t = 0; t < blockCount; t++)
                {
                    dgvColDesc[j, maxColB - blockCount + t].Value = ses.NGram.Lines[1][j].BlocksLengths[t];
                }
            }
            dgvMain.ClearSelection();
        }

        private void buttonHint_Click(object sender, EventArgs e)
        {
            int[] cell = (ses as NTSSWithHints).OpenCell();
            if (cell[0] != -1)
            {
                dgvMain[cell[1], cell[0]].Style.BackColor = Color.Black;
                ses.ChangeCell(cell[0], cell[1], 1);
            }
            else
            {
                MessageBox.Show("All cells are already colored!");
            }
        }

        private void dgvMain_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain[e.ColumnIndex, e.RowIndex].Style.BackColor != Color.Black)
            {
                dgvMain[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.Black;
            }
            else
            {
                dgvMain[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = Color.White;
            }
        }

        private void dgvMain_MouseEnter(object sender, EventArgs e)
        {
            dgvMain.ClearSelection();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ClearGameField();
            dgvMain.Enabled = true;
            dgvColDesc.ForeColor = Color.Black;
            dgvRowDesc.ForeColor = Color.Black;
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            if (comboBoxDiff.SelectedIndex == 2)
            {
                ses = new NTSSWithChecks(ses.NGram);
            }
            else if (comboBoxDiff.SelectedIndex == 0)
            {
                ses = new NTSSWithHints(ses.NGram);
                groupBox2.Height = 83;
                buttonHint.Visible = true;
            }
            else
            {
                groupBox2.Height = 54;
                buttonHint.Visible = false;
            }
            ses.NGram.PictRestart();
        }

        private void solveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloaderForm df = new DownloaderForm(this);
            df.ShowDialog();
            MatchDgvs();
            dgvMain.Enabled = false;
            dgvColDesc.ForeColor = Color.Silver;
            dgvRowDesc.ForeColor = Color.Silver;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            if (comboBoxPMode.SelectedIndex == 1)
            {
                solTime = 0;
                timer1.Interval = 1000;
                timer1.Start();
                timerLabel.Text = "00:00:00";
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateN fcn = new FormCreateN(this);
            fcn.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string address = openFileDialog1.FileName;
                StreamReader strrd = new StreamReader(address);
                cNum = Convert.ToInt32(strrd.ReadLine()) - 1;
                MatchDgvs();
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    string line = strrd.ReadLine();
                    for (int j = 0; j < dgvMain.ColumnCount; j++)
                    {
                        dgvMain[j, i].Style.BackColor = line[j] == '1' ? Color.Black : Color.Empty;
                    }
                }
                strrd.Close();
                timer1.Stop();
                timerLabel.Text = "";
            }
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FormRecords formR = new FormRecords(npg);
            //formR.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*AutoSolve.Solve(ses.NGram);
            int[,] sol = ses.NGram.CorrectPicture;
            for (int i1 = 0; i1 < dgvMain.RowCount; i1++)
            {
                for (int j1 = 0; j1 < dgvMain.ColumnCount; j1++)
                {
                    if (sol[i1, j1] == 1)
                    //if (Convert.ToBoolean(currSol.Rows[i1][j1]))
                    {
                        dgvMain[j1, i1].Style.BackColor = Color.Black;
                    }
                    else if (sol[i1, j1] == 2)
                    {
                        dgvMain[j1, i1].Style.BackColor = Color.DarkGray;
                    }
                }
            }*/
            Array.Copy(ses.NGram.CorrectPicture, ses.NGram.Picture, ses.NGram.CorrectPicture.Length);
            CheckIfCorrect();
            //int a = 0;
        }

        private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPassword fp = new FormPassword(this, Mode.Create);
            if (fp.ShowDialog() == DialogResult.OK)
            {
                createToolStripMenuItem.Visible = true;
                accountToolStripMenuItem.Text += " (" + user.UserName + ")";
                logInToolStripMenuItem.Visible = false;
                signUpToolStripMenuItem.Visible = false;
                logOutToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = true;
                ResizeForm();
            }
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            FormPassword fp = new FormPassword(this, Mode.Login);
            if (fp.ShowDialog() == DialogResult.OK)
            {
                createToolStripMenuItem.Visible = true;
                accountToolStripMenuItem.Text += " (" + user.UserName + ")";
                logInToolStripMenuItem.Visible = false;
                signUpToolStripMenuItem.Visible = false;
                logOutToolStripMenuItem.Visible = true;
                changePasswordToolStripMenuItem.Visible = true;
                ResizeForm();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user = null;
            createToolStripMenuItem.Visible = false;
            accountToolStripMenuItem.Text = accountToolStripMenuItem.Text.Split(' ')[0];
            logInToolStripMenuItem.Visible = true;
            signUpToolStripMenuItem.Visible = true;
            logOutToolStripMenuItem.Visible = false;
            changePasswordToolStripMenuItem.Visible = false;
            ResizeForm();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPassword fp = new FormPassword(this, Mode.Change);
            fp.ShowDialog();
        }
    }
}