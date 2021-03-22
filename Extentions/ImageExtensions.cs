using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Dungeon.Extentions
{
    internal static class ImageExtensions
    {
        public static ImageSource ConvertImageToSource(this Image image)
        {
            try
            {
                if (image != null)
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    var memoryStream = new MemoryStream();
                    image.Save(memoryStream, ImageFormat.Png);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    bitmap.StreamSource = memoryStream;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
            catch { }
            return null;
        }
    }
}
