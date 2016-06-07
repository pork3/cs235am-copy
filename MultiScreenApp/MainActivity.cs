using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MultiScreenApp
{
    [Activity(Label = "MultiScreenApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class FirstActivity : Activity  
    {
        uint count = 1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Use the UI in axml
            SetContentView(Resource.Layout.Main);

            //create second button 
            var showCount = new Button(this);
            showCount.Text = GetString(Resource.String.button_clicked_text, count++);
            
            var showSecond = FindViewById<Button>(Resource.Id.showSecond);
            // start the second activity on click
            showSecond.Click += (sender, e) =>
            {
                var second = new Intent(this, typeof(SecondActivity));
                second.PutExtra("First Data", "Data from First Activity");
                StartActivity(second);
            };
        }
    }
}

