using System;
namespace Schnitzeljagd_App
{
	public abstract class DataPoint
	{
        protected DateTime date;
        protected DataPoint prevData;
        protected int timeDiff;
		public DataPoint()
		{
			date = DateTime.Now;
		}
		public DataPoint(DataPoint data) 
		{
			this.prevData = data;
			date = DateTime.Now;
            if (prevData != null) timeDiff = prevData.getTimeDiff() + getDt(prevData);
		}
		public DateTime getDate() { return date;}
		public DataPoint getPrevData() { return prevData;}
		public int getDt(DataPoint d)
		{
			TimeSpan timeDiffrence = d.date - this.date;
			return (int)timeDiffrence.TotalMilliseconds;
		}
		public DataPoint getPrev()
		{
			return prevData;
		}
        public int getTimeDiff() { return timeDiff; }
        public void Shrink()
        {
			if (prevData != null && prevData.getPrev() != null)
			{
				this.prevData = prevData.getPrev();
				this.prevData.Shrink();
			}
        }
	}
}
