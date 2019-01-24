﻿using System;
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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class addNotesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addNotes);

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
                        var Title = FindViewById<EditText>(Resource.Id.)
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