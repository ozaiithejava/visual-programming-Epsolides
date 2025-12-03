// -------------------------------------------------------------
//  Computer-Assisted Instruction (Multiplication Practice)
//  Made by ozaiithejava
// -------------------------------------------------------------

using System;

class Program
{
    /// <summary>
    /// Uygulamanın giriş noktasıdır.
    /// Çarpma alıştırması için rastgele sorular üretir.
    /// Kullanıcı doğru yanıt verene kadar aynı soruyu tekrar sorar.
    /// Java Javadoc tarzı açıklamalar eklenmiştir.
    /// </summary>
    /// <param name="args">Komut satırı parametreleri (kullanılmaz)</param>
    static void Main(string[] args)
    {
        var rng = new Random();

        Console.WriteLine("=== Computer-Assisted Instruction (Multiplication Practice) ===");
        Console.WriteLine("Made by ozaiithejava");
        Console.WriteLine("Exit anytime by typing 'q' or 'exit'.\n");

        while (true)
        {
            int a = rng.Next(0, 10);
            int b = rng.Next(0, 10);
            int correct = a * b;

            while (true)
            {
                Console.Write($"How much is {a} times {b}? ");
                string input = Console.ReadLine()?.Trim();

                // CHECK
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter an answer (or type 'q' to quit).");
                    continue;
                }

                  // Q
                if (input.Equals("q", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nGoodbye! (made by ozaiithejava)");
                    return;
                }

                // parsing
                if (!int.TryParse(input, out int answer))
                {
                    Console.WriteLine("Please enter a valid integer answer (or 'q' to quit).");
                    continue;
                }

                // true 
                if (answer == correct)
                {
                    int pick = rng.Next(1, 5); // rnd

                    switch (pick)
                    {
                        case 1: Console.WriteLine("Very good!"); break;
                        case 2: Console.WriteLine("Excellent!"); break;
                        case 3: Console.WriteLine("Nice work!"); break;
                        case 4: Console.WriteLine("Keep up the good work!"); break;
                    }

                    Console.WriteLine();
                    break; // next que
                }
                else
                {
                    // Yanlış cevaplar
                    int pick = rng.Next(1, 5);

                    switch (pick)
                    {
                        case 1: Console.WriteLine("No. Please try again."); break;
                        case 2: Console.WriteLine("Wrong. Try once more."); break;
                        case 3: Console.WriteLine("Don't give up!"); break;
                        case 4: Console.WriteLine("No. Keep trying."); break;
                    }

                    //replay
                }
            }
        }
    }
}
