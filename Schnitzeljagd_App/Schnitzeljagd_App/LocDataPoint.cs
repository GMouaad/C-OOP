using System;
using Android.Locations;

namespace Schnitzeljagd_App
{
	public class LocDataPoint : DataPoint , LocationData
	{
		private Location location;
		private double distance;
		public LocDataPoint(Location location) : base()
		{
			this.location = location;
		}

		public double getDistance(Location loc)
		{
			return (double)location.DistanceTo(loc);
		}
		public double getDistance(LocDataPoint locDataPoint)
		{
			return (double)locDataPoint.getDistance(location);
		}
		public double getHeight()
		{
			return location.Accuracy;
		}

		public double getLat()
		{
			return location.Latitude;
		}

		public double getLong()
		{
			return location.Longitude;
		}

		public double getSpeed()
		{
			return location.Speed;
		}
	}
}
