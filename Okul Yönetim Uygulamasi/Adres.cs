using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_Yönetim_Uygulamasi
{
    internal class Adres
    {

        public string Il;
        public string Ilce;
        public string Mahalle;

        public Adres(string il, string semt) 
        {
            this.Il = il;
            this.Ilce = semt;
        }


    }
}
