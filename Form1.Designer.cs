
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
            this.dgvColDesc = new System.Windows.Forms.DataGridView();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonReady = new System.Windows.Forms.Button();
            this.dgvRowDesc = new System.Windows.Forms.DataGridView();
            this.dgvMain = new System.Windows.Forms.DataGridView();
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
            this.buttonDownload.Location = new System.Drawing.Point(12, 12);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(87, 23);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Завантажити";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonReady
            // 
            this.buttonReady.Location = new System.Drawing.Point(12, 41);
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
            this.dgvMain.Location = new System.Drawing.Point(375, 12);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 25;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMain.Size = new System.Drawing.Size(46, 23);
            this.dgvMain.TabIndex = 4;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.dgvRowDesc);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.dgvColDesc);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColDesc;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.DataGridView dgvRowDesc;
        private System.Windows.Forms.DataGridView dgvMain;
    }
}

