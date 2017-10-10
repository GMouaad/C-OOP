using Android.App;
using Android.Widget;
using Android.OS;

namespace MessBox
{
	[Activity(Label = "MessBox", MainLauncher = true, Icon = "@drawable/kugel_icon", Theme="@style/CustomActionBarTheme")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			ActionBar.SetCustomView(Resource.Layout.ActionBar);
            ActionBar.SetDisplayShowCustomEnabled(true);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.myButton);
			//button.Click += delegate { button.Text = $"{count++} clicks!"; };
		}
	}
}

