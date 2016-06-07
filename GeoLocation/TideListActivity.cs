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
using System.IO;
using SQLite;

namespace GeoLocation
{
    [Activity(Label = "TideListActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class TideListActivity : ListActivity
    {
        string dbPath = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            dbPath = dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "stocks.db3");

            ViewTideList();
        }

        private void ViewTideList()
        {
            var dateTick = Intent.GetStringExtra("date");
            var location = Intent.GetStringExtra("lat");
            List<Tide> tide;

            using (var db = new SQLiteConnection(dbPath))
            {
                //copying working 
                // tide = (from t in db.Table<Tide>() select t).ToList();
                tide = db.Table<Tide>().Select(t => t).Where(t => t.Latitude.Contains(location) && t.Date.StartsWith(dateTick)).ToList();
                ListView.FastScrollEnabled = true;
            }

            //ListAdapter = new TideAdapter(this, tide);
            ListAdapter = new TideAdapter(this, tide);

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;
            ViewTideList();
        }

    }
}