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
using AtypikHouseMobile.Class;

namespace AtypikHouseMobile
{
    [Activity(Label = "Acceuil")]
    public class Accueil : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Accueil);

            var btninscription = FindViewById<Button>(Resource.Id.buttonINscription);

            var btnlogin = FindViewById<Button>(Resource.Id.buttonloginlog);

            try
            {

                btninscription.Click += delegate
                {

                    var url = Android.Net.Uri.Parse("http://10.0.2.2:8000/register");

                    Intent intentInscription = new Intent(Intent.Action, url);

                    StartActivity(intentInscription);


                };
                btnlogin.Click += delegate
                {

                    Intent intentlogin = new Intent(this, typeof(Login));
                    StartActivity(intentlogin);

                };

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

            }
        }
    }
}