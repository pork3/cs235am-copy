using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App2
{
    [Activity(Label = "Math Flash Cards", MainLauncher = true, Icon = "@drawable/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class MainActivity : Activity
    {
        MathQuiz quiz = new MathQuiz();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            TextView firstNumberTextView = FindViewById<TextView>(Resource.Id.firstNumberTextView);
            firstNumberTextView.Text = quiz.firstNumber.ToString();

            TextView secondNumberTextView = FindViewById<TextView>(Resource.Id.secondNumberTextView);
            secondNumberTextView.Text = quiz.secondNumber.ToString();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.showAnswer);

            button.Click += delegate
            {
                var answer = new Intent(this, typeof(answerActivity));
                answer.PutExtra("Answer", quiz.calcSum());
                StartActivity(answer); 
            };

            
        }
        // on resume
        protected override void OnResume ()
        {
            base.OnResume();

            quiz.MakeRandom();

            TextView firstNumberTextView = FindViewById<TextView>(Resource.Id.firstNumberTextView);
            firstNumberTextView.Text = quiz.firstNumber.ToString();

            TextView secondNumberTextView = FindViewById<TextView>(Resource.Id.secondNumberTextView);
            secondNumberTextView.Text = quiz.secondNumber.ToString();



        }
    }
}

