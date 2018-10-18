using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConverterLibrary
{
    public class AsciiConverter
    {
        private readonly string[] _asciiChars = { "#", "&", "@", "%", "=", "+", "*", ":", "-", ".", " " };
        private Image _image;

        public Frame ConvertToAscii(string fileName)
        {
            _image = Image.FromFile(fileName);
            var frame = GetFrame();
            
            return frame;
        }

        private Frame GetFrame()
        {
            Frame frame = new Frame
            {
                Location = new string[_image.Width, _image.Height],
                Colors = new Color[_image.Width, _image.Height]
            };

            Bitmap bitmap = new Bitmap(_image);
            for (int x = 0; x < _image.Width; x++)
            {
                for (int y = 0; y < _image.Height; y++)
                {
                    frame.Colors[x, y] = bitmap.GetPixel(x, y);

                    //  Getting the gray-scale version of our image
                    var color = bitmap.GetPixel(x, y);
                    int sum = (color.R + color.G + color.B) / 3;
                    Color grayScale = Color.FromArgb(sum, sum, sum);

                    //  Using a pre-determined array to use as a character based on gray-scale
                    int index = (grayScale.R * 10)/255;
                    frame.Location[x, y] = _asciiChars[index];
                }
            }
            bitmap.Dispose();

            return frame;
        }
    }
}
