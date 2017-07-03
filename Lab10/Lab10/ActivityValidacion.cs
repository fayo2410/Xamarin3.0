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

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher =true)]
    public class ActivityValidacion : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Validacion);

            var EmailEditText = FindViewById<EditText>(Resource.Id.EmailEditText);
            var PasswordEditText = FindViewById<EditText>(Resource.Id.PasswordEditText);
            var ValidateButton = FindViewById<Button>(Resource.Id.ValidateButton);
            var ResultTextView = FindViewById<TextView>(Resource.Id.ResultTextView);

            ValidateButton.Click += async (s, e) =>
            {
                var device = Android.Provider.Settings.Secure.GetString
                (ContentResolver, Android.Provider.Settings.Secure.AndroidId);

                SALLab10.ServiceClient  client = new SALLab10.ServiceClient();
                var Result = await client.ValidateAsync(EmailEditText.Text, 
                    PasswordEditText.Text, device);

                ResultTextView.Text = $"{ Result.Status}\n{Result.Fullname}\n{Result.Token}";
            };
        }
    }
}