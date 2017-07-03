using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var ListColors = FindViewById<ListView>(Resource.Id.listView1);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this, Resource.Layout.ListItem, Resource.Id.textView1, 
                Resource.Id.textView2, Resource.Id.imageView1);

            Validar();
        }
        public async void Validar()
        {
            SALLab12.ServiceClient client = new SALLab12.ServiceClient();
            var studentemail = "fayo2410@hotmail.com";
            var password = "toneja21";
            var device = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);
            SALLab12.ResultInfo result = await client.ValidateAsync(studentemail, password, device);
            FindViewById<TextView>(Resource.Id.txtValidate).Text = 
                $"{result.Status}\n{result.FullName}\n{result.Token}";
        }

    }
}

