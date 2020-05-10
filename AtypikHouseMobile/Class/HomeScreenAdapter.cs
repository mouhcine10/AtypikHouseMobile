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
    class HomeScreenAdapter : BaseAdapter<Recherchedata>
    {
        List<Recherchedata> items;
        Activity context;
        public HomeScreenAdapter(Activity context, List<Recherchedata> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Recherchedata this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.EtiqutteLogement, null);

            // view.FindViewById<ImageView>(Resource.Id.imageViewLogement);

            view.FindViewById<TextView>(Resource.Id.textViewPrix).Text = item.prix;
            view.FindViewById<TextView>(Resource.Id.textViewtitre).Text = item.nom;
            view.FindViewById<TextView>(Resource.Id.textViewTypeLogement).Text = item.adresse ;
          
            return view;
        }
    }
}