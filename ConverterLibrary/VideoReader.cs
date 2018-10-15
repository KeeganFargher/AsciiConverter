using System.Drawing;

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
