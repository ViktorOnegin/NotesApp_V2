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
    [Activity(Label = "PlayNoteActivity")]
    public class PlayNoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var playId = Intent.Extras.GetInt("current_play_id", 0);

            var detailsFrag = PlayNoteFragment.NewInstance(playId);
            FragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, detailsFrag)
                            .Commit();
        }
    }
}