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



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var view = inflater.Inflate(Resource.Layout.MyNotes, null);

            //var toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);

            //var editText = new EditText(Activity);
            //var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            //editText.SetPadding(padding, padding, padding, padding);
            //editText.TextSize = 20;
            //editText.Text = databaseService.GetAllDates().ElementAt(PlayId).Content;

            //var scroller = new ScrollView(Activity);
            //scroller.AddView(editText);

            return view;
        }
    }
}