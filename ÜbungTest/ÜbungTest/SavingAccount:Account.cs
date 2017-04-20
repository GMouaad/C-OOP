using System;
namespace ÜbungTest
{
	public class SavingAccount : Account
	{
		private double interestRate;
		public SavingAccount():base(iBan)
		{
			this.interestRate = 0.0;
		}
		public void setInterestRate(double interestRate) 
		{
			this.interestRate = interestRate;
		}
		public double getInterestRate()
		{
			return interestRate;
		}
	}
}
