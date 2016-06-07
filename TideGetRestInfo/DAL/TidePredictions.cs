﻿using System;
using SQLite;

namespace DAL
{
    //two different databases, one to store places
    //this one stores the preditction
    [Table("TideLocations")]
    public class TideLocations
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(8)]
        public string StationName;
        public int StationID;
        public int Latitude;
        public int Longitude;

    }
}