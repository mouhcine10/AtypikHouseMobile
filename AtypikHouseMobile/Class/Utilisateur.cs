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
    class Utilisateur
    {
            public int id { get; set; }
            public string nom { get; set; }
            public string prenom { get; set; }
            public string adresse { get; set; }
            public string email { get; set; }
            public string motdepasse { get; set; }
    }
}