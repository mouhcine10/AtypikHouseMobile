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
    class EtiquetteLogement
    {
        private int id;

        private int photo;

        private decimal prix;

        private string titre;

        private int note;

        private int nbcommntaire;

        public int Photo { get => photo; set => photo = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public string Titre { get => titre; set => titre = value; }
        public int Note { get => note; set => note = value; }
        public int NbCommntaire { get => nbcommntaire; set => nbcommntaire = value; }
        public int Id { get => id; set => id = value; }

        public EtiquetteLogement() { }
        public EtiquetteLogement(int id ,int p, decimal prix, int nbC, string t, int n)
        {
            this.id = id;
            this.Photo = p;
            this.Prix = prix;
            this.Titre = t;
            this.nbcommntaire = nbC;
            this.Note = n;

        }

    }
}