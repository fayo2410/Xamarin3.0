using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "Phone App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        static readonly System.Collections.Generic.List<string> PhoneNumbers = 
            new System.Collections.Generic.List<string>();

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //Validate();
            var PhoneNumber = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var CallButton = FindViewById<Button>(Resource.Id.CallButton);            
            var CallHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
            var ValidateActivityButton = FindViewById<Button>(Resource.Id.validateactivitybutton);

            CallButton.Enabled = false;

            var TranslatedNumber = string.Empty;

            TranslateButton.Click += (object sender, System.EventArgs e) =>
            {
                var Translator = new PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumber.Text);

                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    CallButton.Text = "Llamar";
                    CallButton.Enabled = false;
                }
                else
                {
                    CallButton.Text = $"Llamar al {TranslatedNumber}";
                    CallButton.Enabled = true;
                }
            };


            CallButton.Click += (object sender, System.EventArgs e) =>
            {

                var CallDialog = new AlertDialog.Builder(this);
                CallDialog.SetMessage($"Llamar al numero {TranslatedNumber}?");
                CallDialog.SetNeutralButton("Llamar", delegate
                {
                    PhoneNumbers.Add(TranslatedNumber);

                    CallHistoryButton.Enabled = true;


                    var CallI = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    CallI.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));
                    StartActivity(CallI);
                });
                CallDialog.SetNegativeButton("Cancelar", delegate { });
                CallDialog.Show();
            };

            CallHistoryButton.Click += (sender, e) =>
            {
                var Intent = new Android.Content.Intent(this,
                    typeof(CallHistoryActivity));
                Intent.PutStringArrayListExtra("phone_numbers",
                    PhoneNumbers);
                StartActivity(Intent);
            };

            ValidateActivityButton.Click += (s, e) =>
            {
                var Intent = new Android.Content.Intent(this, typeof(ValidateActivity));
                StartActivity(Intent);
            };



        }

        private async void Validate()

        {
            SALLab06.ServiceClient ServiceClient = new SALLab06.ServiceClient();

            string studentemail = "fayo2410@hotmail.com";
            string password = "toneja21";
            string myDevice = Android.Provider.Settings.Secure.GetString(

                ContentResolver,
                Android.Provider.Settings.Secure.AndroidId
                );

            SALLab06.ResultInfo Result = await ServiceClient.ValidateAsync(studentemail, password, myDevice);
            TextView txtvalidate = FindViewById<TextView>(Resource.Id.txtValidate);
            txtvalidate.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

            // $"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
        }



    }
}

