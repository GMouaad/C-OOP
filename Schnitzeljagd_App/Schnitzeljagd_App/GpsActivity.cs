using System;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Widget;

namespace Schnitzeljagd_App
{
    [Activity(Label = "GpsActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class GpsActivity : Activity, ILocationListener
	{
        protected LocationManager locMan;
		//private LocDataPoint prevlocDataP = new LocDataPoint(???????); 
		public GpsActivity()
		{
		}

		public virtual void OnLocationChanged(Location location)
		{
            LocDataPoint locDataP = new LocDataPoint(location , DataStorage.getDataStorage().locDataPt);
            DataStorage.getDataStorage().locDataPt = locDataP; // set the new locDataPoint as the actual locdataPoint in the storage

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

		public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
		{
			//throw new NotImplementedException();
		}
		protected override void OnPause()
		{
            base.OnPause();

			locMan.RemoveUpdates(this);
		}
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			locMan = GetSystemService(Context.LocationService) as LocationManager; 
		}
		protected override void OnResume()
		{
			base.OnResume();

		}

	}
}
