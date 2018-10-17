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

        }
        private void ConverterForm_Shown(object sender, EventArgs e)
        {
            AsciiConverter reader = new AsciiConverter();
            _frame = reader.ConvertToAscii("apple.jpg");

            int xLength = _frame.Location.GetLength(0);
            int yLength = _frame.Location.GetLength(1);
            const int spacing = 10;

            for (int y = 0; y < yLength; y += spacing * 2)
            {
                for (int x = 0; x < xLength; x += spacing)
                {
                    textBox1.Text += _frame.Location[x, y];
                }

                textBox1.Text += Environment.NewLine;
            }
        }

        private void ConverterForm_Paint(object sender, PaintEventArgs e)
        {
            //int xLength = _frame.Location.GetLength(0);
            //int yLength = _frame.Location.GetLength(1);

            //for (int y = 20; y < yLength; y += 20)
            //{
            //    for (int x = 10; x < xLength; x += 10)
            //    {
            //        Brush brushColor = new SolidBrush(_frame.Colors[x, y]);
            //        Pen pen = new Pen(brushColor, 1);

            //        e.Graphics.DrawEllipse(pen, x/10, y/20, 2, 2);
            //    }

            //}
        }


    }
}
