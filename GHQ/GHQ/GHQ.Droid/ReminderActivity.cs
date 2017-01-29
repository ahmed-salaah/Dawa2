using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace GHQ.Droid
{
    [Activity(Label = "Dawaya", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", NoHistory = true, MainLauncher = false)]
    public class ReminderActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ReminderLayout);

            var btnOk = (Button)this.FindViewById(Resource.Id.btnOk);
            btnOk.Click += BtnOk_Click;
            RequestedOrientation = ScreenOrientation.Portrait;
            var message = Intent.GetStringExtra("message");
            var messageEntry = (EditText)this.FindViewById(Resource.Id.editDescription);
            messageEntry.Text = message;

            var title = Intent.GetStringExtra("title");
            var medecinEntry = (EditText)this.FindViewById(Resource.Id.editMedecin);
            medecinEntry.Text = title;


            var medicin = Intent.GetStringExtra("medicinId");
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
        }

        private void BtnSnooz_Click(object sender, System.EventArgs e)
        {
        }

        private void BtnPlay_Click(object sender, System.EventArgs e)
        {
        }
    }
}