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
using Android.Support.V7.App;

namespace Note_V2
{
    [Activity(Label = "", Theme = "@style/AppTheme")]
    public class PlayNoteActivity : Activity
    {
        DatabaseService databaseService = new DatabaseService();
        private int PlayId { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyNotes);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);

            var playId = Intent.Extras.GetInt("current_play_id", 0);

            var content = FindViewById<EditText>(Resource.Id.editText);
            content.Text = databaseService.GetAllDates().ElementAt(PlayId).Content;



            //var detailsFrag = PlayNoteFragment.NewInstance(playId);
            //FragmentManager.BeginTransaction()
            //                .Add(Android.Resource.Id.Content, detailsFrag)
            //                .Commit();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}