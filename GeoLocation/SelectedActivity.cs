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
    [Activity(Label = "SelectedActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class SelectedActivity : ListActivity
    {
        string dbPaths = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            dbPaths = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "stocks.db3");

            ViewTideLists();
        }

        private void ViewTideLists()
        {
            var dateTick = Intent.GetStringExtra("date");
            var location = Intent.GetStringExtra("city");
            List<Tide> tide;

            using (var db = new SQLiteConnection(dbPaths))
            {
                //copying working 
                // tide = (from t in db.Table<Tide>() select t).ToList();
                tide = db.Table<Tide>().Select(t => t).Where(t => t.City.Contains(location) && t.Date.StartsWith(dateTick)).ToList();
                ListView.FastScrollEnabled = true;
            }

            //ListAdapter = new TideAdapter(this, tide);
            ListAdapter = new TideAdapter(this, tide);

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Intent = intent;
            ViewTideLists();
        }

    }
}