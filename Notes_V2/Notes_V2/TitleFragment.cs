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

namespace Notes_V2
{
    public class TitleFragment : ListFragment
    {
        bool showingTwoFragments;
        int selectedPlayID;

        public TitleFragment()
        {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            //ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, NotesDate.Titles);

            if (savedInstanceState != null)
            {
                selectedPlayID = savedInstanceState.GetInt("current_play_id", 0);

            }

            var quoteContainer = Activity.FindViewById(Resource.Id.frameLayout1);
            showingTwoFragments = quoteContainer != null &&
                                    quoteContainer.Visibility == ViewStates.Visible;
            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowPlayQuote(selectedPlayID);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_play_id", selectedPlayID);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowPlayQuote(position);
        }

        void ShowPlayQuote(int PlayID)
        {
            selectedPlayID = PlayID;
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(selectedPlayID, true);

                var playQuoteFragment = FragmentManager.FindFragmentById(Resource.Id.frameLayout1) as PlayQuoteFragment;

                if (playQuoteFragment == null || playQuoteFragment.PlayID != PlayID)
                {
                    var container = Activity.FindViewById(Resource.Id.frameLayout1);
                    var quoteFrag = PlayQuoteFragment.NewInstance(selectedPlayID);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.frameLayout1, quoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(PlayQuoteActivity));
                intent.PutExtra("current_play_id", PlayID);
                StartActivity(intent);
            }
        }
    }
}