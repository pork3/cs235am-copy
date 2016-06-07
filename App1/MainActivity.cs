using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Bugs bug = new Bugs();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //create buttons
            var showSecond = FindViewById<Button>(Resource.Id.patchOne);
            showSecond.Click += delegate
            {

                var back = new Intent(this, typeof(SecondActivity));
                StartActivity(typeof(SecondActivity));
                bug.fixBugs();
                back.PutExtra("Patch", bug.Sum);

            };

            var patch = FindViewById<Button>(Resource.Id.patchTwo);
            patch.Click += delegate
            {

                var backs = new Intent(this, typeof(SecondActivity));
                StartActivity(typeof(SecondActivity));
                bug.otherFix();
                backs.PutExtra("Patch", bug.Sum);
            };

        }

        protected override void OnResume()
        {
            base.OnResume();
            var firstNumberTextView = FindViewById<TextView>(Resource.Id.textView1);
            firstNumberTextView.Text = bug.Sum.ToString();
        }

    }
}

