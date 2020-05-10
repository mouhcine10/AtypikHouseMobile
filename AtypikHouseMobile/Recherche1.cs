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
using AtypikHouseMobile.Class;
using Newtonsoft.Json;
using RestSharp;

namespace AtypikHouseMobile
{
    [Activity(Label = "Recherche1")]
    public class Recherche1 : Activity
    {

        EditText datearriver, datedepart;
        static string url = "http://10.0.2.2:8000/api/types-logements";
        static string urllogment = "http://10.0.2.2:8000/api/search";
        static string urlville = "http://10.0.2.2:8000/api/velog";
        static int idville = 0;

        static int item = 0;
        // static List<Typelog> list =new List<Typelog>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            var c = "";
            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            string token = sharedPreferences.GetString("refreshtoken", "0");

            var refrechtoken = JsonConvert.DeserializeObject<Dictionary<string, string>>(token);





            var clientR = new RestClient("http://10.0.2.2:8000/api/token/refresh");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
         
            request.AddParameter("undefined", "{\n\"refresh_token\":\"" + refrechtoken["refresh_token"] + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = clientR.Execute(request);

            var contentrefreshtoken = response.Content;

            var newtoken = JsonConvert.DeserializeObject<Dictionary<string, string>>(contentrefreshtoken);




            // liste des types

            //recp les donneés de l'api les types de logement  

            var client = new RestClient(url);
            var requesttypelogement = new RestRequest(Method.POST);

            requesttypelogement.AddHeader("Authorization", "Bearer " + newtoken["token"]);
            requesttypelogement.AddHeader("Content-Type", "application/json");
            IRestResponse responsetypelogement = client.Execute(requesttypelogement);

            var contenttypelogement = responsetypelogement.Content;

            var list = JsonConvert.DeserializeObject<List<Typelogment>>(contenttypelogement);

            List<string> type = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                type.Add(list[i].type);
            }

            void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
            {
                Spinner spinner = (Spinner)sender;

                switch (type[e.Position])
                {
                    case "Yourte":

                        item = 1;

                        break;
                    case "Cabane":

                        item = 2;
                        break;

                    case "Roulotte":

                        item = 3;
                        break;

                    case "Tipis":
                        item = 4;
                        break;
                    case "Gîte":

                        item = 5;
                        break;

                    case "Péniche":
                        item = 6;
                        break;

                    case "Bulle":
                        item = 7;
                        break;

                    case "Nid":
                        item = 8;
                        break;
                }

            }



            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Recherche1);


            //recuperer les controles de Layout
            //spinnerTYpelogement
            Spinner spinnerTYpelogement = FindViewById<Spinner>(Resource.Id.spinnerTYpelogemente);

