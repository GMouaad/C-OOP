using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace MessBox
{
    public class Dialog_Pairing : DialogFragment
    {
        public Dialog_Pairing()
        {
        }
        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Dialog_Pairing, container, false);
            return view;
        }
    }
}
