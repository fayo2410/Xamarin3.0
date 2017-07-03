using Android.App;
using Android.OS;

namespace Lab11
{
    internal class DataValidate : Fragment
    {
        public SALLab11.ResultInfo Result { get; set; }

        public override string ToString()
        {
            return $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }
    }
}