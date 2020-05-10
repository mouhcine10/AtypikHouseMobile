using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using AtypikHouseMobile.Class;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json.Linq;
using JWT.Builder;
using static Java.Util.Base64;

namespace AtypikHouseMobile.Class
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        static readonly string url = "http://10.0.2.2:8000/api/login_check";
        string txtJwtOut;
        string c;
        //  static HttpClient client = new HttpClient();



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //Appelle les composent de Layout Login 
            SetContentView(Resource.Layout.Login);
            var ID = FindViewById<EditText>(Resource.Id.textInputEditTextID);
            var passe = FindViewById<EditText>(Resource.Id.editTextpasse);
            var btn = FindViewById<Button>(Resource.Id.buttonConnecter);
            var mdpoblier = FindViewById<TextView>(Resource.Id.textViewmotdepasse);


            //enregistrement des donners via la clé SharedPrefernces
            ISharedPreferences sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = sharedPreferences.Edit();


            btn.Click += delegate
           {
               if(ID.Text=="" && passe.Text == "")
               {
                   AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);

                   alertDialog.SetTitle("Erreur");
                   alertDialog.SetMessage("");
                   alertDialog.SetNeutralButton("OK", delegate { alertDialog.Dispose(); });
                   alertDialog.Show();
               }
               

               //  authentification JWT avec l'api 
               var client = new RestClient(url);

               var request = new RestRequest(Method.POST);

               request.AddHeader("Content-Type", "application/json");

               Dictionary<string, string> loginuser = new Dictionary<string, string>
               {
                   { "username", ID.Text },
                   { "password", passe.Text }
               };

               string username = ID.Text;
               // serialiser les données en json 
               var login = JsonConvert.SerializeObject(loginuser);
               // envoyer les parametres 
               request.AddParameter("undefined", login, ParameterType.RequestBody);
               // envoyer la 
               IRestResponse response = client.Execute(request);
               // la réponse 
               var content = response.Content;

               //traduire le contenu de objet json a l'objet c# 
               var token = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

               var clientUser = new RestClient("http://127.0.0.1:8000/api/auth");
               var requestUser = new RestRequest(Method.POST);
               requestUser.AddHeader("Authorization", "Bearer" + token["token"]);
               requestUser.AddHeader("Content-Type", "application/x-www-form-urlencoded");
               requestUser.AddParameter("undefined", "username="+username, ParameterType.RequestBody);

               IRestResponse responseUser = client.Execute(requestUser);

               var cententuser = responseUser.Content;

               Toast.MakeText(this, cententuser, ToastLength.Long).Show();
               if (token == null)
               {

                   Toast.MakeText(this, "verifier votre Nom d'utilisateur et mot de passe" , ToastLength.Long).Show();

               }
               else
               {
                   c = token["token"];
                   //decode le Token
                   var jwtHandler = new JwtSecurityTokenHandler();
                   // affectation de token dans un variable 
                   var jwtInput = c;
                   var readableToken = jwtHandler.CanReadToken(jwtInput);
                   //verification format de token 
                   if (readableToken != true)
                   {
                       Toast.MakeText(this, "le format de JWT invalide.", ToastLength.Long).Show();
                   }

                   if (readableToken == true)
                   {
                       //lire le token
                       var tokenjwt = jwtHandler.ReadJwtToken(jwtInput);

                       editor.PutString("prenom", tokenjwt.Payload["prenom"].ToString());
                       editor.PutString("listutilisateur", cententuser);
                       editor.PutString("nom", tokenjwt.Payload["name"].ToString());

                       // recuperer les donnéed d'utilisateur 
                       
                       // recuperer le refreshtoken  
                       editor.PutString("refreshtoken", content);
                       editor.Apply();
                        Intent intentrecherche = new Intent(this, typeof(Recherche1));
                      //passer a la page de la recherche 
                        StartActivity(intentrecherche);


                   }

               }


           };


        }


    }
}















