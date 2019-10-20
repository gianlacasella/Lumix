using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2_Equipo1
{
    public class SimpleLabelToShow
    {
        private string tag;
        private string labeltype;

        public SimpleLabelToShow(SimpleLabel label)
        {
            this.tag = label.Sentence;
            this.labeltype = "SimpleLabel";
        }

        public SimpleLabelToShow()
        {

        }


        [Category("SimpleLabelToShow")]
        [DisplayName("Tag")]
        [Description("El tag elegido por el usuario")]
        public string Tag { get => this.tag; set => this.tag = value; }

        [Category("SimpleLabelToShow")]
        [DisplayName("LabelType")]
        [Description("El tipo del label")]
        public string Labeltype { get => this.labeltype; set => this.labeltype = value; }
    }
}
