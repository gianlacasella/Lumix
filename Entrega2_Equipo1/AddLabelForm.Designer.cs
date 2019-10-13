namespace Entrega2_Equipo1
{
    partial class AddLabelForm
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
            this.AddLabelButton = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.SelectedLabelComboBox1 = new System.Windows.Forms.ComboBox();
            this.SimpleLabelTag = new System.Windows.Forms.Label();
            this.SimpleLabelTagBox = new System.Windows.Forms.TextBox();
            this.SimpleLabelTitle = new System.Windows.Forms.Label();
            this.PersonLabelTitle = new System.Windows.Forms.Label();
            this.PersonLabelNameLabel = new System.Windows.Forms.Label();
            this.PersonLabelNameBox = new System.Windows.Forms.TextBox();
            this.PersonLabelSurnameLabel = new System.Windows.Forms.Label();
            this.PersonLabelSurnameBox = new System.Windows.Forms.TextBox();
            this.PesonLabelNationalityLabel = new System.Windows.Forms.Label();
            this.PersonLabelNationalityComboBox = new System.Windows.Forms.ComboBox();
            this.PersonLabelHairColorLabel = new System.Windows.Forms.Label();
            this.PersonLabelHairColorComboBox = new System.Windows.Forms.ComboBox();
            this.PersonLabelEyesColorLabel = new System.Windows.Forms.Label();
            this.PersonLabelEyesColorComboBox = new System.Windows.Forms.ComboBox();
            this.PersonLabelSexLabel = new System.Windows.Forms.Label();
            this.PersonLabelSexComboBox = new System.Windows.Forms.ComboBox();
            this.PersonLabelBirthDateLabel = new System.Windows.Forms.Label();
            this.PersonLabelBirthDateTextBox = new System.Windows.Forms.TextBox();
            this.PersonLabelFaceLocationLabel = new System.Windows.Forms.Label();
            this.TOP = new System.Windows.Forms.Label();
            this.LEFT = new System.Windows.Forms.Label();
            this.WIDTH = new System.Windows.Forms.Label();
            this.HEIGHT = new System.Windows.Forms.Label();
            this.PersonLabelTOPDomain = new System.Windows.Forms.DomainUpDown();
            this.PersonLabelLEFTDomain = new System.Windows.Forms.DomainUpDown();
            this.PersonLabelWIDTHDomain = new System.Windows.Forms.DomainUpDown();
            this.PersonLabelHEIGHTDomain = new System.Windows.Forms.DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AddLabelButton
            // 
            this.AddLabelButton.Location = new System.Drawing.Point(123, 404);
            this.AddLabelButton.Name = "AddLabelButton";
            this.AddLabelButton.Size = new System.Drawing.Size(168, 34);
            this.AddLabelButton.TabIndex = 0;
            this.AddLabelButton.Text = "Add Label";
            this.AddLabelButton.UseVisualStyleBackColor = true;
            this.AddLabelButton.Click += new System.EventHandler(this.AddLabelButton_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(65, 12);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(298, 368);
            this.ImageBox.TabIndex = 1;
            this.ImageBox.TabStop = false;
            // 
            // SelectedLabelComboBox1
            // 
            this.SelectedLabelComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectedLabelComboBox1.FormattingEnabled = true;
            this.SelectedLabelComboBox1.Items.AddRange(new object[] {
            "Simple Label",
            "Person Label",
            "Special Label"});
            this.SelectedLabelComboBox1.Location = new System.Drawing.Point(514, 12);
            this.SelectedLabelComboBox1.Name = "SelectedLabelComboBox1";
            this.SelectedLabelComboBox1.Size = new System.Drawing.Size(121, 21);
            this.SelectedLabelComboBox1.TabIndex = 2;
            this.SelectedLabelComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // SimpleLabelTag
            // 
            this.SimpleLabelTag.AutoSize = true;
            this.SimpleLabelTag.Location = new System.Drawing.Point(385, 59);
            this.SimpleLabelTag.Name = "SimpleLabelTag";
            this.SimpleLabelTag.Size = new System.Drawing.Size(29, 13);
            this.SimpleLabelTag.TabIndex = 3;
            this.SimpleLabelTag.Text = "Tag:";
            // 
            // SimpleLabelTagBox
            // 
            this.SimpleLabelTagBox.Enabled = false;
            this.SimpleLabelTagBox.Location = new System.Drawing.Point(417, 56);
            this.SimpleLabelTagBox.Name = "SimpleLabelTagBox";
            this.SimpleLabelTagBox.Size = new System.Drawing.Size(304, 20);
            this.SimpleLabelTagBox.TabIndex = 4;
            // 
            // SimpleLabelTitle
            // 
            this.SimpleLabelTitle.AutoSize = true;
            this.SimpleLabelTitle.Location = new System.Drawing.Point(414, 40);
            this.SimpleLabelTitle.Name = "SimpleLabelTitle";
            this.SimpleLabelTitle.Size = new System.Drawing.Size(67, 13);
            this.SimpleLabelTitle.TabIndex = 5;
            this.SimpleLabelTitle.Text = "Simple Label";
            // 
            // PersonLabelTitle
            // 
            this.PersonLabelTitle.AutoSize = true;
            this.PersonLabelTitle.Location = new System.Drawing.Point(414, 91);
            this.PersonLabelTitle.Name = "PersonLabelTitle";
            this.PersonLabelTitle.Size = new System.Drawing.Size(69, 13);
            this.PersonLabelTitle.TabIndex = 6;
            this.PersonLabelTitle.Text = "Person Label";
            // 
            // PersonLabelNameLabel
            // 
            this.PersonLabelNameLabel.AutoSize = true;
            this.PersonLabelNameLabel.Location = new System.Drawing.Point(376, 112);
            this.PersonLabelNameLabel.Name = "PersonLabelNameLabel";
            this.PersonLabelNameLabel.Size = new System.Drawing.Size(38, 13);
            this.PersonLabelNameLabel.TabIndex = 7;
            this.PersonLabelNameLabel.Text = "Name:";
            // 
            // PersonLabelNameBox
            // 
            this.PersonLabelNameBox.Enabled = false;
            this.PersonLabelNameBox.Location = new System.Drawing.Point(417, 109);
            this.PersonLabelNameBox.Name = "PersonLabelNameBox";
            this.PersonLabelNameBox.Size = new System.Drawing.Size(111, 20);
            this.PersonLabelNameBox.TabIndex = 8;
            // 
            // PersonLabelSurnameLabel
            // 
            this.PersonLabelSurnameLabel.AutoSize = true;
            this.PersonLabelSurnameLabel.Location = new System.Drawing.Point(534, 112);
            this.PersonLabelSurnameLabel.Name = "PersonLabelSurnameLabel";
            this.PersonLabelSurnameLabel.Size = new System.Drawing.Size(52, 13);
            this.PersonLabelSurnameLabel.TabIndex = 9;
            this.PersonLabelSurnameLabel.Text = "Surname:";
            // 
            // PersonLabelSurnameBox
            // 
            this.PersonLabelSurnameBox.Enabled = false;
            this.PersonLabelSurnameBox.Location = new System.Drawing.Point(592, 109);
            this.PersonLabelSurnameBox.Name = "PersonLabelSurnameBox";
            this.PersonLabelSurnameBox.Size = new System.Drawing.Size(129, 20);
            this.PersonLabelSurnameBox.TabIndex = 10;
            // 
            // PesonLabelNationalityLabel
            // 
            this.PesonLabelNationalityLabel.AutoSize = true;
            this.PesonLabelNationalityLabel.Location = new System.Drawing.Point(376, 151);
            this.PesonLabelNationalityLabel.Name = "PesonLabelNationalityLabel";
            this.PesonLabelNationalityLabel.Size = new System.Drawing.Size(59, 13);
            this.PesonLabelNationalityLabel.TabIndex = 11;
            this.PesonLabelNationalityLabel.Text = "Nationality:";
            // 
            // PersonLabelNationalityComboBox
            // 
            this.PersonLabelNationalityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonLabelNationalityComboBox.Enabled = false;
            this.PersonLabelNationalityComboBox.FormattingEnabled = true;
            this.PersonLabelNationalityComboBox.Location = new System.Drawing.Point(441, 148);
            this.PersonLabelNationalityComboBox.Name = "PersonLabelNationalityComboBox";
            this.PersonLabelNationalityComboBox.Size = new System.Drawing.Size(107, 21);
            this.PersonLabelNationalityComboBox.TabIndex = 12;
            // 
            // PersonLabelHairColorLabel
            // 
            this.PersonLabelHairColorLabel.AutoSize = true;
            this.PersonLabelHairColorLabel.Location = new System.Drawing.Point(554, 151);
            this.PersonLabelHairColorLabel.Name = "PersonLabelHairColorLabel";
            this.PersonLabelHairColorLabel.Size = new System.Drawing.Size(56, 13);
            this.PersonLabelHairColorLabel.TabIndex = 13;
            this.PersonLabelHairColorLabel.Text = "Hair Color:";
            // 
            // PersonLabelHairColorComboBox
            // 
            this.PersonLabelHairColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonLabelHairColorComboBox.Enabled = false;
            this.PersonLabelHairColorComboBox.FormattingEnabled = true;
            this.PersonLabelHairColorComboBox.Location = new System.Drawing.Point(614, 148);
            this.PersonLabelHairColorComboBox.Name = "PersonLabelHairColorComboBox";
            this.PersonLabelHairColorComboBox.Size = new System.Drawing.Size(107, 21);
            this.PersonLabelHairColorComboBox.TabIndex = 14;
            // 
            // PersonLabelEyesColorLabel
            // 
            this.PersonLabelEyesColorLabel.AutoSize = true;
            this.PersonLabelEyesColorLabel.Location = new System.Drawing.Point(376, 187);
            this.PersonLabelEyesColorLabel.Name = "PersonLabelEyesColorLabel";
            this.PersonLabelEyesColorLabel.Size = new System.Drawing.Size(60, 13);
            this.PersonLabelEyesColorLabel.TabIndex = 15;
            this.PersonLabelEyesColorLabel.Text = "Eyes Color:";
            // 
            // PersonLabelEyesColorComboBox
            // 
            this.PersonLabelEyesColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonLabelEyesColorComboBox.Enabled = false;
            this.PersonLabelEyesColorComboBox.FormattingEnabled = true;
            this.PersonLabelEyesColorComboBox.Location = new System.Drawing.Point(441, 184);
            this.PersonLabelEyesColorComboBox.Name = "PersonLabelEyesColorComboBox";
            this.PersonLabelEyesColorComboBox.Size = new System.Drawing.Size(107, 21);
            this.PersonLabelEyesColorComboBox.TabIndex = 16;
            // 
            // PersonLabelSexLabel
            // 
            this.PersonLabelSexLabel.AutoSize = true;
            this.PersonLabelSexLabel.Location = new System.Drawing.Point(554, 192);
            this.PersonLabelSexLabel.Name = "PersonLabelSexLabel";
            this.PersonLabelSexLabel.Size = new System.Drawing.Size(28, 13);
            this.PersonLabelSexLabel.TabIndex = 17;
            this.PersonLabelSexLabel.Text = "Sex:";
            // 
            // PersonLabelSexComboBox
            // 
            this.PersonLabelSexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonLabelSexComboBox.Enabled = false;
            this.PersonLabelSexComboBox.FormattingEnabled = true;
            this.PersonLabelSexComboBox.Location = new System.Drawing.Point(588, 187);
            this.PersonLabelSexComboBox.Name = "PersonLabelSexComboBox";
            this.PersonLabelSexComboBox.Size = new System.Drawing.Size(85, 21);
            this.PersonLabelSexComboBox.TabIndex = 18;
            // 
            // PersonLabelBirthDateLabel
            // 
            this.PersonLabelBirthDateLabel.AutoSize = true;
            this.PersonLabelBirthDateLabel.Location = new System.Drawing.Point(376, 223);
            this.PersonLabelBirthDateLabel.Name = "PersonLabelBirthDateLabel";
            this.PersonLabelBirthDateLabel.Size = new System.Drawing.Size(54, 13);
            this.PersonLabelBirthDateLabel.TabIndex = 19;
            this.PersonLabelBirthDateLabel.Text = "BirthDate:";
            // 
            // PersonLabelBirthDateTextBox
            // 
            this.PersonLabelBirthDateTextBox.Enabled = false;
            this.PersonLabelBirthDateTextBox.Location = new System.Drawing.Point(436, 220);
            this.PersonLabelBirthDateTextBox.Name = "PersonLabelBirthDateTextBox";
            this.PersonLabelBirthDateTextBox.Size = new System.Drawing.Size(111, 20);
            this.PersonLabelBirthDateTextBox.TabIndex = 20;
            // 
            // PersonLabelFaceLocationLabel
            // 
            this.PersonLabelFaceLocationLabel.AutoSize = true;
            this.PersonLabelFaceLocationLabel.Location = new System.Drawing.Point(557, 227);
            this.PersonLabelFaceLocationLabel.Name = "PersonLabelFaceLocationLabel";
            this.PersonLabelFaceLocationLabel.Size = new System.Drawing.Size(78, 13);
            this.PersonLabelFaceLocationLabel.TabIndex = 21;
            this.PersonLabelFaceLocationLabel.Text = "Face Location:";
            // 
            // TOP
            // 
            this.TOP.AutoSize = true;
            this.TOP.Location = new System.Drawing.Point(585, 251);
            this.TOP.Name = "TOP";
            this.TOP.Size = new System.Drawing.Size(32, 13);
            this.TOP.TabIndex = 22;
            this.TOP.Text = "TOP:";
            // 
            // LEFT
            // 
            this.LEFT.AutoSize = true;
            this.LEFT.Location = new System.Drawing.Point(585, 274);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(36, 13);
            this.LEFT.TabIndex = 23;
            this.LEFT.Text = "LEFT:";
            // 
            // WIDTH
            // 
            this.WIDTH.AutoSize = true;
            this.WIDTH.Location = new System.Drawing.Point(659, 251);
            this.WIDTH.Name = "WIDTH";
            this.WIDTH.Size = new System.Drawing.Size(47, 13);
            this.WIDTH.TabIndex = 24;
            this.WIDTH.Text = "WIDTH:";
            // 
            // HEIGHT
            // 
            this.HEIGHT.AutoSize = true;
            this.HEIGHT.Location = new System.Drawing.Point(659, 274);
            this.HEIGHT.Name = "HEIGHT";
            this.HEIGHT.Size = new System.Drawing.Size(51, 13);
            this.HEIGHT.TabIndex = 25;
            this.HEIGHT.Text = "HEIGHT:";
            // 
            // PersonLabelTOPDomain
            // 
            this.PersonLabelTOPDomain.Enabled = false;
            this.PersonLabelTOPDomain.Items.Add("1");
            this.PersonLabelTOPDomain.Items.Add("2");
            this.PersonLabelTOPDomain.Items.Add("3");
            this.PersonLabelTOPDomain.Items.Add("4");
            this.PersonLabelTOPDomain.Items.Add("5");
            this.PersonLabelTOPDomain.Location = new System.Drawing.Point(615, 249);
            this.PersonLabelTOPDomain.Name = "PersonLabelTOPDomain";
            this.PersonLabelTOPDomain.Size = new System.Drawing.Size(38, 20);
            this.PersonLabelTOPDomain.TabIndex = 26;
            this.PersonLabelTOPDomain.Text = "domainUpDown1";
            // 
            // PersonLabelLEFTDomain
            // 
            this.PersonLabelLEFTDomain.Enabled = false;
            this.PersonLabelLEFTDomain.Items.Add("1");
            this.PersonLabelLEFTDomain.Items.Add("2");
            this.PersonLabelLEFTDomain.Items.Add("3");
            this.PersonLabelLEFTDomain.Items.Add("4");
            this.PersonLabelLEFTDomain.Items.Add("5");
            this.PersonLabelLEFTDomain.Location = new System.Drawing.Point(615, 272);
            this.PersonLabelLEFTDomain.Name = "PersonLabelLEFTDomain";
            this.PersonLabelLEFTDomain.Size = new System.Drawing.Size(38, 20);
            this.PersonLabelLEFTDomain.TabIndex = 27;
            this.PersonLabelLEFTDomain.Text = "domainUpDown2";
            // 
            // PersonLabelWIDTHDomain
            // 
            this.PersonLabelWIDTHDomain.Enabled = false;
            this.PersonLabelWIDTHDomain.Items.Add("1");
            this.PersonLabelWIDTHDomain.Items.Add("2");
            this.PersonLabelWIDTHDomain.Items.Add("3");
            this.PersonLabelWIDTHDomain.Items.Add("4");
            this.PersonLabelWIDTHDomain.Items.Add("5");
            this.PersonLabelWIDTHDomain.Location = new System.Drawing.Point(712, 249);
            this.PersonLabelWIDTHDomain.Name = "PersonLabelWIDTHDomain";
            this.PersonLabelWIDTHDomain.Size = new System.Drawing.Size(38, 20);
            this.PersonLabelWIDTHDomain.TabIndex = 28;
            this.PersonLabelWIDTHDomain.Text = "domainUpDown1";
            // 
            // PersonLabelHEIGHTDomain
            // 
            this.PersonLabelHEIGHTDomain.Enabled = false;
            this.PersonLabelHEIGHTDomain.Items.Add("1");
            this.PersonLabelHEIGHTDomain.Items.Add("2");
            this.PersonLabelHEIGHTDomain.Items.Add("3");
            this.PersonLabelHEIGHTDomain.Items.Add("4");
            this.PersonLabelHEIGHTDomain.Items.Add("5");
            this.PersonLabelHEIGHTDomain.Location = new System.Drawing.Point(712, 272);
            this.PersonLabelHEIGHTDomain.Name = "PersonLabelHEIGHTDomain";
            this.PersonLabelHEIGHTDomain.Size = new System.Drawing.Size(38, 20);
            this.PersonLabelHEIGHTDomain.TabIndex = 29;
            this.PersonLabelHEIGHTDomain.Text = "domainUpDown1";
            // 
            // AddLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.PersonLabelHEIGHTDomain);
            this.Controls.Add(this.PersonLabelWIDTHDomain);
            this.Controls.Add(this.PersonLabelLEFTDomain);
            this.Controls.Add(this.PersonLabelTOPDomain);
            this.Controls.Add(this.HEIGHT);
            this.Controls.Add(this.WIDTH);
            this.Controls.Add(this.LEFT);
            this.Controls.Add(this.TOP);
            this.Controls.Add(this.PersonLabelFaceLocationLabel);
            this.Controls.Add(this.PersonLabelBirthDateTextBox);
            this.Controls.Add(this.PersonLabelBirthDateLabel);
            this.Controls.Add(this.PersonLabelSexComboBox);
            this.Controls.Add(this.PersonLabelSexLabel);
            this.Controls.Add(this.PersonLabelEyesColorComboBox);
            this.Controls.Add(this.PersonLabelEyesColorLabel);
            this.Controls.Add(this.PersonLabelHairColorComboBox);
            this.Controls.Add(this.PersonLabelHairColorLabel);
            this.Controls.Add(this.PersonLabelNationalityComboBox);
            this.Controls.Add(this.PesonLabelNationalityLabel);
            this.Controls.Add(this.PersonLabelSurnameBox);
            this.Controls.Add(this.PersonLabelSurnameLabel);
            this.Controls.Add(this.PersonLabelNameBox);
            this.Controls.Add(this.PersonLabelNameLabel);
            this.Controls.Add(this.PersonLabelTitle);
            this.Controls.Add(this.SimpleLabelTitle);
            this.Controls.Add(this.SimpleLabelTagBox);
            this.Controls.Add(this.SimpleLabelTag);
            this.Controls.Add(this.SelectedLabelComboBox1);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.AddLabelButton);
            this.Name = "AddLabelForm";
            this.Text = "AddLabelForm";
            this.Load += new System.EventHandler(this.AddLabelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddLabelButton;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.ComboBox SelectedLabelComboBox1;
        private System.Windows.Forms.Label SimpleLabelTag;
        private System.Windows.Forms.TextBox SimpleLabelTagBox;
        private System.Windows.Forms.Label SimpleLabelTitle;
        private System.Windows.Forms.Label PersonLabelTitle;
        private System.Windows.Forms.Label PersonLabelNameLabel;
        private System.Windows.Forms.TextBox PersonLabelNameBox;
        private System.Windows.Forms.Label PersonLabelSurnameLabel;
        private System.Windows.Forms.TextBox PersonLabelSurnameBox;
        private System.Windows.Forms.Label PesonLabelNationalityLabel;
        private System.Windows.Forms.ComboBox PersonLabelNationalityComboBox;
        private System.Windows.Forms.Label PersonLabelHairColorLabel;
        private System.Windows.Forms.ComboBox PersonLabelHairColorComboBox;
        private System.Windows.Forms.Label PersonLabelEyesColorLabel;
        private System.Windows.Forms.ComboBox PersonLabelEyesColorComboBox;
        private System.Windows.Forms.Label PersonLabelSexLabel;
        private System.Windows.Forms.ComboBox PersonLabelSexComboBox;
        private System.Windows.Forms.Label PersonLabelBirthDateLabel;
        private System.Windows.Forms.TextBox PersonLabelBirthDateTextBox;
        private System.Windows.Forms.Label PersonLabelFaceLocationLabel;
        private System.Windows.Forms.Label TOP;
        private System.Windows.Forms.Label LEFT;
        private System.Windows.Forms.Label WIDTH;
        private System.Windows.Forms.Label HEIGHT;
        private System.Windows.Forms.DomainUpDown PersonLabelTOPDomain;
        private System.Windows.Forms.DomainUpDown PersonLabelLEFTDomain;
        private System.Windows.Forms.DomainUpDown PersonLabelWIDTHDomain;
        private System.Windows.Forms.DomainUpDown PersonLabelHEIGHTDomain;
    }
}