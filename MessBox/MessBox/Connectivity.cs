using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using BluetoothLE.Core;
using Java.Util;
//using BluetoothLE.Core.Events;

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
    public class Connectivity : Activity //, IBluetoothService
    {
        int count = 1;
        private string data = null;

        BluetoothAdapter blue;
        ListView List_If_Devices;
        EditText bluetoothName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set ActionBar visible
            ActionBar.SetCustomView(Resource.Layout.mActionBar);
            ActionBar.SetDisplayShowCustomEnabled(true);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Connectivity);
            initialize();
            blue = BluetoothAdapter.DefaultAdapter;



            
        }

        private void initialize()
        {
            FrameLayout frameLayout11 = (FrameLayout)FindViewById<FrameLayout>(Resource.Id.frameLayout11);
            LinearLayout linearLayout11 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout11);
            LinearLayout linearLayout12 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout12);
            LinearLayout linearLayout13 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout13);
            LinearLayout linearLayout14 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout14);
            LinearLayout linearLayout15 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout15);

            ImageView imageView11 = (ImageView)FindViewById<ImageView>(Resource.Id.imageView11);
            Switch switch11 = (Switch)FindViewById<Switch>(Resource.Id.switch11);
            TextView textView11 = (TextView)FindViewById<TextView>(Resource.Id.textView11);
            ImageButton imageButton1 = (ImageButton)FindViewById<ImageButton>(Resource.Id.imageButton1);
            Button button1 = (Button)FindViewById<Button>(Resource.Id.button1);


            switch11.Click += Switch11_clicked;
            imageButton1.Click += ImageButton_Clicked;
            button1.Click += Button1_Clicked;

        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }

        private void Switch11_clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }
    }
}