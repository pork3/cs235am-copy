using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ActivityLifeCycle
{
    [Activity(Label = "ActivityLifeCycle", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //create quote object
        Quotes TheQuote;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            //creating layout stuff etc
            Button button = FindViewById<Button>(Resource.Id.NextQuoteButton);
            TextView QuoteView = FindViewById<TextView>(Resource.Id.QuoteText);

            button.Click += delegate {
                QuoteView.Text = TheQuote.GetQuote();
                
            };
        }
    }
}

//