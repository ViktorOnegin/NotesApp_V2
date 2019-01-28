using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Note_V2
{
    public class DatabaseService
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Dates>();
        }

        public void Add(Dates dates)
        {
            db.Insert(dates);
        }
        public void Delete(Dates dates)
        {
            db.Delete(dates);
        }
        public void Update(Dates dates)
        {
            db.Update(dates);
        }
        //public TableQuery<Dates> GetAllDates()
        //{
        //    var table = db.Table<Dates>();
        //    return table;
        //}
    }
}