using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;

namespace Note_V2
{
    public class PlayNoteFragment : Fragment
    {
        DatabaseService databaseService = new DatabaseService();
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static PlayNoteFragment NewInstance(int playId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", playId);
            return new PlayNoteFragment { Arguments = bundle };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var view = inflater.Inflate(Resource.Layout.MyNotes, null);

            var editBtn = view.FindViewById<Button>(Resource.Id.edit);
            var deleteBtn = view.FindViewById<Button>(Resource.Id.delete);
            var content = view.FindViewById<EditText>(Resource.Id.content);

            editBtn.Click += delegate
            {
                databaseService.Edit(PlayId + 1, content.Text);
            };

            deleteBtn.Click += delegate
            {
                databaseService.Delete(databaseService.GetAllDates().ToList()[PlayId].ID);
            };

            var Notes = databaseService.GetAllDates().ToList();
            content.Text = Notes.ElementAt(PlayId).Content;
       
            return view;
        }
    }
}