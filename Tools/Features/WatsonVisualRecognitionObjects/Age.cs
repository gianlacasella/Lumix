using System;

namespace Entrega2_Equipo1
{
    [Serializable]
    public class Age
    {
        int minAge;
        int maxAge;
        double ageScore;
        public Age(int minAge, int maxAge, double ageScore)
        {
            this.minAge = minAge;
            this.maxAge = maxAge;
            this.ageScore = ageScore;
        }
        public int MinAge { get => minAge; set => minAge = value; }
        public int MaxAge { get => maxAge; set => maxAge = value; }
    }
}
