using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;

namespace MessBox
{
    public class mBluetoothManager
    {
        /*
        // Universal unique ID
        private const string uuid = "00000000-0000-1000-8000-00805F9B34FB";
        //respresents bluetooth data comming from  UART
        private BluetoothDevice result;
        // gets I/O Stream of this communication
        private BluetoothSocket socket;
        // converts byte[] to readable String
        private BufferedReader reader;

        private System.IO.Stream theStream;
        private System.IO.StreamReader theReader;

        public mBluetoothManager ()
        {
            reader = null;
        }


         private UUID getUUIDfromString()
        {
            return UUID.FromString(uuid);
        }
        private void close(IDisposable aConnectedObject)
        {
            if(aConnectedObject == null)
            {
                try
                {
                    aConnectedObject.Dispose();
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        public String getDataFromDevice()
        {
            return reader.ReadLine().ToString();
        }
        public void openDeviceConnection(BluetoothDevice btDevice)
        {
            try
            {
                // getting Socket from specific Device
                socket = btDevice.CreateRfcommSocketToServiceRecord(getUUIDfromString());

                socket.Connect();
                // Input Stream
                theStream = socket.InputStream;
                //  Output Stream
                //theStream = socket.OutputStream;
                theReader = new inputStreamReader(theStream);
                reader = new BufferedReader(theReader);
            }
            catch(IOException e)
            {
                // Close all
                close(socket);
                close(theStream);
                close(theReader);
                throw e;
                Toast toast = Toast.MakeText(this, "can't establish connection ", ToastLength.Long);
                toast.Show();
            }
        }

        public void getPairedDevices()
        {
            // Android Bluetooth Device
            BluetoothAdapter btAdapter = BluetoothAdapter.DefaultAdapter;
            var devices = btAdapter.BondedDevices;
            if(devices != null && devices.Count > 0)
            {
                // search through all devices 
                foreach ( BluetoothDevice mDevice in devices)
                {
                    openDeviceConnection(mDevice);
                }
            }
        }
        */






    }
}