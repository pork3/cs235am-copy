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

namespace QuoteLifeCycle
{
    //create a class for the items in the list
    public class QuoteRequirements
    {
        public string TheQuote { get; set; }
        public string TheAuthor { get; set; }
    }


    public class QuoteLogic
    {
        // List init and getter
        private List<QuoteRequirements> _quote = new List<QuoteRequirements>();
        public List<QuoteRequirements> quoterequirements { get { return _quote; } }

        public QuoteLogic()
        {
            _quote.Add(new QuoteRequirements() { TheQuote = "Android is very different from the GNU/Linux operating system" +
            "because it contains very little of GNU. Indeed, just about the only component in common between Android and GNU/Linux is Linux, the kernel" + "\n", TheAuthor = " -Richard Stallman" });

            _quote.Add(new QuoteRequirements() { TheQuote = "I think swag is very important to rappers. It's the overall appearance and style of an artist"+
            "these blue shorts and this blue hat and this $80,000 chain, this jewelry and all these tattoos, that's swag" + "\n", TheAuthor = " -Soulja Boy"});

            _quote.Add(new QuoteRequirements() { TheQuote = "There's a cure for everything except death" + "\n", TheAuthor = "-Antonio Ricci" });

            _quote.Add(new QuoteRequirements() { TheQuote = "My name is Adam Sandler. I'm not particularly talented. I'm not particularly good-looking. And yet I'm a multi-millionaire." +"\n", TheAuthor = "-Adam Sandler" });

        }

        public string GetQuoteString(int count)
        {
            string funcquote = "";

            for (int i = 0; i < _quote.Count; i++)
            {
                if (i == count)
                {
                    funcquote = _quote[i].TheQuote;
                    break;
                }
            }
            return funcquote;
        }

        public string GetAuthorString(int count)
        {
            string funcauthor = "";

            for (int i = 0; i < _quote.Count; i++)
            {
                if (i == count)
                {
                    funcauthor = _quote[i].TheAuthor;
                    break;
                }
            }
            return funcauthor;
        }

        public void AddQuote (string placeholder, string placeholder2)
        {
            var funcquote = new QuoteRequirements() { TheQuote = placeholder, TheAuthor = placeholder2 };
            _quote.Add(funcquote); 
        }


    }
}