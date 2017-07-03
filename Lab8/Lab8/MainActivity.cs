using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab8
{
    [Activity(Label = "Lab8", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            await Validar();
        }

        public async System.Threading.Tasks.Task Validar()
        {
            SALLab08.ServiceClient client = new SALLab08.ServiceClient();
            var studentemail = "fayo2410@hotmail.com";
            var password = "toneja21";
            var device = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            var Result = await client.ValidateAsync(studentemail, password, device);

            var UserNameResultTextView = FindViewById<TextView>(Resource.Id.UserNameResultTextView);
            var TokenResultTextView = FindViewById<TextView>(Resource.Id.TokenResultTextView);
            var StatusResultTextView = FindViewById<TextView>(Resource.Id.StatusResultTextView);

            UserNameResultTextView.Text = Result.Fullname;
            TokenResultTextView.Text = Result.Token;
            StatusResultTextView.Text = Result.Status.ToString();

            

        }
    }
}

