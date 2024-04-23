using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace контрольная_работа
{
    abstract class String_Task
    {
        protected string text;
        public String_Task (string textt) { text = textt; }
    }
    class Task_1: String_Task
    {
        public Task_1(string text) : base(text) { }

        public override string ToString()
        {
            ParseText (text);
            return text;
        }
        protected void ParseText(string text)
        {
            
            double sum = 0;
            string[] words = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                sum += word.Length;
            }

            double b = sum / words.Length;
            this.text = b.ToString();
        }
        
    }
    class Task_2 : String_Task
    {
        public Task_2(string text) : base(text) { }
        public override string ToString()
        {
            ParseText(text);
            return text;
        }
        protected void ParseText(string text)
        {
            string[] words = text.Split();
            char[] chars = text.ToCharArray();
            int count = 0;
            int[] max = new int[chars.Length];
            char [] maxL = new char [chars.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                char b = chars[i];
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (words[i][j] == b) { count++; maxL[0] = words[i][j]; }
                }
                max[i] = count; count = 0 ;
            }
            int maxx = 0;
            for (int i = max.Length-1;i>=0; i--)
            {
                if (max[i] > max[i-1]) { maxx = max[i]; i++; }
            }
            char maxletter = 'a';
            for (int i = 0; i < max.Length; i++)
            {
                if (i == maxx) { maxletter = maxL[i]; }
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (maxletter == text[i])
                {
                    text.Replace(text[i], ' ');
                }
            }
            double k = 0;
            this.text = k.ToString();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String_Task task_1 = new Task_1 ("Однажды в далеком королевстве жили-были принц" +
                " и принцесса, которых разлучила злая ведьма. Принц отправился в опасное путешествие," +
                " чтобы спасти свою возлюбленную. По дороге ему встретились верные друзья и сильные враги," +
                " но он не унывал и продолжал свой путь.");
            Console.WriteLine(task_1);

            string DeskTopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
    }
}
