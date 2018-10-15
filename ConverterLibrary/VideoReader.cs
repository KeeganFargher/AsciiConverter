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

            for (int width = 1; width < _image.Width; width+=100)
            {
                for (int height = 1; height < _image.Height; height+=100)
                {
                    frame.X.Add(width / 100);
                    frame.Y.Add(height / 100);

                    //Bitmap bitmap = new Bitmap(_image);
                    //frame.Color.Add(bitmap.GetPixel(width, height));
                    //bitmap.Dispose();
                }
            }
            return frame;
        }
    }
}
