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

namespace MultiScreenApp
{
    [Activity(Label = "Second Activity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.Second);

            //show stuff on screen
            var label = FindViewById<TextView>(Resource.Id.screen2Label);
            //if can get data, else not available
            label.Text = Intent.GetStringExtra("First Data") ?? "Data not available";
        }
    }
}