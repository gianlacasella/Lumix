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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importAndAddDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panelImages = new System.Windows.Forms.Panel();
			this.contextMenuStripImage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToEditingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFromLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStripImage.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// filesToolStripMenuItem
			// 
			this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.refreshToolStripMenuItem});
			this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
			this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.filesToolStripMenuItem.Text = "Files";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importAndAddDataToolStripMenuItem,
            this.importOnlyToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.importToolStripMenuItem.Text = "Import";
			// 
			// importAndAddDataToolStripMenuItem
			// 
			this.importAndAddDataToolStripMenuItem.Name = "importAndAddDataToolStripMenuItem";
			this.importAndAddDataToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.importAndAddDataToolStripMenuItem.Text = "Import and add Data";
			// 
			// importOnlyToolStripMenuItem
			// 
			this.importOnlyToolStripMenuItem.Name = "importOnlyToolStripMenuItem";
			this.importOnlyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.importOnlyToolStripMenuItem.Text = "Import only";
			this.importOnlyToolStripMenuItem.Click += new System.EventHandler(this.ImportOnlyToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.exportToolStripMenuItem.Text = "Export";
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
			// 
			// panelImages
			// 
			this.panelImages.AutoScroll = true;
			this.panelImages.Cursor = System.Windows.Forms.Cursors.Hand;
			this.panelImages.Location = new System.Drawing.Point(0, 27);
			this.panelImages.Name = "panelImages";
			this.panelImages.Size = new System.Drawing.Size(601, 690);
			this.panelImages.TabIndex = 3;
			this.panelImages.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelImages_Paint);
			// 
			// contextMenuStripImage
			// 
			this.contextMenuStripImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToEditingAreaToolStripMenuItem,
            this.imageDetailsToolStripMenuItem,
            this.removeFromLibraryToolStripMenuItem});
			this.contextMenuStripImage.Name = "contextMenuStripImage";
			this.contextMenuStripImage.Size = new System.Drawing.Size(186, 70);
			// 
			// addToEditingAreaToolStripMenuItem
			// 
			this.addToEditingAreaToolStripMenuItem.Name = "addToEditingAreaToolStripMenuItem";
			this.addToEditingAreaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.addToEditingAreaToolStripMenuItem.Text = "Add to Editing Area";
			// 
			// imageDetailsToolStripMenuItem
			// 
			this.imageDetailsToolStripMenuItem.Name = "imageDetailsToolStripMenuItem";
			this.imageDetailsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.imageDetailsToolStripMenuItem.Text = "Image details";
			// 
			// removeFromLibraryToolStripMenuItem
			// 
			this.removeFromLibraryToolStripMenuItem.Name = "removeFromLibraryToolStripMenuItem";
			this.removeFromLibraryToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.removeFromLibraryToolStripMenuItem.Text = "Remove from Library";
			this.removeFromLibraryToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromLibraryToolStripMenuItem_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.panelImages);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(1024, 768);
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStripImage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importAndAddDataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importOnlyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.Panel panelImages;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripImage;
		private System.Windows.Forms.ToolStripMenuItem addToEditingAreaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageDetailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeFromLibraryToolStripMenuItem;
	}
}