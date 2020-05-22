
using Android.OS;
using Android.Views;
using Android.Widget;


using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using AppAlmacen.Actividades;

namespace AppAlmacen.Actividades
{
    public class Fragment_DespachoSucursal : Android.Support.V4.App.Fragment
    {
        EditText txtCodigo, txtBolsa, txtSucursal, txtAgencia;
        Button btnBuscar;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_despachoSucursal, container, false);

            txtCodigo = view.FindViewById<EditText>(Resource.Id.editText1);
            txtBolsa = view.FindViewById<EditText>(Resource.Id.editText2);
            txtSucursal = view.FindViewById<EditText>(Resource.Id.editText3);
            txtAgencia = view.FindViewById<EditText>(Resource.Id.editText4);
            btnBuscar = view.FindViewById<Button>(Resource.Id.button1);

            return view;
        }
    }
}