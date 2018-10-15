using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConverterLibrary;

namespace GUI
{
    public partial class ConverterForm : Form
    {
        private Frame _frame = new Frame();

        public ConverterForm()
        {
            InitializeComponent();
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {
            VideoReader reader = new VideoReader();
            reader.OpenReader("StudentPhoto.png");
            _frame = reader.ConvertToAscii();
        }

        private void ConverterForm_Paint(object sender, PaintEventArgs e)
        {
            Brush brushColor = new SolidBrush(Color.BlueViolet);
            Pen pen = new Pen(brushColor, 1);

            for (int width = 0; width < _frame.X.Count; width++)
            {
                for (int height = 0; height < _frame.Y.Count; height++)
                {
                    Point p = new Point(_frame.X[width], _frame.Y[height]);

                    e.Graphics.DrawEllipse(pen, p.X, p.Y, 2, 2);
                }
            }
        }
    }
}
