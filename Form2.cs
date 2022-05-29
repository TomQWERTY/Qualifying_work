using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Threading;
using System.Globalization;

namespace Qualifying_work
{
    public partial class Form2 : Form
    {
        Npg npg;
        int nonId;
        DataTable[] d;

        public Form2(Npg npg_, int nonId_)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            nonId = nonId_;
            npg = npg_;
            d = new DataTable[3];
            InitializeComponent();
            npg.StartWork();
            d[0] = npg.Query("select user_id, score, s_time from records where difficulty=0");
            d[1] = npg.Query("select user_id, score, s_time from records where difficulty=1");
            d[2] = npg.Query("select user_id, score, s_time from records where difficulty=2");
            npg.FinishWork();
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = d[comboBox1.SelectedIndex];
            SetProperSizes();
        }

        private void SetProperSizes()
        {
            dataGridView1.Height = Math.Min(dataGridView1.Rows.Count * dataGridView1.Rows[0].Height + 40, Screen.PrimaryScreen.Bounds.Height - 70);
            this.Height = dataGridView1.Height + 90;
            dataGridView1.Width = Math.Min(dataGridView1.Columns.Count * dataGridView1.Columns[0].Width + 5, Screen.PrimaryScreen.Bounds.Width - 70);
            this.Width = dataGridView1.Width + 50;
            dataGridView1.ClearSelection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = d[comboBox1.SelectedIndex];
            SetProperSizes();
        }
    }
}
