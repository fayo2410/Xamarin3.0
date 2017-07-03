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

namespace AndroidApp
{
    [Activity(Label = "@string/validaractividad")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Validar);

            var Mailtext = FindViewById<EditText>(Resource.Id.MaileditText);
            var Passtext = FindViewById<EditText>(Resource.Id.PasswordText);
            var ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            var ResulText = FindViewById<TextView>(Resource.Id.txtValidate);


            ValidateButton.Click += async (s, e) =>
            {
                SALLab06.ServiceClient ServiceClient = new SALLab06.ServiceClient();

                string studentemail = Mailtext.Text;
                string password = Passtext.Text;
                string myDevice = Android.Provider.Settings.Secure.GetString(
                    ContentResolver,Android.Provider.Settings.Secure.AndroidId
                    );

                SALLab06.ResultInfo Result = await ServiceClient.ValidateAsync(
                    studentemail, password, myDevice);
                TextView txtvalidate = FindViewById<TextView>(Resource.Id.txtValidate);
                txtvalidate.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
            };

            // Create your application here
        }

       
    }
}