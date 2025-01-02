using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Uygulamasi
{
    internal class Okul
    {
        public List<Ogrenci> ogrenciler = new List<Ogrenci>();
         
        public void OgrenciEkleme (string ad, string soyad, SUBE sube, DateTime tarih, int no,CINSIYET cinsiyet)
        {
            this.ogrenciler.Add(new Ogrenci(no, ad, soyad, tarih, cinsiyet, sube));
        }
        
        public void OgrenciSilme(int no)
        {
            this.ogrenciler.RemoveAt(no);
        }

        public void OgrenciGuncelleme(int no, string ad, string soyad, SUBE sube, DateTime tarih, CINSIYET cinsiyet)
        {
            Ogrenci ogr = this.ogrenciler.Where(a => a.No == no).FirstOrDefault();

            ogr.Ad = ad;
            ogr.Soyad = soyad;
            ogr.Sube = sube;
            ogr.DogumTarihi = tarih;
            ogr.Cinsiyet = cinsiyet; 
            ogr.No = no;

        }

        public void NotEkleme (int no, string ders, float not)
        {
            DersNotu dn = new DersNotu(ders, not);

            Ogrenci o = this.ogrenciler.Where(a => a.No == no ).FirstOrDefault();

            if (o != null)
            {
                o.Notlar.Add(dn);
            }
        }
        public void AdresEkleme(int no,string il, string semt)
        {
            
            Ogrenci o = this.ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Adres = new Adres(il, semt);                
                
            }
           
        }

        public void KitapEkleme (int no, string kitapAdi)
        {            
            Ogrenci o = this.ogrenciler.Where(a => a.No == no).FirstOrDefault();                    

            if (o != null)
            {
                o.Kitaplar.Add(kitapAdi);  
                
            }
        }        


        public Okul()
        {
            SahteVeriGir();
          
        }


        public void SahteVeriGir()
        {

            ogrenciler.Add(new Ogrenci(1, "Elif", "Selçuk", new DateTime(2001, 05, 05), CINSIYET.Kiz, SUBE.A));
            ogrenciler.Add(new Ogrenci(2, "Betül", "Yılmaz", new DateTime(2000, 10, 02), CINSIYET.Kiz, SUBE.B));
            ogrenciler.Add(new Ogrenci(3, "Hakan", "Çelik", new DateTime(2001, 08, 12), CINSIYET.Erkek, SUBE.C));
            ogrenciler.Add(new Ogrenci(4, "Kerem", "Akay", new DateTime(2002, 06, 10), CINSIYET.Erkek, SUBE.A));
            ogrenciler.Add(new Ogrenci(5, "Hatice", "Çınar", new DateTime(2000, 06, 05), CINSIYET.Kiz, SUBE.B));
            ogrenciler.Add(new Ogrenci(6, "Selim", "İleri", new DateTime(2004, 07, 18), CINSIYET.Erkek, SUBE.B));
            ogrenciler.Add(new Ogrenci(7, "Selin", "Kamış", new DateTime(2002, 05, 20), CINSIYET.Kiz, SUBE.C));
            ogrenciler.Add(new Ogrenci(8, "Sinan", "Avcı", new DateTime(2003, 02, 15), CINSIYET.Erkek, SUBE.A));
            ogrenciler.Add(new Ogrenci(9, "Deniz", "Çoban", new DateTime(2000, 02, 02), CINSIYET.Kiz, SUBE.C));
            ogrenciler.Add(new Ogrenci(10, "Selda", "Kavak", new DateTime(1999, 09, 20), CINSIYET.Kiz, SUBE.B));

            AdresEkleme(1, "Ankara", "Çankaya");
            AdresEkleme(2, "Ankara", "Keçiören");
            AdresEkleme(3, "Ankara", "Çankaya");
            AdresEkleme(4, "İzmir", "Karşıyaka");
            AdresEkleme(5, "İzmir", "Gaziemir"); 
            AdresEkleme(6, "İzmir", "Gaziemir");
            AdresEkleme(7, "İzmir", "Bayraklı");
            AdresEkleme(8, "İstanbul", "Arnavutköy");
            AdresEkleme(9, "İstanbul", "Beykoy");
            AdresEkleme(10, "İstanbul", "Çankaya");

            Random rnd = new Random();

            NotEkleme(1, "Türkçe", rnd.Next(1,100));
            NotEkleme(1, "Matematik", rnd.Next(1, 100));
            NotEkleme(1, "Fen", rnd.Next(1, 100));
            NotEkleme(1, "Sosyal", rnd.Next(1, 100));

            NotEkleme(2, "Türkçe", rnd.Next(1, 100));
            NotEkleme(2, "Matematik", rnd.Next(1, 100));
            NotEkleme(2, "Fen", rnd.Next(1, 100));
            NotEkleme(2, "Sosyal", rnd.Next(1, 100));

            NotEkleme(3, "Türkçe", rnd.Next(1, 100));
            NotEkleme(3, "Matematik", rnd.Next(1, 100));
            NotEkleme(3, "Fen", rnd.Next(1, 100));
            NotEkleme(3, "Sosyal", rnd.Next(1, 100));

            NotEkleme(4, "Türkçe", rnd.Next(1, 100));
            NotEkleme(4, "Matematik", rnd.Next(1, 100));
            NotEkleme(4, "Fen", rnd.Next(1, 100));
            NotEkleme(4, "Sosyal", rnd.Next(1, 100));

            NotEkleme(5, "Türkçe", rnd.Next(1, 100));
            NotEkleme(5, "Matematik", rnd.Next(1, 100));
            NotEkleme(5, "Fen", rnd.Next(1, 100));
            NotEkleme(5, "Sosyal", rnd.Next(1, 100));

            NotEkleme(6, "Türkçe", rnd.Next(1, 100));
            NotEkleme(6, "Matematik", rnd.Next(1, 100));
            NotEkleme(6, "Fen", rnd.Next(1, 100));
            NotEkleme(6, "Sosyal", rnd.Next(1, 100));

            NotEkleme(7, "Türkçe", rnd.Next(1, 100));
            NotEkleme(7, "Matematik", rnd.Next(1, 100));
            NotEkleme(7, "Fen", rnd.Next(1, 100));
            NotEkleme(7, "Sosyal", rnd.Next(1, 100));

            NotEkleme(8, "Türkçe", rnd.Next(1, 100));
            NotEkleme(8, "Matematik", rnd.Next(1, 100));
            NotEkleme(8, "Fen", rnd.Next(1, 100));
            NotEkleme(8, "Sosyal", rnd.Next(1, 100));

            NotEkleme(9, "Türkçe", rnd.Next(1, 100));
            NotEkleme(9, "Matematik", rnd.Next(1, 100));
            NotEkleme(9, "Fen", rnd.Next(1, 100));
            NotEkleme(9, "Sosyal", rnd.Next(1, 100));

            NotEkleme(10, "Türkçe", rnd.Next(1, 100));
            NotEkleme(10, "Matematik", rnd.Next(1, 100));
            NotEkleme(10, "Fen", rnd.Next(1, 100));
            NotEkleme(10, "Sosyal", rnd.Next(1, 100));


            List<string> kitaplar = new List<string>() { "George Orwell- 1984", "Kuşların Şarkısı", "Harry Potter ve Felsefe Taşı", "Jane Eyre", "Çavdar Tarlasında Çocuklar", "Hayvan Çiftliği", "Noel Şarkısı", "Frankenstein", "Harry Potter Azkaban Tutsağı", "Ölü Ozanlar Derneği", "Gurur ve Ön Yargı", "Sis ve Gece", "Agatha'nın Anahtarı", " Bir Ses Böler Geceyi", "Büyük Umutlar", "Masal Masal İçinde" };
            Random rnd2 = new Random();
            for (int i = 0; i < kitaplar.Count; i++)
            {
                KitapEkleme(i, kitaplar[rnd2.Next(0,kitaplar.Count)]);
            }
            
            
            







        }



    }
}
