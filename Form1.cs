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
    public partial class Form1 : Form
    {
        const int cellSize = 25;
        public Form1()
        {
            InitializeComponent();
            ResizeDgvs(2, 2, 5, 5);
        }

        private void ResizeDgvs(int maxRowB, int maxColB, int newCC, int newRC)
        {
            for (int i = 0; i < newCC; i++)
            {
                dgvColDesc.Columns.Add(i.ToString(), i.ToString());
                dgvColDesc.Columns[i].Width = cellSize;
                dgvMain.Columns.Add(i.ToString(), i.ToString());
                dgvMain.Columns[i].Width = cellSize;
            }
            for (int i = 0; i < maxColB; i++)
            {
                dgvColDesc.Rows.Add();
            }
            for (int i = 0; i < maxRowB; i++)
            {
                dgvRowDesc.Columns.Add(i.ToString(), i.ToString());
                dgvRowDesc.Columns[i].Width = cellSize;
            }
            for (int i = 0; i < newRC; i++)
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
