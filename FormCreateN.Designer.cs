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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.resizeButton = new System.Windows.Forms.Button();
            this.rowCountTB = new System.Windows.Forms.TextBox();
            this.colCountTB = new System.Windows.Forms.TextBox();
            this.insertNButton = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.resizeButton.Location = new System.Drawing.Point(12, 64);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(75, 23);
            this.resizeButton.TabIndex = 5;
            this.resizeButton.Text = "resizeButton";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // rowCountTB
            // 
            this.rowCountTB.Location = new System.Drawing.Point(12, 12);
            this.rowCountTB.Name = "rowCountTB";
            this.rowCountTB.Size = new System.Drawing.Size(45, 20);
            this.rowCountTB.TabIndex = 6;
            // 
            // colCountTB
            // 
            this.colCountTB.Location = new System.Drawing.Point(12, 38);
            this.colCountTB.Name = "colCountTB";
            this.colCountTB.Size = new System.Drawing.Size(45, 20);
            this.colCountTB.TabIndex = 7;
            // 
            // insertNButton
            // 
            this.insertNButton.Location = new System.Drawing.Point(12, 93);
            this.insertNButton.Name = "insertNButton";
            this.insertNButton.Size = new System.Drawing.Size(75, 23);
            this.insertNButton.TabIndex = 8;
            this.insertNButton.Text = "save";
            this.insertNButton.UseVisualStyleBackColor = true;
            this.insertNButton.Click += new System.EventHandler(this.insertNButton_Click);
            // 
            // FormCreateN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.insertNButton);
            this.Controls.Add(this.colCountTB);
            this.Controls.Add(this.rowCountTB);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.dgv);
            this.Name = "FormCreateN";
            this.Text = "FormCreateN";
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
    }
}