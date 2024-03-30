using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_lvl_new
{

    abstract class Human
    {
        private string _surn;
        private double _rez;
        public Human(string surn, double rez)
        {
            _surn = surn;
            _rez = rez;
        }
        public string name
        {
            get => _surn;
        }
        public double rez
        {
            get => _rez;
        }
        public virtual void Print() => Console.WriteLine("Фамилия:{0, 10} Результат:{1,10}", name, rez);

    }
    class Sportsmen : Human
    {
        private static int _id;
        public readonly int id;
        public Sportsmen(string surn, double rez) : base(surn, rez)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            _id = random.Next(45364, 232562);
            id = _id;
        }
        public override void Print() => Console.WriteLine("Фамилия:{0, 10} Результат:{1,10} id:{2, 10}", name, rez, id);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество участников:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество сыгранных партий:");
            int ngames = int.Parse(Console.ReadLine());
            Human[] partis = new Human[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите фамилию {i + 1} участника:");
                string name = Console.ReadLine();
                double z = 0;//суммарный результат
                for (int j = 0; j < ngames; j++)//цикл для вноса результатов данного участника
                {
                    Console.WriteLine($"Введите результат {j + 1} игры {i + 1} участника:");
                    double a = double.Parse(Console.ReadLine());
                    z += a;
                }
                partis[i] = new Sportsmen(name, z);
            }
            Sort(partis);
            for (int i = 0; i < n; i++)
            {
                partis[i].Print();
            }
        }
        static void Sort(Human[] partis)
        {
            for (int i = 0; i < partis.Length; i++)
            {
                for (int j = 0; j < partis.Length - 1 - i; j++)
                {
                    if (partis[j].rez < partis[j + 1].rez)
                    {
                        Human temp = partis[j];
                        partis[j] = partis[j + 1];
                        partis[j + 1] = temp;
                    }
                }
            }
        }
    }
}
