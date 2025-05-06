using System.Text.Json;
using System.Text.Json.Serialization;

class Quiz
{
 
}

class Program
{
    static void Main(string[] args)
    {
        string filePath = "\\quiz.json";

        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);
            var quiz = JsonSerializer.Deserialize<List<Quiz>>(json);

            int punkty = 0;

            foreach (var pyt in quiz)
            {
               
            }

            Console.WriteLine($"\nTwój wynik: {punkty} / {quiz.Count}");
        }
    }
}
