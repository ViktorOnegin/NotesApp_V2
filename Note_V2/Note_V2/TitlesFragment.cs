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
    public class TitlesFragment : ListFragment
    {
        DatabaseService databaseService = new DatabaseService();
        int selectedPlayId;
       
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            var notes = databaseService.GetAllDates();

            List<string> items = new List<string>();
            foreach (var note in notes)
            {
                items.Add(note.Title);
            }

            ListAdapter = new ArrayAdapter(Activity, Android.Resource.Layout.SimpleListItemActivated1, databaseService.GetAllDates().
                ToList().Select(p => p.Title).ToArray());

            //databaseService = new DatabaseService();
            //ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, databaseService.DatesList.Select(p => p.Title).ToArray());

            if (savedInstanceState != null)
            {
                selectedPlayId = savedInstanceState.GetInt("current_play_id", 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_play_id", selectedPlayId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowPlayQuote(position);
        }

        void ShowPlayQuote(int playId)
        {
            var intent = new Intent(Activity, typeof(PlayNoteActivity));
            intent.PutExtra("current_play_id", playId);
            StartActivity(intent);
        }
    }
}