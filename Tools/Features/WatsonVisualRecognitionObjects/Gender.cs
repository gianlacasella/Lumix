using System;

namespace Entrega2_Equipo1
{
    [Serializable   ]
    public class Gender
    {
        string genderType;
        string genderLabel;
        double genderScore;
        public Gender(string gender, string genderLabel, double genderScore)
        {
            this.genderType = gender;
            this.genderLabel = genderLabel;
            this.genderScore = genderScore;
        }
        public string GenderLabel { get => genderLabel; set => genderLabel = value; }
    }
}
