using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Support.V4.View;
using Android.Util;

namespace DemoMvvmCross.Core.Droid.ViewPagers
{
    public class NonSwipeableViewPager : ViewPager
    {
        private bool Enabled;

        public NonSwipeableViewPager(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {

        }

        public NonSwipeableViewPager(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.Enabled = true;
        }


        public override bool OnTouchEvent(MotionEvent e)
        {
            if (this.Enabled)
            {
                return base.OnTouchEvent(e);
            }
            return false;
        }

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            if (this.Enabled)
            {
                return base.OnInterceptTouchEvent(ev);
            }
            return false;
        }

        public void SetPagingEnabled(bool enabled)
        {
            this.Enabled = enabled;
        }
    }
}