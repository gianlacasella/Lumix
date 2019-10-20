using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega2_Equipo1
{
    public class ImageToShow
    {
        private List<SimpleLabelToShow> simplelabels;
        private List<PersonLabelToShow> personlabels;
        private List<SpecialLabelToShow> speciallabels;
        private string name;
        private string calification;
        private string resolution;
        private string aspectRatio;
        private string darkClear;
        private Dictionary<int, Dictionary<string, string>> exif;

        public ImageToShow(Image image)
        {
            this.Simplelabels = new List<SimpleLabelToShow>();
            this.Personlabels = new List<PersonLabelToShow>();
            this.Speciallabels = new List<SpecialLabelToShow>();
            // Creamos la lista de labels to show
            if (image.Labels != null)
            {
                
                foreach (Label label in image.Labels)
                {
                    switch (label.labelType)
                    {
                        case "SimpleLabel":
                            SimpleLabel slabel = (SimpleLabel)label;
                            SimpleLabelToShow sltoshow = new SimpleLabelToShow(slabel);
                            this.Simplelabels.Add(sltoshow);
                            break;

                        case "PersonLabel":
                            PersonLabel plabel = (PersonLabel)label;
                            PersonLabelToShow pstoshow = new PersonLabelToShow(plabel);
                            this.Personlabels.Add(pstoshow);
                            break;

                        case "SpecialLabel":
                            SpecialLabel splabel = (SpecialLabel)label;
                            SpecialLabelToShow sptoshow = new SpecialLabelToShow(splabel);
                            this.Speciallabels.Add(sptoshow);
                            break;
                    }
                }
            }

            // Asignamos el resto de propiedades
            this.Name = image.Name;
            this.Calification = image.Calification == -1 ? "" : Convert.ToString(image.Calification);
            this.Resolution = Convert.ToString(image.Resolution[0]) + "x" + Convert.ToString(image.Resolution[1]);
            this.AspectRatio = Convert.ToString(image.AspectRatio[0]) + ":" + Convert.ToString(image.AspectRatio[1]);
            this.DarkClear = image.DarkClear == false ? "Dark" : "Clear";
            this.Exif = image.Exif;
        }

        
        public string Name { get => this.name; set => this.name = value; }
        public string Calification { get => this.calification; set => this.calification = value; }
        public string Resolution { get => this.resolution; set => this.resolution = value; }
        public string AspectRatio { get => this.aspectRatio; set => this.aspectRatio = value; }
        public string DarkClear { get => this.darkClear; set => this.darkClear = value; }
        public Dictionary<int, Dictionary<string, string>> Exif { get => this.exif; set => this.exif = value; }
        public List<SimpleLabelToShow> Simplelabels { get => this.simplelabels; set => this.simplelabels = value; }
        public List<PersonLabelToShow> Personlabels { get => this.personlabels; set => this.personlabels = value; }
        public List<SpecialLabelToShow> Speciallabels { get => this.speciallabels; set => this.speciallabels = value; }
    }
}
