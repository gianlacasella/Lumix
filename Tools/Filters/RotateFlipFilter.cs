using System;
using System.Drawing;

namespace Entrega2_Equipo1
{
    [Serializable]
    public class RotateFlipFilter : Tool
    {
        public Bitmap RotateFlip(Bitmap image, RotateFlipType type)
        {
            Bitmap copy = (Bitmap)image.Clone();
            copy.RotateFlip(type);
            return copy;
        }
    }
}
