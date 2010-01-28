namespace MediaSync
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.loadMediaButton = new System.Windows.Forms.ToolStripButton();
            this.syncMediaButton = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.assetGridView = new System.Windows.Forms.DataGridView();
            this.Poster = new System.Windows.Forms.DataGridViewImageColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 440);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMediaButton,
            this.syncMediaButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // loadMediaButton
            // 
            this.loadMediaButton.Image = ((System.Drawing.Image)(resources.GetObject("loadMediaButton.Image")));
            this.loadMediaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadMediaButton.Name = "loadMediaButton";
            this.loadMediaButton.Size = new System.Drawing.Size(92, 22);
            this.loadMediaButton.Text = "Open Folder";
            this.loadMediaButton.Click += new System.EventHandler(this.loadMediaButton_Click);
            // 
            // syncMediaButton
            // 
            this.syncMediaButton.Image = ((System.Drawing.Image)(resources.GetObject("syncMediaButton.Image")));
            this.syncMediaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.syncMediaButton.Name = "syncMediaButton";
            this.syncMediaButton.Size = new System.Drawing.Size(88, 22);
            this.syncMediaButton.Text = "Sync Media";
            this.syncMediaButton.Click += new System.EventHandler(this.syncMediaButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the base folder where your media lives.";
            // 
            // assetGridView
            // 
            this.assetGridView.AllowUserToAddRows = false;
            this.assetGridView.AllowUserToDeleteRows = false;
            this.assetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assetGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Poster,
            this.Title,
            this.Directory});
            this.assetGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetGridView.Location = new System.Drawing.Point(0, 25);
            this.assetGridView.Name = "assetGridView";
            this.assetGridView.ReadOnly = true;
            this.assetGridView.RowTemplate.Height = 150;
            this.assetGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assetGridView.Size = new System.Drawing.Size(784, 415);
            this.assetGridView.TabIndex = 2;
            // 
            // Poster
            // 
            this.Poster.DataPropertyName = "Poster";
            this.Poster.HeaderText = "Poster";
            this.Poster.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Poster.Name = "Poster";
            this.Poster.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.FillWeight = 96.90722F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Directory
            // 
            this.Directory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Directory.DataPropertyName = "Directory";
            this.Directory.FillWeight = 103.0928F;
            this.Directory.HeaderText = "Directory";
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.assetGridView);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Name = "Main";
            this.Text = "Media Sync";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton loadMediaButton;
        private System.Windows.Forms.ToolStripButton syncMediaButton;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.DataGridView assetGridView;
        private System.Windows.Forms.DataGridViewImageColumn Poster;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
    }
}

