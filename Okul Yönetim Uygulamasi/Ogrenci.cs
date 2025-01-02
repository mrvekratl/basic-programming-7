using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Uygulamasi
{
    internal class Ogrenci
    {
        public int No;

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public SUBE Sube { get; set; }

        public CINSIYET Cinsiyet { get; set; }

        public Adres Adres { get; set; }

        public float Ortalama
        {
            get
            {
                if(this.Notlar.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return this.Notlar.Average(not => (float)not.Not);
                }
                
            }
        }

        public DateTime DogumTarihi { get; set; }


        public List<string> Kitaplar = new List<string>();

        public List<DersNotu> Notlar = new List<DersNotu>();

        public Ogrenci (int no, string ad, string soyad, DateTime tarih, CINSIYET cinsiyet, SUBE sube)
        {
            this.No = no;
            this.Ad = ad;
            this.Soyad = soyad;
            this.DogumTarihi = tarih;
            this.Cinsiyet = cinsiyet;
            this.Sube = sube;
            

        }
       


       
    }
    public enum CINSIYET
    {
        Empty, Kiz, Erkek
    }

    public enum SUBE
    {
        Empty, A, B, C, 
    }



}
