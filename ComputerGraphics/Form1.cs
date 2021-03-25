using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        private Point MouseDownLocation;
        private bool brightTriangle = false;
        public Form1()
        {
            InitializeComponent();
            PlaceCenter();
            SetStyle(ControlStyles.ResizeRedraw, true);
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);

        }

        private void IncreaseButton_Click(object sender, EventArgs e)
        {
            uxPictureBox.Width += (int)valueNumericUpDown.Value;
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);
            PlaceCenter();
        }

        private void ReduceButton_Click(object sender, EventArgs e)
        {
            if (uxPictureBox.Width - (int)valueNumericUpDown.Value > 1)
            {
                uxPictureBox.Width -= (int)valueNumericUpDown.Value;
                TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);
                PlaceCenter();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            PlaceCenter();
        }

        private void PlaceCenter()
        {
            int X = (int)Math.Round((Width / 2d) - (uxPictureBox.Width / 2d));
            int Y = (int)Math.Round((Height / 2d) - (uxPictureBox.Height / 2d));

            uxPictureBox.Location = new Point(X, Y);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedItem)
            {
                case "Яркий":
                    brightTriangle = true;
                    break;
                case "Нормальный":
                    brightTriangle = false;
                    break;
            }
            TriangleColor.DrawColorTriangle(uxPictureBox, brightTriangle);
        }

        private void uxPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void uxPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                uxPictureBox.Left = e.X + uxPictureBox.Left - MouseDownLocation.X;
                uxPictureBox.Top = e.Y + uxPictureBox.Top - MouseDownLocation.Y;
            }
        }
    }
}
