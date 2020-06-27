
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
using Android.Media;

namespace AppAlmacen.Actividades
{
    public class Fragment_DespachoSucursal : Android.Support.V4.App.Fragment
    {
        EditText txtCodigo, txtBolsa, txtSucursal, txtAgencia;
        Button btnBuscar;
        Ringtone RingToneGood = null;
        Ringtone RingToneError = null;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_despachoSucursal, container, false);

            txtCodigo = view.FindViewById<EditText>(Resource.Id.txtCodigo);
            txtBolsa = view.FindViewById<EditText>(Resource.Id.txtBolsa);
            txtSucursal = view.FindViewById<EditText>(Resource.Id.txtSucursal);
            txtAgencia = view.FindViewById<EditText>(Resource.Id.txtAgencia);
            btnBuscar = view.FindViewById<Button>(Resource.Id.btnBuscar);

            RingToneGood = RingtoneManager.GetRingtone(this.Context, Android.Net.Uri.Parse(@"android.resource://" + this.Context.PackageName + "/" + Resource.Raw.goodreads));
            RingToneError = RingtoneManager.GetRingtone(this.Context, Android.Net.Uri.Parse(@"android.resource://" + this.Context.PackageName + "/" + Resource.Raw.Alarm2));


            return view;
        }
    }
}