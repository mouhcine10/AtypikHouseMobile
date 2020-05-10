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
    class VoshebegementScreenHome:BaseAdapter<EtiquetteVoshebergement>
    {



        List<EtiquetteVoshebergement> items;
        Activity context;
        public VoshebegementScreenHome(Activity context, List<EtiquetteVoshebergement> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override EtiquetteVoshebergement this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.EtiquetteVoshebergement, null);

            view.FindViewById<ImageView>(Resource.Id.imageViewVoslogement).SetImageResource(item.Image);
            view.FindViewById<TextView>(Resource.Id.textViewtitreVosLogement).Text = item.Titre;
            view.FindViewById<TextView>(Resource.Id.textViewdateajout).Text = item.DateAjout.ToString();



            return view;
        }
    }


}
