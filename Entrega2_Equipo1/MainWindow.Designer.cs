﻿namespace Entrega2_Equipo1
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
			this.addLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.informationLabel = new System.Windows.Forms.Label();
			this.ToolbarProgressBar = new System.Windows.Forms.ProgressBar();
			this.pictureChosen = new System.Windows.Forms.PictureBox();
			this.EditingPanel = new System.Windows.Forms.Panel();
			this.contextMenuStripEditing = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeFromEditingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStripImage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureChosen)).BeginInit();
			this.contextMenuStripEditing.SuspendLayout();
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
			this.panelImages.Click += new System.EventHandler(this.PanelImages_Click);
			this.panelImages.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelImages_Paint);
			// 
			// contextMenuStripImage
			// 
			this.contextMenuStripImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToEditingAreaToolStripMenuItem,
            this.removeFromLibraryToolStripMenuItem,
            this.addLabelToolStripMenuItem});
			this.contextMenuStripImage.Name = "contextMenuStripImage";
			this.contextMenuStripImage.Size = new System.Drawing.Size(186, 70);
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
			// addLabelToolStripMenuItem
			// 
			this.addLabelToolStripMenuItem.Name = "addLabelToolStripMenuItem";
			this.addLabelToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.addLabelToolStripMenuItem.Text = "Add Label";
			this.addLabelToolStripMenuItem.Click += new System.EventHandler(this.AddLabelToolStripMenuItem_Click);
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
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Controls.Add(this.titleLabel);
			this.flowLayoutPanel1.Controls.Add(this.informationLabel);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 697);
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
			// informationLabel
			// 
			this.informationLabel.AutoSize = true;
			this.informationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.informationLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.informationLabel.Location = new System.Drawing.Point(3, 31);
			this.informationLabel.Name = "informationLabel";
			this.informationLabel.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
			this.informationLabel.Size = new System.Drawing.Size(20, 29);
			this.informationLabel.TabIndex = 1;
			this.informationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
			this.pictureChosen.Location = new System.Drawing.Point(904, 53);
			this.pictureChosen.Name = "pictureChosen";
			this.pictureChosen.Size = new System.Drawing.Size(423, 359);
			this.pictureChosen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureChosen.TabIndex = 5;
			this.pictureChosen.TabStop = false;
			// 
			// EditingPanel
			// 
			this.EditingPanel.AutoScroll = true;
			this.EditingPanel.Location = new System.Drawing.Point(863, 484);
			this.EditingPanel.Name = "EditingPanel";
			this.EditingPanel.Size = new System.Drawing.Size(738, 233);
			this.EditingPanel.TabIndex = 6;
			this.EditingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.EditingPanel_Paint);
			// 
			// contextMenuStripEditing
			// 
			this.contextMenuStripEditing.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromEditingAreaToolStripMenuItem,
            this.exportToLibraryToolStripMenuItem});
			this.contextMenuStripEditing.Name = "contextMenuStripEditing";
			this.contextMenuStripEditing.Size = new System.Drawing.Size(214, 70);
			// 
			// removeFromEditingAreaToolStripMenuItem
			// 
			this.removeFromEditingAreaToolStripMenuItem.Name = "removeFromEditingAreaToolStripMenuItem";
			this.removeFromEditingAreaToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.removeFromEditingAreaToolStripMenuItem.Text = "Remove from Editing Area";
			this.removeFromEditingAreaToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromEditingAreaToolStripMenuItem_Click);
			// 
			// exportToLibraryToolStripMenuItem
			// 
			this.exportToLibraryToolStripMenuItem.Name = "exportToLibraryToolStripMenuItem";
			this.exportToLibraryToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.exportToLibraryToolStripMenuItem.Text = "Export to Library";
			this.exportToLibraryToolStripMenuItem.Click += new System.EventHandler(this.ExportToLibraryToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1369, 53);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Auto Adjust";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(1468, 53);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Black\\White";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1369, 83);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Brightness";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(1468, 83);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 10;
			this.button4.Text = "Color";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(1369, 113);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 11;
			this.button5.Text = "Invert";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(1468, 113);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 12;
			this.button6.Text = "Mirror";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(1369, 143);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 13;
			this.button7.Text = "Old Film";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(1468, 143);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 14;
			this.button8.Text = "Rotate";
			this.button8.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(1369, 173);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 15;
			this.button9.Text = "Sepia";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(1468, 173);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(75, 23);
			this.button10.TabIndex = 16;
			this.button10.Text = "Windows";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(1369, 229);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(75, 23);
			this.button11.TabIndex = 17;
			this.button11.Text = "Black bar";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(1468, 229);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 23);
			this.button12.TabIndex = 18;
			this.button12.Text = "Pixel Blur";
			this.button12.UseVisualStyleBackColor = true;
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(1369, 259);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(75, 23);
			this.button13.TabIndex = 19;
			this.button13.Text = "Add text";
			this.button13.UseVisualStyleBackColor = true;
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(1468, 259);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(75, 23);
			this.button14.TabIndex = 20;
			this.button14.Text = "Resize Image";
			this.button14.UseVisualStyleBackColor = true;
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(1369, 289);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(75, 23);
			this.button15.TabIndex = 21;
			this.button15.Text = "Mosaic";
			this.button15.UseVisualStyleBackColor = true;
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(1468, 289);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(75, 23);
			this.button16.TabIndex = 22;
			this.button16.Text = "Collage";
			this.button16.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(1613, 729);
			this.Controls.Add(this.button16);
			this.Controls.Add(this.button15);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.button12);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.EditingPanel);
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
			this.contextMenuStripEditing.ResumeLayout(false);
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
        private System.Windows.Forms.Label informationLabel;
		private System.Windows.Forms.PictureBox pictureChosen;
        private System.Windows.Forms.ToolStripMenuItem addLabelToolStripMenuItem;
		private System.Windows.Forms.Panel EditingPanel;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripEditing;
		private System.Windows.Forms.ToolStripMenuItem removeFromEditingAreaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToLibraryToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button button12;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button16;
	}

}