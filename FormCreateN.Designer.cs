namespace Qualifying_work
{
    partial class FormCreateN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.resizeButton = new System.Windows.Forms.Button();
            this.rowCountTB = new System.Windows.Forms.TextBox();
            this.colCountTB = new System.Windows.Forms.TextBox();
            this.insertNButton = new System.Windows.Forms.Button();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(111, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(39, 20);
            this.dgv.TabIndex = 4;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellMouseEnter);
            this.dgv.MouseEnter += new System.EventHandler(this.dgv_MouseEnter);
            // 
            // resizeButton
            // 
            this.resizeButton.Location = new System.Drawing.Point(12, 90);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(75, 45);
            this.resizeButton.TabIndex = 5;
            this.resizeButton.Text = "Змінити розміри";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // rowCountTB
            // 
            this.rowCountTB.Location = new System.Drawing.Point(12, 25);
            this.rowCountTB.Name = "rowCountTB";
            this.rowCountTB.Size = new System.Drawing.Size(45, 20);
            this.rowCountTB.TabIndex = 6;
            // 
            // colCountTB
            // 
            this.colCountTB.Location = new System.Drawing.Point(12, 64);
            this.colCountTB.Name = "colCountTB";
            this.colCountTB.Size = new System.Drawing.Size(45, 20);
            this.colCountTB.TabIndex = 7;
            // 
            // insertNButton
            // 
            this.insertNButton.Location = new System.Drawing.Point(12, 170);
            this.insertNButton.Name = "insertNButton";
            this.insertNButton.Size = new System.Drawing.Size(75, 23);
            this.insertNButton.TabIndex = 8;
            this.insertNButton.Text = "Відправити";
            this.insertNButton.UseVisualStyleBackColor = true;
            this.insertNButton.Click += new System.EventHandler(this.insertNButton_Click);
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Location = new System.Drawing.Point(12, 9);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(38, 13);
            this.labelRows.TabIndex = 9;
            this.labelRows.Text = "Рядки";
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Location = new System.Drawing.Point(12, 48);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(45, 13);
            this.labelCols.TabIndex = 10;
            this.labelCols.Text = "Стовпці";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 141);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Очистити";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormCreateN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.insertNButton);
            this.Controls.Add(this.colCountTB);
            this.Controls.Add(this.rowCountTB);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCreateN";
            this.Text = "Створення кросворду";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.TextBox rowCountTB;
        private System.Windows.Forms.TextBox colCountTB;
        private System.Windows.Forms.Button insertNButton;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.Button buttonClear;
    }
}