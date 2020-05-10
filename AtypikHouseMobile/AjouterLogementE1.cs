using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AtypikHouseMobile.Class;
using Java.Sql;

namespace AtypikHouseMobile.Data
{
    [Activity(Label = "AjouterLogementE1")]
    public class AjouterLogementE1 : Activity
    {
        static readonly int PickImageId = 1000;
        protected override void OnCreate(Bundle savedInstanceState)
        { 
        List<string> bien = new List<string>();
            bien.Add("cabane");
            bien.Add("bulle");
            bien.Add("Yourte");
            bien.Add("Roulotte");
            bien.Add("Tipis");
            bien.Add("Gîte");
            bien.Add("Péniche");
            bien.Add("Nid");
            



            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AjouterLogementE1);

            var Typelogement = FindViewById<Spinner>(Resource.Id.spinnerTypeLogement);
            var add = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,bien);

            Typelogement.Adapter = add;
            var Nombien = FindViewById<EditText>(Resource.Id.textInputEditTextNomdelogement);
            var derscription = FindViewById<EditText>(Resource.Id.textInputEditTextDescription);
            var textadresseprincipal = FindViewById<EditText>(Resource.Id.textInputEditTextAdresse);
            var textville = FindViewById<EditText>(Resource.Id.textInputEditTextville);
            var prix = FindViewById<EditText>(Resource.Id.textInputEditTextPrix);
            var nbpersone = FindViewById<EditText>(Resource.Id.textInputEditTextnbrpesonne);
            var nbrcouchage = FindViewById<EditText>(Resource.Id.textInputEditTextNombredecouchages);

            var Commodités = FindViewById<EditText>(Resource.Id.textInputEditTextCommodité);

            var Réglement = FindViewById<EditText>(Resource.Id.textInputEditTextRéglementdevotrelogement);

            var btnajoutephoto = FindViewById<Button>(Resource.Id.Ajouterbutton);

            var imagebien = FindViewById<ImageView>(Resource.Id.imageViewAjouterbien);
            var btnajouterbien = FindViewById<Button>(Resource.Id.buttonAjouterbien);

           btnajoutephoto.Click += delegate {
               
        Intent = new Intent();
                Intent.SetType("image/*");
                Intent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);


            };

            btnajouterbien.Click += delegate {

              

                AjouterEtiquette ajouter = new AjouterEtiquette();

                ajouter.etiquttlogement.Add(new EtiquetteLogement());

                Intent intentE2 = new Intent(this, typeof(VosHebergement));

                StartActivity(intentE2);

            };

        }
    }
}