using System;

namespace Entrega2_Equipo1
{
    [Serializable]
    public class SpecialLabel : Label
    {
        // (latitude, longitude)
        private double[] geographicLocation;
        private const double[] DEFAULT_GEOGRAPHIC_LOCATION = null;
        private string address;
        private const string DEFAULT_ADDRESS = null;
        private string photographer;
        private const string DEFAULT_PHOTOGRAPHER = null;
        private string photoMotive;
        private const string DEFAULT_PHOTOMOTIVE = null;
        private bool selfie;
        private const bool DEFAULT_SELFIE = false;

        public SpecialLabel(double[] geographicLocation, string address) : this(geographicLocation, address, DEFAULT_PHOTOGRAPHER) { }

        public SpecialLabel(double[] geographicLocation, string address, string photographer) : this(geographicLocation, address, photographer, DEFAULT_PHOTOMOTIVE) { }

        public SpecialLabel(double[] geographicLocation, string address, string photographer, string photomotive) : this(geographicLocation, address, photographer, photomotive, DEFAULT_SELFIE) { }

        public SpecialLabel(double[] geographicLocation, string address, string photographer, string photomotive, bool selfie) : this(geographicLocation, address, photographer, photomotive, selfie, DEFAULT_SERIAL_NUMBER) { }

        public SpecialLabel(double[] geographicLocation, string address, string photographer, string photomotive, bool selfie, int serialNumber) : base(serialNumber)
        {
            this.geographicLocation = geographicLocation;
            Address = address;
            Photographer = photographer;
            PhotoMotive = photomotive;
            Selfie = selfie;
            this.labelType = "SpecialLabel";
        }


        // [latitude, longitude]
        public double[] GeographicLocation
        {
            get => geographicLocation;
            set
            {
                if ((value[0] > -90 && value[0] < 90) && (value[1] > -180 && value[1] < 180))
                {
                    geographicLocation = value;
                }
                else
                {
                    throw new Exception("Invalid Geographic Location");
                }
            }
        }

        public string Address { get => address; set => address = value; }

        public string Photographer { get => photographer; set => photographer = value; }

        public string PhotoMotive { get => photoMotive; set => photoMotive = value; }

        public bool Selfie { get => selfie; set => selfie = value; }
        
    }
}
