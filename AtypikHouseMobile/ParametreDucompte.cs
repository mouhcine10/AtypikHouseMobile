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
    [Activity(Label = "ParametreDucompte", Theme = "@style/AppTheme")]
    public class ParametreDucompte : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PrametreDucompte);

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
                    
                }





            };
        }
    }
}