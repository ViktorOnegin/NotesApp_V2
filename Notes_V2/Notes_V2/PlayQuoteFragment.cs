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

namespace Notes_V2
{
    public class PlayQuoteFragment : Fragment
    {
        public int PlayID => Arguments.GetInt("current_play_id", 0);

        public static PlayQuoteFragment NewInstance(int PlayID)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", PlayID);
            return new PlayQuoteFragment { Arguments = bundle };
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }

            var textView = new TextView(Activity);
            var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            textView.SetPadding(padding, padding, padding, padding);
            textView.TextSize = 24;
            //textView.Text = NotesDate.Dialogue[PlayID];

            var scroller = new ScrollView(Activity);
            scroller.AddView(textView);

            return scroller;
        }
    }
}