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
    class DatabaseService
    {
        SQLiteConnection db;

        public DatabaseService()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3");
            db = new SQLiteConnection(dbPath);
        }
        public void CreateDatabase()
        {
            db.CreateTable<Dates>();
        }
        public void CreateTableWithDates()
        {
            db.CreateTable<Dates>();
            if (db.Table<Dates>().Count() ==0)
            {
                var dates = new Dates();
                dates.Title = "TestTitle";
                dates.Content = "TestContent";
                db.Insert(dates);
            }
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
        public TableQuery<Dates> GetAllDates()
        {
            var table = db.Table<Dates>();
            return table;
        }
    }
}