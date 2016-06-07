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

namespace ActivityLifeCycle
{

    public class Thequote
    {
        public string quote { get; set; }
        public string author { get; set; }
    }



    public class Quotes
    {  
        //constructor
        public Quotes( string thing)
        {
            _quote.Add(new Thequote() { quote = "Swag Aint Dead" });
            _quote.Add(new Thequote() { quote = "A quote" });

        }

        //list for quote/author
        private List<Thequote> _quote = new List<Thequote>();
        
        //getter
        public List<Thequote> Thequotes { get { return _quote; } }

        //func to return quotes
        public string GetQuote()//add parameter to increment list count by one
        {
            string funcquote = ""; //init variable
            
            foreach (Thequote q in _quote)
            {
                funcquote += q.quote +"\n" ;
            }
            return funcquote;
        }

        //todo add input for quotes
        public void AddQuote(string zeequote)
        {
            var qquote = new Thequote() { quote = zeequote };
            _quote.Add(qquote);
        }
    }
}