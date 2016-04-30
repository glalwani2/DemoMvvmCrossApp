using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace DemoMvvmCross.Core.Droid
{
    public class LiquorCategory : Fragment
    {
        public LiquorCategory()
        {

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            return inflater.Inflate(Resource.Layout.FragmentOne, container, false);
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}