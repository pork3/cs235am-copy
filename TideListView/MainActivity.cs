using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TideListView
{
    [Activity(Label = "TideListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        List<VocabItem> vocabItems;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            vocabItems = new List<VocabItem>();

            const uint NUMBER_OF_FIELDS = 3; //number of fields in list view

            var vocablist = parser

            button.Click += delegate { };
        }
    }
}

