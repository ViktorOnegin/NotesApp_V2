using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace Notes_V2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var addBtn = FindViewById<Button>(Resource.Id.button1);

            addBtn.Click += AddBtn_Click;
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            var fourthActivity = new Intent(this, typeof(AddNotesActivity));
            //fourthActivity.PutExtra("MyData", textField.Text);
            StartActivity(fourthActivity);
        }
    }
}