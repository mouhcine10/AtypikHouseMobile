using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using AtypikHouseMobile.Data;

namespace AtypikHouseMobile.Class
{
    [Activity(Label = "VosHebergement")]
    public class VosHebergement : Activity
    {
        AjouterEtiquette ajouter = new AjouterEtiquette();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.VosHebergement);
            Android.Widget.Toolbar editToolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbarMenuRE);
            editToolbar.InflateMenu(Resource.Menu.BarMenu);
            editToolbar.MenuItemClick += (sender, e) =>
            {


               
                        Intent intentprofil = new Intent(this, typeof(Profil));

                        StartActivity(intentprofil);
                        Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();


               
                        Intent intentMessage = new Intent(this, typeof(Messages));

                        StartActivity(intentMessage);
                        Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();

                       
                        Intent intentMesreservation = new Intent(this, typeof(VosHebergement));

                        StartActivity(intentMesreservation);
                        Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();

                        Intent intentrecherche = new Intent(this, typeof(VosHebergement));

                        StartActivity(intentrecherche);
                        Toast.MakeText(this, "Bottom toolbar tapped: " + e.Item.TitleFormatted, ToastLength.Short).Show();






            };

            ListView listView = FindViewById<ListView>(Resource.Id.listViewVpsHebergement);

            listView.Adapter = new VoshebegementScreenHome(this, ajouter.etiquetteVosheb());

            var btnajputer = FindViewById<FloatingActionButton>(Resource.Id.floatingActionButtonAjouter);


            listView.ItemClick += ListView_ItemClick;

            btnajputer.Click += delegate {

                Intent intentAjouterLogement = new Intent(this, typeof(AjouterLogementE1));

                StartActivity(intentAjouterLogement);


            };

        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                var listView = (ListView)sender;

                var t = ajouter.EtiquetteVoshebergements[e.Position];

                Intent intentdetaile = new Intent(this, typeof(DetailLogement));

                StartActivity(intentdetaile);

                Toast.MakeText(this, e.Id.ToString(), ToastLength.Long).Show();

            }catch(Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();


            }
        }
    }
}