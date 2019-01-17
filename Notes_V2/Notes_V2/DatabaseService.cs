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
using SQLite;
using System.IO;

namespace Notes_V2
{
    class DatabaseService
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MyDatabase.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<NotesDate>();
        }
        public void Add(NotesDate date)
        {
            db.Insert(date);
        }
        //public void Save(NotesDate date)
        //{
        //   db.
        //}
        public void Delete(NotesDate date)
        {
            db.Delete(date);
        }
        public void Update(NotesDate date)
        {
            db.Update(date);
        }
        public TableQuery<NotesDate> GetNotesDates()
        {
            var table = db.Table<NotesDate>();
            return table;
        }
    }
}