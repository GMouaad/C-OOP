using Android.App;
using Android.Widget;
using Android.OS;
using Android.Locations;
using Android.Runtime;
using System;

namespace Schnitzeljagd_App
{
	[Activity(Label = "Treasure Hunt", MainLauncher = true, Icon = "@mipmap/treasure_icon")]
	public class MainActivity : GpsActivity
	{
		int count = 1;

		//Buttons in the main Layout
		private Button butGame;
		private Button butSpeed;
		private Button butMinGame1;
		private Button butMinGame2;
		private Button butMinGame3;

		//private LocationManager locMan;



		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			//setting the refferences to the id's
			butGame = FindViewById<Button>(Resource.Id.butGame);
			butSpeed = FindViewById<Button>(Resource.Id.butSpeed);
			butMinGame1 = FindViewById<Button>(Resource.Id.butMinGame1);
			butMinGame2 = FindViewById<Button>(Resource.Id.butMinGame2);
			butMinGame3 = FindViewById<Button>(Resource.Id.butMinGame3);

			butGame.Click += ButGame_Click;
			butSpeed.Click += ButSpeed_Click;
			butMinGame1.Click += ButMinGame1_Click;
			butMinGame2.Click += ButMinGame2_Click;
			butMinGame3.Click += ButMinGame3_Click;

			//button.Click += delegate { button.Text = $"{count++} clicks!"; };
		}


		//Event handling methods
		public void ButGame_Click(object sender, System.EventArgs e)
		{
			StartActivity(typeof(GameActivity));
		}

		public void ButSpeed_Click(object sender, System.EventArgs e)
		{
			Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
			toast.Show();
		}

		public void ButMinGame1_Click(object sender, System.EventArgs e)
		{
            StartActivity(typeof(MinGame_1_Activity));
		}

		public void ButMinGame2_Click(object sender, System.EventArgs e)
		{
			Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
			toast.Show();
		}

		public void ButMinGame3_Click(object sender, System.EventArgs e)
		{
			Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
			toast.Show();
		}

	}
}

