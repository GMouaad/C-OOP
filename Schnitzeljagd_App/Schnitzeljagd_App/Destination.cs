using System;
using Android.Locations;

namespace Schnitzeljagd_App
{
	public class Destination
	{
		private Location location;
		private String message;
		public Destination(Location location , String message)
		{
			this.location = location;
			this.message = message;
		}
		public Location getLocation() {
			return location;
		}
		public String getMessage() {
			return message;
		}
	}
}
