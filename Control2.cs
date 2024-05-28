using System.Text.Json;
using System.Text.Json.Serialization;
abstract class Task
{
    protected string text = "No text";
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    [JsonConstructor]
    public Task()
    {

    }
}
class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) { this.text = text; }
    public override string ToString()
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int b = words.Length / 2;
        return words[b];
    }
}
class Task2 : Task
{
    [JsonConstructor]
    public Task2(string text) { this.text = text; }
    public override string ToString()
    {
        string[] s = text.Split(' ');
        List<string> words = new List<string>();
        foreach (string c in s)
        {
            foreach (char e in c)
            {
                if (char.IsLetter(e))
                {
                    if (char.IsUpper(e))
                    {
                        words.Add(c);
                        break;
                    }
                }
            }
        }
        return string.Join("\n", words.ToArray());
    }
}
class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}

    class Control2
    {
        static void Main()
        {
            string text = "Я не думаю, что это хорошая идея, а f Вы? f f j";
            Task[] tasks = { new Task1(text), new Task2(text)};
            Console.WriteLine(tasks[0]);
            Console.WriteLine(tasks[1]);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string folderName = "Fourth Task";
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName1 = "string_1.json";
            string fileName2 = "string_2.json";

            fileName1 = Path.Combine(path, fileName1);
            fileName2 = Path.Combine(path, fileName2);

            if (!File.Exists(fileName1))
            {
                JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
                JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
            }
            else
            {
                var t1 = JsonIO.Read<Task1>(fileName1);
                var t2 = JsonIO.Read<Task2>(fileName2);
                Console.WriteLine(t1);
                Console.WriteLine(t2);
            }
        }
    }