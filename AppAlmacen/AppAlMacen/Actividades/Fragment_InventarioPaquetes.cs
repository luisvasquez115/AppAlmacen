using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AppAlmacen.Clases;
using AppAlmacen.Wrappers;

namespace AppAlmacen.Actividades
{
    public class Fragment_InventarioPaquetes : Android.Support.V4.App.Fragment
    {
        EditText txtUbicacion, txtCodigo;
        Button btnBuscar;
        CheckBox disponibleParaEntregar;
        string usuario, ip;
        Ringtone RingTono2 = null;
        Ringtone RingTono3 = null;
        String sessionId;
        Bultos _bultosWS = new Bultos();
        BultosApp _bultos;
        AlertDialog _noDisponibleAlertDialog;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_inventarioPaquetes, container, false);

            txtUbicacion = view.FindViewById<EditText>(Resource.Id.editText1);
            txtCodigo = view.FindViewById<EditText>(Resource.Id.editText2);
            btnBuscar = view.FindViewById<Button>(Resource.Id.button1);
            disponibleParaEntregar = view.FindViewById<CheckBox>(Resource.Id.checkBox1);
            //usuario = Intent.GetStringExtra("user");

            RingTono2 = RingtoneManager.GetRingtone(this.Context, Android.Net.Uri.Parse(@"android.resource://" + this.Context.PackageName + "/" + Resource.Raw.goodreads));
            RingTono3 = RingtoneManager.GetRingtone(this.Context, Android.Net.Uri.Parse(@"android.resource://" + this.Context.PackageName + "/" + Resource.Raw.Alarm2));

            foreach (IPAddress adress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                ip = adress.ToString();
            }

            btnBuscar.Click += BtnBuscar_Click;
            txtCodigo.KeyPress += TxtCodigo_KeyPress;

            return view;
        }
        private void TxtCodigo_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keycode.Enter && e.Event.Action == KeyEventActions.Up)
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtUbicacion.Text.Trim()))
                        actualizar();
                    else
                        ReproducirAlertaError();
                }
            }
            catch (Exception ex)
            {
                ReproducirAlertaError();
            }
        }

        public string Chequear()
        {
            return disponibleParaEntregar.Checked ? "S" : "N";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtUbicacion.Text.Trim()))
                    actualizar();
                else
                    ReproducirAlertaError();
            }
            catch (Exception ex)
            {
                ReproducirAlertaError();
            }
        }

        public void ReproducirAlerta()
        {
            if (RingTono2.IsPlaying)
            {
                RingTono2.Stop();
                RingTono2.Play();
            }
            else
            {
                RingTono2.Play();
            }
        }

        public void ReproducirAlertaError()
        {
            if (RingTono3.IsPlaying)
            {
                RingTono3.Stop();
                RingTono3.Play();
            }
            else
            {
                RingTono3.Play();
            }
        }

        public void actualizar()
        {
            _bultos = _bultosWS.ActualizarInventarioPaquetes("", usuario, "001", txtCodigo.Text.Trim(),
                txtUbicacion.Text.Trim(), Chequear(), "1", ip);

            if (_bultos == null)
            {
                ReproducirAlertaError();
                LimpiarCodigo();
                return;
            }
            if (_bultos.BltNumero == 0)
            {
                ReproducirAlerta();
                if (_noDisponibleAlertDialog != null && _noDisponibleAlertDialog.IsShowing)
                    _noDisponibleAlertDialog.Hide();
                MostrarMensaje();
            }
            else
            {
                ReproducirAlertaError();
                if (_noDisponibleAlertDialog != null && _noDisponibleAlertDialog.IsShowing)
                    _noDisponibleAlertDialog.Hide();
                MostrarMensaje();
            }
            LimpiarCodigo();
        }

        public void MostrarMensaje()
        {
            using (var builder = new AlertDialog.Builder(this.Context))
            {
                var title = _bultos.BltTrackingNumber;
                builder.SetTitle(title);
                builder.SetNegativeButton("Aceptar", CancelAction);
                _noDisponibleAlertDialog = builder.Create();
                _noDisponibleAlertDialog.Show();
            }
        }

        public void CancelAction(object sender, DialogClickEventArgs e)
        {

        }

        public void LimpiarCodigo()
        {
            txtCodigo.Text = "";
        }
    }
}