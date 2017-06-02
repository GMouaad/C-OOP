using System;
using Android.Locations;

namespace Schnitzeljagd_App
{
	public class TreasureHunt
	{
		private Destination[] destinationArray;
		private int position;
		public TreasureHunt(Destination[] destinationArray)
		{
			this.destinationArray = destinationArray;
		}
		public Location getActLocation()
		{
			return destinationArray[position].getLocation();
		}
		public int getPosition()
		{
			return position;
		}
		public String getActMessageM(Destination destinationObj)
		{
			return destinationArray[position].getMessage();
		}
		public bool Next()
		{
			position++;
			if (position == destinationArray.Length)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public static TreasureHunt GenerateHunt(Location[] locationArray, String[] messages)
		{
			if (locationArray.Length != messages.Length) // check if arrays match
			{
				throw new Exception("locs and messages don't have same length");
			}
			else
			{
				Destination[] dest = new Destination[locationArray.Length];
				for (int i = 0; i < locationArray.Length; i++)
				{
					dest[i] = new Destination(locationArray[i], messages[i]); // generate Destination objects
				}
				return new TreasureHunt(dest);
			}
		}
	}
}
