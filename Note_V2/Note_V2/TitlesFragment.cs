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
        int selectViewId;
        bool showingTwoFragments;

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

            var notecontainer = Activity.FindViewById(Resource.Id.note_container);
            showingTwoFragments = notecontainer != null &&
                                  notecontainer.Visibility == ViewStates.Visible;
            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowNotes(selectViewId);
            }

            if (savedInstanceState != null)
            {
                selectViewId = savedInstanceState.GetInt("current_note_id", 0);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_note_id", selectViewId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowNotes(position);
        }

        void ShowNotes(int ViewId)
        {
            selectViewId = ViewId;
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(selectViewId, true);

                var NoteFragment = FragmentManager.FindFragmentById(Resource.Id.note_container) as PlayNoteFragment;

                if (NoteFragment == null || NoteFragment.PlayId != ViewId)
                {
                    var container = Activity.FindViewById(Resource.Id.note_container);
                    var NoteFrag = PlayNoteFragment.NewInstance(selectViewId);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.note_container, NoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(PlayNoteActivity));
                intent.PutExtra("current_note_id", ViewId);
                StartActivity(intent);
            }
        }
    }
}