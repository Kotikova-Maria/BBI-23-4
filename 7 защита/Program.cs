using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_защита
{

    internal class Program
    {
        abstract class Character
        {
            protected string _surname, _group, _trainer;
            protected int _Distance;
            protected double _rez;
            public Character(string surname, string group, string trainer, int distance, double rez)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _Distance = distance;
                _rez = rez;
            }
            public double rez { get { return _rez; } }
            public abstract void Print();

            public int FindPivot(Character[] runner, int minIndex, int maxIndex)//для того чтобы разбить на подмассивы
            {
                int pivot = -1;
                Character temp;
                for (int i = minIndex; i < maxIndex; i++)
                {
                    if (runner[i].rez < runner[maxIndex].rez)
                    {
                        pivot++;
                        temp = runner[pivot];
                        runner[pivot] = runner[i];
                        runner[i] = temp;
                    }
                }
                pivot++;
                temp = runner[pivot];
                runner[pivot] = runner[maxIndex];
                runner[maxIndex] = temp;

                return pivot;
            }

            public Character[] QuickSort(Character[] runner, int minIndex, int maxIndex)
            {
                if (minIndex >= maxIndex) { return runner; }

                int pivot = FindPivot(runner, minIndex, maxIndex);
                QuickSort(runner, minIndex, pivot - 1);
                QuickSort(runner, pivot + 1, maxIndex);

                return runner;
            }

        }
        class Run100 : Character
        {
            public Run100(string surname, string group, string trainer, int distance, double rez) : base(surname, group, trainer, distance, rez) { }
            public override void Print()
            {
                Console.WriteLine("Забег на 100 метров:");
                Console.WriteLine("Фамилия:{0, 10} Группа:{1, 10}" +
                    " Тренер:{2, 10} Результат:{3, 10}", _surname, _group, _trainer, _rez);
                if (_rez <= 2.5)
                {
                    Console.Write(" - норматив сдан");
                }
                else { Console.WriteLine(" - норматив не сдан"); }
                Console.WriteLine();
            }
        }
        class Run500 : Character
        {
            public Run500(string surname, string group, string trainer, int distance, double rez) : base(surname, group, trainer, distance, rez) { }
            public override void Print()
            {
                Console.WriteLine("Забег на 500 метров:");
                Console.WriteLine("Фамилия:{0, 10} Группа:{1, 10}" +
                    " Тренер:{2, 10} Результат:{3, 10}", _surname, _group, _trainer, _rez);
                if (_rez <= 5.0)
                {
                    Console.Write(" - норматив сдан");
                }
                else { Console.WriteLine(" - норматив не сдан"); }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {


            Character[] runner2 = new Character[2];
            runner2[0] = new Run100("Иванова", "1", "Полякова", 100, 3);
            runner2[1] = new Run100("Смирнова", "7", "Аванесова", 100, 7);
            Character[] runner3 = new Character[3];
            runner3[0] = new Run500("Сидорова", "3", "Березка", 500, 5.0);
            runner3[1] = new Run500("Петрова", "2", "Шварц", 500, 4.5);
            runner3[2] = new Run500("Попова", "7", "Кузнецов", 500, 6.8);


            runner2[0].QuickSort(runner2, 0, runner2.Length - 1);
            runner3[0].QuickSort(runner3, 0, runner3.Length - 1);
            //вывод отсортированных данных

            for (int i = 0; i < runner2.Length; i++)
            {
                runner2[i].Print();
            }
            for (int i = 0; i < runner3.Length; i++)
            {
                runner3[i].Print();
            }
        }

    }
}
