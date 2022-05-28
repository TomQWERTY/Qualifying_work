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
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            f1.npg.StartWork();
            DataTable res = f1.npg.Query("select blocks_descriptions, need_backtracking from nonograms where id=" + textBox1.Text);
            var temp_ = res.Rows[0].ItemArray[0];
            int[] blocksDescs = (int[])temp_;
            f1.npg.FinishWork();
            f1.ses = new NonogramToSolveSession(new Nonogram(blocksDescs));
            f1.ses.NGram.Type = Convert.ToBoolean(res.Rows[0][1]) ? NonogramType.NeedBacktracking : NonogramType.OnlyILL;
            this.Close();
        }
    }
}
