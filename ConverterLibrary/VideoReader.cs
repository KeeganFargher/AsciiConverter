using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConverterLibrary
{
    public class VideoReader
    {

        private Image _image;

        public void OpenReader(string fileName)
        {
            _image = Image.FromFile(fileName);
        }

        public Frame ConvertToAscii()
        {
            var frame = GetFrame();
            
            return frame;
        }

        private Frame GetFrame()
        {
            Frame frame = new Frame();
            frame.Location = new string[_image.Width, _image.Height];
            frame.Colors = new Color[_image.Width, _image.Height];

            Bitmap bitmap = new Bitmap(_image);
            for (int x = 0; x < _image.Width; x++)
            {
                for (int y = 0; y < _image.Height; y++)
                {
                    frame.Colors[x, y] = bitmap.GetPixel(x, y);

                    var color = bitmap.GetPixel(x, y);
                    int sum = (color.R + color.G + color.B);

                    char c = (char) MapValue(0, 756, 48, 122, sum);
                    frame.Location[x, y] = c.ToString();
                }
            }
            bitmap.Dispose();

            return frame;
        }

        private double MapValue(
            double fromSource, double toSource, double fromTarget, double toTarget, double value)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}
