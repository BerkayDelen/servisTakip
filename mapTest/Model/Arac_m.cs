using System;
namespace mapTest.Model
{
    public class Arac_m
    {
		public int Id
        {
            get;
            set;
        }

        public string Ad
        {
            get;
            set;
        }
        public string Plaka
        {
            get;
            set;
        }

        public Arac_m(int Id, string Ad, string Plaka)
        {
            this.Id = Id;
            this.Ad = Ad;
            this.Plaka = Plaka;
        }
    }
}
