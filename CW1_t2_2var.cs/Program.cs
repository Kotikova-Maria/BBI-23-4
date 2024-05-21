using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_t2_2var.cs
{
    public abstract class Fourangle
    {
        private Point[] _points = new Point[4];

        public Fourangle(Point[] points)
        {
            Random random = new Random();
            for (int i = 0; i < points.Length; i++)
            {
                points[i].GetX = random.Next(-10, 10);
            }
        }
        public Point[] GetPoint { get { return _points; } }
        public struct Point
        {
            private int _x, _y;
            public Point(int[] kord)
            {
                _x = kord[0];
                _y = kord[1];
            }
            public int GetX { get { return _x; } set { _x = value; } }
            public int GetY { get { return _y; } set { _y = value; } }
        }
        public virtual void Perim() { }
        public virtual void Square_() { }

    }
    class Square : Fourangle
    {
        public Square(Point[] points) : base(points) { }
        public override void Perim()
        {

        }
        public override void Square_()
        {

        }
    }
    class Rectangle : Fourangle
    {
        public Rectangle(Point[] points) : base(points) { }
        public override void Perim()
        {
            for (int i = 0; i < )
                int a = Math.Abs() - Math.Abs();
        }
        public override void Square_()
        {

        }
    }
    class Trapezium : Fourangle
    {
        public Trapezium(Point[] points) : base(points) { }
        public override void Perim()
        {

        }
        public override void Square_()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Square[] squares = new Square[3];
            Rectangle[] rectangles = new Rectangle[3];
            Trapezium[] trapeziums = new Trapezium[3];
        }
    }
}
