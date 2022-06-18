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
            //labelUser.Text = username_;
            comboBoxPMode.SelectedIndex = 0;
            comboBoxDiff.SelectedIndex = 0;
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
            this.Width = Math.Max(dgvMain.Left + dgvMain.Width + 25, 112 + accountToolStripMenuItem.Width +
                (createToolStripMenuItem.Visible ? createToolStripMenuItem.Width : 0) +
                (recordsToolStripMenuItem.Visible ? recordsToolStripMenuItem.Width : 0) +
                (adminToolStripMenuItem.Visible ? adminToolStripMenuItem.Width : 0));
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
                if (opStatus == 1)
                {
                    MessageBox.Show("Ризикований хід!");
                }
                if (opStatus == 2)
                {
                    MessageBox.Show("Помилка!");
                    if (comboBoxPMode.SelectedIndex == 1)
                    {
                        ses.Score = Math.Max(0, ses.Score - 10);
                        toolStripStatusLabelScore2.Text = ses.Score.ToString();
                    }
                }
                if (opStatus == 0)
                {
                    if (comboBoxPMode.SelectedIndex == 1)
                    {
                        ses.Score += 10;
                        toolStripStatusLabelScore2.Text = ses.Score.ToString();
                    }
                }
            }
            else
            {
                buttonUndo.Enabled = true;
            }
        }

        private void buttonReady_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Кросворд розв'язано правильно! " + "Ваш рахунок - " + ses.Score.ToString()
                        + ". Ваш час - " + toolStripStatusLabelTime2.Text);
                    if (user != null)
                    {
                        npg.StartWork();
                        DataTable oldRes = npg.Query("select score, s_time from records where user_id=" + user.Id + " and nonogram_id=" + ses.NGram.Id + 
                            " and difficulty=" + comboBoxDiff.SelectedIndex);
                        if (oldRes.Rows.Count > 0)
                        {
                            bool update = false;
                            if (ses.Score > Convert.ToInt32(oldRes.Rows[0][0]))
                            {
                                update = true;
                            }
                            else if (ses.Score == Convert.ToInt32(oldRes.Rows[0][0]))
                            {
                                int[] currTime = Array.ConvertAll(oldRes.Rows[0][1].ToString().Split(':'), Convert.ToInt32);
                                if (ses.SolTime < currTime[0] * 3600 + currTime[1] * 60 + currTime[2])
                                {
                                    update = true;
                                }
                            }
                            if (update)
                            {
                                npg.Query("update records set score=" + ses.Score + ", s_time=\'" + toolStripStatusLabelTime2.Text +
                                       "\' where user_id=" + user.Id + " and nonogram_id=" + ses.NGram.Id +
                                       " and difficulty=" + comboBoxDiff.SelectedIndex);
                            }
                        }
                        else
                        {
                            npg.Query("insert into records(score, s_time, user_id, nonogram_id, difficulty) values(" + ses.Score + ", \'" +
                                toolStripStatusLabelTime2.Text + "\', " + user.Id + ", " + ses.NGram.Id + ", " + comboBoxDiff.SelectedIndex + ")");
                        }
                        npg.FinishWork();
                    }
                }
                if (!ses.IsFromLocal)
                {
                    groupBox1.Enabled = true;
                }
                groupBox2.Enabled = false;
                dgvMain.Enabled = false;
                dgvColDesc.ForeColor = Color.Silver;
                dgvRowDesc.ForeColor = Color.Silver;
                MakeGameFieldInactive();
            }
            else
            {
                if (comboBoxPMode.SelectedIndex == 1)
                {
                    ses.Score = Math.Max(0, ses.Score - 10);
                    toolStripStatusLabelScore2.Text = ses.Score.ToString();
                }
                MessageBox.Show("Кросворд розв'язано неправильно!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ses.SolTime++;
            string time = (ses.SolTime / 3600).ToString().PadLeft(2, '0') + ":";
            int noHours = ses.SolTime % 3600;
            time += (noHours / 60).ToString().PadLeft(2, '0') + ":" + (noHours % 60).ToString().PadLeft(2, '0');
            toolStripStatusLabelTime2.Text = time;
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
                buttonUndo.Enabled = true;
                dgvMain[cell[1], cell[0]].Style.BackColor = Color.Black;
                ses.ChangeCell(cell[0], cell[1], 1);
                ses.Score = Math.Max(0, ses.Score - 10);
                toolStripStatusLabelScore2.Text = ses.Score.ToString();
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
            ses.NGram.PictRestart();
            if (comboBoxDiff.SelectedIndex == 2)
            {
                ses = new NTSSWithChecks(ses.NGram);
                groupBox2.Height = 83;
                buttonHint.Visible = false;
                buttonUndo.Visible = false;
            }
            else if (comboBoxDiff.SelectedIndex == 0)
            {
                ses = new NTSSWithHints(ses.NGram);
                groupBox2.Height = 139;
                buttonHint.Visible = true;
                buttonUndo.Visible = true;
            }
            else
            {
                ses = new NonogramToSolveSession(ses.NGram);
                groupBox2.Height = 114;
                buttonHint.Visible = false;
                buttonUndo.Visible = true;
            }
            ResizeForm();
            
            if (comboBoxPMode.SelectedIndex == 1)
            {
                ses.SolTime = 0;
                timer1.Interval = 1000;
                timer1.Start();
                toolStripStatusLabelTime2.Text = "00:00:00";
                switch (comboBoxDiff.SelectedIndex)
                {
                    case (0):
                        {
                            ses.Score = ses.NGram.BlackCount / 2 * 10;
                            break;
                        }
                    case (1):
                        {
                            ses.Score = 100;
                            break;
                        }
                    case (2):
                        {
                            ses.Score = 0;
                            break;
                        }
                }
                toolStripStatusLabelScore2.Text = ses.Score.ToString();
            }
            else
            {
                toolStripStatusLabelTime2.Text = "";
            }
        }

        private void solveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloaderForm df = new DownloaderForm(this);
            if (df.ShowDialog() == DialogResult.OK)
            {
                Stop();
                if (ses.NGram.Type == NonogramType.NeedBacktracking)
                {
                    if (comboBoxDiff.Items.Count > 2)
                    {
                        comboBoxDiff.Items.RemoveAt(2);
                    }
                }
                else
                {
                    if (comboBoxDiff.Items.Count < 3)
                    {
                        comboBoxDiff.Items.Add("With Checks");
                    }
                }
                MatchDgvs();
                dgvMain.Enabled = false;
                dgvColDesc.ForeColor = Color.Silver;
                dgvRowDesc.ForeColor = Color.Silver;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                recordsToolStripMenuItem.Visible = true;
                ResizeForm();
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateN fcn = new FormCreateN(this);
            fcn.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (buttonReady.Enabled)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string address = saveFileDialog1.FileName;
                    StreamWriter strwr = new StreamWriter(address);
                    strwr.WriteLine(comboBoxDiff.SelectedIndex);
                    strwr.WriteLine(ses.NGram.Type == NonogramType.OnlyILL ? 0 : 1);
                    strwr.WriteLine(ses.NGram.ToString());
                    for (int i = 0; i < dgvMain.RowCount; i++)
                    {
                        for (int j = 0; j < dgvMain.ColumnCount; j++)
                        {
                            strwr.Write(dgvMain[j, i].Style.BackColor == Color.Black ? '1' : '0');
                        }
                        strwr.WriteLine();
                    }
                    if (ses.GetType() == typeof(NTSSWithChecks) || ses.GetType() == typeof(NTSSWithHints))
                    {
                        for (int i = 0; i < ses.NGram.RowCount; i++)
                        {
                            for (int j = 0; j < ses.NGram.ColumnCount; j++)
                            {
                                strwr.Write(ses.NGram.Picture[i, j]);
                            }
                            strwr.WriteLine();
                        }
                    }
                    if (ses.GetType() == typeof(NTSSWithHints))
                    {
                        //(ses as NTSSWithHints).FailedCells.
                    }
                    strwr.Close();
                }
            }
            else
            {
                MessageBox.Show("Розв'язування не запущене!");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string address = openFileDialog1.FileName;
                StreamReader strrd = new StreamReader(address);
                int diff = Convert.ToInt32(strrd.ReadLine());
                bool onlyILL = strrd.ReadLine() == "0";
                switch (diff)
                {
                    case (0):
                        {
                            ses = new NonogramToSolveSession(new Nonogram(strrd.ReadLine()), true);
                            break;
                        }
                    case (1):
                        {
                            ses = new NTSSWithHints(new Nonogram(strrd.ReadLine()), true);
                            break;
                        }
                    case (2):
                        {
                            ses = new NTSSWithChecks(new Nonogram(strrd.ReadLine()), true);
                            break;
                        }
                }
                MatchDgvs();
                for (int i = 0; i < dgvMain.RowCount; i++)
                {
                    string line = strrd.ReadLine();
                    for (int j = 0; j < dgvMain.ColumnCount; j++)
                    {
                        dgvMain[j, i].Style.BackColor = line[j] == '1' ? Color.Black : Color.Empty;
                    }
                }
                if (ses.GetType() == typeof(NTSSWithChecks) || ses.GetType() == typeof(NTSSWithHints))
                {
                    for (int i = 0; i < ses.NGram.RowCount; i++)
                    {
                        string line = strrd.ReadLine();
                        for (int j = 0; j < ses.NGram.ColumnCount; j++)
                        {
                            ses.NGram.Picture[i, j] = Convert.ToInt32(line[j].ToString());
                        }
                    }
                }
                strrd.Close();
                timer1.Stop();
                toolStripStatusLabelScore2.Text = "";
                toolStripStatusLabelTime2.Text = "";
                dgvMain.Enabled = true;
                dgvColDesc.ForeColor = Color.Black;
                dgvRowDesc.ForeColor = Color.Black;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                comboBoxPMode.SelectedIndex = 0;
                comboBoxDiff.SelectedIndex = diff;
                ResizeForm();
            }
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(npg, ses.NGram.Id);
            form2.ShowDialog();
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
                if (user.IsAdmin)
                {
                    adminToolStripMenuItem.Visible = true;
                }
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
            adminToolStripMenuItem.Visible = false;
            ClearDgvs();
            Stop();
            SetToInit();
            ResizeForm();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPassword fp = new FormPassword(this, Mode.Change);
            fp.ShowDialog();
        }

        private void verifyNonogramsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            npg.StartWork();
            DataTable res = npg.Query("select * from nonograms where id=(select min(id) from (select * from nonograms where verified=false) as unver)");
            npg.FinishWork();
            if (res.Rows.Count > 0)
            {
                int nonId = Convert.ToInt32(res.Rows[0][0]);
                var temp_ = res.Rows[0].ItemArray[1];
                int[] blocksDescs = (int[])temp_;
                VerifyNonForm vnf = new VerifyNonForm(blocksDescs, nonId);
                DialogResult dr = vnf.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    npg.StartWork();
                    npg.Query("update nonograms set verified=true where id=" + nonId);
                    npg.FinishWork();
                }
                else if (dr == DialogResult.No)
                {
                    npg.StartWork();
                    npg.Query("delete from nonograms where id=" + nonId);
                    npg.FinishWork();
                }
            }
            else
            {
                MessageBox.Show("Наразі немає неперевірених кросвордів.");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            ClearGameField();
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            dgvMain.Enabled = false;
            dgvColDesc.ForeColor = Color.Silver;
            dgvRowDesc.ForeColor = Color.Silver;
            MakeGameFieldInactive();
            timer1.Stop();
            toolStripStatusLabelTime2.Text = "";
            toolStripStatusLabelScore2.Text = "";
            if (ses != null && ses.IsFromLocal)
            {
                SetToInit();
            }
        }

        private void SetToInit()
        {
            ResizeDgvs(2, 2, 5, 5);
            ClearDgvs();
            groupBox2.Height = 114;
            buttonHint.Visible = false;
            groupBox1.Enabled = false;
            buttonUndo.Enabled = false;
            ses = null;
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            int temp = ses.LastStep;
            int i = temp / ses.NGram.ColumnCount;
            int j = temp % ses.NGram.ColumnCount;
            int oldVal = 2;
            if (dgvMain[j, i].Style.BackColor == Color.Black)
            {
                dgvMain[j, i].Style.BackColor = Color.White;
                oldVal = 1;
            }
            else
            {
                dgvMain[j, i].Style.BackColor = Color.Black;
            }
            ses.UndoStep(oldVal);
            if (ses.SavedStepsCount == 0)
            {
                buttonUndo.Enabled = false;
            }
        }
    }
}