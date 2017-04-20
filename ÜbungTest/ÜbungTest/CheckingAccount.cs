using System;
namespace ÜbungTest
{
	public class CheckingAccount : Account
	{
		double drawingCredit;
		public CheckingAccount() : base(iBan)
		{
			this.drawingCredit = 0.0;
		}
		public void setDrawingCredit(double drawingCredit)
		{
			this.drawingCredit = drawingCredit;
		}
		public double getdrawingCredit()
		{
			return drawingCredit;
		}
	}
}
