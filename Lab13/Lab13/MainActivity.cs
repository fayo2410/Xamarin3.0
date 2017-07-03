using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var ValidarButton = FindViewById < ImageButton>(Resource.Id.imageButton1);


            ValidarButton.Click += (s, e) =>
            {
                Validar();
            };
         
        }

        public async void Validar()
        {
            var Client = new SALLab13.ServiceClient();
            string Email = "fayo2410@hotmail.com";
            string password = "toneja21";
            var Result = await Client.ValidateAsync(this, Email, password);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificacion");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token}");
            Alert.SetButton("ok", (s, ev) => { });
            Alert.Show();
        }
    }
}

