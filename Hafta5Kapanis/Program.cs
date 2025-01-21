using System;
using System.Collections.Generic;

public class Araba
{
    public DateTime UretimTarihi { get; } = DateTime.Now;
    public string SeriNumarasi { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Renk { get; set; }
    public int KapiSayisi { get; set; }
    public string YakitTuru { get; set; } // Added YakitTuru property

    public Araba(string seriNumarasi, string marka, string model, string renk, int kapiSayisi)
    {
        SeriNumarasi = seriNumarasi ?? throw new ArgumentNullException(nameof(seriNumarasi));
        Marka = marka ?? throw new ArgumentNullException(nameof(marka));
        Model = model ?? throw new ArgumentNullException(nameof(model));
        Renk = renk ?? throw new ArgumentNullException(nameof(renk));
        KapiSayisi = kapiSayisi;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Araba> arabalar = new List<Araba>();

        while (true)
        {
            Console.Write("Araba üretmek ister misiniz? (e/h): ");
            string? cevap = Console.ReadLine()?.ToLower();

            if (cevap == "e")
            {
                Console.Write("Seri Numarası: ");
                string? seriNumarasi = Console.ReadLine();

                Console.Write("Marka: ");
                string? marka = Console.ReadLine();

                Console.Write("Model: ");
                string? model = Console.ReadLine();

                Console.Write("Renk: ");
                string? renk = Console.ReadLine();

                bool isValid = false;
                do
                {
                    Console.Write("Kapı Sayısı: ");
                    string? kapiSayisiStr = Console.ReadLine();

                    if (int.TryParse(kapiSayisiStr, out int kapiSayisi))
                    {
                        isValid = true;
                        if (seriNumarasi != null && marka != null && model != null && renk != null)
                        {
                            Araba yeniAraba = new Araba(seriNumarasi, marka, model, renk, kapiSayisi);
                            arabalar.Add(yeniAraba);

                            // Ek özellikler (örneğin, yakıt türü)
                            Console.Write("Yakıt Türü (benzin/dizel): ");
                            string? yakitTuru = Console.ReadLine()?.ToLower();
                            yeniAraba.YakitTuru = yakitTuru; // Set YakitTuru property
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz giriş! Lütfen bir sayı giriniz.");
                    }
                } while (!isValid);
            }
            else if (cevap == "h")
            {
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz cevap! Lütfen 'e' veya 'h' giriniz.");
            }
        }

        // Tüm arabaları listeleme
        Console.WriteLine("\nOluşturulan Arabalar:");
        foreach (var araba in arabalar)
        {
            Console.WriteLine($"Seri Numarası: {araba.SeriNumarasi}, Marka: {araba.Marka}, Model: {araba.Model}, Renk: {araba.Renk}, Kapı Sayısı: {araba.KapiSayisi}, Yakıt Türü: {araba.YakitTuru}, Üretim Tarihi: {araba.UretimTarihi}");
        }
    }
}
