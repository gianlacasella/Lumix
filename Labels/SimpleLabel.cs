using System;

namespace Entrega2_Equipo1
{
    [Serializable]
    public class SimpleLabel : Label
    {
        private string sentence;
        private const string DEFAULT_SENTENCE = null;
        

        public SimpleLabel(string sentence) : this(sentence, DEFAULT_SERIAL_NUMBER) {}

        public SimpleLabel(string sentence, int serialNumber) : base(serialNumber)
        {
            this.sentence = sentence;
            this.labelType = "SimpleLabel";
        }

        public string Sentence
        {
            get => this.sentence;
            set => this.sentence = value;
        }
        
    }
}
