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
    class EtiquetteVoshebergement
    {
        private int idVoshebergement;

        private int image;

        private string titre;

        private string dateAjout;

        public EtiquetteVoshebergement()
        {



        }
        public EtiquetteVoshebergement(int id, int im,string t , string DA)
        {
            this.idVoshebergement = id;
            this.image = im;
            this.titre = t;
            this.DateAjout = DA;

        }
        public int IdVoshebergement { get => idVoshebergement; set => idVoshebergement = value; }
        public int Image { get => image; set => image = value; }
        public string Titre { get => titre; set => titre = value; }
        public string DateAjout { get => dateAjout; set => dateAjout = value; }
    }
}