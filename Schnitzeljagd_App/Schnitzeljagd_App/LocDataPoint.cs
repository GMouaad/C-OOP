using System;
using Android.Locations;

namespace Schnitzeljagd_App
{
	public class LocDataPoint : DataPoint , ILocationData
	{
		private Location location;
		private double distance = 0;
        private static int count = 0;
		public LocDataPoint(Location location) : base()
		{
			this.location = location;
		}
		public LocDataPoint(Location loc, LocDataPoint prevData) : base(prevData)
		{
			this.location = loc;
			count++;
			if (count > 999)
			{
				this.Shrink();
				count /= 2;
			}
			if (prevData != null) distance = prevData.getDistanceTravelled() + getDistance(prevData);
			// calculate distance to first element in list

		}
		public double getDistance(Location loc)
		{
			return (double)location.DistanceTo(loc);
		}
		public double getDistance(LocDataPoint locDataPoint)
		{
			return (double)locDataPoint.getDistance(location);
		}
        public double getDistanceTravelled() { return distance; }

		public double getHeight(){ return location.Accuracy; }

		public double getLat() { return location.Latitude; }

		public double getLong() { return location.Longitude; }

		public double getSpeed()
{
			if (this.location.HasSpeed) return location.Speed;  // Speed is given in m/s
            else return 0.0;
		}
	}
}
