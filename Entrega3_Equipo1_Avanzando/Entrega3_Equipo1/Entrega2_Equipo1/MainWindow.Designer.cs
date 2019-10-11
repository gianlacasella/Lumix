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
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelImages = new System.Windows.Forms.Panel();
            this.contextMenuStripImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToEditingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importWithLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.importWithLabelsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exportAsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportAsToolStripMenuItem
            // 
            this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
            this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.exportAsToolStripMenuItem.Text = "Export as";
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
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.importToolStripMenuItem1.Text = "Import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.ImportOnlyToolStripMenuItem_Click);
            // 
            // importWithLabelsToolStripMenuItem
            // 
            this.importWithLabelsToolStripMenuItem.Name = "importWithLabelsToolStripMenuItem";
            this.importWithLabelsToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.importWithLabelsToolStripMenuItem.Text = "Import with labels";
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
		private System.Windows.Forms.Panel panelImages;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripImage;
		private System.Windows.Forms.ToolStripMenuItem addToEditingAreaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageDetailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeFromLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importWithLabelsToolStripMenuItem;
    }
}