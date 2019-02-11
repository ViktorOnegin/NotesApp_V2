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

namespace Note_V2
{
    [Activity(Label = "", Theme = "@style/AppTheme")]
    public class PlayNoteActivity : Activity
    {
        private int PlayId { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyNotes);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);

            var playId = Intent.Extras.GetInt("current_play_id", 0);

            //var content = FindViewById<EditText>(Resource.Id.editText);
            //content.Text = DatabaseService.DatesList[PlayId].Content;


            var detailsFrag = PlayNoteFragment.NewInstance(playId);
            FragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, detailsFrag)
                            .Commit();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus3, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.save:
                    {
                        break;
                    }
                case Resource.Id.delete:
                    {
                        break;
                    }
                case Resource.Id.back:
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