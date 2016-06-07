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

namespace App1
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Back); // set Layout from AXML


            int patches = Intent.GetIntExtra("Patch", 1);// Answer is equal to 'bugs patched' starting from 99
            TextView patchTextView = FindViewById<TextView>(Resource.Id.patchTextView);
            patchTextView.Text = patches.ToString();

            Button button = FindViewById<Button>(Resource.Id.takemebackButton);

            button.Click += delegate
            {
                var front = new Intent(this, typeof(MainActivity));
                StartActivity(front);
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            int patches = Intent.GetIntExtra("Patch", 1);
            TextView patchTextView = FindViewById<TextView>(Resource.Id.patchTextView);
            patchTextView.Text = patches.ToString();

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;

        }
    }


}

