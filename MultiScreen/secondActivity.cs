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

namespace MultiScreen
{
    [Activity(Label = "Screen Two", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class secondActivity : Activity
    {
        int count2 = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //set the view to second.axml
            SetContentView(Resource.Layout.Second);
            //declar message button
            Button message = FindViewById<Button>(Resource.Id.screenOneButton);

             //set int to display times counted
            int timesCounted = Intent.Extras.GetInt("Poked");
            var timesCountedTextView = FindViewById<TextView>(Resource.Id.countTextView);
            timesCountedTextView.Text = timesCounted.ToString();

            //set message on click
            message.Click += delegate
            {
                //create intent to send to main activity
                var first = new Intent(this, typeof(MainActivity));
                //increment by 1 on click
                count2++;
                // convert to string and send;
                first.PutExtra("counted", "You've poke me " + count2.ToString() + " times" );
                StartActivity(first);
            };

        }

        protected override void OnResume()
        {
            base.OnResume();

            int timesCounted = Intent.Extras.GetInt("Poked");
            var timesCountedTextView = FindViewById<TextView>(Resource.Id.countTextView);
            timesCountedTextView.Text = timesCounted.ToString();
        }

        protected override void OnNewIntent(Intent intent)
        {

            base.OnNewIntent(intent);
            Intent = intent;
        }

    }
}