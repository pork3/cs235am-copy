using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace TideWaveAppListView
{
    [Activity(Label = "Tide Wave App List View", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private List<string> tideItems;
        private ListView tideListView; 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            tideListView = FindViewById<ListView>(Resource.Id.TideListView);

            const int NUMBER_OF_FIELDS = 3;

            TextParser parser = new TextParser(",", NUMBER_OF_FIELDS);
            List<string[]> stringArray;
            stringArray = parser.ParseText(Assets.Open(@"tideinfo.txt"));

            //sort the array
            stringArray.Sort((x, y) => String.Compare(x[2], y[2], StringComparison.Ordinal));

            //copy
            foreach(string[] word in stringArray)
                tideItems.Add(TideInfo(word[0], word[1],word[2]));


            ListView.FastScrollEnabled = true; 

            MyListViewAdapter tideAdapter = new MyListViewAdapter(this, tideItems);

            tideListView.Adapter = tideAdapter;
        }
    }
}

