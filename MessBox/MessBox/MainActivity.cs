using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace MessBox
{
	[Activity(Label = "MessBox", MainLauncher = true, Icon = "@drawable/kugel_icon", Theme="@style/CustomActionBarTheme")]
	public class MainActivity : Activity
	{
        

        int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
            // Set ActionBar view
            ActionBar.SetCustomView(Resource.Layout.mActionBar);
            ActionBar.SetDisplayShowCustomEnabled(true);
			// Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            initialize();

			//button.Click += delegate { button.Text = $"{count++} clicks!"; };
		}
        private void initialize()
        {
            LinearLayout linearLayout1 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            LinearLayout linearLayout2 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            LinearLayout linearLayout3 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout3);
            LinearLayout linearLayout4 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout4);
            LinearLayout linearLayout5 = (LinearLayout)FindViewById<LinearLayout>(Resource.Id.linearLayout5);

            linearLayout1.Click += Home_clicked;
            linearLayout2.Click += Sensors_clicked;
            linearLayout3.Click += Scores_clicked;
            linearLayout4.Click += Connectivity_clicked;
            linearLayout5.Click += Info_clicked;


        }

        private void Info_clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }

        private void Connectivity_clicked(object sender, EventArgs e)
        {
            StartActivity(typeof(Connectivity));
        }

        private void Scores_clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }

        private void Sensors_clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }

        private void Home_clicked(object sender, EventArgs e)
        {
            Toast toast = Toast.MakeText(this, "Not implemented yet !", ToastLength.Long);
            toast.Show();
        }
    }
}

