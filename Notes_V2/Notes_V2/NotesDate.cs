﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Notes_V2
{
    class NotesDate
    {
        //public static string[] Titles =
        //{
        //    "kool"
        //};

        //public static string[] Dialogue =
        //{
        //    "Täna on kolm mata tundi!!!!!!!!, tra"
        //};

        [PrimaryKey, AutoIncrement, Column("_ID")]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}