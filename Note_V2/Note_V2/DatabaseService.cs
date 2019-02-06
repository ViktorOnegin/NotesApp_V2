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
                var note = new Dates();
                note.Title = "SimpleNotesApp";
                note.Content = "You can add, delete and edit notes. Hope you enjoy my app)";
                db.Insert(note);
            }
        }
        public void Add(string title, string content)
        {
            var note = new Dates
            {
                Title = title,
                Content = content
            };
            db.Insert(note);
        }
        public void Delete(int id)
        {
            Dates note = new Dates();
            note.ID = id;
            db.Delete(note);
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