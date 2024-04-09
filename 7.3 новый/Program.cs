using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._3_новый
{
    abstract class Group
    {
        protected string _group, _potok, _surname;
        protected int _matem, _prog, _system;
        public Group(string group, string potok, string surname, int matem, int prog, int system)
        {
            _group = group;
            _potok = potok;
            _surname = surname;
            _matem = matem;
            _prog = prog;
            _system = system;
        }
        public string surname { get => _surname; }
        public string group { get => _group; }
        public string potok { get => _potok; }
        public int matem { get => _matem; }
        public int prog { get => _prog; }
        public int system { get => _system; }
        public virtual void sred_rez(Group grops, ref double sr) { }
        public void Print(Group grops, double sred)
        {
            Console.WriteLine("Surname:{0,10} Potok:{1, 10} Group:{2, 10} sredni_rez:{3, 10}", surname, potok, group, sred);
        }
        public void itog_sred(double[][] a, ref double[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                double sum = 0, n = 5;
                for (int j = 0; j < 5; j++)
                {
                    sum += a[i][j];
                }
                b[i] = sum / n;
            }
        }

    }
    class Group1 : Group
    {
        private int _analis;
        private int _IP;
        public Group1(string group, string potok, string surname, int matem, int prog, int system, int analys, int IP)
         : base(group, potok, surname, matem, prog, system)
        {
            _analis = analys;
            _IP = IP;
        }
        public override void sred_rez(Group grops1, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops1.prog + grops1.matem + grops1.system + _analis + _IP;
            sr = sum / n;

        }
    }
    class Group2 : Group
    {
        private int _physics, _vichmash;
        public Group2(string group, string potok, string surname, int matem, int prog, int system, int physics, int vichmash) :
        base(group, potok, surname, matem, prog, system)
        {
            _physics = physics;
            _vichmash = vichmash;
        }
        public override void sred_rez(Group grops1, ref double sr)
        {

            double sum = 0, n = 5;
            sum = grops1.prog + grops1.matem + grops1.system + _physics + _vichmash;
            sr = sum / n;

        }
    }
    class Group3 : Group
    {
        private int _perseff, _angl;
        public Group3(string group, string potok, string surname, int matem, int prog, int system, int perseff, int angl) :
        base(group, potok, surname, matem, prog, system)
        { _perseff = perseff; _angl = angl; }

        public override void sred_rez(Group grops, ref double sr)
        {

            double sum = 0, n = 5;
            sum = grops.prog + grops.matem + grops.system + _perseff + _angl;
            sr = sum / n;
        }
    }
    class Group4 : Group
    {
        private int _history, _chinese;
        public Group4(string group, string potok, string surname, int matem, int prog, int system, int history, int chinese) :
            base(group, potok, surname, matem, prog, system)
        {
            _history = history;
            _chinese = chinese;
        }
        public override void sred_rez(Group grops, ref double sr)
        {

            double sum = 0, n = 5;
            sum = grops.prog + grops.matem + grops.system + _history + _chinese;
            sr = sum / n;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Group[] grops1 = new Group1[5];
            grops1[0] = new Group1("1", "BBI", "Kirsanov", 5, 3, 3, 1, 5);
            grops1[1] = new Group1("1", "BBI", "Bazarov", 5, 5, 3, 4, 2);
            grops1[2] = new Group1("1", "BBI", "Arataki", 5, 5, 4, 5, 5);
            grops1[3] = new Group1("1", "BBI", "Smirnov", 2, 4, 3, 4, 5);
            grops1[4] = new Group1("1", "BBI", "Miller", 2, 2, 2, 5, 3);

            Group[] grops2 = new Group2[5];
            grops2[0] = new Group2("2", "BBI", "Even", 1, 1, 2, 3, 1);
            grops2[1] = new Group2("2", "BBI", "Shwartz", 5, 2, 3, 4, 2);
            grops2[2] = new Group2("2", "BBI", "Molochni", 2, 5, 4, 4, 5);
            grops2[3] = new Group2("2", "BBI", "Ivanov", 2, 5, 5, 4, 5);
            grops2[4] = new Group2("2", "BBI", "Shlyakov", 2, 1, 1, 5, 3);

            Group[] grops3 = new Group3[5];
            grops3[0] = new Group3("3", "IVT", "Rico", 1, 1, 2, 3, 1);
            grops3[1] = new Group3("3", "IVT", "Miko", 5, 2, 3, 4, 2);
            grops3[2] = new Group3("3", "IVT", "Soko", 2, 5, 4, 4, 5);
            grops3[3] = new Group3("3", "IVT", "Shoko", 2, 5, 5, 4, 5);
            grops3[4] = new Group3("3", "IVT", "Loko", 2, 1, 1, 5, 3);

            Group[] grops4 = new Group4[5];
            grops4[0] = new Group4("4", "BBI", "Krico", 5, 1, 2, 3, 1);
            grops4[1] = new Group4("4", "BBI", "Estriper", 5, 2, 5, 4, 2);
            grops4[2] = new Group4("4", "BBI", "Mayakov", 2, 5, 4, 4, 5);
            grops4[3] = new Group4("4", "BBI", "Mirova", 2, 5, 5, 4, 5);
            grops4[4] = new Group4("4", "BBI", "Hilova", 2, 1, 5, 4, 3);

            Group[][] grops = new Group[][] { grops1, grops2, grops3, grops4 };

            Group[][] gropsBBI = new Group[3][];

            double[] sred_student1 = new double[5];
            double[] sred_student2 = new double[5];
            double[] sred_student3 = new double[5];

            double[][] sred = new double[][] { sred_student1, sred_student2, sred_student3 };

            double sr = 0;
            int k = 0;//number of element in BBI

            //поиск групп ББИ
            for (int i = 0; i < grops.Length; i++)
            {
                string BBI = "BBI";
                if (grops[i][i].potok.Equals(BBI))
                {
                    gropsBBI[k] = grops[i];
                    for (int j = 0; j < 5; j++)
                    {
                        gropsBBI[k][j].sred_rez(gropsBBI[k][j], ref sr);
                        sred[k][j] = sr;
                    }
                    k++;
                }
            }

            double[] sredni = new double[3];

            gropsBBI[0][0].itog_sred(sred, ref sredni);

            sort(gropsBBI, sredni);

            for (int i = 0; i < gropsBBI.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gropsBBI[i][j].Print(gropsBBI[i][j], sredni[i]);
                }
            }

        }
        static void sort(Group[][] grops, double[] sr)
        {
            for (int i = 0; i < grops.Length; i++)
            {
                for (int j = 0; j < grops.Length - 1 - i; j++)
                {
                    if (sr[j] < sr[j + 1])
                    {
                        double temp = sr[j];
                        sr[j] = sr[j + 1];
                        sr[j + 1] = temp;

                        Group[] g = grops[j];
                        grops[j] = grops[j + 1];
                        grops[j + 1] = g;
                    }
                }
            }
        }
    }
}
