using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega2_Equipo1
{
	public partial class SlideNPresentation : Form
	{
		PictureBox chosenImage = null;
		List<PictureBox> mainList = new List<PictureBox>();
		List<Image> images = new List<Image>();
		int DEFAULT_TIME = 3000;
		int indexPic =0;
		public SlideNPresentation(List<Image> featuresImage, bool Slide)
		{
			InitializeComponent();
			images = featuresImage;
			timeImageLabel.Text = "";
			if (Slide)
			{
				Load_Main_Panel(featuresImage, EventArgs.Empty);
			}
			else
			{
				panelShowImage.Visible = true;
				////////////////////////////
				MainPanel.Visible = false;
				NextButton.Visible = true;
				BackButton.Visible = true;
				MainPictureBox.Visible = true;
				WindowState = FormWindowState.Maximized;
				LoadImage(indexPic);
			}
		}

		private void Load_Main_Panel(object sender, EventArgs e)
		{
			int x = 20;
			int y = 20;
			int maxHeight = -1;
			List<Image> featuresImage = (List<Image>)sender;
			foreach (Image image in featuresImage)
			{
				PictureBox pic = new PictureBox();
				pic.Image = image.BitmapImage;
				pic.Location = new Point(x, y);
				pic.SizeMode = PictureBoxSizeMode.StretchImage;
				pic.Click += ImageBorderClick;
				pic.Click += ShowImageDetails;
				pic.Click += CleanTextBox;
				pic.Name = image.Name;
				pic.Tag = DEFAULT_TIME;


				x += pic.Width + 10;
				maxHeight = Math.Max(pic.Height, maxHeight);
				if (x > this.picturePanel.Width - 100)
				{
					x = 20;
					y += maxHeight + 10;
				}
				this.picturePanel.Controls.Add(pic);
				mainList.Add(pic);
			}
		}

		private void LoadImage(int Index)
		{
			MainPictureBox.Image = images[Index].BitmapImage;
		}

		private void CleanTextBox(object sender, EventArgs e)
		{
			textBoxNumber.Text = "";
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

		private void ShowImageDetails(object sender, EventArgs e)
		{
			PictureBox PIC = (PictureBox)sender;
			SlidePictureBox.Image = PIC.Image;
			timeImageLabel.Text = PIC.Tag.ToString();
		}

		private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		private void SetTimeImage_Click(object sender, EventArgs e)
		{
			if (textBoxNumber.TextLength > 0)
			{
				chosenImage.Tag = Convert.ToInt32(textBoxNumber.Text);
			}
			else
			{
				chosenImage.Tag = Convert.ToInt32(timeImageLabel.Text);
			}

			ShowImageDetails(chosenImage, EventArgs.Empty);
		}

		private void StartSlideButton_Click(object sender, EventArgs e)
		{
			MainPanel.Visible = false;
			panelShowImage.Visible = true;
			MainPictureBox.Visible = true;
			timerMain.Enabled = true;
			WindowState = FormWindowState.Maximized;

		}

		private void TimerMain_Tick(object sender, EventArgs e)
		{
			if (indexPic == mainList.Count)
			{
				timerMain.Enabled = false;
				Close();
			}
			else
			{
				PictureBox Pic = mainList[indexPic];
				timerMain.Interval = Convert.ToInt32(Pic.Tag);
				MainPictureBox.Image = Pic.Image;
				indexPic++;
			}
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			
			indexPic++;
			if (indexPic < images.Count)
			{
				LoadImage(indexPic);
			}
			else if(indexPic == images.Count)
			{
				MainPictureBox.Image = MainPictureBox.ErrorImage;
			}
			else
			{
				Close();
			}
			
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			if (indexPic != 0)
			{
				indexPic--;
				LoadImage(indexPic);
			}
		}
	}
}
