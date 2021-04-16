using Model3D;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComputerGraphics
{
    public partial class Form1 : Form
    {
        double size = 0;

        Point3D position = new Point3D(0, 0, 0);

        double yaw = 0;
        double pitch = 0;
        double roll = 0;

        private readonly TrackBar tbSize;
        private readonly TrackBar tbRoll;
        private readonly TrackBar tbPitch;
        private readonly TrackBar tbYaw;

        private readonly Figure3D mainFigure;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            //Задаем фигуру
            mainFigure = FigureCreator.Cube;

            tbSize = new TrackBar { Parent = this, Maximum = 200, Left = 0, Value = 100 };
            tbRoll = new TrackBar { Parent = this, Maximum = 360, Left = 110, Value = 0 };
            tbPitch = new TrackBar { Parent = this, Maximum = 360, Left = 220, Value = 20 };
            tbYaw = new TrackBar { Parent = this, Maximum = 360, Left = 330, Value = 20 };

            tbYaw.Visible = true;

            tbSize.ValueChanged += tb_ValueChanged;
            tbRoll.ValueChanged += tb_ValueChanged;
            tbPitch.ValueChanged += tb_ValueChanged;
            tbYaw.ValueChanged += tb_ValueChanged;

            tb_ValueChanged(null, EventArgs.Empty);
        }

        void tb_ValueChanged(object sender, EventArgs e)
        {
            size = tbSize.Value;
            pitch = tbPitch.Value * Math.PI / 180;
            roll = tbRoll.Value * Math.PI / 180;
            yaw = tbYaw.Value * Math.PI / 180;

            CreateFigure(size, position, yaw, pitch, roll);

            Invalidate();
        }

        private void CreateFigure(double scale, Point3D position, double yaw, double pitch, double roll)
        {
            mainFigure.SetConversions(scale, position, yaw, pitch, roll);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //рисуем
            DrawCube(e.Graphics, new PointF(200, 250));
        }

        void DrawCube(Graphics gr, PointF startPoint)
        {
            //создаем путь
            var path = new GraphicsPath();

            mainFigure.DeleteLines();

            //Добавляем линии фигуры в путь
            foreach (var line in mainFigure.Edges)
            {
                path.AddLine(new PointF((float)line.StartPoint.X, -(float)line.StartPoint.Y), new PointF((float)line.EndPoint.X, -(float)line.EndPoint.Y));
                path.CloseFigure();
            }

            //Устанавливает расположение начала координат
            gr.TranslateTransform(startPoint.X, startPoint.Y);

            //рисуем
            gr.DrawPath(Pens.Black, path);
        }
    }
}
