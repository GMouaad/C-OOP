
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
	public class SpeedDiagram : Diagram
	{
		public SpeedDiagram(Context context) :
			base(context)
		{
			Initialize();
		}

		public SpeedDiagram(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			Initialize();
		}

		public SpeedDiagram(Context context, IAttributeSet attrs, int defStyle) :
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
				return locDataPoint.getSpeed()*3.6;
			}
			catch (Exception)
			{ 
				Toast toast = Toast.MakeText(this, "Error occurred !", ToastLength.Long);
				toast.Show();
			
			}
		}
	}
}
