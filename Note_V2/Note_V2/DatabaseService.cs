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
                dates.Title = "SimpleNotesApp";
                dates.Content = "You can add, delete and edit notes. Hope you enjoy my app)";
                db.Insert(dates);
            }
        }
        public void Add(string title, string content)
        {
            var add = new Dates
            {
                Title = title,
                Content = content
            };
        }
        public void Delete(int id)
        {
            Dates dates = new Dates();
            dates.ID = id;
            db.Delete(dates);
        }
        public void Edit(int id, string content)
        {

        }
        public TableQuery<Dates> GetAllDates()
        {
            var table = db.Table<Dates>();
            return table;
        }
    }
}