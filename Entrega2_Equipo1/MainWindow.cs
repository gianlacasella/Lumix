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


		public MainWindow()
		{
			InitializeComponent();

		}


		private void MainWindow_Load(object sender, EventArgs e)
		{
			library = PM.LoadingLibraryManager();
			producer = PM.LoadingProducerManager();
			PanelImages_Paint(sender, e);
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
			SelectedImageName.Text = PIC.Name;
			ResolutionLabel.Text = Convert.ToString(PIC.Image.Width) + "x" + Convert.ToString(PIC.Image.Height);
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
					pictureChosen.Image = PIC.Image;
					pictureChosen.Tag = (Image)PIC.Tag;
				}
			}
		}

		private void OldFilmButton_Click(object sender, EventArgs e)
		{	
			pictureChosen.Image = producer.ApplyFilter((Image)pictureChosen.Tag, EFilter.OldFilmFilter);
		}
	}
}
