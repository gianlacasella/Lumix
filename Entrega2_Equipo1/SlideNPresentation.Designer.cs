namespace Entrega2_Equipo1
{
	partial class SlideNPresentation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlideNPresentation));
			this.MainPanel = new System.Windows.Forms.Panel();
			this.picturePanel = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.StartSlideButton = new System.Windows.Forms.Button();
			this.setTimeImage = new System.Windows.Forms.Button();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.timeImageLabel = new System.Windows.Forms.Label();
			this.timeLabel = new System.Windows.Forms.Label();
			this.SlidePictureBox = new System.Windows.Forms.PictureBox();
			this.panelShowImage = new System.Windows.Forms.Panel();
			this.MainPictureBox = new System.Windows.Forms.PictureBox();
			this.BackButton = new System.Windows.Forms.Button();
			this.NextButton = new System.Windows.Forms.Button();
			this.timerMain = new System.Windows.Forms.Timer(this.components);
			this.MainPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SlidePictureBox)).BeginInit();
			this.panelShowImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// MainPanel
			// 
			this.MainPanel.Controls.Add(this.picturePanel);
			this.MainPanel.Controls.Add(this.panel2);
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(0, 0);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(844, 557);
			this.MainPanel.TabIndex = 0;
			// 
			// picturePanel
			// 
			this.picturePanel.AutoScroll = true;
			this.picturePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picturePanel.Location = new System.Drawing.Point(0, 0);
			this.picturePanel.Name = "picturePanel";
			this.picturePanel.Size = new System.Drawing.Size(644, 557);
			this.picturePanel.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.StartSlideButton);
			this.panel2.Controls.Add(this.setTimeImage);
			this.panel2.Controls.Add(this.textBoxNumber);
			this.panel2.Controls.Add(this.timeImageLabel);
			this.panel2.Controls.Add(this.timeLabel);
			this.panel2.Controls.Add(this.SlidePictureBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(644, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 557);
			this.panel2.TabIndex = 0;
			// 
			// StartSlideButton
			// 
			this.StartSlideButton.Location = new System.Drawing.Point(51, 278);
			this.StartSlideButton.Name = "StartSlideButton";
			this.StartSlideButton.Size = new System.Drawing.Size(75, 23);
			this.StartSlideButton.TabIndex = 6;
			this.StartSlideButton.Text = "Start SlideShow";
			this.StartSlideButton.UseVisualStyleBackColor = true;
			this.StartSlideButton.Click += new System.EventHandler(this.StartSlideButton_Click);
			// 
			// setTimeImage
			// 
			this.setTimeImage.Location = new System.Drawing.Point(19, 172);
			this.setTimeImage.Name = "setTimeImage";
			this.setTimeImage.Size = new System.Drawing.Size(58, 23);
			this.setTimeImage.TabIndex = 5;
			this.setTimeImage.Text = "Set";
			this.setTimeImage.UseVisualStyleBackColor = true;
			this.setTimeImage.Click += new System.EventHandler(this.SetTimeImage_Click);
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Location = new System.Drawing.Point(100, 175);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(85, 20);
			this.textBoxNumber.TabIndex = 1;
			this.textBoxNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNumber_KeyPress);
			// 
			// timeImageLabel
			// 
			this.timeImageLabel.AutoSize = true;
			this.timeImageLabel.Location = new System.Drawing.Point(97, 145);
			this.timeImageLabel.Name = "timeImageLabel";
			this.timeImageLabel.Size = new System.Drawing.Size(88, 13);
			this.timeImageLabel.TabIndex = 4;
			this.timeImageLabel.Text = "DEFAULT_TIME";
			// 
			// timeLabel
			// 
			this.timeLabel.AutoSize = true;
			this.timeLabel.Location = new System.Drawing.Point(20, 145);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(33, 13);
			this.timeLabel.TabIndex = 3;
			this.timeLabel.Text = "Time:";
			// 
			// SlidePictureBox
			// 
			this.SlidePictureBox.Location = new System.Drawing.Point(41, 26);
			this.SlidePictureBox.Name = "SlidePictureBox";
			this.SlidePictureBox.Size = new System.Drawing.Size(131, 98);
			this.SlidePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.SlidePictureBox.TabIndex = 2;
			this.SlidePictureBox.TabStop = false;
			// 
			// panelShowImage
			// 
			this.panelShowImage.Controls.Add(this.BackButton);
			this.panelShowImage.Controls.Add(this.NextButton);
			this.panelShowImage.Controls.Add(this.MainPictureBox);
			this.panelShowImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelShowImage.Location = new System.Drawing.Point(0, 0);
			this.panelShowImage.Name = "panelShowImage";
			this.panelShowImage.Size = new System.Drawing.Size(844, 557);
			this.panelShowImage.TabIndex = 1;
			this.panelShowImage.Visible = false;
			// 
			// MainPictureBox
			// 
			this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("MainPictureBox.ErrorImage")));
			this.MainPictureBox.Location = new System.Drawing.Point(0, 0);
			this.MainPictureBox.Name = "MainPictureBox";
			this.MainPictureBox.Size = new System.Drawing.Size(844, 557);
			this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.MainPictureBox.TabIndex = 1;
			this.MainPictureBox.TabStop = false;
			this.MainPictureBox.Visible = false;
			// 
			// BackButton
			// 
			this.BackButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.BackButton.Location = new System.Drawing.Point(0, 0);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(75, 557);
			this.BackButton.TabIndex = 3;
			this.BackButton.Text = "Back";
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Visible = false;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// NextButton
			// 
			this.NextButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.NextButton.Location = new System.Drawing.Point(777, 0);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size(67, 557);
			this.NextButton.TabIndex = 2;
			this.NextButton.Text = "Next";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Visible = false;
			this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// timerMain
			// 
			this.timerMain.Interval = 1;
			this.timerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
			// 
			// SlideNPresentation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(844, 557);
			this.Controls.Add(this.panelShowImage);
			this.Controls.Add(this.MainPanel);
			this.Name = "SlideNPresentation";
			this.Text = "SlideNPresentation";
			this.MainPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SlidePictureBox)).EndInit();
			this.panelShowImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.TextBox textBoxNumber;
		private System.Windows.Forms.PictureBox SlidePictureBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Button StartSlideButton;
		private System.Windows.Forms.Button setTimeImage;
		private System.Windows.Forms.Label timeImageLabel;
		private System.Windows.Forms.Panel picturePanel;
		private System.Windows.Forms.PictureBox MainPictureBox;
		private System.Windows.Forms.Timer timerMain;
		private System.Windows.Forms.Panel panelShowImage;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Button NextButton;
	}
}