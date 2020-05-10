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
using System.Data.SqlClient;
using Android.Preferences;

namespace AtypikHouseMobile
{
    [Activity(Label = "Profil", Theme = "@style/AppTheme")]
    public class Profil : Activity
    {


        Android.Widget.Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.Profil);
            Android.Widget.Toolbar editToolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbarMenuRE);
            // recuperer la barre de menu
            editToolbar.InflateMenu(Resource.Menu.BarMenu);
            //barre de menu 
            editToolbar.MenuItemClick += (sender, e) =>
            {
                switch (e.Item.Order)
                {
                    case 1:
                        Intent intentprofil = new Intent(this, typeof(Profil));

                        StartActivity(intentprofil);


                        break;
                    case 2:

                        Intent intentMessage = new Intent(this, typeof(Messages));

                        StartActivity(intentMessage);

                        break;
                    case 3:
                        Intent intentMesreservation = new Intent(this, typeof(VosHebergement));

                        StartActivity(intentMesreservation);

                        break;
                    case 4:
                        Intent intentrecherche = new Intent(this, typeof(VosHebergement));

                        StartActivity(intentrecherche);

                        break;

                }
            };

            try
            {
                var nomprenopm = FindViewById<TextView>(Resource.Id.textViewNomPrenom);
                LinearLayout l1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
                LinearLayout Modifierprofil = FindViewById<LinearLayout>(Resource.Id.linearLayoutModifierProfil);
                LinearLayout GereHebergement = FindViewById<LinearLayout>(Resource.Id.linearLayoutGerevoshebergement);
                LinearLayout mesreservation = FindViewById<LinearLayout>(Resource.Id.linearLayoutMesReservation);
                LinearLayout deconnexion = FindViewById<LinearLayout>(Resource.Id.linearLayoutdeconnexion);

                // passer les donnés entre les pages

                ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);

                string nom = sharedPreferences.GetString("nom", "");
                string prenom = sharedPreferences.GetString("prenom", "");

                nomprenopm.Text = nom + " " + prenom;



                Modifierprofil.Click += delegate
                {

                    Intent intentmedifierprofil = new Intent(this, typeof(ModifierProfil));

                    StartActivity(intentmedifierprofil);
                };

                GereHebergement.Click += delegate
                {
                    Intent intentGerehebergement = new Intent(this, typeof(VosHebergement));
                    StartActivity(intentGerehebergement);
                };

                mesreservation.Click += delegate
                {
                    Intent intentmesreservation = new Intent(this, typeof(Historique));
                    StartActivity(intentmesreservation);
                };

                //deconnexion
                deconnexion.Click += delegate
                {
                    Intent intentdeconnextion = new Intent(this, typeof(Login));
                    StartActivity(intentdeconnextion);
                };


            }
            catch (Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

            }


        }
    }
}