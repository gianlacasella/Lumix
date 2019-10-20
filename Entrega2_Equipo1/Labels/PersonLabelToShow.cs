using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2_Equipo1
{
    public class PersonLabelToShow
    {
        private string Name;
        private string Surname;
        private ENationality Nationality;
        private EColor EyesColor;
        private EColor HairColor;
        private ESex Sex;
        private string BirthDate;
        private double[] FaceLocation;
        private string labeltype;

        public PersonLabelToShow(PersonLabel label)
        {
            this.Name1 = label.Name;
            this.Surname1 = label.Surname;
            this.Nationality1 = label.Nationality;
            this.EyesColor1 = label.EyesColor;
            this.HairColor1 = label.HairColor;
            this.Sex1 = label.Sex;
            this.BirthDate1 = label.BirthDate;
            this.FaceLocation1 = label.FaceLocation;
            this.Labeltype = "PersonLabel";
        }

        public string Name1 { get => this.Name; set => this.Name = value; }
        public string Surname1 { get => this.Surname; set => this.Surname = value; }
        public ENationality Nationality1 { get => this.Nationality; set => this.Nationality = value; }
        public EColor EyesColor1 { get => this.EyesColor; set => this.EyesColor = value; }
        public EColor HairColor1 { get => this.HairColor; set => this.HairColor = value; }
        public ESex Sex1 { get => this.Sex; set => this.Sex = value; }
        public string BirthDate1 { get => this.BirthDate; set => this.BirthDate = value; }
        public double[] FaceLocation1 { get => this.FaceLocation; set => this.FaceLocation = value; }
        public string Labeltype { get => this.labeltype; set => this.labeltype = value; }
    }
}
