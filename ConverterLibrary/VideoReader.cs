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

            for (int width = 0; width < _image.Width; width+=10)
            {
                for (int height = 0; height < _image.Height; height+=10)
                {
                    frame.Y.Add(height / 10);
                    frame.ascii.Add("N");
                }
                frame.X.Add(width / 10);
            }
            return frame;
        }
    }
}
