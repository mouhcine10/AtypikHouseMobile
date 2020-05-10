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
using AtypikHouseMobile.Data;

namespace AtypikHouseMobile.Class
{
    class AjouterEtiquette
    {
        private CLassLogin c;
        public List<CLassLogin> cLassLogins = new List<CLassLogin>();

        public List<EtiquetteLogement> etiquttlogement = new List<EtiquetteLogement>();
        public List<EtiquetteHistorique> etiquetteHistoriques = new List<EtiquetteHistorique>();
        public List<EtiquetteVoshebergement> EtiquetteVoshebergements = new List<EtiquetteVoshebergement>();
      

       

        public List<EtiquetteVoshebergement> etiquetteVosheb()
        {

            EtiquetteVoshebergements.Add(new EtiquetteVoshebergement(1, Resource.Drawable.cabanezenforet,"Cabane", "20/10/2017"));
            EtiquetteVoshebergements.Add(new EtiquetteVoshebergement(2, Resource.Drawable.DSCF2464, "Cabane", "20/10/2017"));

            return EtiquetteVoshebergements;
        }

       


            

        public List<CLassLogin> cLassLog()
        {

           // cLassLogins.Add(new CLassLogin("momo", "123"));

            return cLassLogins;
        }

        


        public List<EtiquetteHistorique> etiquetteHisto()
        {

           
            etiquetteHistoriques.Add(new EtiquetteHistorique(1, "cabane", "10/08/2018", "15/10/2018", Resource.Drawable.icons_adresse));
            etiquetteHistoriques.Add(new EtiquetteHistorique(2, "yourte", "10/08/2019", "15/10/2019", Resource.Drawable.icons_adresse));

            return etiquetteHistoriques;

        }
        public List<EtiquetteLogement> Etiquttelog()
        {

            etiquttlogement.Add(new EtiquetteLogement(1,10, 100, 10, "cabane", 5));
            etiquttlogement.Add(new EtiquetteLogement(2,10, 100, 10, "Bulle", 5));


            return etiquttlogement;

        }
    }
}