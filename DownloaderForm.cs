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
    public partial class DownloaderForm : Form
    {
        Form1 f1;

        public DownloaderForm(Form1 f1_)
        {
            f1 = f1_;
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            int indInRes = 0;
            bool allOk = true;
            DataTable res = new DataTable();
            if (radioButtonID.Checked)
            {
                f1.npg.StartWork();
                try
                {
                    res = f1.npg.Query("select blocks_descriptions, need_backtracking, verified from nonograms where id=" + Convert.ToInt32(textBox1.Text));
                    if (res.Rows.Count < 1)
                    {
                        MessageBox.Show("Помилка! Кросворду з таким Id не існує або він був видалений.");
                        allOk = false;
                    }
                    else if (!Convert.ToBoolean(res.Rows[0][2]))
                    {
                        MessageBox.Show("Помилка! Даний кросворд ще не був перевірений адміністратором.");
                        allOk = false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("ID кросворду має бути числом!");
                    allOk = false;
                }
                finally
                {
                    f1.npg.FinishWork();
                }
            }
            else
            {
                List<string> sizeStr = new List<string>(comboBox1.SelectedItem.ToString().Split('-'));
                if (sizeStr[0][0] == '<')
                {
                    sizeStr.Add(sizeStr[0]);
                    sizeStr[0] = "0";
                    sizeStr[1] = sizeStr[1].Substring(1);
                }
                else if (sizeStr[0][0] == '>')
                {
                    sizeStr[0] = sizeStr[0].Substring(1);
                    sizeStr.Add("1000000");
                }
                f1.npg.StartWork();
                res = f1.npg.Query("select blocks_descriptions, need_backtracking, verified from nonograms where " +
                    "blocks_descriptions[1]*blocks_descriptions[2]>" + sizeStr[0] + " and blocks_descriptions[1]*blocks_descriptions[2]<" + sizeStr[1] + 
                    (checkBoxInclBacktr.Checked ? "" : " and need_backtracking=false"));
                f1.npg.FinishWork();
                if (res.Rows.Count < 1)
                {
                    MessageBox.Show("Помилка! Наразі на жаль немає кросвордів з обраними параметрами.");
                    allOk = false;
                }
                else
                {
                    Random rnd = new Random();
                    indInRes = rnd.Next(0, res.Rows.Count);
                }
            }
            if (allOk)
            {
                var temp_ = res.Rows[indInRes].ItemArray[0];
                int[] blocksDescs = (int[])temp_;
                f1.ses = new NonogramToSolveSession(new Nonogram(blocksDescs, Convert.ToInt32(textBox1.Text)));
                f1.ses.NGram.Type = Convert.ToBoolean(res.Rows[0][1]) ? NonogramType.NeedBacktracking : NonogramType.OnlyILL;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
