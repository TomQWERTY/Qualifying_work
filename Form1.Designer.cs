
namespace Qualifying_work
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvColDesc = new System.Windows.Forms.DataGridView();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonReady = new System.Windows.Forms.Button();
            this.dgvRowDesc = new System.Windows.Forms.DataGridView();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.buttonRecords = new System.Windows.Forms.Button();
            this.labelUT = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBoxPMode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColDesc
            // 
            this.dgvColDesc.AllowUserToAddRows = false;
            this.dgvColDesc.AllowUserToDeleteRows = false;
            this.dgvColDesc.AllowUserToResizeColumns = false;
            this.dgvColDesc.AllowUserToResizeRows = false;
            this.dgvColDesc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvColDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvColDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColDesc.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColDesc.Enabled = false;
            this.dgvColDesc.Location = new System.Drawing.Point(105, 12);
            this.dgvColDesc.MultiSelect = false;
            this.dgvColDesc.Name = "dgvColDesc";
            this.dgvColDesc.ReadOnly = true;
            this.dgvColDesc.RowHeadersVisible = false;
            this.dgvColDesc.RowTemplate.Height = 25;
            this.dgvColDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvColDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvColDesc.Size = new System.Drawing.Size(196, 71);
            this.dgvColDesc.TabIndex = 0;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(12, 161);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(87, 23);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Завантажити";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(12, 89);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(87, 23);
            this.buttonReady.TabIndex = 2;
            this.buttonReady.Text = "Готово!";
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // dgvRowDesc
            // 
            this.dgvRowDesc.AllowUserToAddRows = false;
            this.dgvRowDesc.AllowUserToDeleteRows = false;
            this.dgvRowDesc.AllowUserToResizeColumns = false;
            this.dgvRowDesc.AllowUserToResizeRows = false;
            this.dgvRowDesc.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRowDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRowDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRowDesc.ColumnHeadersVisible = false;
            this.dgvRowDesc.Enabled = false;
            this.dgvRowDesc.Location = new System.Drawing.Point(105, 98);
            this.dgvRowDesc.MultiSelect = false;
            this.dgvRowDesc.Name = "dgvRowDesc";
            this.dgvRowDesc.ReadOnly = true;
            this.dgvRowDesc.RowHeadersVisible = false;
            this.dgvRowDesc.RowTemplate.Height = 25;
            this.dgvRowDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRowDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRowDesc.Size = new System.Drawing.Size(35, 27);
            this.dgvRowDesc.TabIndex = 3;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.Location = new System.Drawing.Point(375, 12);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 25;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMain.Size = new System.Drawing.Size(46, 23);
            this.dgvMain.TabIndex = 4;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(12, 42);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 15);
            this.timerLabel.TabIndex = 5;
            // 
            // buttonRecords
            // 
            this.buttonRecords.Location = new System.Drawing.Point(12, 118);
            this.buttonRecords.Name = "buttonRecords";
            this.buttonRecords.Size = new System.Drawing.Size(87, 23);
            this.buttonRecords.TabIndex = 6;
            this.buttonRecords.Text = "Рекорди";
            this.buttonRecords.UseVisualStyleBackColor = true;
            this.buttonRecords.Click += new System.EventHandler(this.buttonRecords_Click);
            // 
            // labelUT
            // 
            this.labelUT.AutoSize = true;
            this.labelUT.Location = new System.Drawing.Point(12, 9);
            this.labelUT.Name = "labelUT";
            this.labelUT.Size = new System.Drawing.Size(74, 15);
            this.labelUT.TabIndex = 7;
            this.labelUT.Text = "Користувач:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 24);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 15);
            this.labelUser.TabIndex = 8;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(12, 190);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(87, 23);
            this.buttonWrite.TabIndex = 9;
            this.buttonWrite.Text = "Записати";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(12, 219);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(87, 23);
            this.buttonRead.TabIndex = 10;
            this.buttonRead.Text = "Зчитати";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // comboBoxPMode
            // 
            this.comboBoxPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPMode.FormattingEnabled = true;
            this.comboBoxPMode.Items.AddRange(new object[] {
            "Тренувальний",
            "Змагальний"});
            this.comboBoxPMode.Location = new System.Drawing.Point(12, 60);
            this.comboBoxPMode.Name = "comboBoxPMode";
            this.comboBoxPMode.Size = new System.Drawing.Size(87, 23);
            this.comboBoxPMode.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 250);
            this.Controls.Add(this.comboBoxPMode);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelUT);
            this.Controls.Add(this.buttonRecords);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.dgvRowDesc);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.dgvColDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColDesc;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.DataGridView dgvRowDesc;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button buttonRecords;
        private System.Windows.Forms.Label labelUT;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBoxPMode;
    }
}

