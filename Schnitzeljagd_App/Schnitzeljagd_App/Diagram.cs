
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
    public abstract class Diagram : View
    {
        private DataPoint dataPoint;
        private double min, max, average;
        public double getMin () {return min; }
        public double getMax (){return max; }
        public double getAverage (){return average; }
        public void setDataPoint(DataPoint dataPoint)
        {
            this.dataPoint = dataPoint;
        }
        public Diagram(Context context) :base(context)
        {
            Initialize();
        }
        public Diagram(Context context, IAttributeSet attrs) :base(context, attrs)
        {
            Initialize();
        }
        public Diagram(Context context, IAttributeSet attrs, int defStyle) :base(context, attrs, defStyle)
        {
            Initialize();
        }
        void Initialize()
        {
        }
        protected abstract double getValue(DataPoint data);
        public override void OnDrawForeground(Android.Graphics.Canvas canvas)
        {
            base.OnDrawForeground(canvas);
            while (dataPoint != null)
            {
                if (getValue(dataPoint)< min)
                {
                    min = getValue(dataPoint);
                }
				if (getValue(dataPoint) > max)
				{
					max = getValue(dataPoint);
				}
                average = (average + getValue(dataPoint)) / 2; 
            }

        }
    }
}
