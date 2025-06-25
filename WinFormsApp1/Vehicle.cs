using System;
using System.Drawing;

namespace VehicleSimulation
{
    public abstract class Vehicle
    {
        public PointF Position;
        public PointF Target;
        public float Speed;
        public Brush Color;

        public Vehicle(PointF start, PointF target, float speed, Brush color)
        {
            Position = start;
            Target = target;
            Speed = speed;
            Color = color;
        }

        public void Move()
        {
            float dx = Target.X - Position.X;
            float dy = Target.Y - Position.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance < Speed || distance == 0)
                return;

            Position = new PointF(Position.X + dx / distance * Speed, Position.Y + dy / distance * Speed);
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Color, Position.X, Position.Y, 10, 10);
        }

        public bool ReachedTarget()
        {
            return Math.Abs(Position.X - Target.X) < 1 && Math.Abs(Position.Y - Target.Y) < 1;
        }
    }

    public class Truck : Vehicle
    {
        public Truck(PointF start, PointF target)
            : base(start, target, 2.0f, Brushes.Red) { }
    }

    public class Car : Vehicle
    {
        public Car(PointF start, PointF target)
            : base(start, target, 3.0f, Brushes.Blue) { }
    }
}
