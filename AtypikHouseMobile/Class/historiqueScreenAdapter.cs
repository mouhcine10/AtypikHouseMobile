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
    class historiqueScreenAdapter:BaseAdapter<EtiquetteHistorique>
    {
        List<EtiquetteHistorique> items;
        Activity context;
        public historiqueScreenAdapter(Activity context, List<EtiquetteHistorique> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override EtiquetteHistorique this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.EtiquetteHistorique, null);

            view.FindViewById<ImageView>(Resource.Id.imageViewHistorique).SetImageResource(item.Image);
            view.FindViewById<TextView>(Resource.Id.textViewTitreHisto).Text=item.Titre.ToString();
            view.FindViewById<TextView>(Resource.Id.textViewdatearriveeHisto).Text = item.DateArrivée.ToString();
            view.FindViewById<TextView>(Resource.Id.textViewdatedepartHisto).Text = item.Dartedepart.ToString();



            return view;
        }
    }
}