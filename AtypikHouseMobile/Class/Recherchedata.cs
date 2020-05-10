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
    class Recherchedata
    {
            public string id { get; set; }
            public string id_type_id { get; set; }
            public string id_proprietaire_id { get; set; }
            public string ville_id { get; set; }
            public string nom { get; set; }
            public string description { get; set; }
            public string prix { get; set; }
            public string adresse { get; set; }
            public string code_postal { get; set; }
            public string nb_personne { get; set; }
            public string etat { get; set; }
            public string nb_couchage { get; set; }
            public string commodites { get; set; }
            public string reglement { get; set; }
        
    }
}