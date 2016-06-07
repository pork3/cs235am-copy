using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Xml.Serialization;



namespace QuoteLifeCycle
{
    [Activity(Label = "Quote Life Cycle", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        QuoteLogic quotelogic; //create object 

        int count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            // Get our button from the layout resource,
            // all the laoyt in this block
            TextView QuoteTextView = FindViewById<TextView>(Resource.Id.QuoteTextView);
            TextView AuthorTextView = FindViewById<TextView>(Resource.Id.AuthorTextView);
            Button NextButton = FindViewById<Button>(Resource.Id.NextQuoteButton);
            var UserQuote = FindViewById<TextView>(Resource.Id.UserEditText);
            var UserAuthor = FindViewById<TextView>(Resource.Id.UserEditAuthor);
            Button UserButton = FindViewById<Button>(Resource.Id.UserQuoteButton);
            //end of layout

            if (bundle == null)
            {
                quotelogic = new QuoteLogic(); //create object 
            }
            else
            {
                string XmlQuotes = bundle.GetString("quote");
                XmlSerializer x = new XmlSerializer(typeof(QuoteLogic));
                quotelogic = (QuoteLogic)x.Deserialize(new StringReader(XmlQuotes));

                var tom = new StringReader(XmlQuotes);
                QuoteTextView.Text = bundle.GetString("quote");
                AuthorTextView.Text = bundle.GetString("quote");
                count = bundle.GetInt("click");
            }



            NextButton.Click += delegate 
                {//add if statement for bundle has stuff

                QuoteTextView.Text = quotelogic.GetQuoteString(count);
                 AuthorTextView.Text = quotelogic.GetAuthorString(count);

                if (count > quotelogic.quoterequirements.Count - 1)
                {
                        count = 0;
                }
                 else
                {
                        ++count;
                }
                };

            UserButton.Click += delegate
            {
                quotelogic.AddQuote(UserQuote.Text,UserAuthor.Text);

                UserAuthor.Text = string.Empty;
                UserQuote.Text = string.Empty;
            };

        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer quoteSerializer = new XmlSerializer(typeof(QuoteLogic));
            TextView QuoteTextView = FindViewById<TextView>(Resource.Id.QuoteTextView);
            TextView AuthorTextView = FindViewById<TextView>(Resource.Id.AuthorTextView);
            quoteSerializer.Serialize(writer, quotelogic);
            string XmlQuotes = writer.ToString();

            outState.PutString("quote", XmlQuotes);
            outState.PutInt("click", count);

            //savecount
            base.OnSaveInstanceState(outState);
        }

        private int RandomNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min,max);
        }



    }
}

