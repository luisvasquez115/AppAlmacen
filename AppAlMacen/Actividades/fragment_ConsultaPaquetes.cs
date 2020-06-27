using Android.OS;
using Android.Views;

namespace AppAlmacen.Actividades
{
    public class fragment_ConsultaPaquetes : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_consulta, container, false);


            return view;
        }
    }
}