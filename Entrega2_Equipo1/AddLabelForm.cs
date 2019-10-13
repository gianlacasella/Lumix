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
    public partial class AddLabelForm : Form
    {
        // Created label es un atributo de la ventana
        Label createdLabel;
        Image imagetoaddlabel;

        public AddLabelForm(Image imagetoaddlabel)
        {
            InitializeComponent();
            this.ImageBox.Image = imagetoaddlabel.BitmapImage;
            this.imagetoaddlabel = imagetoaddlabel;
            this.ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.createdLabel = null;
            this.PersonLabelNationalityComboBox.DataSource = Enum.GetValues(typeof(ENationality));
            this.PersonLabelHairColorComboBox.DataSource = Enum.GetValues(typeof(EColor));
            this.PersonLabelEyesColorComboBox.DataSource = Enum.GetValues(typeof(EColor));
            this.PersonLabelSexComboBox.DataSource = Enum.GetValues(typeof(ESex));
        }

        private void AddLabelForm_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            switch (combo.SelectedIndex)
            {
                case 0:
                    AuxiliarEnablerDisabler("SimpleLabel", true);
                    AuxiliarEnablerDisabler("PersonLabel", false);
                    break;
                case 1:
                    AuxiliarEnablerDisabler("SimpleLabel", false);
                    AuxiliarEnablerDisabler("PersonLabel", true);
                    break;
                case 2:
                    break;
            }
        }

        private void AuxiliarEnablerDisabler(string type, bool enable)
        {
            switch (type)
            {
                case "SimpleLabel":
                    this.SimpleLabelTagBox.Enabled = enable;
                    break;
                case "PersonLabel":
                    PersonLabelNameBox.Enabled = enable;
                    PersonLabelSurnameBox.Enabled = enable;
                    PersonLabelNationalityComboBox.Enabled = enable;
                    PersonLabelHairColorComboBox.Enabled = enable;
                    PersonLabelEyesColorComboBox.Enabled = enable;
                    PersonLabelSexComboBox.Enabled = enable;
                    PersonLabelBirthDateTextBox.Enabled = enable;
                    PersonLabelHEIGHTDomain.Enabled = enable;
                    PersonLabelWIDTHDomain.Enabled = enable;
                    PersonLabelTOPDomain.Enabled = enable;
                    PersonLabelLEFTDomain.Enabled = enable;
                    break;
            }
        }

        // Cuando el usuario hace clic sobre el boton para agregar label
        private void AddLabelButton_Click(object sender, EventArgs e)
        {
            switch (this.SelectedLabelComboBox1.SelectedIndex)
            {
                case 0:
                    this.createdLabel = new SimpleLabel(this.SimpleLabelTagBox.Text);
                    this.imagetoaddlabel.AddLabel(createdLabel);
                    break;
                case 1:
                    this.createdLabel = new PersonLabel(this.PersonLabelNameBox.Text, new double[] { this.PersonLabelTOPDomain.SelectedIndex,
                    this.PersonLabelLEFTDomain.SelectedIndex, this.PersonLabelHEIGHTDomain.SelectedIndex, this.PersonLabelWIDTHDomain.SelectedIndex},
                    this.PersonLabelSurnameBox.Text, (ENationality)this.PersonLabelNationalityComboBox.SelectedItem,
                    (EColor)this.PersonLabelEyesColorComboBox.SelectedItem, (EColor)this.PersonLabelHairColorComboBox.SelectedItem, (ESex)this.PersonLabelSexComboBox.SelectedItem, 
                    this.PersonLabelBirthDateLabel.Text);
                    this.imagetoaddlabel.AddLabel(createdLabel);
                    break;
            }


            if (createdLabel == null)
            {
                if (MessageBox.Show("You didn't create any new Label. Do you want to exit?", "Warning!",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
