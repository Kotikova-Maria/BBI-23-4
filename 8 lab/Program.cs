using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_lab
{
        abstract class Task
        {
            protected string text;
            public Task(string textt) { text = textt; }
            protected abstract void ParseText(string text);
        }
        class Task_1 : Task
        {
            public Task_1(string text) : base(text) { }
            public override string ToString()
            {
                ParseText(text);
                return text;
            }
            protected override void ParseText(string text)
            {
                string[] words = text.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = Rev(words[i]);
                }
                string new_text = "";
                for (int i = 0; i < words.Length; i++)
                {
                    new_text += String.Concat(words[i], " ");
                }
                this.text = new_text;
            }
            static string Rev(string b)
            {
                int j = b.Length - 1;
                char[] chars = b.ToCharArray();
                int u = 0;
                while (u < j)
                {
                    char temp = chars[u];
                    chars[u] = chars[j];
                    chars[j] = temp;
                    u++;
                    j--;
                }
                string c = new string(chars);
                return c;
            }
        }
        class Task_4 : Task
        {
            public Task_4(string text) : base(text) { }
            public override string ToString()
            {
                ParseText(text);
                return text;
            }
            private static int k = 0;
            protected override void ParseText(string text)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if ((text[i] == '-') || (text[i] == ',') || (text[i] == '.'))
                    { k++; }
                }
                string[] words = text.Split(' ', ',', '.');//здесь учитываются
                int b = words.Length - k;
                k += b;
                this.text = k.ToString();
            }
        }
        class Task_6 : Task
        {
            public Task_6(string text) : base(text) { }
            public override string ToString()
            {
                ParseText(text);
                return text;
            }
            protected override void ParseText(string text)
            {
                string[] words = text.Split(' ', ',');

                int c1 = 0, c2 = 0, c3 = 0;
                string glasnie = "ауоыиэяюёе";
                char[] charGlasnie = glasnie.ToCharArray();

                for (int i = 0; i < words.Length; i++)
                {

                    int check = 0;
                    char[] chars = words[i].ToCharArray();

                    for (int j = 0; j < chars.Length; j++) 
                    {
                        for (int k = 0; k < glasnie.Length; k++) 
                        {
                            if (chars[j] == charGlasnie[k]) { check++; }
                        }
                    }

                    if (check == 1) { c1++; } else { if (check == 2) { c2++; } else { if (check == 3) { c3++; } } }
                }
                this.text = $"Слов с 1 слогом - {c1} , с двумя - {c2} с тремя - {c3}";
            }

        }
        class Task_8 : Task
        {
            public Task_8(string text) : base(text) { }
            public override string ToString()
            {
                ParseText(text);
                return text;
            }
            protected override void ParseText(string text)
            {
                double n = 50;

                double a = (text.Length + 1) / n;

                int b = (int)(Math.Ceiling(a));

                string[] lines = new string[b];

                string[] words = text.Split();

                int k = 0;
                int count = 0;

                for (int i = 0; i < words.Length; i++)
                {
                    count += words[i].Length;

                    if (count < 50) { lines[k] += words[i] + ' '; } else { k++; count = words[i].Length; lines[k] += words[i] + ' '; }
                }
                this.text = String.Join("\n", lines);
            }

        }
        class Task_9 : Task
        {
            public Task_9(string text) : base(text) { }
            public override string ToString()
            {
                ParseText(text);
                return text;
            }
            protected override void ParseText(string text)
            {
                string[] zamena = { "#", "%", "&", "^", "@" };

                Dictionary<string, int> sequenceCounts = new Dictionary<string, int>();

                for (int i = 0; i < text.Length - 1; i++)
                {
                    string pair = text.Substring(i, 2);
                    if (!char.IsLetter(pair[0]) || !char.IsLetter(pair[1])) 
                    {
                        continue;
                    }

                    if (sequenceCounts.ContainsKey(pair))
                    {
                        sequenceCounts[pair]++;
                    }
                    else
                    {
                        sequenceCounts[pair] = 1;
                    }
                }

                List<string> topSequences = new List<string>();

                foreach (var pair in sequenceCounts)
                {
                    if (pair.Value > 8) { topSequences.Add(pair.Key); }
                }

                Dictionary<string, string> CodeTable = new Dictionary<string, string>();

                string replacedText = text;
                for (int i = 0; i < topSequences.Count; i++)
                {
                    CodeTable.Add(zamena[i], topSequences[i]);
                    replacedText = replacedText.Replace(topSequences[i], zamena[i]);
                }

                string table = "Таблица кодов:\n";
                foreach (var code in CodeTable)
                {
                    table += code.Key + " " + code.Value + "\n";
                }
                replacedText += "\n" + table;
                this.text = replacedText;

            }

        }
        class Task_10 : Task
        {
            public override string ToString()
            {
                ParseText(text);
                return text;
            }
            public Task_10(string text) : base(text) { }
            protected override void ParseText(string text)
            {
                string decoded_text = text.Replace("#", "ле").Replace("%", "ни").Replace("&", "ен").Replace("^", "ны").Replace("@", "ст");
                this.text = decoded_text;
            }
        }
        class Program
        {
            public static void Main()
            {
                Task task1 = new Task_1
                    ("Двигатель самолета – это сложная инженерная конструкция," +
                    " обеспечивающая подъем, управление и движение в воздухе." +
                    " Он состоит из множества компонентов," +
                    " каждый из которых играет важную роль в общей " +
                    "работе механизма. Внутреннее устройство двигателя включает" +
                    " в себя компрессор, камеру сгорания," +
                    " турбину и системы управления и охлаждения." +
                    " Принцип работы основан на воздушно-топливной смеси," +
                    " которая подвергается сжатию, воспламенению и расширению," +
                    " обеспечивая движение воздушного судна."); 
                Console.WriteLine(task1);

                Console.WriteLine();

                Task task2 = new Task_4("После многолетних исследований ученые обнаружили" +
                    " тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал," +
                    " что основной участник разрушения лесного покрова – человеческая деятельность." +
                    " За последние десятилетия рост объема вырубки достиг критических показателей." +
                    " Главными факторами, способствующими этому, являются промышленные рубки, производство" +
                    " древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины." +
                    " Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия," +
                    " ухудшение климата и угроза вымирания многих видов животных и растений.");
                Console.WriteLine(task2);

                Console.WriteLine();

                Task task3 = new Task_6("1 июля 2015 года Греция объявила о дефолте по государственному долгу," +
                    " став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства" +
                    " в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие" +
                    " переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский" +
                    " центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. " +
                    "Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой" +
                    " стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных" +
                    " инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного" +
                    " рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата" +
                    " доверия со стороны международных инвесторов.");
                Console.WriteLine(task3);

                Console.WriteLine();

                Task task4 = new Task_8("Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой." +
                    " Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные " +
                    "высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов" +
                    " и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\"," +
                    " в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая" +
                    " вдохновлять людей со всего мира.");
                Console.WriteLine(task4);

                Task task5 = new Task_9("После многолетних исследований ученые обнаружили" +
                    " тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал," +
                    " что основной участник разрушения лесного покрова – человеческая деятельность." +
                    " За последние десятилетия рост объема вырубки достиг критических показателей." +
                    " Главными факторами, способствующими этому, являются промышленные рубки, производство" +
                    " древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины." +
                    " Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия," +
                    " ухудшение климата и угроза вымирания многих видов животных и растений.");
                Console.WriteLine(task5);

                Task task6 = new Task_10("Пос# много#т%х исс#дова%й уч&ые обнаружили тревожную т&д&цию в вырубке #сов Амазо%и." +
                    " Анализ дан^х показал, что основной уча@%к разруше%я #сного покрова - человеческая деятельно@ь. За пос#д%е десяти#тия" +
                    " ро@ объема вырубки до@иг критических показате#й. Глав^ми факторами, способ@вующими этому, являются промыш#н^е рубки," +
                    " производ@во древеси^, расшире%е сельскохозяй@в&^х угодий и незаконная добыча древеси^. Это приводит к серьез^м экологическим" +
                    " пос#д@виям, таким как потеря биоразнообразия, ухудше%е климата и угроза вымира%я многих видов живот^х и ра@е%й.");
                Console.WriteLine(task6);
            }
        }
}
