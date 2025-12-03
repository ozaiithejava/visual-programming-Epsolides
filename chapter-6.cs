// -------------------------------------------------------------
//  Global Warming Quiz Application
//  Made by ozaiithejava
// -------------------------------------------------------------

using System;
using System.Collections.Generic;

class GlobalWarmingQuiz
{
    /// <summary>
    /// Uygulamanın giriş noktasıdır.
    /// Java'daki Javadoc benzeri açıklamalar eklenmiştir.
    /// </summary>
    /// <param name="args">Komut satırı parametreleri (kullanılmıyor).</param>
    static void Main(string[] args)
    {
        Console.WriteLine("=== Global Warming Facts Quiz ===");
        Console.WriteLine("Made by ozaiithejava");
        Console.WriteLine("Her soru için 1–4 arası bir cevap giriniz.\n");

        // Sorular ve seçenekler
        var questions = new List<(string q, string[] opts, int correct)>
        {
            (
                "1) Bilim camiasına göre 20. yüzyıl ortasından bu yana gözlenen ısınmanın en güçlü açıklaması nedir?",
                new string[]
                {
                    "1) Güneş aktivitesindeki uzun vadeli artış",
                    "2) Volkanik patlamaların ısıtıcı etkisi",
                    "3) İnsan kaynaklı sera gazı artışı (CO2 vb.)",
                    "4) Doğal tektonik süreçler"
                },
                3
            ),
            (
                "2) Küresel ısınma şüphecilerinin sıkça söylediği iddia nedir?",
                new string[]
                {
                    "1) Tüm iklim modelleri insan etkisini göz ardı ediyor",
                    "2) Sıcaklık değişimleri tamamen doğal döngüler ve güneş aktivitesiyle açıklanabilir",
                    "3) Bilim insanlarının çoğu insan kaynaklı ısınmayı reddediyor",
                    "4) Sera gazları ısı tutmaz"
                },
                2
            ),
            (
                "3) IPCC bulgularını en iyi yansıtan ifade hangisidir?",
                new string[]
                {
                    "1) Isınma tamamen doğal değişkenlikten kaynaklanıyor",
                    "2) Fosil yakıt kullanımı başta olmak üzere insan faaliyetleri gözlenen ısınmanın ana nedenidir",
                    "3) Modeller geleceği tahmin edemez; etkiler bilinmiyor",
                    "4) CO2 artışı küresel soğumaya yol açar"
                },
                2
            ),
            (
                "4) İklim bilimindeki ‘belirsizlik’ en iyi nasıl tanımlanır?",
                new string[]
                {
                    "1) Belirsizlik varsa politika gerekliliği yoktur",
                    "2) Bazı büyüklük ve zamanlamalarda belirsizlik vardır; bu risk yönetimi gerektirir",
                    "3) Belirsizlik bilimin tamamen yanlış olduğunu kanıtlar",
                    "4) Belirsizlik yalnızca model hatalarından kaynaklanır"
                },
                2
            ),
            (
                "5) Hangisi iklim değişikliğinin potansiyel etkileri arasında yer almaz?",
                new string[]
                {
                    "1) Deniz seviyesinin yükselmesi",
                    "2) Aşırı hava olaylarının bazı türlerinde artış",
                    "3) Bazı bölgelerde verim artışı",
                    "4) Hemen ve evrensel olarak tüm canlılar için faydalı etkiler"
                },
                4
            )
        };

        int score = 0;

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine(questions[i].q);
            foreach (var opt in questions[i].opts)
                Console.WriteLine(opt);

            int answer = 0;

            // Kullanıcı cevabını güvenli biçimde alma
            while (true)
            {
                Console.Write("Cevabınız (1-4): ");
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out answer) && answer >= 1 && answer <= 4)
                    break;

                Console.WriteLine("Lütfen 1 ile 4 arasında bir sayı giriniz.");
            }

            if (answer == questions[i].correct)
                score++;

            Console.WriteLine();
        }

        Console.WriteLine($"Doğru sayınız: {score}/{questions.Count}");

        if (score == questions.Count)
        {
            Console.WriteLine("Mükemmel! Harika iş çıkardınız.");
        }
        else if (score >= 4)
        {
            Console.WriteLine("Çok iyi!");
        }
        else
        {
            Console.WriteLine("Biraz daha çalışmak iyi olabilir.");
            Console.WriteLine("\nKaynak önerileri:");
            Console.WriteLine("- IPCC AR6 (WG1) — Fiziksel Bilim Temeli");
            Console.WriteLine("- NASA Climate — İklim değişikliğinin nedenleri");
            Console.WriteLine("- SkepticalScience — Şüpheci iddialara yanıtlar");
        }

        Console.WriteLine("\nMade by ozaiithejava");
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
