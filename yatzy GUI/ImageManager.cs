using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace yatzy_GUI
{
    class ImageManager
    {

        private static List<Image> images = new List<Image>();


        public static void setImage(int v, Image image)
        {
            BitmapImage bi = new BitmapImage();

            bi.BeginInit();
            bi.UriSource = new Uri("/img/" + v + ".png", UriKind.Relative);
            bi.EndInit();
            image.Source = bi;
        }

        public static List<Image> Images
        {
            get => images;
            set => images = value;
        }
    }
}
