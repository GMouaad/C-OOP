using System;
namespace Schnitzeljagd_App
{
	public abstract class DataPoint
	{
		private DateTime date;
		private DataPoint prevData;
		public DataPoint()
		{
			date = DateTime.Now;
		}
		public DataPoint(DataPoint data) 
		{
			this.prevData = data;
			date = DateTime.Now;
		}
		public DateTime getDate() { return date;}
		public DataPoint getPrevData() { return prevData;}
		public int getDt(DataPoint d)
		{
			TimeSpan timeDiff = d.date - this.date;
			return (int)timeDiff.TotalMilliseconds;
		}
	}
}
