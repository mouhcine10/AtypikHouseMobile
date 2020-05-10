using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AtypikHouseMobile.Class
{
    class EtiquetteHistorique
    {
        private int idHistorique;

        private string titre;

        private  string dateArrivée;

        private string dartedepart;

        private int image;

        public EtiquetteHistorique() { }

        public EtiquetteHistorique(int idh, string t,string da,string dd,int i)
        {
            
            this.idHistorique = idh;
            this.titre = t;
            this.dateArrivée = da;
            this.dartedepart = dd;
            this.image = i;
}


        public int IdHistorique { get => idHistorique; set => idHistorique = value; }
        public string Titre { get => titre; set => titre = value; }
        public string DateArrivée { get => dateArrivée; set => dateArrivée = value; }
        public string Dartedepart { get => dartedepart; set => dartedepart = value; }
        public int Image { get => image; set => image = value; }
    }
}