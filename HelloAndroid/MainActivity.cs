using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloAndroid
{
    [Activity(Label = "HelloAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        const string Hello = "Hello from the button";

        const string Xamarin = "Hello, Xamarin.Android";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //create the user interface in clode
            var layout1 = new LinearLayout(this);
            layout1.Orientation = Orientation.Vertical;

            var aLabel = new TextView(this);
            aLabel.Text = Xamarin;

            var aButton = new Button(this);
            aButton.Text = "Say Hello";
            aButton.Click += (sender, e) =>
            {
                aLabel.Text = Hello;
            };

            var bButton = new Button(this);
            bButton.Text = "Reset the label";
            bButton.SetBackgroundColor(Android.Graphics.Color.LightSeaGreen);
            bButton.Click += (sender, e) =>
                {
                    aLabel.Text = Xamarin;
                };

            //add buttons to layout
            layout1.AddView(aLabel);
            layout1.AddView(aButton);
            layout1.AddView(bButton);
            // set the layout to be the "view"
            SetContentView(layout1);
        }
    }

}
