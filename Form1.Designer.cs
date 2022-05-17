
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.button1 = new System.Windows.Forms.Button();
            this.createNButton = new System.Windows.Forms.Button();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColDesc.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColDesc.Enabled = false;
            this.dgvColDesc.Location = new System.Drawing.Point(90, 10);
            this.dgvColDesc.MultiSelect = false;
            this.dgvColDesc.Name = "dgvColDesc";
            this.dgvColDesc.ReadOnly = true;
            this.dgvColDesc.RowHeadersVisible = false;
            this.dgvColDesc.RowTemplate.Height = 25;
            this.dgvColDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvColDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvColDesc.Size = new System.Drawing.Size(168, 62);
            this.dgvColDesc.TabIndex = 0;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(10, 140);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 20);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Завантажити";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(10, 77);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(75, 20);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRowDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRowDesc.Enabled = false;
            this.dgvRowDesc.Location = new System.Drawing.Point(90, 85);
            this.dgvRowDesc.MultiSelect = false;
            this.dgvRowDesc.Name = "dgvRowDesc";
            this.dgvRowDesc.ReadOnly = true;
            this.dgvRowDesc.RowHeadersVisible = false;
            this.dgvRowDesc.RowTemplate.Height = 25;
            this.dgvRowDesc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRowDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRowDesc.Size = new System.Drawing.Size(30, 23);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.Location = new System.Drawing.Point(321, 10);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 25;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMain.Size = new System.Drawing.Size(39, 20);
            this.dgvMain.TabIndex = 4;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellMouseEnter);
            this.dgvMain.MouseEnter += new System.EventHandler(this.dgvMain_MouseEnter);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(10, 36);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 13);
            this.timerLabel.TabIndex = 5;
            // 
            // buttonRecords
            // 
            this.buttonRecords.Location = new System.Drawing.Point(10, 102);
            this.buttonRecords.Name = "buttonRecords";
            this.buttonRecords.Size = new System.Drawing.Size(75, 20);
            this.buttonRecords.TabIndex = 6;
            this.buttonRecords.Text = "Рекорди";
            this.buttonRecords.UseVisualStyleBackColor = true;
            this.buttonRecords.Click += new System.EventHandler(this.buttonRecords_Click);
            // 
            // labelUT
            // 
            this.labelUT.AutoSize = true;
            this.labelUT.Location = new System.Drawing.Point(10, 8);
            this.labelUT.Name = "labelUT";
            this.labelUT.Size = new System.Drawing.Size(68, 13);
            this.labelUT.TabIndex = 7;
            this.labelUT.Text = "Користувач:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(10, 21);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 13);
            this.labelUser.TabIndex = 8;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(10, 165);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 20);
            this.buttonWrite.TabIndex = 9;
            this.buttonWrite.Text = "Записати";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(10, 190);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 20);
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
            this.comboBoxPMode.Location = new System.Drawing.Point(10, 52);
            this.comboBoxPMode.Name = "comboBoxPMode";
            this.comboBoxPMode.Size = new System.Drawing.Size(75, 21);
            this.comboBoxPMode.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // createNButton
            // 
            this.createNButton.Location = new System.Drawing.Point(10, 245);
            this.createNButton.Name = "createNButton";
            this.createNButton.Size = new System.Drawing.Size(75, 23);
            this.createNButton.TabIndex = 13;
            this.createNButton.Text = "create new";
            this.createNButton.UseVisualStyleBackColor = true;
            this.createNButton.Click += new System.EventHandler(this.createNButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 308);
            this.Controls.Add(this.createNButton);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button createNButton;
    }
}

