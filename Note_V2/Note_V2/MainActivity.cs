using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;
using SQLite;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace Note_V2
{
    [Activity(Label = "", Icon= "@drawable/Note", Theme = "@style/AppTheme")]
    public class MainActivity : Activity
    {
        DatabaseService databaseService = new DatabaseService();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AppCenter.Start("8e3e3e29-e523-4a16-a8a4-65a91bef0cfa", typeof(Analytics), typeof(Crashes), typeof(Distribute));

            databaseService.CreateTableWithDates();

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_add:
                    {
                        var startActivity = new Intent(this, typeof(addNotesActivity));
                        StartActivity(startActivity);
                        break;
                    }
                case Resource.Id.menu_delete:
                    {
                        break;
                    }
                default:
                    {
                        //databaseService.Delete(dates);
                        break;
                    }

            }

            return base.OnOptionsItemSelected(item);
        }
    }
}