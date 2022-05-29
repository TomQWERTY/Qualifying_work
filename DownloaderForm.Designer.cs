namespace Qualifying_work
{
    partial class DownloaderForm
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
            this.radioButtonRand = new System.Windows.Forms.RadioButton();
            this.radioButtonID = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelLoad = new System.Windows.Forms.Label();
            this.checkBoxInclBacktr = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // radioButtonRand
            // 
            this.radioButtonRand.AutoSize = true;
            this.radioButtonRand.Location = new System.Drawing.Point(12, 50);
            this.radioButtonRand.Name = "radioButtonRand";
            this.radioButtonRand.Size = new System.Drawing.Size(232, 17);
            this.radioButtonRand.TabIndex = 0;
            this.radioButtonRand.Text = "Випадковий (оберіть кількість клітинок): ";
            this.radioButtonRand.UseVisualStyleBackColor = true;
            // 
            // radioButtonID
            // 
            this.radioButtonID.AutoSize = true;
            this.radioButtonID.Checked = true;
            this.radioButtonID.Location = new System.Drawing.Point(12, 25);
            this.radioButtonID.Name = "radioButtonID";
            this.radioButtonID.Size = new System.Drawing.Size(52, 17);
            this.radioButtonID.TabIndex = 1;
            this.radioButtonID.TabStop = true;
            this.radioButtonID.Text = "За ID";
            this.radioButtonID.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "3";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(12, 96);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(91, 23);
            this.buttonDownload.TabIndex = 3;
            this.buttonDownload.Text = "Завантажити";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "<40",
            "40-100",
            "100-200",
            "200-400",
            ">400"});
            this.comboBox1.Location = new System.Drawing.Point(250, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(61, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // labelLoad
            // 
            this.labelLoad.AutoSize = true;
            this.labelLoad.Location = new System.Drawing.Point(12, 9);
            this.labelLoad.Name = "labelLoad";
            this.labelLoad.Size = new System.Drawing.Size(77, 13);
            this.labelLoad.TabIndex = 5;
            this.labelLoad.Text = "Завантажити:";
            // 
            // checkBoxInclBacktr
            // 
            this.checkBoxInclBacktr.AutoSize = true;
            this.checkBoxInclBacktr.Location = new System.Drawing.Point(24, 73);
            this.checkBoxInclBacktr.Name = "checkBoxInclBacktr";
            this.checkBoxInclBacktr.Size = new System.Drawing.Size(316, 17);
            this.checkBoxInclBacktr.TabIndex = 6;
            this.checkBoxInclBacktr.Text = "Включати кросворди, що не розв\'язуються без перебору";
            this.checkBoxInclBacktr.UseVisualStyleBackColor = true;
            // 
            // DownloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 133);
            this.Controls.Add(this.checkBoxInclBacktr);
            this.Controls.Add(this.labelLoad);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButtonID);
            this.Controls.Add(this.radioButtonRand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DownloaderForm";
            this.Text = "Завантаження кросворду";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonRand;
        private System.Windows.Forms.RadioButton radioButtonID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelLoad;
        private System.Windows.Forms.CheckBox checkBoxInclBacktr;
    }
}