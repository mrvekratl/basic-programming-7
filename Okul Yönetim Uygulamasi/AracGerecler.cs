using Okul_Yönetim_Uygulamasi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Uygulamasi
{
    internal class AracGerecler
    {

        public void ListeYazdir(List<Ogrenci> liste)
        {
            if(liste.Count == 0)
            {
                Console.WriteLine("\r\nListelenecek ögrenci yok.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Sube".PadRight(10) + "No".ToString().PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.".PadRight(15));
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (Ogrenci item in liste)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.Kitaplar.Count);
                }
            }
        }

        public void IlleriListeYazdir(List<Ogrenci> liste)
        {
            if (liste.Count== 0)
            {
                Console.WriteLine("\r\nListelenecek ögrenci yok.\r\n");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Sube".PadRight(10) + "No".ToString().PadRight(10) + "Adı Soyadı".PadRight(25) + "Sehir".PadRight(15) + "Semt".PadRight(15));
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (Ogrenci item in liste)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + (item.Adres.Il.Substring(0, 1).ToUpper() + item.Adres.Il.Substring(1).ToLower()).PadRight(15) + (item.Adres.Ilce.Substring(0, 1).ToUpper() + item.Adres.Ilce.Substring(1).ToLower()));

                }

            }

        }

        public void NotlarListeYazdir(List<Ogrenci> liste)
        {            
            Console.WriteLine();
            foreach (Ogrenci item in liste)
            {
                Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                Console.WriteLine();
                
               if (item.Notlar.Count == 0) 
               {
                    Console.WriteLine("Öğrenciye ait bir not bulunmamaktadır");
               }
               else
               {
                    Console.WriteLine("Dersin Adi     Notu");
                    Console.WriteLine("--------------------");
                    for (int i = 0; i < item.Notlar.Count; i++)
                    {
                        Console.WriteLine(item.Notlar[i].DersAdi.PadRight(15) + item.Notlar[i].Not);
                    }
               }

                //Console.WriteLine("Türkçe         " + item.Notlar.FirstOrDefault(a => a.DersAdi == "Türkçe").Not);
                //Console.WriteLine("Matematik     " + item.Notlar.FirstOrDefault(a => a.DersAdi == "Matematik").Not);
                //Console.WriteLine("Fen            " + item.Notlar.FirstOrDefault(a => a.DersAdi == "Fen").Not);
                //Console.WriteLine("Sosyal         " + item.Notlar.FirstOrDefault(a => a.DersAdi == "Sosyal").Not);
                //Console.WriteLine();
            }
                
        }

        static public bool TarihMi(string mesaj)
        {
            DateTime secim;
            if (DateTime.TryParse(mesaj, out secim))
            {
                return true;
            }
            else
            {
                
                return false;

            }

            
        }

        static public string YaziAl(string yazi)
        {
            int sayi;


            do
            {                             
                    
               string giris = Console.ReadLine().ToUpper();

               if (int.TryParse(giris, out sayi))
               {
                   throw new Exception("Giriş tanımlanamadı. Tekrar deneyin.");
               }
               
               else
               {
                   return giris;
               }

               

            } while (true);

        }

        static public int SayiAl(string mesaj)
        {
            int sayi;

            while(true)          
            {             
                               
               string giris = Console.ReadLine().ToUpper();

               if (int.TryParse(giris, out sayi))
               {
                   return sayi;
               }
               
               else
               {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write("Ögrencinin numarasi: ");
                }
                
               
            } 

        }
        static public int NotAl(string mesaj, int adet)
        {
            int sayi;

            while (true)
            {


                string giris = Console.ReadLine().ToUpper();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }

                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write(adet + ". Notu girin:");


                }


            }

        }



    }
}




