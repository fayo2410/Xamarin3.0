using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab07
{
    [Activity(Label = "Lab07", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var Mailtext = FindViewById<EditText>(Resource.Id.MaileditText);
            var Passtext = FindViewById<EditText>(Resource.Id.PasswordText);
            var ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            var ResulText = FindViewById<TextView>(Resource.Id.txtValidate);

            ValidateButton.Click += async (s, e) =>
            {
                SALLab07.ServiceClient ServiceClient = new SALLab07.ServiceClient();
                string studentemail = Mailtext.Text;
                string password = Passtext.Text;
                string myDevice = Android.Provider.Settings.Secure.GetString(
                    ContentResolver, Android.Provider.Settings.Secure.AndroidId
                    );
                SALLab07.ResultInfo Result = await ServiceClient.ValidateAsync(
                    studentemail, password, myDevice);
                TextView txtvalidate = FindViewById<TextView>(Resource.Id.txtValidate);
                var Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    var Builder = new Notification.Builder(this)
                            .SetContentTitle("Validacion de la Actividad")
                            .SetContentText(Text)
                            .SetSmallIcon(Resource.Drawable.Icon);
                    Builder.SetCategory(Notification.CategoryMessage);
                    var objectNotification = Builder.Build();
                    var manager = (NotificationManager)GetSystemService(NotificationService);
                    manager.Notify(0, objectNotification);
                }
                else
                {
                    txtvalidate.Text = Text;
                }                
            };
        }
    }
}

