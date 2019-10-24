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
        Size formsizewithrightpanel = new Size(1662, 822);
        Size formsizewithoutrightpanel = new Size(665, 822);
        // Usuario que se ha logueado
        User userLoggedIn = null;
        // bool que controla si el usuario desea cerrar el programa o cerrar sesion
        bool exit = true;
        // bool que controla si el usuario desea eliminar su cuenta
        bool deleteaccount = false;
        Bitmap chooseUserPictureBitmap;
        Searcher mainSearcher;

        public User UserLoggedIn { get => this.userLoggedIn; set => this.userLoggedIn = value; }
        public bool Exit { get => this.exit; set => this.exit = value; }
        public bool Deleteaccount { get => this.deleteaccount; set => this.deleteaccount = value; }

        // =============================== FRAME METHODS ================================
        public MainWindow()
		{
			InitializeComponent();
            this.menuStrip1.Renderer = new MyRenderer();
        }

		private void MainWindow_Load(object sender, EventArgs e)
		{
			library = PM.LoadingUsersLibraryManager(UserLoggedIn.Usrname);
			producer = PM.LoadingUsersProducerManager(UserLoggedIn.Usrname);
			PanelImages_Paint(sender, e);
			comboRotate.DataSource = Enum.GetValues(typeof(RotateFlipType));
			comboCensor.Items.Add("Black bar"); comboCensor.Items.Add("Pixel blur");comboCensor.Text = "Black bar";
            AddLabelPanel.Location = panelImages.Location;
            AddLabelPanel.Visible = false;
            this.Size = formsizewithoutrightpanel;
            string arrowiconslocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\logos\";
            Bitmap rightarrow = (Bitmap)Bitmap.FromFile(arrowiconslocation + "rightarrow.png");
            OpenRightPanelButton.BackgroundImage = rightarrow;
            OpenRightPanelButton.BackgroundImageLayout = ImageLayout.Zoom;
            
            string imageLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\logos\";
            Bitmap image = (Bitmap)Bitmap.FromFile(imageLocation + "changeuserpicture.png");
            Resizer res = new Resizer();
            int x = 150;
            int y = 150;
            this.chooseUserPictureBitmap = res.ResizeImage(image, x, y);

            this.mainSearcher = new Searcher();
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
                this.Cursor = Cursors.WaitCursor;
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
                this.Cursor = Cursors.Arrow;
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
            PM.SavingUsersLibraryManager(UserLoggedIn.Usrname, library);
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
                    //panelImages.Visible = false;
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

        // Metodo que se utiliza para imprimir en pantalla los resultados de una busqueda
        private void PanelImages_PaintSearchResult(List<Image> result)
        {
            int x = 20;
            int y = 20;
            int maxHeight = -1;
            int count = 1;
            this.ToolbarProgressBar.Value = 0;
            this.ToolbarProgressBar.Visible = true;
            foreach (Image image in result)
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
                this.ToolbarProgressBar.Increment((count * 100) / library.Images.Count);
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
            // Esto estaba del property grid
            //this.LabelsPropertyGrid.SelectedObject = imagets;
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
                // Tambien del property grid
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
            panelImages.Visible = true;
            this.importToolStripMenuItem1.Enabled = true;
            this.exportToolStripMenuItem.Enabled = true;
            this.saveToolStripMenuItem.Enabled = true;
            this.cleanLibraryToolStripMenuItem.Enabled = true;
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
            this.exportToolStripMenuItem.Enabled = false;
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
            panelImages.Visible = false;
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

        private void PanelImages_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            panelImages.BackColor = Color.FromArgb(35, 32, 39);
            this.Cursor = Cursors.WaitCursor;
            this.ToolbarProgressBar.Value = 0;
            this.ToolbarProgressBar.Visible = true;
            int count = 1;
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
            this.Cursor = Cursors.Arrow;
        }

        private void PanelImages_DragLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            panelImages.BackColor = Color.FromArgb(11, 7, 17);
        }

        private void OpenRightPanelButton_Click(object sender, EventArgs e)
        {
            string arrowiconslocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\logos\";
            if (RightPanel.Visible == false)
            {
                RightPanel.Visible = true;
                this.Size = formsizewithrightpanel;
                Bitmap leftarrow = (Bitmap)Bitmap.FromFile(arrowiconslocation + "leftarrow.png");
                OpenRightPanelButton.BackgroundImage = leftarrow;
                
            }
            else
            {
                RightPanel.Visible = false;
                this.Size = formsizewithoutrightpanel;
                Bitmap rightarrow = (Bitmap)Bitmap.FromFile(arrowiconslocation + "rightarrow.png");
                OpenRightPanelButton.BackgroundImage = rightarrow;
            }
            OpenRightPanelButton.BackgroundImageLayout = ImageLayout.Zoom;
        }

		private void ExitCollageButton_Click(object sender, EventArgs e)
		{
			panelCollage.Visible = false;
		}

		private void ExitResizeButton_Click(object sender, EventArgs e)
		{
			panelResize.Visible = false;
		}

		private void SlideShowButton_Click(object sender, EventArgs e)
		{
			if (featuresImage.Count > 0)
			{
				SlideNPresentation slide = new SlideNPresentation(featuresImage, true);
				slide.ShowDialog();
			}
			else
			{
				MessageBox.Show("There has to be at least one picture selected", "Error",
					  MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}

		private void PresentationButton_Click(object sender, EventArgs e)
		{
			if (featuresImage.Count > 0)
			{
				SlideNPresentation slide = new SlideNPresentation(featuresImage, false);
				slide.ShowDialog();
			}
			else
			{
				MessageBox.Show("There has to be at least one picture selected", "Error",
					  MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cambiamos el atributo de exit a false, pues quiere cambiar de usuario
            this.exit = false;
            // Ya el  usuario no es el current user, por lo tanto
            this.UserLoggedIn.CurrentUser = false;
            // Cerramos el form
            this.Close();
        }

        private void LogOutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void LogOutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void ExitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void ExitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void MyAccountToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Bold);
        }

        private void MyAccountToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            var selecteditem = (ToolStripMenuItem)sender;
            selecteditem.Font = new Font(selecteditem.Font, FontStyle.Regular);
        }

        private void MyAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hacemos switch entre los paneles
            if (AccountPanel.Visible == false)
            {
                AccountPanel.Visible = true;
                panelImages.Visible = false;
                AddLabelPanel.Visible = true;
                UsernameLabel.Text = userLoggedIn.Usrname;
                UserPicturePictureBox.BackgroundImage = userLoggedIn.UsrImage;
                this.MemberSinceLabel.Text = "Member since " + userLoggedIn.Membersince.Date.ToString("MM/dd/yyyy");
                if (UserLoggedIn.Name != null && UserLoggedIn.Name != "")
                {
                    this.RealNameTextBox.Text = UserLoggedIn.Name;
                }
                if (UserLoggedIn.Surname != null && UserLoggedIn.Surname != "")
                {
                    this.RealSurnameTextBox.Text = UserLoggedIn.Surname;
                }
                if (UserLoggedIn.Nationality != ENationality.None)
                {
                    this.RealNationalityComboBox.SelectedItem = UserLoggedIn.Nationality;
                }
                if (UserLoggedIn.Description != null && UserLoggedIn.Description != "")
                {
                    this.DescriptionTextBox.Text = UserLoggedIn.Description;
                }
                if (UserLoggedIn.BirthDate != new DateTime(1,1,1,0,0,0)) 
                {
                    this.UserDateTimePicker.Value = UserLoggedIn.BirthDate;
                }
                RealNationalityComboBox.DataSource = Enum.GetValues(typeof(ENationality));
            }
            else
            {
                AccountPanel.Visible = false;
                panelImages.Visible = true;
                AddLabelPanel.Visible = false;
            }
        }

        private void UserPicturePictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            UserPicturePictureBox.Image = null;
            UserPicturePictureBox.BackgroundImage = chooseUserPictureBitmap;
        }

        private void UserPicturePictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            UserPicturePictureBox.BackgroundImage = UserLoggedIn.UsrImage;
        }

        private void UserPicturePictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select your profile picture";
            ofd.Multiselect = false;
            ofd.Filter = "Supported formats |*.jpg;*.jpeg;*.png;*.bmp";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Resizer res = new Resizer();
                UserLoggedIn.UsrImage = res.ResizeImage((Bitmap)Bitmap.FromFile(ofd.FileNames[0]), 100, 100);
                UserPicturePictureBox.BackgroundImage = UserLoggedIn.UsrImage;
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            // Cambiamos el atributo de exit a false, pues quiere cambiar de usuario
            this.exit = false;
            // Ya el  usuario no es el current user, por lo tanto
            this.UserLoggedIn.CurrentUser = false;
            // Cerramos el form
            this.Close();
        }

        private void RealNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UserLoggedIn.Name = RealNameTextBox.Text;
        }

        private void RealSurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UserLoggedIn.Surname = RealSurnameTextBox.Text;
        }

        private void RealNationalityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UserLoggedIn.Nationality = (ENationality)RealNationalityComboBox.SelectedItem;
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UserLoggedIn.Description = DescriptionTextBox.Text;
        }

        private void UserDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.UserLoggedIn.BirthDate = UserDateTimePicker.Value.Date;
        }

        private void ChangePassButton_Click(object sender, EventArgs e)
        {
            if (ChangePasswordPanel.Visible == false)
            {
                ChangePasswordPanel.Visible = true;
            }
            else
            {
                ChangePasswordPanel.Visible = false;
            }
        }

        private void OldPasswordTextBox_MouseEnter(object sender, EventArgs e)
        {
            
            if (OldPasswordTextBox.Text == "OLD PASSWORD")
            {
                OldPasswordTextBox.Text = "";
                OldPasswordTextBox.ForeColor = Color.White;
            }
            
        }

        private void OldPasswordTextBox_MouseLeave(object sender, EventArgs e)
        {
            
            if (OldPasswordTextBox.Text == "")
            {
                OldPasswordTextBox.Text = "OLD PASSWORD";
                OldPasswordTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void NewPasswordTextBox_MouseEnter(object sender, EventArgs e)
        {
            
            if (NewPasswordTextBox.Text == "NEW PASSWORD")
            {
                NewPasswordTextBox.Text = "";
                NewPasswordTextBox.ForeColor = Color.White;
            }
        }

        private void NewPasswordTextBox_MouseLeave(object sender, EventArgs e)
        {
            
            if (NewPasswordTextBox.Text == "")
            {
                NewPasswordTextBox.Text = "NEW PASSWORD";
                NewPasswordTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void OldPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (OldPasswordTextBox.Text != userLoggedIn.Password && OldPasswordTextBox.Text != "OLD PASSWORD" && OldPasswordTextBox.Text != "")
                WrongOldPassword.Visible = true;
            else WrongOldPassword.Visible = false;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            userLoggedIn.Password = NewPasswordTextBox.Text;
            OldPasswordTextBox.Text = "OLD PASSWORD";
            OldPasswordTextBox.ForeColor = Color.DarkGray;
            NewPasswordTextBox.Text = "NEW PASSWORD";
            NewPasswordTextBox.ForeColor = Color.DarkGray;
            ChangePasswordPanel.Visible = false;
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your account?", "Delete account",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Cambiamos el atributo de exit a false, pues no se quiere cerrar la app sino cambiar de usuario
                this.exit = false;
                // Ya el  usuario no es el current user, por lo tanto
                this.UserLoggedIn.CurrentUser = false;
                // Como quiere eliminar su cuenta
                this.Deleteaccount = true;
                // Cerramos el form
                this.Close();
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "SEARCH PATTERN")
            {
                SearchTextBox.Text = "";
                SearchTextBox.ForeColor = Color.White;
            }
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "SEARCH PATTERN";
                SearchTextBox.ForeColor = Color.DarkGray;
            }
        }


        // METODO QUE SE EJECUTA CUANDO CAMBIA EL TEXTO EN EL SEARCHTEXTBOX
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // No hace el clear nisiquiera, no se porque
            panelImages.Controls.Clear();
            try
            {
                if (SearchTextBox.Text != "")
                {
                    List<Image> result = mainSearcher.Search(library.Images, SearchTextBox.Text);

                    if (result.Count != 0)
                    {
                        PanelImages_PaintSearchResult(result);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "NEW NAME")
            {
                nameTextBox.Text = "";
                nameTextBox.ForeColor = Color.White;
            }
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "")
            {
                nameTextBox.Text = "NEW NAME";
                nameTextBox.ForeColor = Color.DarkGray;
            }
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            MyAccountToolStripMenuItem_Click(this, EventArgs.Empty);
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

