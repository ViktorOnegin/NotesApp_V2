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
        //DatabaseService databaseService = new DatabaseService();
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static int PlayID { get; set; }
        public static EditText edit { get; set; }

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

            var notes = DatabaseService.databaseService.GetAllDates();

            PlayID = PlayId;

            List<string> notesList = DatabaseService.DatesList.Select(p => p.Content).ToList();

            var editText = Activity.FindViewById<EditText>(Resource.Id.editText);
            edit = editText;
            try
            {
                editText.Text = notesList[PlayId];
            }
            catch (Exception)
            {
                editText.Text = notesList[0];
            }

            //var content = Activity.FindViewById<EditText>(Resource.Id.editText);
            //var NoteList = DatabaseService.databaseService.GetAllDates().ToList();
            //content.Text = NoteList.ElementAt(PlayId).Content;

            return null;


            //var view = inflater.Inflate(Resource.Layout.MyNotes, null);

            //var editBtn = view.FindViewById<Button>(Resource.Id.button1);
            //var deleteBtn = view.FindViewById<Button>(Resource.Id.button2);
            //var content = view.FindViewById<EditText>(Resource.Id.editText);

            //editBtn.Click += delegate
            //{
            //    databaseService.Edit(PlayId + 1, content.Text);
            //};

            //deleteBtn.Click += delegate
            //{
            //    //databaseService.Delete(databaseService.GetAllDates().ToList()[PlayId]);
            //};

            //var NoteList = databaseService.GetAllDates().ToList();
            //content.Text = NoteList.ElementAt(PlayId).Content;






            //var toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);

            //var editText = new EditText(Activity);
            //var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            //editText.SetPadding(padding, padding, padding, padding);
            //editText.TextSize = 20;
            //editText.Text = databaseService.ElementAt(PlayId).Content;

            //var scroller = new ScrollView(Activity);
            //scroller.AddView(editText);

            
        }
    }
}