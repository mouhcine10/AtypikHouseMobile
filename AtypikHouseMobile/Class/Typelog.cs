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
    class Typelog
    {
        private string type;

        private string value;

        public string Type { get => type; set => type = value; }
        public string Value { get => value; set => this.value = value; }
    }
}