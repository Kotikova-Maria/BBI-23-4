using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._3_lv
{

    abstract class Group
    {
        protected string _group, _potok;
        protected int _matem, _prog, _system;
        public Group(string group, string potok, int matem, int prog, int system)
        {
            _group = group;
            _potok = potok;
            _matem = matem;
            _prog = prog;
            _system = system;
        }
        public string group { get => _group; }
        public string potok { get => _potok; }
        public int matem { get => _matem; }
        public int prog { get => _prog; }
        public int system { get => _system; }
        public virtual void sred_rez(Group grops, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops.prog + grops.matem + grops.system;
            sr = sum / n;
        }
        public virtual void Print(Group grops, double sred)
        {
            Console.WriteLine("Potok:{0, 10} Group:{1, 10} sredni_rez:{2, 10}", potok, group, sred);
        }

    }
    class Group1 : Group
    {
        private int _analis;
        private int _IP;
        public Group1(string group, string potok, int matem, int prog, int system, int analys, int IP) : base(group, potok, matem, prog, system)
        {
            _analis = analys;
            _IP = IP;
        }
        public override void sred_rez(Group grops, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops.prog + grops.matem + grops.system + _analis + _IP;
            sr = sum / n;
        }
    }
    class Group2 : Group
    {
        private int _physics, _vichmash;
        public Group2(string group, string potok, int matem, int prog, int system, int physics, int vichmash) : base(group, potok, matem, prog, system)
        {
            _physics = physics;
            _vichmash = vichmash;
        }
    }
    class Group3 : Group
    {
        private int _perseff, _angl;
        public Group3(string group, string potok, int matem, int prog, int system, int perseff, int angl) : base(group, potok, matem, prog, system)
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
        public Group4(string group, string potok, int matem, int prog, int system, int history, int chinese) : base(group, potok, matem, prog, system)
        {
            _history = history;
            _chinese = chinese;
        }
    }
    class Group5 : Group
    {
        private int _espanyol, _logika;
        public Group5(string group, string potok, int matem, int prog, int system, int espanyol, int logika) : base(group, potok, matem, prog, system)
        { _espanyol = espanyol; _logika = logika; }
        public override void sred_rez(Group grops, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops.prog + grops.matem + grops.system + _espanyol + _logika;
            sr = sum / n;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] grops = new Group[5];
            grops[0] = new Group1("3", "BBI", 5, 3, 3, 1, 5);
            grops[1] = new Group2("1", "IVT", 5, 5, 3, 4, 2);
            grops[2] = new Group3("4", "BBI", 5, 5, 4, 5, 5);
            grops[3] = new Group4("1", "PM", 2, 4, 3, 4, 5);
            grops[4] = new Group5("2", "BBI", 2, 2, 2, 5, 3);

            Group[] gropsBBI = new Group[3];
            double[] sred = new double[3];
            int k = 0;//number of element in sred
            double sr = 0;
            for (int i = 0; i < grops.Length; i++)
            {
                string BBI = "BBI";
                if (grops[i].potok.Equals(BBI))
                {
                    gropsBBI[k] = grops[i];
                    grops[i].sred_rez(grops[i], ref sr); sred[k] = sr; k++;
                }
            }
            sort(gropsBBI, sred);
            for (int i = 0; i < gropsBBI.Length; i++)
            {
                gropsBBI[i].Print(gropsBBI[i], sred[i]);
            }
        }
        static void sort(Group[] grops, double[] sr)
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
                        Group g = grops[j];
                        grops[j] = grops[j + 1];
                        grops[j + 1] = g;
                    }
                }
            }
        }
    }
}
