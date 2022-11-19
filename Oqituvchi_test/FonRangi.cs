using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oqituvchi_test
{
    public static class FonRangi
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }

        public static List<string> ColorList = new List<string>()
        { "#C0C0C0","#FF0000","#00FF00","#0000FF","#FFFF00","#00FFFF","#FF00FF","#800080","#FFD700","#2F4F4F","#8A2BE2","#B0C4DE","#B0C4DE" };

        public static Color ChangeColorBrightness(Color color, double correcrionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correcrionFactor < 0)
            {
                correcrionFactor = 1 + correcrionFactor;
                red *= correcrionFactor;
                green *= correcrionFactor;
                blue *= correcrionFactor;
            }
            else
            {
                red = (255 - red) * correcrionFactor + red;
                green = (255 - green) * correcrionFactor + green;
                blue = (255 - blue) * correcrionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }

       //#3F51B5","#009688", "#FF5722", "#5978BB", "#126881", "#FF9800", "#EA676C", "#EA4833", "#F37521", "#0094BC",
       
}
