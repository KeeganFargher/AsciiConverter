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
            reader.OpenReader("photo.jpeg");
            _frame = reader.ConvertToAscii();

            int length = (_frame.X.Count * _frame.Y.Count);
            for (int i = 0; i < length; i++)
            {
                textBox1.Text += _frame.ascii[i];
            }
        }

        private void ConverterForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
