
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

namespace Schnitzeljagd_App
{
    [Activity(Label = "SpeedActivity", Icon = "@mipmap/treasure_icon")]
    public class SpeedActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			// Set our view from the "Speed" layout resource
            SetContentView(Resource.Layout.Speed);
        }
    }
}
