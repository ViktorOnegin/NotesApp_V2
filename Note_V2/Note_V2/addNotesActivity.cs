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
using Newtonsoft.Json;

namespace Note_V2
{
    [Activity(Label = "", Theme = "@style/AppTheme")]
    public class addNotesActivity : Activity
    {
        DatabaseService databaseService = new DatabaseService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addNotes);
            
            databaseService.CreateDatabase();

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus2, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.menu_add:
                    {
                        Datas dates = new Datas();

                        var title = FindViewById<EditText>(Resource.Id.edit1);
                        var content = FindViewById<EditText>(Resource.Id.edit2);

                        dates.Title = title.Text;
                        dates.Content = content.Text;

                        databaseService.Add(dates.Title, dates.Content);
                        break;
                    }
                case Resource.Id.menu_back:
                    {
                        var startActivity = new Intent(this, typeof(MainActivity));
                        StartActivity(startActivity);
                        break;
                    }
                default:
                    {
                        break;
                    }

            }

            return base.OnOptionsItemSelected(item);
        }


    }
}