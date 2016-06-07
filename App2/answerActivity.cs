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

namespace App2
{
    [Activity(Label = "answerActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class answerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Answer);

            int answer = Intent.Extras.GetInt("Answer");
            var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
            answerTextView.Text = answer.ToString();

            Button button = FindViewById<Button> (Resource.Id.goBackButton);

            button.Click += delegate {

                   var front = new Intent (this, typeof(MainActivity));
                StartActivity(front);
            };
        }

        protected override void OnResume()
        {
 	         base.OnResume();

             int answer = Intent.Extras.GetInt("Answer");
            var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
            answerTextView.Text = answer.ToString();
        }

            protected override void OnNewIntent(Intent intent)
            {

 	            base.OnNewIntent(intent);
                Intent = intent;
            }

        
    }
}