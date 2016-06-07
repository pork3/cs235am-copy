using System;
using SQLite;

namespace GeoLocation
{
    public class Tide
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(8)]
        public string City { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public string Feet { get; set; }
        public string Cent { get; set; }
        public string HiLo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}