namespace ManagerVanzari
{
    partial class VanzariAzi
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VanzariAzi));
            this.panelContent = new System.Windows.Forms.Panel();
            this.dataGridViewVanzari = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxMenuV = new System.Windows.Forms.PictureBox();
            this.labelTitluVanzari = new System.Windows.Forms.Label();
            this.contextMenuStripStergeVanzare = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SergeVanzareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PretCumparare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PretVanzare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVanzari)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuV)).BeginInit();
            this.contextMenuStripStergeVanzare.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelContent.Controls.Add(this.dataGridViewVanzari);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 75);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(25, 10, 25, 10);
            this.panelContent.Size = new System.Drawing.Size(1008, 654);
            this.panelContent.TabIndex = 41;
            // 
            // dataGridViewVanzari
            // 
            this.dataGridViewVanzari.AllowUserToAddRows = false;
            this.dataGridViewVanzari.AllowUserToResizeColumns = false;
            this.dataGridViewVanzari.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewVanzari.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVanzari.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.dataGridViewVanzari.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewVanzari.CausesValidation = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVanzari.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewVanzari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVanzari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nume,
            this.Descriere,
            this.PretCumparare,
            this.PretVanzare,
            this.Deleted});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewVanzari.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewVanzari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVanzari.EnableHeadersVisualStyles = false;
            this.dataGridViewVanzari.GridColor = System.Drawing.Color.White;
            this.dataGridViewVanzari.Location = new System.Drawing.Point(25, 10);
            this.dataGridViewVanzari.MultiSelect = false;
            this.dataGridViewVanzari.Name = "dataGridViewVanzari";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewVanzari.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewVanzari.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewVanzari.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewVanzari.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewVanzari.RowTemplate.Height = 25;
            this.dataGridViewVanzari.Size = new System.Drawing.Size(958, 634);
            this.dataGridViewVanzari.TabIndex = 5;
            this.dataGridViewVanzari.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewVanzari_CellMouseUp);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.panelHeader.Controls.Add(this.pictureBoxMenuV);
            this.panelHeader.Controls.Add(this.labelTitluVanzari);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1008, 75);
            this.panelHeader.TabIndex = 40;
            // 
            // pictureBoxMenuV
            // 
            this.pictureBoxMenuV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBoxMenuV.Image = global::ManagerVanzari.Properties.Resources.icons8_average_2_64;
            this.pictureBoxMenuV.Location = new System.Drawing.Point(408, 15);
            this.pictureBoxMenuV.Name = "pictureBoxMenuV";
            this.pictureBoxMenuV.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxMenuV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMenuV.TabIndex = 32;
            this.pictureBoxMenuV.TabStop = false;
            // 
            // labelTitluVanzari
            // 
            this.labelTitluVanzari.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTitluVanzari.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitluVanzari.ForeColor = System.Drawing.Color.White;
            this.labelTitluVanzari.Location = new System.Drawing.Point(0, 15);
            this.labelTitluVanzari.Name = "labelTitluVanzari";
            this.labelTitluVanzari.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.labelTitluVanzari.Size = new System.Drawing.Size(1008, 60);
            this.labelTitluVanzari.TabIndex = 4;
            this.labelTitluVanzari.Text = "Vanzari (azi)";
            this.labelTitluVanzari.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStripStergeVanzare
            // 
            this.contextMenuStripStergeVanzare.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SergeVanzareToolStripMenuItem});
            this.contextMenuStripStergeVanzare.Name = "contextMenuStripStergeProdus";
            this.contextMenuStripStergeVanzare.Size = new System.Drawing.Size(151, 26);
            // 
            // SergeVanzareToolStripMenuItem
            // 
            this.SergeVanzareToolStripMenuItem.Name = "SergeVanzareToolStripMenuItem";
            this.SergeVanzareToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.SergeVanzareToolStripMenuItem.Text = "Sterge vanzare";
            this.SergeVanzareToolStripMenuItem.Click += new System.EventHandler(this.SergeVanzareToolStripMenuItem_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "IdVanzare";
            this.Id.FillWeight = 43.01075F;
            this.Id.HeaderText = "#";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // Nume
            // 
            this.Nume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nume.DataPropertyName = "DataOraVanzare";
            this.Nume.FillWeight = 164.8094F;
            this.Nume.HeaderText = "Data/Ora";
            this.Nume.Name = "Nume";
            this.Nume.ReadOnly = true;
            // 
            // Descriere
            // 
            this.Descriere.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descriere.DataPropertyName = "NumeClient";
            this.Descriere.FillWeight = 150.5501F;
            this.Descriere.HeaderText = "Client";
            this.Descriere.Name = "Descriere";
            this.Descriere.ReadOnly = true;
            // 
            // PretCumparare
            // 
            this.PretCumparare.DataPropertyName = "PretTotal";
            dataGridViewCellStyle3.Format = "N2";
            this.PretCumparare.DefaultCellStyle = dataGridViewCellStyle3;
            this.PretCumparare.FillWeight = 100.3759F;
            this.PretCumparare.HeaderText = "Pret total";
            this.PretCumparare.Name = "PretCumparare";
            this.PretCumparare.ReadOnly = true;
            this.PretCumparare.Width = 80;
            // 
            // PretVanzare
            // 
            this.PretVanzare.DataPropertyName = "NumarInmatriculare";
            dataGridViewCellStyle4.Format = "N2";
            this.PretVanzare.DefaultCellStyle = dataGridViewCellStyle4;
            this.PretVanzare.FillWeight = 80.73859F;
            this.PretVanzare.HeaderText = "Nr masina";
            this.PretVanzare.Name = "PretVanzare";
            this.PretVanzare.ReadOnly = true;
            this.PretVanzare.Width = 110;
            // 
            // Deleted
            // 
            this.Deleted.DataPropertyName = "Deleted";
            this.Deleted.HeaderText = "Sters";
            this.Deleted.Name = "Deleted";
            this.Deleted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Deleted.Visible = false;
            // 
            // VanzariAzi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "VanzariAzi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vanzari (azi)";
            this.Load += new System.EventHandler(this.VanzariAzi_Form_Load);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVanzari)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenuV)).EndInit();
            this.contextMenuStripStergeVanzare.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.DataGridView dataGridViewVanzari;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxMenuV;
        private System.Windows.Forms.Label labelTitluVanzari;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStergeVanzare;
        private System.Windows.Forms.ToolStripMenuItem SergeVanzareToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriere;
        private System.Windows.Forms.DataGridViewTextBoxColumn PretCumparare;
        private System.Windows.Forms.DataGridViewTextBoxColumn PretVanzare;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Deleted;
    }
}