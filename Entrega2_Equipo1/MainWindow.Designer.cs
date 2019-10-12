namespace Entrega2_Equipo1
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.importWithLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cleanLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelImages = new System.Windows.Forms.Panel();
			this.contextMenuStripImage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToEditingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFromLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.resolutionLabel = new System.Windows.Forms.Label();
			this.aspectRatioLabel = new System.Windows.Forms.Label();
			this.ClearLabel = new System.Windows.Forms.Label();
			this.ToolbarProgressBar = new System.Windows.Forms.ProgressBar();
			this.pictureChosen = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStripImage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureChosen)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.importWithLabelsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exportAsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.cleanLibraryToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1613, 34);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// importToolStripMenuItem1
			// 
			this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
			this.importToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.importToolStripMenuItem1.Size = new System.Drawing.Size(67, 30);
			this.importToolStripMenuItem1.Text = "Import";
			this.importToolStripMenuItem1.Click += new System.EventHandler(this.ImportOnlyToolStripMenuItem_Click);
			// 
			// importWithLabelsToolStripMenuItem
			// 
			this.importWithLabelsToolStripMenuItem.Name = "importWithLabelsToolStripMenuItem";
			this.importWithLabelsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.importWithLabelsToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
			this.importWithLabelsToolStripMenuItem.Text = "Import with labels";
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(65, 30);
			this.exportToolStripMenuItem.Text = "Export";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
			// 
			// exportAsToolStripMenuItem
			// 
			this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
			this.exportAsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(79, 30);
			this.exportAsToolStripMenuItem.Text = "Export as";
			this.exportAsToolStripMenuItem.Click += new System.EventHandler(this.ExportAsToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(55, 30);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// cleanLibraryToolStripMenuItem
			// 
			this.cleanLibraryToolStripMenuItem.Name = "cleanLibraryToolStripMenuItem";
			this.cleanLibraryToolStripMenuItem.Size = new System.Drawing.Size(88, 30);
			this.cleanLibraryToolStripMenuItem.Text = "Clean Library";
			this.cleanLibraryToolStripMenuItem.Click += new System.EventHandler(this.CleanLibraryToolStripMenuItem_Click);
			// 
			// panelImages
			// 
			this.panelImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelImages.AutoScroll = true;
			this.panelImages.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelImages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelImages.BackgroundImage")));
			this.panelImages.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelImages.Location = new System.Drawing.Point(0, 32);
			this.panelImages.Name = "panelImages";
			this.panelImages.Size = new System.Drawing.Size(612, 700);
			this.panelImages.TabIndex = 3;
			this.panelImages.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelImages_Paint);
			// 
			// contextMenuStripImage
			// 
			this.contextMenuStripImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToEditingAreaToolStripMenuItem,
            this.removeFromLibraryToolStripMenuItem});
			this.contextMenuStripImage.Name = "contextMenuStripImage";
			this.contextMenuStripImage.Size = new System.Drawing.Size(186, 48);
			// 
			// addToEditingAreaToolStripMenuItem
			// 
			this.addToEditingAreaToolStripMenuItem.Name = "addToEditingAreaToolStripMenuItem";
			this.addToEditingAreaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.addToEditingAreaToolStripMenuItem.Text = "Add to Editing Area";
			this.addToEditingAreaToolStripMenuItem.Click += new System.EventHandler(this.AddToEditingAreaToolStripMenuItem_Click);
			// 
			// removeFromLibraryToolStripMenuItem
			// 
			this.removeFromLibraryToolStripMenuItem.Name = "removeFromLibraryToolStripMenuItem";
			this.removeFromLibraryToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.removeFromLibraryToolStripMenuItem.Text = "Remove from Library";
			this.removeFromLibraryToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromLibraryToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.panel1.Controls.Add(this.flowLayoutPanel1);
			this.panel1.Location = new System.Drawing.Point(610, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(247, 729);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.titleLabel);
			this.flowLayoutPanel1.Controls.Add(this.resolutionLabel);
			this.flowLayoutPanel1.Controls.Add(this.aspectRatioLabel);
			this.flowLayoutPanel1.Controls.Add(this.ClearLabel);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(236, 732);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.titleLabel.Location = new System.Drawing.Point(0, 0);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
			this.titleLabel.Size = new System.Drawing.Size(30, 31);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// resolutionLabel
			// 
			this.resolutionLabel.AutoSize = true;
			this.resolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resolutionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.resolutionLabel.Location = new System.Drawing.Point(3, 31);
			this.resolutionLabel.Name = "resolutionLabel";
			this.resolutionLabel.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
			this.resolutionLabel.Size = new System.Drawing.Size(20, 34);
			this.resolutionLabel.TabIndex = 1;
			this.resolutionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// aspectRatioLabel
			// 
			this.aspectRatioLabel.AutoSize = true;
			this.aspectRatioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.aspectRatioLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.aspectRatioLabel.Location = new System.Drawing.Point(3, 65);
			this.aspectRatioLabel.Name = "aspectRatioLabel";
			this.aspectRatioLabel.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
			this.aspectRatioLabel.Size = new System.Drawing.Size(20, 29);
			this.aspectRatioLabel.TabIndex = 2;
			this.aspectRatioLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ClearLabel
			// 
			this.ClearLabel.AutoSize = true;
			this.flowLayoutPanel1.SetFlowBreak(this.ClearLabel, true);
			this.ClearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClearLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClearLabel.Location = new System.Drawing.Point(3, 94);
			this.ClearLabel.Name = "ClearLabel";
			this.ClearLabel.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
			this.ClearLabel.Size = new System.Drawing.Size(20, 29);
			this.ClearLabel.TabIndex = 3;
			this.ClearLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ToolbarProgressBar
			// 
			this.ToolbarProgressBar.Location = new System.Drawing.Point(618, 3);
			this.ToolbarProgressBar.Name = "ToolbarProgressBar";
			this.ToolbarProgressBar.Size = new System.Drawing.Size(148, 23);
			this.ToolbarProgressBar.Step = 1;
			this.ToolbarProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ToolbarProgressBar.TabIndex = 0;
			this.ToolbarProgressBar.Visible = false;
			// 
			// pictureChosen
			// 
			this.pictureChosen.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pictureChosen.Location = new System.Drawing.Point(944, 78);
			this.pictureChosen.Name = "pictureChosen";
			this.pictureChosen.Size = new System.Drawing.Size(510, 517);
			this.pictureChosen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureChosen.TabIndex = 5;
			this.pictureChosen.TabStop = false;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(1613, 729);
			this.Controls.Add(this.pictureChosen);
			this.Controls.Add(this.ToolbarProgressBar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelImages);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(1024, 768);
			this.Name = "MainWindow";
			this.Text = "iFruit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStripImage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureChosen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Panel panelImages;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripImage;
		private System.Windows.Forms.ToolStripMenuItem addToEditingAreaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeFromLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importWithLabelsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar ToolbarProgressBar;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cleanLibraryToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label aspectRatioLabel;
        private System.Windows.Forms.Label ClearLabel;
		private System.Windows.Forms.PictureBox pictureChosen;
	}

}