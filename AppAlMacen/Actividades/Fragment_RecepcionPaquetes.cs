using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace AppAlmacen.Actividades
{
    public class Fragment_RecepcionPaquetes : Android.Support.V4.App.Fragment
    {
        Spinner SpinnerEstado;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_recepcionPaquetes, container, false);

            SpinnerEstado = view.FindViewById<Spinner>(Resource.Id.spinnerEstado);

            setSpinner();

            return view;
        }

        private void setSpinner()
        {
            List<string> mitems = new List<string>();
            mitems.Add("Seleccionar un Estado");
            mitems.Add("Estado 2");
            mitems.Add("Estado 3");
            mitems.Add("Estado 4");
            ArrayAdapter adapter = new ArrayAdapter(this.Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, mitems);
            SpinnerEstado.Adapter = adapter;

        }
    }
}