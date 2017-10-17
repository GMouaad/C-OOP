using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BluetoothLE.Core;
using Java.Util;
using BluetoothLE.Core.Events;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;

namespace MessBox
{
    [Activity(Label = "Connectivity")]
    public class Connectivity : Activity , IBluetoothService
    {
        int count = 1;
        private string data = null;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set ActionBar visible
            ActionBar.SetCustomView(Resource.Layout.ActionBar);
            ActionBar.SetDisplayShowCustomEnabled(true);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Connectivity);


            
        }
    }
}