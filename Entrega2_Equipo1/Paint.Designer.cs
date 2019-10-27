namespace Entrega2_Equipo1
{
	partial class Paint
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
			this.ImagePictureBox = new System.Windows.Forms.PictureBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.DoneButton = new System.Windows.Forms.Button();
			this.ColorButton = new System.Windows.Forms.Button();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ImagePictureBox
			// 
			this.ImagePictureBox.Location = new System.Drawing.Point(-2, -1);
			this.ImagePictureBox.Name = "ImagePictureBox";
			this.ImagePictureBox.Size = new System.Drawing.Size(801, 417);
			this.ImagePictureBox.TabIndex = 0;
			this.ImagePictureBox.TabStop = false;
			this.ImagePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClickDown);
			this.ImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Brush);
			this.ImagePictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseClickUp);
			// 
			// DoneButton
			// 
			this.DoneButton.Location = new System.Drawing.Point(710, 423);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new System.Drawing.Size(75, 23);
			this.DoneButton.TabIndex = 1;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = true;
			this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
			// 
			// ColorButton
			// 
			this.ColorButton.Location = new System.Drawing.Point(611, 422);
			this.ColorButton.Name = "ColorButton";
			this.ColorButton.Size = new System.Drawing.Size(75, 23);
			this.ColorButton.TabIndex = 2;
			this.ColorButton.Text = "Color";
			this.ColorButton.UseVisualStyleBackColor = true;
			this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
			// 
			// numericUpDown
			// 
			this.numericUpDown.Location = new System.Drawing.Point(558, 422);
			this.numericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numericUpDown.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(47, 20);
			this.numericUpDown.TabIndex = 3;
			this.numericUpDown.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.numericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// Paint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.numericUpDown);
			this.Controls.Add(this.ColorButton);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.ImagePictureBox);
			this.Name = "Paint";
			this.Text = "Paint";
			this.Load += new System.EventHandler(this.Paint_Load);
			((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox ImagePictureBox;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button DoneButton;
		private System.Windows.Forms.Button ColorButton;
		private System.Windows.Forms.NumericUpDown numericUpDown;
	}
}