using Android.App;
using Android.Widget;
using Android.OS;


namespace Lab11
{
    [Activity(Label = "Lab11", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        Complex Data;
        DataValidate Datavalidar;
        
        int Counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnCreate");
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.StarActivity).Click += (s, e) =>
            {
                var ActivityIntent = new Android.Content.Intent(this, typeof(SecondActivity1));
                StartActivity(ActivityIntent);
            };

            //Utilizar Fragmentmanager para recuperar el fragmento
            Data = (Complex)this.FragmentManager.FindFragmentByTag("Data");
            if (Data == null)
            {
                //No ha sido almacenado, agregar el fragamento al activity
                Data = new Complex();
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(Data, "Data");
                FragmentTransaction.Commit();
            }


            if(bundle!=null)
            {
                Counter = bundle.GetInt("CounterValue", 0);
                Android.Util.Log.Debug("Lab11Log", "Activity A - Recovered Instance State");
            }
            var ClickCounter = FindViewById<Button>(Resource.Id.ClicksCounter);
            ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);
            ClickCounter.Text += $"\n{Data.ToString()}";
            ClickCounter.Click += (s, e) =>
            {
                Counter++;
                ClickCounter.Text = Resources.GetString
                (Resource.String.ClicksCounter_Text, Counter);

                Data.Real++;
                Data.Imaginary++;

                ClickCounter.Text += $"\n{Data.ToString()}";
            };
            Validate();
        }
        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("CounterValue", Counter);
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnSaveInstaceState");
            base.OnSaveInstanceState(outState);
        }



        protected override void OnStart()
        {
            Android.Util.Log.Debug("Lab11log", "Activity A - OnStart");
            base.OnStart();
        }

        protected async override void OnResume()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnResume");
            base.OnResume();
                    
        }
        
        public async void Validate()
        {
            var studentemail = "fayo2410@hotmail.com";
            var password = "toneja21";
            var device = Android.Provider.Settings.Secure.GetString(ContentResolver,
                Android.Provider.Settings.Secure.AndroidId);

            Datavalidar = (DataValidate)FragmentManager.FindFragmentByTag("Datavalidar");
            if (Datavalidar == null)
            {
                Datavalidar = new DataValidate();

                var ValFragment = FragmentManager.BeginTransaction();
                ValFragment.Add(Datavalidar, "Datavalidar");
                ValFragment.Commit();

                SALLab11.ServiceClient ServiceClient = new SALLab11.ServiceClient();
                Datavalidar.Result = await ServiceClient.ValidateAsync(studentemail, password, device);

            }

            FindViewById<TextView>(Resource.Id.txtValidate).Text = Datavalidar.ToString();
        }

        protected override void OnPause()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnStop()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnStop");
            base.OnStop();
        }
        protected override void OnDestroy()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnDestroy");
            base.OnDestroy();
        }

        protected override void OnRestart()
        {
            Android.Util.Log.Debug("Lab11Log", "Activity A - OnRestart");
            base.OnRestart();
        }
    }
}

