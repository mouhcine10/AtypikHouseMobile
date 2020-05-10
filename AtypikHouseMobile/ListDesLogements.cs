using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace AtypikHouseMobile.Class
{
    [Activity(Label = "ListDesLogements")]
    public class ListDesLogements : Activity
    {
        List<Recherchedata> recherchedatas;
        EtiquetteLogement etiquette;
        AjouterEtiquette ajouter = new AjouterEtiquette();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //recuper la list des logements en format JSON
            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);

            var s = sharedPreferences.GetString("list", null);

            // traduire la list en objet C#
            recherchedatas = JsonConvert.DeserializeObject<List<Recherchedata>>(s);


            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Listdeslogement);

            //la deuxieme barre
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

            //difiner une liste

            ListView listView = FindViewById<ListView>(Resource.Id.listViewdeslogement);

            listView.Adapter = new HomeScreenAdapter(this, recherchedatas);

            // lorsque en click sur un item de la liste
            listView.ItemClick += OnListItemClick;

            // le contenu de la liste 
            ISharedPreferencesEditor editor = sharedPreferences.Edit();
            for (int i = 0; i < recherchedatas.Count; i++)
            {

                editor.PutString("id", recherchedatas[i].id);
                editor.PutString("idtype", recherchedatas[i].id_type_id);
                editor.PutString("idproprio", recherchedatas[i].id_proprietaire_id);
                editor.PutString("villeid", recherchedatas[i].ville_id);
                editor.PutString("Nom", recherchedatas[i].nom);
                editor.PutString("description", recherchedatas[i].description);
                editor.PutString("Prix", recherchedatas[i].prix);
                editor.PutString("adresse", recherchedatas[i].code_postal);
                editor.PutString("nbpersonne", recherchedatas[i].nb_personne);
                editor.PutString("Etat", recherchedatas[i].etat);
                editor.PutString("nbcouchage", recherchedatas[i].nb_couchage);
                editor.PutString("commidite", recherchedatas[i].commodites);
                editor.PutString("reglement", recherchedatas[i].reglement);
                editor.Apply();


            }

        }

        // la methode lorsqu'on click sur les items de la liste 
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = (ListView)sender;
            var t = recherchedatas[e.Position];

            Toast.MakeText(this, t.adresse, ToastLength.Long).Show();


            Intent intent = new Intent(this, typeof(DetailLogement));

            intent.PutExtra("ID", t.id);
            intent.PutExtra("idtype", t.id_type_id);
            intent.PutExtra("id_type_id", t.id_type_id);
            intent.PutExtra("idproprio", t.id_proprietaire_id);
            intent.PutExtra("villeid", t.id_type_id);
            intent.PutExtra("Nom", t.nom);
            intent.PutExtra("description", t.description);
            intent.PutExtra("Prix", t.prix);
            intent.PutExtra("adresse", t.adresse);
            intent.PutExtra("nbpersonne", t.nb_personne);
            intent.PutExtra("Etat", t.etat);
            intent.PutExtra("nbcouchage", t.nb_couchage);
            intent.PutExtra("commidite", t.commodites);
            intent.PutExtra("reglement", t.reglement);
            StartActivity(intent);
        }



    }
}