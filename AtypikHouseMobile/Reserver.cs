using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AtypikHouseMobile.Class;

namespace AtypikHouseMobile
{
    [Activity(Label = "Reserver", Theme = "@style/AppTheme")]
    public class Reserver : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //var toolbar = FindViewById<Toolbar>(Resource.Id.BarAction);
            //SetActionBar(toolbar);
            //ActionBar.Title = "My Toolbar";
            SetContentView(Resource.Layout.Reserver);


            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);

            ISharedPreferencesEditor editor = sharedPreferences.Edit();
            string da = sharedPreferences.GetString("datearrivee", "00");
            string dd = sharedPreferences.GetString("datedepart", "00");


            var btnvalder = FindViewById<Button>(Resource.Id.Valider);
            var datearrive = FindViewById<TextView>(Resource.Id.textViewarrivée);
            var datedepart = FindViewById<TextView>(Resource.Id.textViewdepart);
            var nom = FindViewById<EditText>(Resource.Id.textInputEditTextNom);
            var prnom = FindViewById<EditText>(Resource.Id.textInputEditTextPrenom);
            var email = FindViewById<EditText>(Resource.Id.email);

            datearrive.Text = da;
            datedepart.Text = dd;





            Android.Widget.Toolbar editToolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbarMenuRE);
            editToolbar.InflateMenu(Resource.Menu.BarMenu);
            editToolbar.MenuItemClick += (sender, e) =>
            {

                switch (e.Item.Order)
                {
                    case 0:
                        Intent intentprofil = new Intent(this, typeof(Profil));

                        StartActivity(intentprofil);


                        break;
                    case 1:

                        Intent intentMessage = new Intent(this, typeof(Messages));

                        StartActivity(intentMessage);

                        break;
                    case 2:
                        Intent intentMesreservation = new Intent(this, typeof(VosHebergement));

                        StartActivity(intentMesreservation);

                        break;
                    case 3:
                        Intent intentrecherche = new Intent(this, typeof(VosHebergement));

                        StartActivity(intentrecherche);

                        break;

                }



            };

            var barrating = FindViewById<RatingBar>(Resource.Id.ratingBarAvis);
            var btnvalider = FindViewById<Button>(Resource.Id.Valider);

            barrating.NumStars = 5;
            barrating.ScrollBarSize = 2;

            try
            {

                btnvalider.Click += delegate
                {

                    Toast.MakeText(this, "hello", ToastLength.Long).Show();

                };




            }
            catch (Exception ex)
            {


                Toast.MakeText(this, ex.Message.ToString(), ToastLength.Long).Show();


            }


        }
    }
}