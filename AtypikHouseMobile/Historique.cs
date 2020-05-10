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
    [Activity(Label = "Historique", Theme = "@style/AppTheme")]
    public class Historique : Activity
    {
        Android.Widget.Toolbar toolbar;
        AjouterEtiquette ajouter = new AjouterEtiquette();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Historique);
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

            try
            {

                ListView listViewHistorique = FindViewById<ListView>(Resource.Id.listViewHistorique);

                toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbarMenuRE);
                listViewHistorique.Adapter = new historiqueScreenAdapter(this, ajouter.etiquetteHisto());


                toolbar.InflateMenu(Resource.Menu.BarMenu);
            }catch(Exception ex)
            {

                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();

            }
           

 
        }
    }
}