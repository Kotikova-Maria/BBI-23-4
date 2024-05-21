using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_t1_var2.cs
{
    internal class Program
    {
        struct Point
        {
            private int _x, _y;
            public Point(int[] kord)
            {
                _x = kord[0];
                _y = kord[1];
            }
            public int GetX { get { return _x; } }
            public int GetY { get { return _y; } }
        }
        private static void Get_Kord_Distance(Point p1, Point p2)
        {
            int distance_x = Math.Abs(p1.GetX) - Math.Abs(p2.GetX);
            int distance_y = Math.Abs(p1.GetY) - Math.Abs(p2.GetY);
            double TotalDistance = Math.Sqrt(Math.Pow(distance_x, 2) + Math.Pow(distance_y, 2));
            Console.WriteLine("Первая точка:\nКоордината по x:{0, 10}" +
                " координата по y{1, 10} Расстояние {2, 10}", p1.GetX, p1.GetY, TotalDistance);
            Console.WriteLine("Вторая точка:\nКоордината по x:{0, 10}" +
                " координата по y{1, 10} Расстояние {2, 10}", p2.GetX, p2.GetY, TotalDistance);
        }
        static void Main(string[] args)
        {
            Point[] points = new Point[3];
            int[] p0_k = { 1, 2 };
            int[] p1_k = { 3, 4 };
            int[] p2_k = { 5, -6 };
            points[0] = new Point(p0_k);
            points[1] = new Point(p1_k);
            points[2] = new Point(p2_k);

            Console.WriteLine("Вторая и третья точки:\n");
            Get_Kord_Distance(points[1], points[2]);
            Console.WriteLine("\nПервая и вторая точки:\n");
            Get_Kord_Distance(points[0], points[1]);
            Console.WriteLine("\nПервая и третья точки:\n");
            Get_Kord_Distance(points[0], points[2]);


        }
    }
}
