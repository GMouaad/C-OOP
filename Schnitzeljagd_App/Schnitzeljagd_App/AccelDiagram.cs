
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Schnitzeljagd_App
{
	public class AccelDiagram : Diagram
	{
		public AccelDiagram(Context context) :
			base(context)
		{
			Initialize();
		}

		public AccelDiagram(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			Initialize();
		}

		public AccelDiagram(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
			Initialize();
		}

		void Initialize()
		{
		}
		protected override double getValue(DataPoint data)
		{
			try
			{
				LocDataPoint locDataPoint = (LocDataPoint)data;
				LocDataPoint prev_ldp = (LocDataPoint)data.getPrev();
				double Accel = (locDataPoint.getSpeed() - prev_ldp.getSpeed())/data.getTimeDiff();

				return Accel;
			}
			catch (Exception)
			{
				Toast toast = Toast.MakeText(this, "Error occurred !", ToastLength.Long);
				toast.Show();

			}
		}
	}
}
