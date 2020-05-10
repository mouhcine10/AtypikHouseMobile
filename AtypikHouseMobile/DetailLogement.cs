using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AtypikHouseMobile.Class;

namespace AtypikHouseMobile
{
    [Activity(Label = "DetailLogement", Theme = "@style/AppTheme")]
    public class DetailLogement : Activity, IOnMapReadyCallback
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetaileLogement);

            ////  Gallery gallery = (Gallery)FindViewById<Gallery>(Resource.Id.detaillelogementphoto);
            //  gallery.Adapter = new ImageAdapter(this);
            ////  gallery.ItemClick += delegate (object sender, Android.Widget.AdapterView.ItemClickEventArgs args)
            //  {
            //      Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();
            //  };



            Android.Widget.Toolbar editToolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbarMenuRE);
            var titre = FindViewById<TextView>(Resource.Id.textViewtitre);
            var description = FindViewById<TextView>(Resource.Id.textViewdescription);
            var textcham = FindViewById<TextView>(Resource.Id.textViewchambre);
            var lircommentaire = FindViewById<TextView>(Resource.Id.textViewlirplus);
            var voyageurs = FindViewById<TextView>(Resource.Id.textViewVoyageur);
            var btnreserver = FindViewById<Button>(Resource.Id.buttonreserver);


            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            // passer les donnés entre les pages

            titre.Text = Intent.GetStringExtra("Nom");
            description.Text = Intent.GetStringExtra("description");
            voyageurs.Text = Intent.GetStringExtra("nbpersonne")+"  Voyageurs";
            textcham.Text = Intent.GetStringExtra("nbcouchage") + " lits ";

            btnreserver.Click += delegate {


                Intent intentreservee = new Intent(this, typeof(Reserver));

                StartActivity(intentreservee);

            };
            lircommentaire.Click += delegate
            {
                Intent intentcom = new Intent(this, typeof(Commentaire));

                StartActivity(intentcom);



            };


         
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

           
        }

        public void OnMapReady(GoogleMap map)
        {
            map.MapType = GoogleMap.MapTypeHybrid;
        }

      
    }
}