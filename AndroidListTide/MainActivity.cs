using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AndroidListTide
{
    [Activity(Label = "Android List Tide", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        List<TideItems> tideItems; 

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            tideItems = new List<TideItems>();

            const int NUMBER_OF_FIELDS = 5;

            TextParser parser = new TextParser("\t", NUMBER_OF_FIELDS);
            List<string[]> stringArrays; //generate string array;
            stringArrays = parser.ParseText (Assets.Open(@"tideinfo.txt");

            //sort
            stringArrays.Sort((x, y) => String.Compare(x[2], y[2],	  // provide a comparator method for the array element containing pos		
				StringComparison.Ordinal));

            foreach(string[] word in stringArrays)
                tideItems.Add(new TideItem(word[0], word[1], word[2], word[3],word[4]));

            ListAdapter = new TideAdapter (this , tideItems);

            ListView.FastScrollEnabled = true; 
        }
    }
}

