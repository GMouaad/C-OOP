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

            //Get the default actionbar instance
            //ActionBar mActionBar = getActionBar();
            //mActionBar.setDisplayShowHomeEnabled(false);
            //mActionBar.setDisplayShowTitleEnabled(false);

            //Initializes the custom action bar layout
            //LayoutInflater mInflater = LayoutInflater.from(this);
            //View mCustomView = mInflater.inflate(R.layout.custom_actionbar, null);
            //mActionBar.setCustomView(mCustomView);

            mActionBar.SetCustomView(Resource.Layout.mActionBar);
            mActionBar.SetDisplayShowCustomEnabled(true);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.ActionBar);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.myButton);
			//button.Click += delegate { button.Text = $"{count++} clicks!"; };
		}
	}
}

