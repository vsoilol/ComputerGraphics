using Algorithm;
using Operations;
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
        Bitmap mainBitmap;

        List<Edge> mainFigure;

        public Form1()
        {
            InitializeComponent();

            mainFigure = Shapes.ThreeArrows.Figure.ToList();

            mainBitmap = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);

            Fill.FillSAR(mainFigure, mainBitmap, Color.Black);

            mainPictureBox.Image = mainBitmap;
        }

        private void buttonMoveImage_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(mainBitmap.Width, mainBitmap.Height);

            mainFigure = Figure.MoveImage(new Point((int)numericUpDownX.Value, (int)numericUpDownY.Value), mainFigure).ToList();
            Fill.FillSAR(mainFigure, bitmap, Color.Black);

            mainPictureBox.Image = bitmap;
        }

        private void buttonStretching_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(mainBitmap.Width, mainBitmap.Height);

            mainFigure = Figure.StretchingImage(new double[] { (double)numericUpDownStretchingX.Value,
                (double)numericUpDownStretchingY.Value}, mainFigure).ToList();
            Fill.FillSAR(mainFigure, bitmap, Color.Black);

            mainPictureBox.Image = bitmap;
        }

        private void buttonnCompression_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(mainBitmap.Width, mainBitmap.Height);

            mainFigure = Figure.CompressionImage(new double[] { (double)numericUpDownCompressionX.Value,
                (double)numericUpDownCompressionY.Value}, mainFigure).ToList();
            Fill.FillSAR(mainFigure, bitmap, Color.Black);

            mainPictureBox.Image = bitmap;
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(mainBitmap.Width, mainBitmap.Height);

            mainFigure = Figure.RotateFigure((int)numericUpDownAngel.Value, mainFigure).ToList();
            Fill.FillSAR(mainFigure, bitmap, Color.Black);

            mainPictureBox.Image = bitmap;
        }
    }
}
