using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2_Equipo1
{
    public class SpecialLabelToShow
    {
        private double[] geographicLocation;
        private string address;
        private string photographer;
        private string photoMotive;
        private bool selfie;
        private string labeltype;

        public SpecialLabelToShow(SpecialLabel label)
        {
            this.GeographicLocation = label.GeographicLocation;
            this.Address = label.Address;
            this.Photographer = label.Photographer;
            this.PhotoMotive = label.PhotoMotive;
            this.Selfie = label.Selfie;
            this.Labeltype = "SpecialLabel";
        }

        public double[] GeographicLocation { get => this.geographicLocation; set => this.geographicLocation = value; }
        public string Address { get => this.address; set => this.address = value; }
        public string Photographer { get => this.photographer; set => this.photographer = value; }
        public string PhotoMotive { get => this.photoMotive; set => this.photoMotive = value; }
        public bool Selfie { get => this.selfie; set => this.selfie = value; }
        public string Labeltype { get => this.labeltype; set => this.labeltype = value; }
    }
}
