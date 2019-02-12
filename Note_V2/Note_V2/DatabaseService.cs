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
            CreateDatabase();
            CreateTableWithDatas();
        }
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3");
            db = new SQLiteConnection(dbPath);
        }
        public void CreateTableWithDatas()
        {
            db.CreateTable<Datas>();
            if (db.Table<Datas>().Count() ==0)
            {
                var note = new Datas();
                note.Title = "SimpleNotesApp";
                note.Content = "You can add, delete and edit notes. Hope you enjoy my app)";
                db.Insert(note);
            }
        }
        public void Add(string title, string content)
        {
            var addnote = new Datas
            {
                Title = title,
                Content = content
            };
            db.Insert(addnote);
        }
        public void Delete(int id)
        {
            Datas note = new Datas();
            note.ID = id;
            db.Delete(note);
        }
        public void Edit(int id, string content)
        {
            var getDatas = GetAllDatas();
            var query = from note in getDatas
                        where note.ID == id
                        select note;
            foreach(Datas datas in query)
            {
                datas.ID = id;
                datas.Content = content;
                db.Update(datas);
            }
        }
        public TableQuery<Datas> GetAllDatas()
        {
            var table = db.Table<Datas>();
            return table;
        }
    }
}