            spinnerTYpelogement.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, type);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerTYpelogement.Adapter = adapter;


            var textrecherche = FindViewById<TextView>(Resource.Id.textViewville);




            //recuper les ville 

            //datearriver
            datearriver = FindViewById<EditText>(Resource.Id.textInputEditTextDatearrivée);
            datearriver.Click += DateSelect_OnClick;
            //datedepart
            datedepart = FindViewById<EditText>(Resource.Id.textInputEditTextdatedepart);
            datedepart.Click += DateSelectdepart_OnClick;

            // NumberPicker
            NumberPicker numbredepersonne = FindViewById<NumberPicker>(Resource.Id.numberPickerNbrpers);
            numbredepersonne.MinValue = 1;
            numbredepersonne.MaxValue = 100;

            //recherche logement     

            Button btnrecherche = FindViewById<Button>(Resource.Id.buttonRechderche);



            try
            {
                btnrecherche.Click += delegate
                {
                    ////recuperer les ville via l'api 
                    
                    // récupérer le nouveau token 
                    var clientRVille = new RestClient("http://10.0.2.2:8000/api/token/refresh");

                    var requestRville = new RestRequest(Method.POST);

                    request.AddHeader("Content-Type", "application/json");
                    // parametres  
                    request.AddParameter("undefined", "{\n\"refresh_token\":\"" + newtoken["refresh_token"] + "\"\n}", ParameterType.RequestBody);
                    IRestResponse responseRville = clientR.Execute(request);

                    var contentrefreshtokenRville = response.Content;

                    var newtokenville = JsonConvert.DeserializeObject<Dictionary<string, string>>(contentrefreshtoken);



                    // récupérer la ville 
                    var clientVille = new RestClient(urlville);
                    var requestville = new RestRequest(Method.POST);

                    requestville.AddHeader("Content-Type", "application/json");
                    requestville.AddHeader("Authorization", "Bearer " + newtokenville["token"]);
                    requestville.AddParameter("undefined", "term=" + textrecherche.Text, ParameterType.RequestBody);

                    IRestResponse responseville = clientVille.Execute(requestville);

                    var contentville = responseville.Content;

                    var ville = JsonConvert.DeserializeObject<List<Ville>>(contentville);

                    // récupérer les ID de la ville 
                    for (int i = 0; i < ville.Count; i++)
                    {
                        idville = ville[i].Id;
                    }


                    //// recuperer les logements via l'api  

                    // récupérer le nouveau token 

                    var clientRLogement = new RestClient("http://10.0.2.2:8000/api/token/refresh");
                    var requestRLogement = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    // parametres  
                    request.AddParameter("undefined", "{\n\"refresh_token\":\"" + newtokenville["refresh_token"] + "\"\n}", ParameterType.RequestBody);
                    IRestResponse responseRLogement = clientR.Execute(request);
                    // réponse
                    var contentrefreshtokenRLogement = response.Content;

                    var newtokenLogement = JsonConvert.DeserializeObject<Dictionary<string, string>>(contentrefreshtoken);

                    //  récupérer les logements
                    var clientLogement = new RestClient(urllogment);
                    var requestLogement = new RestRequest(Method.POST);
                    //header 
                    requestLogement.AddHeader("Content-Type", "application/json");
                    // autorisation pour accdes a la méthode de l'api 
                    requestLogement.AddHeader("Authorization", "Bearer " + newtokenLogement["token"]);
                    //
                    requestLogement.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    // parametres de la methode 
                    requestLogement.AddParameter("undefined", "ville=" + idville.ToString() + "&nb=" + numbredepersonne.Value + "&type=" + item + "", ParameterType.RequestBody);
                    // resultat en JSON
                    IRestResponse responseLogment = clientLogement.Execute(requestLogement);

                    var contentLogement = responseLogment.Content;

                    //deserialiser le JSON

                    var recherchedata = JsonConvert.DeserializeObject<List<Recherchedata>>(contentLogement);


                    for (int i = 0; i < recherchedata.Count; i++)
                    {
                        if (recherchedata.Count <= 0)
                        {

                            Toast.MakeText(this, "vide", ToastLength.Long).Show();

                        }

                        c = recherchedata[i].prix;

                        break;
                    }



                    Intent intentdetail = new Intent(this, typeof(ListDesLogements));


                    //  clé pour enregistre les donnés sur l'application 


                    ISharedPreferencesEditor editor = sharedPreferences.Edit();

                    // passer les donnes entre les pages 
                    editor.PutString("list", contentLogement);

                    editor.PutString("datearrivee", datearriver.Text);
                    editor.PutString("datedepart", datedepart.Text);
                    editor.Apply();

                    Toast.MakeText(this, recherchedata[0].prix.ToString(), ToastLength.Long).Show();


                    StartActivity(intentdetail);



                };

            }// en cas d'exception 
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();


            }



        }

        //methode pour appeler le fragement DatePicker 
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DateTimeFragement frag = DateTimeFragement.NewInstance(delegate (DateTime time)
            {
                datearriver.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DateTimeFragement.TAG);
        }
        void DateSelectdepart_OnClick(object sender, EventArgs eventArgs)
        {
            DateTimeFragement frag11 = DateTimeFragement.NewInstance(delegate (DateTime time)
            {
                datedepart.Text = time.ToLongDateString();
            });
            frag11.Show(FragmentManager, DateTimeFragement.TAG);
        }


    }
}
