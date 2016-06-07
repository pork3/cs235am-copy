using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MultiScreen
{
    [Activity(Label = "Screen One", MainLauncher = true, Icon = "@drawable/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class MainActivity : Activity
    {
        //init variables
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.screenOneButton);

            button.Click += delegate
            
            { 
                //on click go to second activity increment count
                var second = new Intent(this, typeof(secondActivity));
                second.PutExtra("Poked", count++);
                StartActivity(second);
            
            };


           



        }

        protected override void OnResume()
        {
            base.OnResume();
            // text view of number of times from second activity 
            string messages = Intent.GetStringExtra("counted");
            var secondCountTextView = FindViewById<TextView>(Resource.Id.messageTextView);
            //set the text to intent or null
             secondCountTextView.Text =Intent.GetStringExtra("counted") ?? "No Message Received";


        }


        protected override void OnNewIntent(Intent intent)
        {

            base.OnNewIntent(intent);
            Intent = intent;
        }



    }
}

