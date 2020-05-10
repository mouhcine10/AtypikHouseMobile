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
    class Inscrire : Connexion
    {
        private Connexion connexion;

        private string civilité;
        private string nom;
        private string prenom;
        private string email;
        private int tel;
        private string passe;
        private string confipasse;
        public Inscrire() { }
        public Inscrire(string c, string n, string p, string e, int t, string pa, string cpa)
        {
            this.Civilité = c;
            this.Nom = n;
            this.prenom = p;
            this.email = e;
            this.tel = t;
            this.passe = p;
            this.confipasse = cpa;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Civilité { get => civilité; set => civilité = value; }

        //public void iscrireUtilisateur(Inscrire c)
        //{
        //    connexion.Cnx.Open();
        //    connexion.Cmd.Connection = connexion.Cnx;
        //    connexion.Cmd.CommandText = "";
        //    connexion.Cmd.ExecuteNonQuery();

        //}


    }
}