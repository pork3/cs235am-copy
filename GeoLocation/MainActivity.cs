using System;
using System.Linq;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Geolocator;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;

namespace GeoLocation
{
    [Activity(Label = "GeoLocation", MainLauncher = true, Icon = "@drawable/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    public class MainActivity : Activity
    {
        double userlat;
        double userlon;
        string dbPath; 
        protected override void OnCreate(Bundle bundle)
        {
            dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "stocks.db3");

            using (Stream inStream = Assets.Open("stocks.db3"))
            using (Stream outStream = File.Create(dbPath))
                inStream.CopyTo(outStream);
            var db = new SQLiteConnection(dbPath);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button tidebutton = FindViewById<Button>(Resource.Id.secondbutton);
            Button selectbutton = FindViewById<Button>(Resource.Id.selectedbutton);
            TextView textview = FindViewById<TextView>(Resource.Id.textView1);
            Spinner spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            DatePicker dates = FindViewById<DatePicker>(Resource.Id.datePicker1);
            //spinner + getting spinner locations
            var spinloc = GetLocations();
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, spinloc);
            spinner1.Adapter = adapter;
            //event handler
            string city;

            spinner1.ItemSelected += delegate(object sender, AdapterView.ItemSelectedEventArgs e)
            {
                Spinner spinner = (Spinner)sender;
                city = (string)spinner.GetItemAtPosition(e.Position);
            };
            city = (string)spinner1.SelectedItem;
            ////////////////////////////////

            selectbutton.Click += delegate
            {
                var intent = new Intent(this, typeof(SelectedActivity));
                intent.PutExtra("city", city);
                intent.PutExtra("date", dates.DateTime.ToString("yyyy/MM/dd"));
                StartActivity(intent);
            };

            ////


            button.Click += delegate
            {
                locator.GetPositionAsync(timeoutMilliseconds: 1000).ContinueWith(t =>
                    {
                        try
                        {
                            //t in a position
                            textview.Text = string.Format("Position status: {0}\n", t.Result.Timestamp);
                            textview.Text += string.Format("Position Latitue: {0} \n", t.Result.Latitude);
                            userlat = t.Result.Latitude;
                            textview.Text += string.Format("Position Longitued: {0}\n", t.Result.Longitude);
                            userlon = t.Result.Longitude;
                        }
                        catch (Exception ex)
                        {
                            textview.Text += ex.ToString();
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());

            };

            var distinctlat = db.Table<Tide>().GroupBy(s => s.Latitude).Select(s => s.First());
            var latlist = distinctlat.Select(s => Convert.ToDouble(s.Latitude)).ToList();

            var distinctlon = db.Table<Tide>().GroupBy(t => t.Longitude).Select(t => t.First());
            var lonlist = distinctlon.Select(t => Convert.ToDouble(t.Longitude)).ToList();
            //merged lists, probably easier way but it works
            var latlon = latlist.Zip(lonlist, (lat, lon) => new { lat, lon }).ToList();
            double[] temp = new double[latlon.Count()]; 

            for (int i = 0; i < latlon.Count(); i++ )
            {
              temp[i] = getDistance(userlat, userlon, latlon[i].lat, latlon[i].lon);     
            };
            //find the smallest value and index
            //again probably easier way, but it works
            double smallest = temp[0]; int theindex = 0;
            for (int index = 1; index < temp.Length; index++)
            {
                if (temp[index] < smallest) 
                    smallest = temp[index] ;
                theindex = index;
            } 
           // foreach (var tt in temp)
           // { button.Text += "\n" + tt; }

            //loop through the list with index and get the lat

            tidebutton.Click += delegate
            {
                var intent = new Intent(this, typeof(TideListActivity));
                string UserLatIntent = (latlon[theindex].lat).ToString();
                intent.PutExtra("lat", UserLatIntent);
                intent.PutExtra("date", DateTime.Now.ToString("yyyy/MM/dd"));
                StartActivity(intent);
            };
        }

        /// <summary>
        /// Getting distance from points on the earth
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        private static double deg2Rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2Deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        private double getDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double distance = Math.Sin(deg2Rad(lat1)) * Math.Sin(deg2Rad(lat2)) + Math.Cos(deg2Rad(lat1)) * Math.Cos(deg2Rad(lat2)) * Math.Cos(deg2Rad(theta));
            distance = Math.Acos(distance);
            distance = rad2Deg(distance);
            distance = distance * 60 * 1.1515;
            return distance; 
        }

        private List<string> GetLocations()
        {
            var loc = new List<string>();

            using (var l = new SQLiteConnection(dbPath))
            {
                loc = l.Table<Tide>().ToList().Select(x => x.City).Distinct().ToList();
            }
            return loc;
        }
    }




}

