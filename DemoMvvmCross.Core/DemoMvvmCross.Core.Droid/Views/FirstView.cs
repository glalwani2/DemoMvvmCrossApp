using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Content;

namespace DemoMvvmCross.Core.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var button = FindViewById<Button>(Resource.Id.click);
            button.Click += handle_click;
        }

        private void handle_click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainLayout));
            StartActivity(intent);
        }
    }
}
