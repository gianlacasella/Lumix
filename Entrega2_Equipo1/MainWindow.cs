using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega2_Equipo1
{
	public partial class MainWindow : Form
	{
		Library library;
        Producer producer;
		ProgramManager PM = new ProgramManager();
		bool Saved = true;
		PictureBox chosenImage = null;
		PictureBox chosenEditingImage = null;
		List<Image> featuresImage = new List<Image>();
        Label createdLabel;
        Image imagetoaddlabel;

        // =============================== FRAME METHODS ================================
		public MainWindow()
		{
			InitializeComponent();
            this.menuStrip1.Renderer = new MyRenderer();
        }

		private void MainWindow_Load(object sender, EventArgs e)
		{
			library = PM.LoadingLibraryManager();
			producer = PM.LoadingProducerManager();
			PanelImages_Paint(sender, e);
			comboRotate.DataSource = Enum.GetValues(typeof(RotateFlipType));
			comboCensor.Items.Add("Black bar"); comboCensor.Items.Add("Pixel blur");comboCensor.Text = "Black bar";
            AddLabelPanel.Location = panelImages.Location;
            AddLabelPanel.Visible = false;
            panelImages.Visible = true;
            
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved)
            {
                // Display a MsgBox asking the user to close the form.
                if (MessageBox.Show("Are you sure you want to close without saving?", "Exit without save",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Cancel the Closing event
                    e.Cancel = true;
                }
            }
        }

        // ==============================================================================
        // =============================== TOOL STRIP MENU METHODS ===========================
        private void ImportOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select the desired images";
            ofd.Multiselect = true;
            ofd.Filter = "Supported formats |*.jpg;*.jpeg;*.png;*.bmp";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.ToolbarProgressBar.Value = 0;
                this.ToolbarProgressBar.Visible = true;
                int count = 1;
                string[] files = ofd.FileNames;
                foreach (string path in files)
                {
                    string name = Path.GetFileNameWithoutExtension(path);
                    Image returningImage = new Image(path, new List<Label>(), -1);
                    returningImage.Name = name;
                    library.AddImage(returningImage);
                    this.ToolbarProgressBar.Increment((count * 100) / files.Length);
                }
                this.ToolbarProgressBar.Visible = false;
                this.ToolbarProgressBar.Value = 0;
                ReLoadPanelImage(sender, e);
                Saved = false;
            }
        }

        private void RemoveFromLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    PictureBox PIC = (PictureBox)sourceControl;
                    Image im = (Image)PIC.Tag;
                    library.RemoveImage(im.Name);
                    ReLoadPanelImage(sender, e);
                    Saved = false;
                    if (PIC == chosenImage)
                    {
                        chosenImage = null;
                    }
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PM.SaveLibrary(library);
            Saved = true;
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chosenImage != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images |*.jpg;*.jpeg;*.png;*.bmp";
                ImageFormat format = ImageFormat.Jpeg;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    chosenImage.Image.Save(sfd.FileName, format);
                }
            }
            else
            {
                NoPictureChosen(sender, e);
            }
        }

        private void ExportAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chosenImage != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = ".jpg|*.jpg|.bmp|*.bmp|.png|*.png";
                ImageFormat format = ImageFormat.Jpeg;
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".png":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }
                    chosenImage.Image.Save(sfd.FileName, format);
                }
            }
            else
            {
                NoPictureChosen(sender, e);
            }

        }

        private void CleanLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (library.Images.Count != 0)
            {
                if (MessageBox.Show("Are you sure you want to clean the library?", "Warning!",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    library.ResetImages();
                    ReLoadPanelImage(sender, e);
                }
            }
            else
            {

                MessageBox.Show("There are no pictures in library", "Clean library error.",
                       MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }

        private void AddToEditingAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    PictureBox PIC = (PictureBox)sourceControl;
                    //pictureChosen.Image = PIC.Image;
                    pictureChosen.Tag = (Image)PIC.Tag;
                    producer.LoadImagesToWorkingArea(new List<Image>() { (Image)PIC.Tag });
                    EditingPanel_Paint(sender, e);
                    //PM.SaveProducer();    ERRORES CUANDO SE LEE IMAGENES EN producer.bin
                }
            }
        }

        private void AddLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Control sourceControl = owner.SourceControl;
                    PictureBox PIC = (PictureBox)sourceControl;
                    Image imagetoaddlabel = (Image)PIC.Tag;
                    // Ya reconocimos cual fue el Image seleccionado para agregar el label
                    AddLabelPanel.Visible = true;
                    this.imagetoaddlabel = imagetoaddlabel;
                    AddLabelController();
                }
            }
            else
            {
                return;
            }


        }

        // ==============================================================================
        // =============================== PANEL IMAGES METHODS =========================

        private void PanelImages_Paint(object sender, EventArgs e)
		{
			int x = 20;
			int y = 20;
			int maxHeight = -1;
            int count = 1;
            this.ToolbarProgressBar.Value = 0;
            this.ToolbarProgressBar.Visible = true;
            foreach (Image image in library.Images)
			{
				PictureBox pic = new PictureBox();
				pic.Image = image.BitmapImage;
				pic.Location = new Point(x, y);
				pic.Tag = image;
				pic.SizeMode = PictureBoxSizeMode.StretchImage;
				pic.Click += ImageDetailClick;
				pic.Click += ImageBorderClick;
				pic.ContextMenuStrip = contextMenuStripImage;
				pic.Name = image.Name;
                pic.Cursor = Cursors.Hand;

				x += pic.Width + 10;
				maxHeight = Math.Max(pic.Height, maxHeight);
				if (x > this.panelImages.Width - 100)
				{
					x = 20;
					y += maxHeight + 10;
				}
				this.panelImages.Controls.Add(pic);
				this.ToolbarProgressBar.Increment((count * 100)/library.Images.Count);
                count++;
			}
            this.ToolbarProgressBar.Visible = false;
            this.ToolbarProgressBar.Value = 0;
        }

        // Metodo que se ejecuta cuando el usuario hace clic sobre una imagen del library
        private void ImageDetailClick(object sender, EventArgs e)
        {
            PictureBox PIC = (PictureBox)sender;
            Image image = (Image)PIC.Tag;
            ImageToShow imagets = new ImageToShow(image);
            this.LabelsPropertyGrid.SelectedObject = imagets;
            this.calificationUpDown.Enabled = true;
            this.SetCalificationButton.Enabled = true;
            this.setNewNameButton.Enabled = true;
            this.nameTextBox.Enabled = true;
            this.addnewlabelbutton.Enabled = true;
            this.EditLabelButton.Enabled = true;
            this.DeleteLabelButton.Enabled = true;
            this.imagetoaddlabel = image;
        }

		private void ImageBorderClick(object sender, EventArgs e)
		{
			PictureBox PIC = (PictureBox)sender;
			if (chosenImage != PIC && chosenImage != null)
			{
				chosenImage.BorderStyle = BorderStyle.None;
				chosenImage = PIC;
			}
			else
			{
				chosenImage = PIC;
			}
			PIC.BorderStyle = BorderStyle.Fixed3D;
		}

		private void NoPictureChosen(object sender, EventArgs e)
		{

			MessageBox.Show("A picture has to be chosen in order to export.", "No picture chosen",
			   MessageBoxButtons.OK, MessageBoxIcon.Question);

		}

		private void ReLoadPanelImage(object sender, EventArgs e)
		{
			panelImages.Controls.Clear();
			PanelImages_Paint(sender, e);
		}

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelImages_Click(object sender, EventArgs e)
        {
            if (chosenImage != null)
            {
                this.LabelsPropertyGrid.SelectedObject = new object();
                this.LabelsPropertyGrid.Update();
                chosenImage.BorderStyle = BorderStyle.None;
                chosenImage = null;
                this.calificationUpDown.Enabled = false;
                this.SetCalificationButton.Enabled = false;
                this.setNewNameButton.Enabled = false;
                this.addnewlabelbutton.Enabled = false;
                this.EditLabelButton.Enabled = false;
                this.DeleteLabelButton.Enabled = false;
                this.nameTextBox.Enabled = false;
            }
            
        }

        private void SetCalificationButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.imagetoaddlabel.Calification = (calificationUpDown.Value == 0) ? -1 : Convert.ToInt32(calificationUpDown.Value);
                Refresh_LabelsPropertyGrid();
            }
            catch
            {
                return;
            }
        }

        private void SetNewNameButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.imagetoaddlabel.Name = nameTextBox.Text;
                Refresh_LabelsPropertyGrid();
            }
            catch
            {
                return;
            }
        }

        private void Refresh_LabelsPropertyGrid()
        {
            try
            {
                this.LabelsPropertyGrid.SelectedObject = new object();
                this.LabelsPropertyGrid.SelectedObject = new ImageToShow(this.imagetoaddlabel);
            }
            catch
            {
                return;
            }
        }

        // ==============================================================================
        // =============================== EDITING PANEL METHODS ========================

        private void EditingPanel_Paint(object sender, EventArgs e)
		{
			int x = 20;
			int y = 20;
			int maxHeight = -1;
			List<Image> editingImages = PM.producer.imagesInTheWorkingArea();
			foreach (Image image in editingImages)
			{
				PictureBox pic = new PictureBox();
				pic.Image = image.BitmapImage;
				pic.Location = new Point(x, y);
				pic.Tag = image;
				pic.SizeMode = PictureBoxSizeMode.StretchImage;
				pic.Click += ImageEditingBorderClick;
				pic.Click += MainEditingImage;
				pic.ContextMenuStrip = contextMenuStripEditing;
				pic.Name = image.Name;

				x += pic.Width + 10;
				maxHeight = Math.Max(pic.Height, maxHeight);
				if (x > this.topauxlabel.Width - 100)
				{
					x = 20;
					y += maxHeight + 10;
				}
				this.topauxlabel.Controls.Add(pic);
			}

		}

		private void MainEditingImage(object sender, EventArgs e)
		{
			PictureBox image = (PictureBox)sender;
			pictureChosen.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureChosen.Image = image.Image;
			brightnessBar.Value = 0;
		}

        private void ImageEditingBorderClick(object sender, EventArgs e)
		{
			PictureBox PIC = (PictureBox)sender;
			if (chosenEditingImage != PIC && chosenEditingImage != null)
			{
				chosenEditingImage.BorderStyle = BorderStyle.None;
				chosenEditingImage = PIC;
			}
			else
			{
				chosenEditingImage = PIC;
			}
			pictureCollageImage.Image = chosenEditingImage.Image;
			PIC.BorderStyle = BorderStyle.Fixed3D;
		}

		private void ReLoadEditingPanelImage(object sender, EventArgs e)
		{
			topauxlabel.Controls.Clear();
			EditingPanel_Paint(sender, e);
		}

		private void RemoveFromEditingAreaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (library.Images.Count != 0)
			{
				if (MessageBox.Show("Are you sure you want to delete this image from the editing area?", "Warning!",
					   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ToolStripItem menuItem = sender as ToolStripItem;
					if (menuItem != null)
					{
						// Retrieve the ContextMenuStrip that owns this ToolStripItem
						ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
						if (owner != null)
						{
							// Get the control that is displaying this context menu
							Control sourceControl = owner.SourceControl;
							PictureBox PIC = (PictureBox)sourceControl;
							Image im = (Image)PIC.Tag;
							PM.producer.RemoveImage(im.Name);
							ReLoadEditingPanelImage(sender, e);
							Saved = false;
							if (PIC == chosenEditingImage)
							{
								pictureChosen.SizeMode = PictureBoxSizeMode.CenterImage;
								pictureChosen.Image = pictureChosen.ErrorImage;
								chosenEditingImage = null;
							}
							//PM.SaveProducer();    ERRORES CUANDO SE LEE IMAGENES EN producer.bin
						}
					}
				}
			}
			
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.BlackNWhiteFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.SepiaFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void ExportToLibraryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					Control sourceControl = owner.SourceControl;
					PictureBox PIC = (PictureBox)sourceControl;
					Image im = (Image)PIC.Tag;
					PM.producer.RemoveImage(im.Name);
					library.AddImage(im);
					ReLoadPanelImage(sender, e);
					ReLoadEditingPanelImage(sender, e);
					Saved = false;
					if (PIC == chosenEditingImage)
					{
						pictureChosen.SizeMode = PictureBoxSizeMode.CenterImage;
						pictureChosen.Image = pictureChosen.ErrorImage;
						chosenEditingImage = null;
					}

				}
			}
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.WindowsFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.OldFilmFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.InvertFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.AutomaticAdjustmentFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.MirrorFilter);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				if (colorDialogFilter.ShowDialog() == DialogResult.OK)
				{
					Image image = (Image)chosenEditingImage.Tag;
					image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.ColorFilter,colorDialogFilter.Color);
					chosenEditingImage.Image = image.BitmapImage;
					pictureChosen.Image = chosenEditingImage.Image;
				}
			}


		}

		private void ComboRotate_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.RotateFlipFilter,Color.Empty,0,60,(RotateFlipType)comboRotate.SelectedItem);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void TrackBar1_Scroll(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				image.BitmapImage = producer.ApplyFilter((Image)chosenEditingImage.Tag, EFilter.BrightnessFilter, Color.Empty, brightnessBar.Value);
				chosenEditingImage.Image = image.BitmapImage;
				pictureChosen.Image = chosenEditingImage.Image;
			}
		}

		private void ComboCensor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				SelectFaceLocationForm newForm = new SelectFaceLocationForm();
				newForm.ActualImage = image.BitmapImage;
				newForm.ShowDialog();
				int newLeft = newForm.ReturningLeft;
				int newTop = newForm.ReturningTop;
				int newHeight = newForm.ReturningHeight;
				int newWidth = newForm.ReturningWidth;
				
				switch (comboCensor.SelectedItem) {
					case "Black bar":
						if (newForm.Exit)
						{
							int[] coordinatesBlack = { newWidth, newHeight, newTop, newLeft };
							image.BitmapImage = producer.BlackCensorship(image, coordinatesBlack);
							chosenEditingImage.Image = image.BitmapImage;
							pictureChosen.Image = chosenEditingImage.Image;
						}
						break;
					case "Pixel blur":
						if (newForm.Exit)
						{
							int[] coordinatesBlur = { newLeft, newTop, newWidth, newHeight };
							image.BitmapImage = producer.PixelCensorship(image, coordinatesBlur);
							chosenEditingImage.Image = image.BitmapImage;
							pictureChosen.Image = chosenEditingImage.Image;
						}
						break;
				}
			}
		}

        // ==============================================================================
        // =============================== ADD LABEL METHODS ============================

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (createdLabel == null)
            {
                if (MessageBox.Show("You didn't create any new Label. Do you want to exit?", "Warning!",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AddLabelPanel.Visible = false;
                }
            }
            AddLabelPanel.Visible = false;
            this.importToolStripMenuItem1.Enabled = true;
            this.importWithLabelsToolStripMenuItem.Enabled = true;
            this.exportToolStripMenuItem.Enabled = true;
            this.exportAsToolStripMenuItem.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;
            this.cleanLibraryToolStripMenuItem.Enabled = true;
            this.LabelsPropertyGrid.SelectedObject = new object();
            Refresh_LabelsPropertyGrid();
        }

        private void AddLabelController()
        {
            this.createdLabel = null;
            this.AddLabelImageBox.Image = (Bitmap)this.imagetoaddlabel.BitmapImage.Clone();
            this.AddLabelImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PersonLabelNationalityComboBox.DataSource = Enum.GetValues(typeof(ENationality));
            this.PersonLabelHairColorComboBox.DataSource = Enum.GetValues(typeof(EColor));
            this.PersonLabelEyesColorComboBox.DataSource = Enum.GetValues(typeof(EColor));
            this.PersonLabelSexComboBox.DataSource = Enum.GetValues(typeof(ESex));
            this.PersonalizedTagCheck.Checked = true;
            this.SpecialLabelSelfieComboxBox.SelectedIndex = 0;
            this.importToolStripMenuItem1.Enabled = false;
            this.importWithLabelsToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Enabled = false;
            this.exportAsToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Enabled = false;
            this.cleanLibraryToolStripMenuItem.Enabled = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            switch (combo.SelectedIndex)
            {
                case 0:
                    AuxiliarEnablerDisabler("SimpleLabel");
                    break;
                case 1:
                    AuxiliarEnablerDisabler("PersonLabel");
                    break;
                case 2:
                    AuxiliarEnablerDisabler("SpecialLabel");
                    break;
            }
        }

        private void AuxiliarEnablerDisabler(string type)
        {
            switch (type)
            {
                case "SimpleLabel":
                    AddSimpleLabelPanel.Visible = true;
                    AddPersonLabelPanel.Visible = false;
                    AddSpecialLabelPanel.Visible = false;
                    break;

                case "PersonLabel":
                    AddPersonLabelPanel.Visible = true;
                    AddSimpleLabelPanel.Visible = false;
                    AddSpecialLabelPanel.Visible = false;
                    break;
                case "SpecialLabel":
                    AddPersonLabelPanel.Visible = false;
                    AddSimpleLabelPanel.Visible = false;
                    AddSpecialLabelPanel.Visible = true;
                    break;
            }
        }

        private void AddLabelButton_Click(object sender, EventArgs e)
        {
            switch (this.SelectedLabelComboBox1.SelectedIndex)
            {
                case 0:
                    if (this.PersonalizedTagCheck.Checked)
                    {
                        if (this.SimpleLabelTagBox.Text == "")
                        {
                            MessageBox.Show("You cant add an empty tag", "Add label error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            
                            this.createdLabel = new SimpleLabel(this.SimpleLabelTagBox.Text);
                            this.imagetoaddlabel.AddLabel(createdLabel);
                        }
                    }
                    else
                    {
                        if (Convert.ToString(this.WatsonRecommendationsComboBox.SelectedItem) == "")
                        {
                            MessageBox.Show("You cant add an empty tag", "Add label error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                        {
                            this.createdLabel = new SimpleLabel(Convert.ToString(this.WatsonRecommendationsComboBox.SelectedItem));
                            this.imagetoaddlabel.AddLabel(createdLabel);
                        }
                    }
                    break;
                case 1:
                    this.createdLabel = new PersonLabel(this.PersonLabelNameBox.Text == "" ? null : this.PersonLabelNameBox.Text,
                    (FaceLocationLeftTag.Text == "0" && FaceLocationTopTag.Text == "0" && FaceLocationWidthTag.Text == "0" && FaceLocationHeightTag.Text == "0") ? null : new double[] { Convert.ToInt32(FaceLocationLeftTag.Text), Convert.ToInt32(FaceLocationTopTag.Text), Convert.ToInt32(FaceLocationWidthTag.Text), Convert.ToInt32(FaceLocationHeightTag.Text) },
                    this.PersonLabelSurnameBox.Text == "" ? null : this.PersonLabelSurnameBox.Text, (ENationality)this.PersonLabelNationalityComboBox.SelectedItem,
                    (EColor)this.PersonLabelEyesColorComboBox.SelectedItem, (EColor)this.PersonLabelHairColorComboBox.SelectedItem, (ESex)this.PersonLabelSexComboBox.SelectedItem,
                    this.PersonLabelBirthDatePicker.Value.Date.ToString() == "01-01-1930 0:00:00" ? "" : this.PersonLabelBirthDatePicker.Value.Date.ToString());
                    this.imagetoaddlabel.AddLabel(createdLabel);
                    break;
                case 2:
                    this.createdLabel = new SpecialLabel((this.SpecialLabelLatitudeUpDown.Value == 0 && this.SpecialLabelLongitudeUpDown.Value == 0) ? null : new double[] { Convert.ToDouble(this.SpecialLabelLatitudeUpDown.Value), Convert.ToDouble(this.SpecialLabelLatitudeUpDown.Value) },
                        (this.SpecialLabelAddressTextBox.Text == "") ? null : this.SpecialLabelAddressTextBox.Text, (this.SpecialLabelPhotographerTextBox.Text == "") ? null : this.SpecialLabelPhotographerTextBox.Text,
                        (this.SpecialLabelPhotoMotiveTextBox.Text == "") ? null : this.SpecialLabelPhotoMotiveTextBox.Text, (this.SpecialLabelSelfieComboxBox.SelectedItem.ToString() == "Si") ? true : false) ;
                    this.imagetoaddlabel.AddLabel(createdLabel);
                    break;
            }
        }

        private void PersonalizedTagCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                SimpleLabelTagBox.Enabled = true;
                WatsonTagCheck.Checked = false;
            }
            else
            {
                SimpleLabelTagBox.Enabled = false;
                WatsonTagCheck.Checked = true;
            }
        }

        private void WatsonTagCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                PersonalizedTagCheck.Checked = false;
                LoadWatsonRecommendationsButton.Enabled = true;
                WatsonRecommendationsComboBox.Enabled = true;
            }
            else
            {
                PersonalizedTagCheck.Checked = true;
                LoadWatsonRecommendationsButton.Enabled = false;
                WatsonRecommendationsComboBox.Enabled = false;
                LoadingWatsonRecommendationsLabel.Text = "";
            }
            
        }

        private void LoadWatsonRecommendationsButton_Click(object sender, EventArgs e)
        {
            this.WatsonRecommendationsComboBox.Items.Clear();
            this.LoadingWatsonRecommendationsLabel.Text = "Loading...";
            this.LoadingWatsonRecommendationsLabel.Visible = true;
            List<string> options = this.PM.LoadWatsonRecommendations(this.imagetoaddlabel, this.producer);
            foreach (string option in options)
            {
                this.WatsonRecommendationsComboBox.Items.Add(option);
            }
            this.LoadingWatsonRecommendationsLabel.Text = "Done!";
        }

        private void SelectFaceLocationButton_Click(object sender, EventArgs e)
        {
            SelectFaceLocationForm newForm = new SelectFaceLocationForm();
            newForm.ActualImage = (Bitmap)this.AddLabelImageBox.Image;
            var result = newForm.ShowDialog();
            int newLeft = newForm.ReturningLeft;
            int newTop = newForm.ReturningTop;
            int newHeight = newForm.ReturningHeight;
            int newWidth = newForm.ReturningWidth;
            if (newLeft != 0 && newTop != 0 && newHeight != 0 && newWidth != 0)
            {
                this.FaceLocationTopTag.Text = Convert.ToString(newTop);
                this.FaceLocationLeftTag.Text = Convert.ToString(newLeft);
                this.FaceLocationWidthTag.Text = Convert.ToString(newWidth);
                this.FaceLocationHeightTag.Text = Convert.ToString(newHeight);
            }
        }

        private void PutZeroButton_Click(object sender, EventArgs e)
        {
            this.FaceLocationTopTag.Text = "0";
            this.FaceLocationLeftTag.Text = "0";
            this.FaceLocationWidthTag.Text = "0";
            this.FaceLocationHeightTag.Text = "0";
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Asdfbutton_Click(object sender, EventArgs e)
        {
            // Ya reconocimos cual fue el Image seleccionado para agregar el label
            AddLabelPanel.Visible = true;
            AddLabelController();
        }

		private void Button13_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				Image image = (Image)chosenEditingImage.Tag;
				FormAdd form = new FormAdd();
				form.ActualImage = image.BitmapImage;
				form.ShowDialog();
				int x = form.X;
				int y = form.Y;
				string Text = form.Text;
				string FontStyle = form.FontStyle;
				string FontName = form.FontName;
				float FontSize = form.FontSize;
				Color MainColor = form.MainColor;
				Color SecondColor = form.SecondaryColor;
				if (SecondColor == Color.Empty)
				{
					SecondColor = MainColor;
				}
				if (form.Exit)
				{
					image.BitmapImage = producer.AddText(image.BitmapImage, Text, x, y, FontSize, MainColor, FontStyle, FontName, SecondColor);
					chosenEditingImage.Image = image.BitmapImage;
					pictureChosen.Image = chosenEditingImage.Image;
				}
			}
		}

		private void Button14_Click(object sender, EventArgs e)
		{
			if (chosenEditingImage != null)
			{
				panelResize.Visible = true;
				Image image = (Image)chosenEditingImage.Tag;
				XText.Text = image.Resolution[0].ToString();
				YText.Text = image.Resolution[1].ToString();
			}

		}

		private void ResizeDone_Click(object sender, EventArgs e)
		{
			panelResize.Visible = false;
			Resizer res = new Resizer();
			int x = Convert.ToInt32(XText.Text);
			int y = Convert.ToInt32(YText.Text);
			Image image = (Image)chosenEditingImage.Tag;
			image.BitmapImage = res.ResizeImage(image.BitmapImage, x,y);
			chosenEditingImage.Image = image.BitmapImage;
			pictureChosen.Image = chosenEditingImage.Image;
		}

		private void AddToFeaturesListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					Control sourceControl = owner.SourceControl;
					PictureBox PIC = (PictureBox)sourceControl;
					Image im = (Image)PIC.Tag;
					featuresImage.Add(im);
				}
			}
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			if (featuresImage.Count > 1)
			{
				Bitmap merged = producer.Merge(featuresImage);
				Image MergeImage = new Image(merged, new List<Label>(), -1);
				producer.LoadImagesToWorkingArea(new List<Image>() { MergeImage});
				EditingPanel_Paint(sender, e);
				featuresImage.Clear();
				pictureChosen.Image = merged;
			}
			else
			{
				MessageBox.Show("Select at least two images", "Not enough images.",
					  MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}

		private void RemoveFromFeaturesListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripItem menuItem = sender as ToolStripItem;
			if (menuItem != null)
			{
				// Retrieve the ContextMenuStrip that owns this ToolStripItem
				ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
				if (owner != null)
				{
					// Get the control that is displaying this context menu
					Control sourceControl = owner.SourceControl;
					PictureBox PIC = (PictureBox)sourceControl;
					Image im = (Image)PIC.Tag;
					featuresImage.Remove(im);
				}
			}
		}

		private void EditingPanel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Button15_Click(object sender, EventArgs e)
		{
		
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			if(featuresImage.Count > 1)
			{
				panelCollage.Visible = true;
				try
				{
					pictureCollageImage.Image = chosenEditingImage.Image;
					pictureCollageImage.SizeMode = PictureBoxSizeMode.StretchImage;
				}
				catch
				{
					pictureCollageImage.Image = pictureCollageImage.ErrorImage;
					pictureCollageImage.SizeMode = PictureBoxSizeMode.StretchImage;
				}
			}
			else
			{
				MessageBox.Show("Select at least two images", "Not enough images.",
					  MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}


		private void ButtonCollage_Click(object sender, EventArgs e)
		{
			try
			{
				int BaseW = Convert.ToInt32(textBaseW.Text);
				int BaseH = Convert.ToInt32(textBaseH.Text);
				int InsertW = Convert.ToInt32(textInsertW.Text);
				int InsertH = Convert.ToInt32(textInsertH.Text);
				if (radioButtonSolid.Checked)
				{
					if (colorDialogFilter.ShowDialog() == DialogResult.OK)
					{

						Color color = colorDialogFilter.Color;
						Bitmap collage = producer.Collage(featuresImage, BaseW, BaseH, InsertW, InsertH, null, color.R, color.G, color.B);
						Image MergeImage = new Image(collage, new List<Label>(), -1);
						producer.LoadImagesToWorkingArea(new List<Image>() { MergeImage });
						EditingPanel_Paint(sender, e);
						featuresImage.Clear();
						pictureChosen.Image = collage;
						panelCollage.Visible = false;
						textBaseW.Text = "";
						textBaseH.Text = "";
						textInsertW.Text = "";
						textInsertH.Text = "";
					}
				}
				else if (radioButtonImage.Checked && chosenEditingImage != null)
				{
					Image im = (Image)chosenEditingImage.Tag;
					Bitmap collage = producer.Collage(featuresImage, BaseW, BaseH, InsertW, InsertH, im.BitmapImage);
					Image MergeImage = new Image(collage, new List<Label>(), -1);
					producer.LoadImagesToWorkingArea(new List<Image>() { MergeImage });
					EditingPanel_Paint(sender, e);
					featuresImage.Clear();
					pictureChosen.Image = collage;
					panelCollage.Visible = false;
					textBaseW.Text = "";
					textBaseH.Text = "";
					textInsertW.Text = "";
					textInsertH.Text = "";
				}
				else
				{
					MessageBox.Show("There is no picture selected", "Error",
					  MessageBoxButtons.OK, MessageBoxIcon.Question);
				}
			}
			catch
			{
				MessageBox.Show("Wrong Parameters", "Error",
					  MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}

        private void ImportToolStripMenuItem1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void ImportToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor= Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void ImportWithLabelsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void ImportWithLabelsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void ExportToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void ExportToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void ExportAsToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void ExportAsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void SaveToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void SaveToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void CleanLibraryToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void CleanLibraryToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }
    }

   public class MyRenderer : ToolStripProfessionalRenderer
   {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            Color c = e.Item.Selected ? Color.Crimson : Color.FromArgb(11, 7, 17);
            using (SolidBrush brush = new SolidBrush(c))
                e.Graphics.FillRectangle(brush, rc);
        }
   }
}

