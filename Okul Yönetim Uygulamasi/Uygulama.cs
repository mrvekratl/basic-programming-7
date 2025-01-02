using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Uygulamasi
{
    internal class Uygulama
    {
        Okul okul = new Okul();
        AracGerecler ag = new AracGerecler();
        string secim;

        public void Calistir()
        {

            Menu();
            while (true)
            {
                Console.Write("Yapmak istediginiz islemi seçiniz: ");
                secim = Console.ReadLine();
                Console.WriteLine();

                switch (secim)
                {
                    case "1": ButunOgrencileriListele(); break; //Bütün öğrencileri listele                      
                    case "2": SubeyeGoreListele(); break;//Şubeye göre öğrencileri listele
                    case "3": CinsiyeteGoreListele(); break;//Cinsiyetine göre öğrencileri listele
                    case "4": SuTarihtenSonraDoganlarıListele(); break; //Şu tarihten sonra doğan öğrencileri listele
                    case "5": IllereGoreListele(); break;//İllere göre sıralayarak öğrencileri listele
                    case "6": OgrencininTumNotlarıListele(); break;//Öğrencinin tüm notlarını listele
                    case "7": OgrencininKitaplariniListele(); break;// Öğrencinin okuduğu kitapları listele
                    case "8": EnBasariliBesOgrenciListele(); break;//Okuldaki en yüksek notlu 5 öğrenciyi listele
                    case "9": EnBasarisizUcOgrenciListele(); break;//Okuldaki en düşük notlu 3 öğrenciyi listele
                    case "10": SubedekiBasariliBesOgrenciListele(); break; //Şubedeki en yüksek notlu 5 öğrenciyi listele
                    case "11": SubedekiBasarisizUcOgrenciListele(); break; //Şubedeki en düşük notlu 3 öğrenciyi listele
                    case "12": OgrencininNotOrtalamasiListele(); break; //Öğrencinin not ortalamasını gör
                    case "13": SubeninNotOrtalamasiListele(); break; // Şubenin Not Ortalamasını Gör
                    case "14": OgrencininSonKitabiniListele(); break;// Öğrencinin okuduğu son kitabı gör
                    case "15": OgrenciEkle(); break;//Öğrenci ekle
                    case "16": OgrenciGüncelle(); break; //Öğrenci güncelle
                    case "17": OgrenciSil(); break;//Öğrenci sil
                    case "18": OgrencininAdresiniGir(); break; //Öğrencinin adresini gir
                    case "19": OgrencininOkuduguKitabiGir(); break;// Öğrencinin okuduğu kitabı gir
                    case "20": OgrencininNotunuEkle(); break;//Öğrencinin notunu gir
                    case "çıkış": Environment.Exit(0); break;//Çıkış
                    case "liste": Console.WriteLine(); Menu(); Console.WriteLine("\r\n\rMenüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.\r\n\r"); break;
                    default: Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin. \r\n\r\nMenüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.\r\n"); break;

                }


            }


        }
        public void Menu()
        {
            Console.WriteLine("------Okul Yönetim Uygulamasi  -----");
            Console.WriteLine();
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("çıkış yapmak için “çıkış” yazıp “enter”a basın.");
            Console.WriteLine();
        }
        public string SecimiYonlendir()
        {
            Console.WriteLine("\r\n\rMenüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.\r\n\r");
            return secim;
        }
        public void ButunOgrencileriListele()
        {

            Console.WriteLine("1-Bütün Öğrencileri Listele --------------------------------------------------");
            ag.ListeYazdir(okul.ogrenciler.OrderBy(a => a.No).ToList());
            SecimiYonlendir();


        }
        public void SubeyeGoreListele()
        {
            Console.WriteLine("2-Subeye Göre Ögrencileri Listele --------------------------------------------");

            bool kontrol = false;

            while (kontrol == false)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string secim = Console.ReadLine().ToUpper();


                switch (secim)
                {
                    case "A": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.A).OrderBy(a => a.No).ToList()); kontrol = true; break;
                    case "B": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.B).OrderBy(a => a.No).ToList()); kontrol = true; break;
                    case "C": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.C).OrderBy(a => a.No).ToList()); kontrol = true; break;
                    case "":
                        Console.WriteLine();
                        Console.WriteLine("Listelenecek ögrenci yok."); kontrol = true; break;
                    default:

                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); break;

                }
            }
            SecimiYonlendir();
        }
        public void CinsiyeteGoreListele()
        {
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");

            bool kontrol = false;

            while (kontrol == false)
            {
                Console.Write("Listelemek istediğiniz cinsiyeti girin (K/E): ");
                string secim = Console.ReadLine().ToUpper();
                switch (secim)
                {
                    case "K": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Cinsiyet == CINSIYET.Kiz).OrderBy(a => a.No).ToList()); kontrol = true; break;
                    case "E": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Cinsiyet == CINSIYET.Erkek).OrderBy(a => a.No).ToList()); kontrol = true; break;
                    case "":
                        Console.WriteLine();
                        Console.WriteLine("Listelenecek ögrenci yok."); kontrol = true; break;
                    default: Console.WriteLine("Hatali giris yapildi.Tekrar deneyin"); break;


                }
            }
            SecimiYonlendir();
        }
        public void SuTarihtenSonraDoganlarıListele()
        {
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");

            bool kontrol = false;



            while (kontrol == false)
            {
                Console.Write("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
                string secim = Console.ReadLine();

                if (AracGerecler.TarihMi(secim) == true)
                {

                    ag.ListeYazdir(okul.ogrenciler.Where(a => a.DogumTarihi > DateTime.Parse(secim)).ToList());

                    kontrol = true; break;

                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi.Tekrar deneyin");
                }

            }
            SecimiYonlendir();
        }
        public void IllereGoreListele()
        {
            Console.WriteLine();
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");
            ag.IlleriListeYazdir(okul.ogrenciler.OrderBy(a => a.Adres.Il).ToList());
            SecimiYonlendir();
        }
        public void OgrencininTumNotlarıListele()
        {
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");


            while (true)
            {
                Ogrenci o = okul.ogrenciler.Where(a => a.No == no).FirstOrDefault();
                if (o != null)
                {
                    ag.NotlarListeYazdir(okul.ogrenciler.Where(a => a.No == no).ToList());
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = int.Parse(Console.ReadLine());

                }
            }
            SecimiYonlendir();
        }
        public void OgrencininKitaplariniListele()
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");

            while (true)
            {
                Ogrenci o = okul.ogrenciler.Where(a => a.No == no).FirstOrDefault();
                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
                    Console.WriteLine();
                    Console.WriteLine("Okudugu Kitaplar");
                    Console.WriteLine("-----------------");
                    for (int i = 0; i < okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar.Count; i++)
                    {
                        Console.WriteLine(okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar[i]);
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = int.Parse(Console.ReadLine());
                }

            }

            SecimiYonlendir();
        }
        public void EnBasariliBesOgrenciListele()
        {
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            ag.ListeYazdir(okul.ogrenciler.OrderByDescending(a => a.Ortalama).Take(5).ToList());
            SecimiYonlendir();
        }
        public void EnBasarisizUcOgrenciListele()
        {
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");
            ag.ListeYazdir(okul.ogrenciler.OrderBy(a => a.Ortalama).Take(3).ToList());
            SecimiYonlendir();
        }
        public void SubedekiBasariliBesOgrenciListele()
        {
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            bool kontrol = false;

            while (kontrol == false)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "A": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.A).OrderByDescending(a => a.Ortalama).Take(5).ToList()); kontrol = true; break;
                    case "B": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.B).OrderByDescending(a => a.Ortalama).Take(5).ToList()); kontrol = true; break;
                    case "C": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.C).OrderByDescending(a => a.Ortalama).Take(5).ToList()); kontrol = true; break;
                    case "":
                        Console.WriteLine();
                        Console.WriteLine("Listelenecek ögrenci yok."); kontrol = true; break;
                    default:

                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); break;

                }
            }
            SecimiYonlendir();

        }
        public void SubedekiBasarisizUcOgrenciListele()
        {
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");
            bool kontrol = false;

            while (kontrol == false)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "A": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.A).OrderBy(a => a.Ortalama).Take(4).ToList()); kontrol = true; break;
                    case "B": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.B).OrderBy(a => a.Ortalama).Take(4).ToList()); kontrol = true; break;
                    case "C": ag.ListeYazdir(okul.ogrenciler.Where(a => a.Sube == SUBE.C).OrderBy(a => a.Ortalama).Take(4).ToList()); kontrol = true; break;
                    case "":
                        Console.WriteLine();
                        Console.WriteLine("Listelenecek ögrenci yok."); kontrol = true; break;
                    default:

                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); break;

                }
            }
            SecimiYonlendir();
        }
        public void OgrencininNotOrtalamasiListele()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");

            while (true)
            {
                Ogrenci o = okul.ogrenciler.Where(a => a.No == no).FirstOrDefault();

                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube);
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin not ortalaması:" + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ortalama);
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = int.Parse(Console.ReadLine());
                }

            }
            SecimiYonlendir();
        }
        public void SubeninNotOrtalamasiListele()
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör -------------------------------------");

            bool kontrol = false;

            while (kontrol == false)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string secim = Console.ReadLine().ToUpper();


                switch (secim)
                {
                    case "A": Console.WriteLine(); Console.WriteLine("A subesinin not ortalaması:" + okul.ogrenciler.Where(a => a.Sube == SUBE.A).Select(a => a.Ortalama).Average()); kontrol = true; break;
                    case "B": Console.WriteLine(); Console.WriteLine("B subesinin not ortalaması:" + okul.ogrenciler.Where(a => a.Sube == SUBE.B).Select(a => a.Ortalama).Average()); kontrol = true; break;
                    case "C": Console.WriteLine(); Console.WriteLine("C subesinin not ortalaması:" + okul.ogrenciler.Where(a => a.Sube == SUBE.C).Select(a => a.Ortalama).Average()); kontrol = true; break;
                    case "":
                        Console.WriteLine();
                        Console.WriteLine("Listelenecek ögrenci yok."); kontrol = true; break;
                    default:

                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin"); break;

                }
            }
            SecimiYonlendir();
        }
        public void OgrencininSonKitabiniListele()
        {
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
            while (true)
            {
                Ogrenci o = okul.ogrenciler.Where(a => a.No == no).FirstOrDefault();
                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube);
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                    Console.WriteLine("-----------------");
                    Console.WriteLine(okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar[okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Kitaplar.Count - 1]);
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = int.Parse(Console.ReadLine());
                }

            }

            SecimiYonlendir();

        }
        public void OgrenciEkle()
        {


            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");

            Console.Write("Ögrencinin numarası: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
            int sayac = 0;
            int varolanno = 0;
            if (okul.ogrenciler.Where(a => a.No == no).FirstOrDefault() != null)
            {
                sayac++;
                varolanno = no;
                no = okul.ogrenciler.Count + 1;
            }

            Console.Write("Ögrencinin adı: ");
            string ad = Console.ReadLine();

            Console.Write("Ögrencinin soyadı: ");
            string soyad = Console.ReadLine();

            DateTime tarih = new DateTime();
            int gun = tarih.Day;
            int ay = tarih.Month;
            int yil = tarih.Year;
            Console.Write("Ögrencinin dogum tarihi: ");
            string dogumTarihiInput = Console.ReadLine();

            while (true)
            {
                if (DateTime.TryParse(dogumTarihiInput, out tarih))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write("Ögrencinin dogum tarihi: ");
                    dogumTarihiInput = Console.ReadLine();
                }
            }


            Console.Write("Ögrencinin cinsiyeti (K/E): ");
            string cinsiyet = Console.ReadLine().ToUpper();

            while (true)
            {

                if (cinsiyet == "K" || cinsiyet == "E")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write("Ögrencinin cinsiyeti (K/E): ");
                    cinsiyet = Console.ReadLine().ToUpper();
                }

            }




            Console.Write("Ögrencinin subesi (A/B/C): ");
            string sube = Console.ReadLine().ToUpper();

            while (true)
            {

                if (sube == "A" || sube == "B" || sube == "C")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write("Ögrencinin subesi (A/B/C): ");
                    sube = Console.ReadLine().ToUpper();
                }
            }

            //SUBE subeEnum = (SUBE)Enum.Parse(typeof(SUBE), sube);
            //CINSIYET cinsiyetEnum = (CINSIYET)Enum.Parse(typeof(CINSIYET), cinsiyet);

            okul.OgrenciEkleme(ad, soyad, SUBE.Empty, tarih, no, CINSIYET.Empty);

            if (cinsiyet == "K")
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Cinsiyet = CINSIYET.Kiz;
            }
            else
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Cinsiyet = CINSIYET.Erkek;
            }

            if (sube == "A")
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Sube = SUBE.A;
            }
            else if (sube == "B")
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Sube = SUBE.B;
            }
            else
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Sube = SUBE.C;
            }

            if (sayac != 0)
            {
                Console.WriteLine();
                Console.WriteLine(okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().No + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
                Console.WriteLine("Sistemde " + varolanno + " numaralı öğrenci olduğu için verdiğiniz öğrenci no " + no + " olarak değiştirildi.");
                no = okul.ogrenciler.Count() + 1;


            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().No + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
            }

            okul.NotEkleme(no, "Türkçe", 0);
            okul.NotEkleme(no, "Matematik", 0);
            okul.NotEkleme(no, "Fen", 0);
            okul.NotEkleme(no, "Sosyal", 0);



            SecimiYonlendir();

        }
        public void OgrenciGüncelle()
        {
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");



            while (true)
            {
                if (okul.ogrenciler.Where(a => a.No == no).FirstOrDefault() != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                }
            }



            Console.Write("Ögrencinin adı: ");
            string ad = Console.ReadLine();

            Console.Write("Ögrencinin soyadı: ");
            string soyad = Console.ReadLine();

            DateTime tarih = new DateTime();
            int gun = tarih.Day;
            int ay = tarih.Month;
            int yil = tarih.Year;
            Console.Write("Ögrencinin dogum tarihi: ");
            string dogumTarihiInput = Console.ReadLine();

            //while (true)
            //{
            //    if (DateTime.TryParse(dogumTarihiInput, out tarih))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
            //        Console.Write("Ögrencinin dogum tarihi: ");
            //        dogumTarihiInput = Console.ReadLine();
            //    }
            //}

            Console.Write("Ögrencinin cinsiyeti (K/E): ");
            string cinsiyet = Console.ReadLine();
            while (true)
            {

                if (cinsiyet == "K" || cinsiyet == "E")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write("Ögrencinin cinsiyeti (K/E): ");
                    cinsiyet = Console.ReadLine().ToUpper();
                }

            }
            Console.Write("Ögrencinin subesi (A/B/C): ");
            string sube = Console.ReadLine().ToUpper();

            while (true)
            {

                if (sube == "A" || sube == "B" || sube == "C")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                    Console.Write("Ögrencinin subesi (A/B/C): ");
                    sube = Console.ReadLine().ToUpper();
                }
            }


            okul.OgrenciGuncelleme(no, ad, soyad, SUBE.Empty, tarih, CINSIYET.Empty);

            if (cinsiyet == "K")
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Cinsiyet = CINSIYET.Kiz;
            }
            else
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Cinsiyet = CINSIYET.Erkek;
            }

            if (sube == "A")
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Sube = SUBE.A;
            }
            else if (sube == "B")
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Sube = SUBE.B;
            }
            else
            {
                okul.ogrenciler.Where(a => a.Ad == ad).FirstOrDefault().Sube = SUBE.C;
            }


            Console.WriteLine();
            Console.WriteLine("Ogrenci güncellendi.");
            SecimiYonlendir();



        }
        public void OgrenciSil()
        {
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
            while (true)
            {
                if (okul.ogrenciler.Where(a => a.No == no).FirstOrDefault() != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = int.Parse(Console.ReadLine());
                }

            }

            Console.WriteLine("\r\nÖgrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
            Console.WriteLine("Ögrencinin Subesi: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube);
            Console.WriteLine();
            Console.Write("Ögrenciyi silmek istediginize emin misiniz (E/H): ");
            string secim = Console.ReadLine().ToUpper();

            switch (secim)
            {
                case "E":
                    okul.ogrenciler.Remove(okul.ogrenciler.Where(a => a.No == no).FirstOrDefault());
                    Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");

                    break;


                default:

                    break;

            }
            SecimiYonlendir();
        }
        public void OgrencininAdresiniGir()
        {
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
            while (true)
            {
                if (okul.ogrenciler.Where(a => a.No == no).FirstOrDefault() != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                }

            }

            Console.WriteLine("\r\nÖgrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
            Console.WriteLine("Ögrencinin Subesi: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube);
            Console.WriteLine();

            Console.Write("Il: ");
            string il = Console.ReadLine();

            Console.Write("Ilce: ");
            string ilce = Console.ReadLine();

            Console.Write("Mahalle: ");
            string mahalle = Console.ReadLine();

            okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Adres.Il = il;
            okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Adres.Ilce = ilce;
            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
            SecimiYonlendir();
        }
        public void OgrencininOkuduguKitabiGir()
        {
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
            while (true)
            {
                if (okul.ogrenciler.Where(a => a.No == no).FirstOrDefault() != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                }

            }
            Console.WriteLine();
            Console.WriteLine("Ögrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
            Console.WriteLine("Ögrencinin Subesi: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube);
            Console.WriteLine();
            Console.Write("Eklenecek Kitabin Adı: ");
            string kitapAdi = Console.ReadLine();

            okul.KitapEkleme(no, kitapAdi);

            Console.WriteLine("Bilgiler sisteme girilmistir.");
            SecimiYonlendir();
        }
        public void OgrencininNotunuEkle()
        {
            Console.WriteLine("20-Not Gir ----------------------------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
            while (true)
            {
                if (okul.ogrenciler.Where(a => a.No == no).FirstOrDefault() != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    Console.Write("Ögrencinin numarasi: ");
                    no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                }

            }
            Console.WriteLine("\r\nÖgrencinin Adı Soyadı: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Ad + " " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Soyad);
            Console.WriteLine("Ögrencinin Subesi: " + okul.ogrenciler.Where(a => a.No == no).FirstOrDefault().Sube);
            Console.WriteLine();
            Console.Write("Not eklemek istediğiniz dersi giriniz: ");
            string dersAdi = Console.ReadLine();
            Console.Write("Eklemek istediginiz not adedi: ");
            int notAdedi = int.Parse(Console.ReadLine());


            for (int i = 1; i <= notAdedi; i++)
            {                
                Console.Write(i + ". Notu girin: ");
                int not = AracGerecler.NotAl(i + ". Notu girin: ", i);
               
                okul.NotEkleme(no, dersAdi, not);
            }    


            
            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
            SecimiYonlendir();

        }

    


                        

                
            
                            
                            
       
        


    
   
    }
}


        





       

       

















    
