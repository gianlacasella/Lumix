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
			foreach (Image image in library.Images)
			{
				PictureBox pic = new PictureBox();
				pic.Image = image.BitmapImage;
				pic.Location = new Point(x, y);
				pic.SizeMode = PictureBoxSizeMode.StretchImage;
				//pic.Click += Picture_Clicked;
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
			}
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
				string[] files = ofd.FileNames;
				foreach(string path in files)
				{
					string name = Path.GetFileNameWithoutExtension(path);
					Image returningImage = new Image(path, new List<Label>(), -1);
					returningImage.Name = name;
					library.AddImage(returningImage);
					panelImages.Controls.Clear();
					PM.SaveLibrary(library);
				}
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
					panelImages.Controls.Clear();
					PM.SaveLibrary(library);

				}
			}
		}

	}
}
