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
			this.panelImages = new System.Windows.Forms.Panel();
			this.contextMenuStripImage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToEditingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFromLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ResolutionLabel = new System.Windows.Forms.Label();
			this.SelectedImageName = new System.Windows.Forms.Label();
			this.ToolbarProgressBar = new System.Windows.Forms.ProgressBar();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStripImage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.importWithLabelsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exportAsToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1008, 34);
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
			// 
			// exportAsToolStripMenuItem
			// 
			this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
			this.exportAsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(79, 30);
			this.exportAsToolStripMenuItem.Text = "Export as";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 4);
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(55, 30);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// panelImages
			// 
			this.panelImages.AutoScroll = true;
			this.panelImages.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panelImages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelImages.BackgroundImage")));
			this.panelImages.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelImages.Location = new System.Drawing.Point(0, 32);
			this.panelImages.Name = "panelImages";
			this.panelImages.Size = new System.Drawing.Size(774, 700);
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
			this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.panel1.Controls.Add(this.ResolutionLabel);
			this.panel1.Controls.Add(this.SelectedImageName);
			this.panel1.Location = new System.Drawing.Point(772, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(236, 732);
			this.panel1.TabIndex = 4;
			// 
			// ResolutionLabel
			// 
			this.ResolutionLabel.AutoSize = true;
			this.ResolutionLabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResolutionLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.ResolutionLabel.Location = new System.Drawing.Point(18, 59);
			this.ResolutionLabel.Name = "ResolutionLabel";
			this.ResolutionLabel.Size = new System.Drawing.Size(0, 24);
			this.ResolutionLabel.TabIndex = 1;
			// 
			// SelectedImageName
			// 
			this.SelectedImageName.AutoSize = true;
			this.SelectedImageName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.SelectedImageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SelectedImageName.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.SelectedImageName.Location = new System.Drawing.Point(18, 25);
			this.SelectedImageName.Name = "SelectedImageName";
			this.SelectedImageName.Size = new System.Drawing.Size(0, 24);
			this.SelectedImageName.TabIndex = 0;
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
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(1008, 729);
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
			this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label SelectedImageName;
        private System.Windows.Forms.ProgressBar ToolbarProgressBar;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label ResolutionLabel;
	}

}