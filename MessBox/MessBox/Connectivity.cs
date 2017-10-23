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

        // Controls from Layouts
        FrameLayout frameLayout11;
        LinearLayout linearLayout11, linearLayout12, linearLayout13, linearLayout14, linearLayout15;
        ImageView imageView11;
        Switch switch11, switch12;
        TextView textView11;
        ImageButton imageButton1;
        Button button1;

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
            //initialize();
            blue = BluetoothAdapter.DefaultAdapter;

            // Get Controls from Layout
            frameLayout11 = (FrameLayout)FindViewById<FrameLayout>(Resource.Id.frameLayout11);
            linearLayout11 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout11);
            linearLayout12 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout12);
            linearLayout13 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout13);
            linearLayout14 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout14);
            linearLayout15 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout15);
            imageView11 = (ImageView)FindViewById<ImageView>(Resource.Id.imageView11);
            switch11 = (Switch)FindViewById<Switch>(Resource.Id.switch11);
            switch12 = (Switch)FindViewById<Switch>(Resource.Id.switch12);
            textView11 = (TextView)FindViewById<TextView>(Resource.Id.textView11);
            imageButton1 = (ImageButton)FindViewById<ImageButton>(Resource.Id.imageButton1);
            button1 = (Button)FindViewById<Button>(Resource.Id.button1);

            // Register Events
            imageButton1.Click += SearchBtn_Clicked;
            button1.Click += SetWifiBtn_Clicked;

            // listen for SwitchState change
            switch12.CheckedChange += BtlConnectionSwitch_CheckedChange;
            switch11.CheckedChange += BltSwitch_CheckedChange;
        
        }

        // if Switch is enabled this methode checks if Bluetooth is enabled , if not it does.
        // if Switch is disabled this methode checks if Bluetooth is disabled , if not it does.
        void BltSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (switch11.Checked == true)
            {
                if (!blue.Enable())
                {
                    Intent o = new Intent(BluetoothAdapter.ActionRequestEnable);
                    StartActivityForResult(o, 0);
                    textView11.Text = "Bluetooth State: Enabled";
                }
                Toast.MakeText(this, "Enabled", ToastLength.Short).Show();
            }
            else
            {
                if (blue.Enable())
                {
                    blue.Disable();
                    Toast.MakeText(this, "Bluetooth Disabled", ToastLength.Short).Show();
                    textView11.Text = "Bluetooth State: Disabled";
                }
            }
        }
        void BtlConnectionSwitch_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Toast.MakeText(this, "Not Implimented yet!", ToastLength.Short).Show();
        }

        private void SetWifiBtn_Clicked(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Not Implimented yet!", ToastLength.Short).Show();
        }

        //This methode will open a Dialog , make the Device visible , pair with other Devices
        private void SearchBtn_Clicked(object sender, EventArgs e)
        {
            //Make Device visible
            Intent visible = new Intent(BluetoothAdapter.ActionRequestDiscoverable);
            StartActivityForResult(visible, 0);

            // Pull up Pairing Dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_Pairing SearchPairDialog = new Dialog_Pairing();
            SearchPairDialog.Show(transaction,"Diaog fragment");


        }

        public void initialize()
        {
           

        }

    }
}