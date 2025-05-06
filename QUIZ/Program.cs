using System.Text.Json;
using System.Text.Json.Serialization;

class Quiz
{
    [JsonPropertyName("pytanie")]
    public string Pytanie { get; set; }

    [JsonPropertyName("odpowiedzi")]
    public Dictionary<string, string> Odpowiedzi { get; set; }

    [JsonPropertyName("poprawna")]
    public string Poprawna { get; set; }
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
                Console.WriteLine("\n" + pyt.Pytanie);
                foreach (var odp in pyt.Odpowiedzi)
                {
                    Console.WriteLine($"{odp.Key}. {odp.Value}");
                }

                Console.Write("Twoja odpowiedź (A/B/C/D): ");
                string odpUzytkownika = Console.ReadLine().ToUpper();

                if (odpUzytkownika == pyt.Poprawna.ToUpper())
                {
                    Console.WriteLine("Poprawna!");
                    punkty++;
                }
                else
                {
                    Console.WriteLine($"Błędna. Poprawna odpowiedź: {pyt.Poprawna}");
                }
            }

            Console.WriteLine($"\nTwój wynik: {punkty} / {quiz.Count}");
        }
    }
}
