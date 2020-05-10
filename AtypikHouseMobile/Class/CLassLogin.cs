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
    class CLassLogin
    {

        private string id;

        private string motdepasse;

        private string token;
        public string Id { get => id; set => id = value; }
        public string Motdepasse { get => motdepasse; set => motdepasse = value; }
        public string Token { get => token; set => token = value; }

        public CLassLogin() { }

        public CLassLogin(string i,string mdp,string t)
        {
            this.id = i;
            this.motdepasse = mdp;
            this.token = t;

        }




    }


}