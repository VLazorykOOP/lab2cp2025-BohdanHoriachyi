using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleSimulation
{
    public partial class SimulationForm : Form
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();  // <-- Явне вказання

        private int mode;
        private Random rand = new Random();
        private const int w = 800, h = 600;

        public SimulationForm(int mode)
        {
            this.mode = mode;
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Width = w;
            this.Height = h;
            this.Text = "Симуляція руху";

            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();

            GenerateVehicles();
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateVehicles()
        {
            for (int i = 0; i < 10; i++)
            {
                if (mode == 1 || mode == 3)
                {
                    var start = RandomPoint();
                    var target = new PointF(rand.Next(w / 2), rand.Next(h / 2));
                    if (!InTopLeft(start))
                        vehicles.Add(new Truck(start, target));
                }

                if (mode == 2 || mode == 3)
                {
                    var start = RandomPoint();
                    var target = new PointF(rand.Next(w / 2, w), rand.Next(h / 2, h));
                    if (!InBottomRight(start))
                        vehicles.Add(new Car(start, target));
                }
            }
        }

        private PointF RandomPoint() =>
            new PointF(rand.Next(w), rand.Next(h));

        private bool InTopLeft(PointF p) =>
            p.X < w / 2 && p.Y < h / 2;

        private bool InBottomRight(PointF p) =>
            p.X >= w / 2 && p.Y >= h / 2;

        private void Timer_Tick(object? sender, EventArgs e)
        {
            foreach (var v in vehicles)
                if (!v.ReachedTarget())
                    v.Move();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (var v in vehicles)
                v.Draw(e.Graphics);
        }
    }
}
