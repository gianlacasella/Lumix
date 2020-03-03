using System;

namespace Entrega2_Equipo1
{
    [Serializable]
    public abstract class Label
    {
        public string labelType { get; set; }

        protected const int DEFAULT_SERIAL_NUMBER = 0;
        protected int serialNumber;

        public Label(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public int SerialNumber { get => serialNumber; set => this.serialNumber = value; }
    }
}
