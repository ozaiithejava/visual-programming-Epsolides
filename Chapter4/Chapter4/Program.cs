using System;
using System.Collections.Generic;

class GelismisSinifOrtalamasi
{
    static void Main()
    {
        Console.WriteLine("=== Gelişmiş Sınıf Ortalaması Hesaplayıcı ===");

        List<int> notlar = new List<int>();
        bool devam = true;

        while (devam)
        {
            int not = SayiAl("Notu girin veya çıkmak için -1 yazın: ");

            if (not == -1)
            {
                devam = false;
                break;
            }

            // 0-100 arası not kontrolü
            if (not < 0 || not > 100)
            {
                Console.WriteLine("Hatalı giriş! Not 0 ile 100 arasında olmalıdır.");
                continue;
            }

            notlar.Add(not);
        }

        if (notlar.Count > 0)
        {
            int toplam = 0;
            int min = notlar[0];
            int max = notlar[0];

            foreach (var n in notlar)
            {
                toplam += n;
                if (n < min) min = n;
                if (n > max) max = n;
            }

            double ortalama = (double)toplam / notlar.Count;

            Console.WriteLine($"\nGirilen {notlar.Count} notun toplamı: {toplam}");
            Console.WriteLine($"Sınıf ortalaması: {ortalama:F2}");
            Console.WriteLine($"En düşük not: {min}");
            Console.WriteLine($"En yüksek not: {max}");
            Console.WriteLine($"Ortalamanın harf karşılığı: {HarfNotu(ortalama)}");
        }
        else
        {
            Console.WriteLine("Hiç not girilmedi.");
        }
    }

    // Kullanıcıdan sayı alma metodu (hata kontrolü ile)
    static int SayiAl(string mesaj)
    {
        int sayi;
        while (true)
        {
            Console.Write(mesaj);
            string giris = Console.ReadLine();
            if (int.TryParse(giris, out sayi))
                return sayi;
            else
                Console.WriteLine("Hatalı giriş! Lütfen bir tamsayı girin.");
        }
    }

    // Ortalama notu harf notuna çevir
    static string HarfNotu(double ortalama)
    {
        if (ortalama >= 90) return "A";
        else if (ortalama >= 80) return "B";
        else if (ortalama >= 70) return "C";
        else if (ortalama >= 60) return "D";
        else return "F";
    }
}
