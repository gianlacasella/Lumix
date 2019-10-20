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
        Label createdLabel;
        Image imagetoaddlabel;


		public MainWindow()
		{
			InitializeComponent();
		}


		private void MainWindow_Load(object sender, EventArgs e)
		{
			library = PM.LoadingLibraryManager();
			producer = PM.LoadingProducerManager();
			PanelImages_Paint(sender, e);
			comboRotate.DataSource = Enum.GetValues(typeof(RotateFlipType));
			comboCensor.Items.Add("Black bar"); comboCensor.Items.Add("Pixel blur");
            AddLabelPanel.Location = panelImages.Location;
            AddLabelPanel.Visible = false;
            panelImages.Visible = true;
		}


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
				foreach(string path in files)
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
					if(PIC == chosenImage)
					{
						chosenImage = null;
					}
				}
			}
		}


		private void ImageDetailClick(object sender, EventArgs e)
        { 
			PictureBox PIC = (PictureBox)sender;
            Image image = (Image)PIC.Tag;
            titleLabel.Text = image.Name + "\n\n";
            informationLabel.Text = "Res: " + Convert.ToString(image.Resolution[0]) + "x" + Convert.ToString(image.Resolution[1] + "\n");
            informationLabel.Text += "AspectR: " + Convert.ToString(image.AspectRatio[0]) + ":" + Convert.ToString(image.AspectRatio[1]+"\n");
            if (image.DarkClear == true)
            {
                informationLabel.Text += "Clear" + "\n";
            }
            else
            {
                informationLabel.Text += "Dark" + "\n";
            }

            // Now, we see if the images has some labels
            List<SpecialLabel> splabels = image.SelectSpecialLabel();
            List<SimpleLabel> slabels = image.SelectSimpleLabels();
            List<PersonLabel> plabels = image.SelectPersonLabels();

            List<Label> aux = new List<Label>();

            foreach (SimpleLabel sl in slabels)
            {
                aux.Add((Label)sl);
            }
            string response = ToString(aux, "SimpleLabel");
            informationLabel.Text += response;

            aux.Clear();
            foreach (PersonLabel sl in plabels)
            {
                aux.Add((Label)sl);
            }
            informationLabel.Text += ToString(aux, "PersonLabel");

            aux.Clear();
            foreach (SpecialLabel sl in splabels)
            {
                aux.Add((Label)sl);
            }
            informationLabel.Text += ToString(aux, "SpecialLabel");

        }


        private string ToString(List<Label> labels, string type)
        {
            string returningstring = "";
            switch (type)
            {
                case "SimpleLabel":
                    returningstring += "\n\nSimpleLabels:";
                    if (labels.Count == 0)
                    {
                        returningstring += " Empty";
                        break;
                    }
                    foreach (Label label in labels)
                    {
                        SimpleLabel splabel = (SimpleLabel)label;
                        if(splabel.Sentence != null) returningstring += "\nTag: " + splabel.Sentence;
                    }
                    break;
                case "PersonLabel":
                    returningstring += "\n\nPersonLabels:";
                    if (labels.Count == 0)
                    {
                        returningstring += " Empty";
                        break;
                    }
                    foreach (Label label in labels)
                    {
                        PersonLabel pslabel = (PersonLabel)label;
                        if(pslabel.Name != null) returningstring += "\nName: " + pslabel.Name;
                        if (pslabel.Surname!= null) returningstring += "\nSurname: " + pslabel.Surname;
                        if (pslabel.Nationality != ENationality.None) returningstring += "\nNationality: " + pslabel.Nationality;
                        if (pslabel.HairColor != EColor.None) returningstring += "\nHairColor: " + pslabel.HairColor;
                        if (pslabel.EyesColor != EColor.None) returningstring += "\nEyesColor: " + pslabel.HairColor;
                        if (pslabel.Sex != ESex.None) returningstring += "\nSex: " + pslabel.Sex;
                        if (pslabel.BirthDate != "") returningstring += "\nBirthdate: " + pslabel.BirthDate;
                        if (pslabel.FaceLocation!= null) returningstring += "\nFaceLocation: " + pslabel.FaceLocation[0]+","+pslabel.FaceLocation[1]+","+pslabel.FaceLocation[2]+","+pslabel.FaceLocation[3];
                    }
                    break;
                case "SpecialLabel":
                    returningstring += "\n\nSpecialLabels:";
                    if (labels.Count == 0)
                    {
                        returningstring += " Empty";
                        break;
                    }
                    foreach (Label label in labels)
                    {
                        SpecialLabel splabel = (SpecialLabel)label;
                        if (splabel.GeographicLocation != null) returningstring += "\nGeographicLoc: " + splabel.GeographicLocation[0] + ","+splabel.GeographicLocation[1];
                        if (splabel.Photographer != null) returningstring += "\nPhotographer: " + splabel.Photographer;
                        if (splabel.Address != null) returningstring += "\nAddress: " + splabel.Address;
                        if (splabel.PhotoMotive != null) returningstring += "\nPhotoMotive: " + splabel.PhotoMotive;
                        if (splabel.Selfie != false) returningstring += "\nSelfie: " + "Yes";
                        else returningstring += "\nSelfie: " + "No";
                    }
                    break;
            }
            return returningstring;
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


		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PM.SaveLibrary(library);
			Saved = true;
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

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
					producer.LoadImagesToWorkingArea(new List<Image>() { (Image)PIC.Tag});
					EditingPanel_Paint(sender, e);
					//PM.SaveProducer();    ERRORES CUANDO SE LEE IMAGENES EN producer.bin
				}
			}
        }

        private void PanelImages_Click(object sender, EventArgs e)
        {
            if (chosenImage != null)
            {
                titleLabel.Text = "";
                informationLabel.Text = "";
                
                chosenImage.BorderStyle = BorderStyle.None;
                chosenImage = null;
            }
            
        }

        // Metodo que se ejecuta cuando el usuario quiere agregar un label (hace clic en la opcion Add label)
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
                    //AddLabelForm newForm = new AddLabelForm(imagetoaddlabel);
                    //panelImages.Visible = ;
                    AddLabelPanel.Visible = true;
                    this.imagetoaddlabel = imagetoaddlabel;
                    AddLabelController();
                    //newForm.ShowDialog();
				}
            }
            else
            {
                return;
            }


        }

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
				switch (comboCensor.SelectedItem) {
					case "Black bar":
						break;
					case "Pixel blur":
						break;
				}
			}
		}

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (createdLabel == null)
            {
                if (MessageBox.Show("You didn't create any new Label. Do you want to exit?", "Warning!",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            AddLabelPanel.Visible = false;
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
                    break;

                case "PersonLabel":
                    AddPersonLabelPanel.Visible = true;
                    AddSimpleLabelPanel.Visible = false;
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
                    if (FaceLocationLeftTag.Text != "0" && FaceLocationTopTag.Text != "0" && FaceLocationWidthTag.Text != "0" && FaceLocationHeightTag.Text != "0")
                    {
                        this.createdLabel = new PersonLabel(this.PersonLabelNameBox.Text, new double[] { Convert.ToInt32(FaceLocationLeftTag.Text),
                        Convert.ToInt32(FaceLocationTopTag.Text),Convert.ToInt32(FaceLocationWidthTag.Text), Convert.ToInt32(FaceLocationHeightTag.Text)},
                        this.PersonLabelSurnameBox.Text, (ENationality)this.PersonLabelNationalityComboBox.SelectedItem,
                        (EColor)this.PersonLabelEyesColorComboBox.SelectedItem, (EColor)this.PersonLabelHairColorComboBox.SelectedItem, (ESex)this.PersonLabelSexComboBox.SelectedItem,
                        this.PersonLabelBirthDatePicker.Value.Date.ToString());
                        this.imagetoaddlabel.AddLabel(createdLabel);
                        break;
                    }
                    else
                    {
                        this.createdLabel = new PersonLabel(this.PersonLabelNameBox.Text, null,
                        this.PersonLabelSurnameBox.Text, (ENationality)this.PersonLabelNationalityComboBox.SelectedItem,
                        (EColor)this.PersonLabelEyesColorComboBox.SelectedItem, (EColor)this.PersonLabelHairColorComboBox.SelectedItem, (ESex)this.PersonLabelSexComboBox.SelectedItem,
                        this.PersonLabelBirthDatePicker.Value.Date.ToString());
                        this.imagetoaddlabel.AddLabel(createdLabel);
                        break;
                    }
                    
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
    }
        
}

