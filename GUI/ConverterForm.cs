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
            AllowDrop = true;
            DragEnter += ConverterForm_DragEnter;
            DragDrop += ConverterForm_DragDrop;
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {

        }
        private void ConverterForm_Shown(object sender, EventArgs e)
        {

        }

        void ConverterForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void ConverterForm_DragDrop(object sender, DragEventArgs e)
        {
            textBox1.Clear();
            string[] file = (string[]) e.Data.GetData(DataFormats.FileDrop);

            AsciiConverter reader = new AsciiConverter();
            _frame = reader.ConvertToAscii(file[0]);

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

    }
}
