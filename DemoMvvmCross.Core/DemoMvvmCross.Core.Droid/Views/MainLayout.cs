using Android.App;
using Android.OS;
using Android.Views;
using Android.Runtime;
using System.Collections.Generic;
using DemoMvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using TabLayout = Android.Support.Design.Widget.TabLayout;
using ViewPager = Android.Support.V4.View.ViewPager;
using Android.Support.V4.App;
using static Android.Views.View;
using DemoMvvmCross.Core.Droid.ViewPagers;

namespace DemoMvvmCross.Core.Droid.Views
{
    [Activity(Label ="Rhythm")]
    public class MainLayout : MvxAppCompatActivity
    {
        private Toolbar toolbar;
        private TabLayout tabLayout;
        private NonSwipeableViewPager viewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainLayout);

            //Enabling the Tool Bar
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            //viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager = FindViewById<NonSwipeableViewPager>(Resource.Id.viewpager);
            viewPager.SetPagingEnabled(false);
            setupViewPager(viewPager);

            tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            // Create your application here
        }

        private void setupViewPager(ViewPager viewPager)
        {
            var fragments = new List<Android.Support.V4.App.Fragment>();
            //var titles = new List<string>();
            foreach (var item in LiquorNames())
            {
                fragments.Add(new LiquorCategory());
                //titles.Add(item);
            }

            var titles = CharSequence.ArrayFromStringArray(new[]
               {
                   "Beer",
                "Whisky",
                "Wine",
                "Champagne",
                "Cognac",
                "Cocktails"
                });
            LiquorCategoryAdapter adapter = new LiquorCategoryAdapter(base.SupportFragmentManager, fragments.ToArray(), titles);
            viewPager.Adapter = adapter;
        }

        private List<string> LiquorNames()
        {
            return new List<string>()
            {
                "Beer",
                "Whisky",
                "Wine",
                "Champagne",
                "Cognac",
                "Cocktails"
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            // Handle action bar item clicks here. The action bar will
            // automatically handle clicks on the Home/Up button, so long
            // as you specify a parent activity in AndroidManifest.xml.
            int id = item.ItemId;

            //noinspection SimplifiableIfStatement
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}