using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Graphics;
using System.Threading;

namespace CircularMenu
{
    [Activity(Label = "CircularMenu", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private LinearLayout container;

        private static readonly string TAG = "MainActivity";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            container = FindViewById<LinearLayout>(Resource.Id.container);

            CircularMenu circularMenu = new CircularMenu(this, container);

            circularMenu.InnerCircleText = "FIRST TEXT";
            circularMenu.InnerCircleTextColor = Color.Aqua;
            circularMenu.InnerCircleBackgroundColor = Color.Black;
            circularMenu.SetVisible(true);

        }
    }
}

