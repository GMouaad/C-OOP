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
using Android.Locations;

namespace Schnitzeljagd_App
{
	public class GameActivity : Activity, ILocationListener
	{

		private LocationManager locMan;
		private TextView txtLongitude;
		private TextView txtLatitude;
		private TextView txtHeight;
		private TextView txtVel;
		private TextView txtDist;
		private TextView txtMessage;
		public GameActivity()
		{

		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.TextViewsLayout);

			txtLongitude = FindViewById<TextView>(Resource.Id.textLongitude);
			txtLatitude = FindViewById<TextView>(Resource.Id.textLatitude);
			txtHeight = FindViewById<TextView>(Resource.Id.textHeight);
			txtVel = FindViewById<TextView>(Resource.Id.textVel);
			txtDist = FindViewById<TextView>(Resource.Id.textDistance);
			txtMessage = FindViewById<TextView>(Resource.Id.textDestReached);

			locMan = GetSystemService(Context.LocationService) as LocationManager;

			// Generate TreasureHunt

			Location[] locs = new Location[3];
			TreasureHunt hunt;

			for (int i = 0; i < locs.Length; i++)
			{
				locs[i] = new Location("gps");
			}
			locs[0].Latitude = 47.666735;
			locs[0].Longitude = 9.171735;
			locs[1].Latitude = 47.665877;
			locs[1].Longitude = 9.174154;
			locs[2].Latitude = 47.658395;
			locs[2].Longitude = 9.171163;

			string[] messages = new string[3];
			messages[0] = "Take a picture of street sign \"Rheingutstrasse\"";
			messages[1] = "Take a picture of the bus stop";
			messages[2] = "Take a picture of the crossing";

			hunt = TreasureHunt.GenerateHunt(locs, messages);

			for (int i = 0; i <= locs.Length; i++)
			{
				locs[i].DistanceTo(hunt.getActLocation());
			}
				

		}
		public void OnLocationChanged(Location location)
		{
			//Setting up the TextViews
			txtLongitude.Text = "Current Longtitude : " + Convert.ToString(location.Longitude);
			txtLatitude.Text = "Current Latitude : " + Convert.ToString(location.Latitude);
			txtHeight.Text = "Current Height : " + Convert.ToString(location.Altitude);
			txtVel.Text = "Current Longtitude : " + Convert.ToString((location.Speed) * 3.6) + "km/h" ; // convert speed to km/h and print it




		}

		public void OnProviderDisabled(string provider)
		{
			Toast toast = Toast.MakeText(this, "GPS disabled", ToastLength.Long);
			toast.Show();
		}

		public void OnProviderEnabled(string provider)
		{
			Toast toast = Toast.MakeText(this, "GPS enabled", ToastLength.Long);
			toast.Show();
		}
		protected override void OnResume()
		{

			//locMan.RequestLocationUpdate(LocationManager.GpsProvider, 50, 0, this);
		}
		protected override void OnPause()
		{
			locMan.RemoveUpdates(this);
		}

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
			//throw new NotImplementedException();
		}
	}
}
