using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MediaToolkit;
using MediaToolkit.Model;

namespace AsciiConverter
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

            for (int width = 0; width < _image.Width; width+=2)
            {
                for (int height = 0; height < _image.Height; height+=2)
                {
                    frame.X.Add(width);
                    frame.Y.Add(height);

                    //Bitmap bitmap = new Bitmap(_image);
                    //frame.Color.Add(bitmap.GetPixel(width, height));
                    //bitmap.Dispose();
                }
            }
            return frame;
        }
    }
}
