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

namespace TideWaveAppListView
{
    class MyListViewAdapter : BaseAdapter<TideInfo> //, ISectionIndexer
    {
        private List<TideInfo> tideItems; 
        private Activity tContext;

        public MyListViewAdapter(Activity context, List<TideInfo> items)
        {
            tContext = context;
            tideItems = items;
        }


        public override int Count
        { get { return tideItems.Count; } }// how many items in list

        public override long GetItemId(int position)
        {
            return position;
        }

        public override TideInfo this[int position] //indexer
        {
            get { return tideItems[position]; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null) //recycle rows
            {
                row = LayoutInflater.From(tContext).Inflate(Resource.Layout.ListViewRow, null, false);
            }

            TextView AdapterTextView = row.FindViewById<TextView>(Resource.Id.dateDayTextView);

            AdapterTextView.Text = tideItems[position].GetdateDay();

            TextView AdapterTextView2 = row.FindViewById<TextView>(Resource.Id.HighLowTimeTextView);
            AdapterTextView2.Text = tideItems[position].GetHLtime();

            return row;
        }

        //add code for isection
    }
}