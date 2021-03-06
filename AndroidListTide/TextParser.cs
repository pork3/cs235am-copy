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
using Android.Media;
using System.IO;

namespace AndroidListTide
{
    class TextParser
    {
        string delimiter;
        int numFields;


        public TextParser (string columnDelimiter, int NumberOfFields)
        {
            delimiter = columnDelimiter;
            numFields = NumberOfFields;
        }

        public List<string[]> ParseText (System.IO.Stream stream)
        {
            List<string[]> rows = new List<string[]>();

            string[] delim = new string[1];
            delim[0] = delimiter;

            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    rows.Add(reader.ReadLine().Split(delim, numFields, StringSplitOptions.None));
                }
                
            }
            return rows; 
        }

    }
}