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

namespace AndroidListTide
{
    public class TideAdapter : BaseAdapter<TideItems>, ISectionIndexer
    {
        List<TideItems> items;
        Activity tcontext;


        public TideAdapter(Activity c, List<TideItems> t)
            : base()
        {
            items = t;
            tcontext = c;
            BuildSectionIndex();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override TideItems this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            //recycle rows
            if (view == null)
                view = tcontext.LayoutInflater.Inflate(Android.Resource.Layout.TwoLineListItem, null);

            view.FindViewById<TextView> (Android.Resource.Id.DateDayTextView).Text = items [position].(date + day);
            view.FindViewById<TextView> (Android.Resource.Id.HighLowTextView).Text = items [position].(hilo + time);

            return view;
        }

        //Isection Indexer Code

        String[] sections;
        Java.Lang.Object[] sectionObjects;
        Dictionary<string, int> alphaIndex;

        public int GetPositionForSection(int section)
        {
            return alphaIndex[sections[section]];
        }

        public int GetSectionForPosition(int position)
        {
            return 1;
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionObjects;
        }

        private void BuildSectionIndex()
        {
            alphaIndex = new Dictionary<string, int();
            for (var i= 0; i < items.Count; i++)
            {
                var key = items[i].date;
                if(!alphaIndex.ContainsKey(key))
                {
                    alphaIndex.Add(key,i);
                }
            }
            ////s////////

            sections = new string[alphaIndex.Keys.Count];

            alphaIndex.Keys.CopyTo(sections,0);

            //copy to array
            sectionObjects = new Java.Lang.Object[sections.Length];
            for (var i = 0; i < sections.Length; i++)
            {
                sectionObjects[i] = new Java.Lang.String(sections[i]);
            }
        }



    }
}