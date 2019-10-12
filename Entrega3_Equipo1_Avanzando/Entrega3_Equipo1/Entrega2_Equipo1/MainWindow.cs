using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


		public MainWindow()
		{
			InitializeComponent();
			library = PM.LoadingLibraryManager();
            producer = PM.LoadingProducerManager();
		}


		private void MainWindow_Load(object sender, EventArgs e)
		{

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
				pic.SizeMode = PictureBoxSizeMode.StretchImage;
				pic.Click += ImageDetailClick;
				pic.ContextMenuStrip = contextMenuStripImage;
				pic.Tag = image;
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
					panelImages.Controls.Clear();
					library.AddImage(returningImage);
                    this.ToolbarProgressBar.Increment((count * 100) / files.Length);
                }
                this.ToolbarProgressBar.Visible = false;
                this.ToolbarProgressBar.Value = 0;
				PanelImages_Paint(sender, e);
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
					panelImages.Controls.Clear();
					library.RemoveImage(im.Name);
					PanelImages_Paint(sender, e);
					Saved = false;
				}
			}
		}

		/*
        private void ImageDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    PictureBox PIC = (PictureBox)sourceControl;
                    SelectedImageName.Text = PIC.Name;
                    ResolutionLabel.Text = Convert.ToString(PIC.Image.Width) + "x" + Convert.ToString(PIC.Image.Height);
                }
            }
        }
		*/

		private void ImageDetailClick(object sender, EventArgs e)
		{
			PictureBox PIC = (PictureBox)sender;
			Image image = (Image)PIC.Tag;
			SelectedImageName.Text = PIC.Name;
			ResolutionLabel.Text = Convert.ToString(PIC.Image.Width) + "x" + Convert.ToString(PIC.Image.Height);
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
	}
}
