using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ListView
{
    [Activity(Label = "ListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string>  mItems;
        private ListView mListview;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mListview = FindViewById(Resource.Id.listView1);
            mItems = new List<string>();
            mItems.add("kitty");
            mItems.add("Bob");
            mItems.add("george");

            
        }
    }
}

