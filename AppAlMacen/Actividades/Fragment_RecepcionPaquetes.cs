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
using AppAlmacen.Clases;

namespace AppAlmacen.Actividades
{
    public class Fragment_RecepcionPaquetes : Android.Support.V4.App.Fragment
    {
        EditText txtCodigo, txtBolsa, txtSucursal, txtAgencia;
        Button btnBuscar;
        Spinner SpinnerEstado;
        BultosApp _bultos;
        string usuario;
        Android.App.AlertDialog _noDisponibleAlertDialog;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_recepcionPaquetes, container, false);

            txtCodigo = view.FindViewById<EditText>(Resource.Id.editText2);
            btnBuscar = view.FindViewById<Button>(Resource.Id.button1);
            SpinnerEstado = view.FindViewById<Spinner>(Resource.Id.spinnerEstado);


            SpinnerEstado.ItemSelected += SpinnerSelected;
            SetSpinner();

            return view;
        }

        private void SpinnerSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
        }

        private void SetSpinner()
        {
            List<string> mitems = new List<string>();
            mitems.Add("Seleccionar un Estado");
            mitems.Add("Estado 2");
            mitems.Add("Estado 3");
            mitems.Add("Estado 4");
            ArrayAdapter adapter = new ArrayAdapter(this.Context, Android.Resource.Layout.SimpleSpinnerDropDownItem, mitems);
            SpinnerEstado.Adapter = adapter;

        }

        public async System.Threading.Tasks.Task ActualizarAsync()
        {

            _bultos = await API.ApiClient.GetData<BultosApp>("proc_ActualizaEstadoPaquetesPistola",
                new
                {
                    Ret_Mensaje = "",
                    Ret_Tipo = 0,
                    RES_CODIGO = usuario,
                    BLT_CODIGO_BARRA = txtCodigo.Text.Trim(),
                    CON_CODIGO = "",
                    LOG_SESSION_ID = "1",
                    LOG_DIRECCION_IP = MainActivity.GetIp()
                });

            if (_bultos == null)
            {
                MainActivity.ReproducirAlertaError();
                LimpiarCodigo();
                return;
            }
            if (_bultos.BltNumero == 0)
            {
                MainActivity.ReproducirAlerta();
                if (_noDisponibleAlertDialog != null && _noDisponibleAlertDialog.IsShowing)
                    _noDisponibleAlertDialog.Hide();
                MostrarMensaje();
            }
            else if (_bultos.BltNumero == 1)
            {
                MainActivity.ReproducirAlertaError();
                if (_noDisponibleAlertDialog != null && _noDisponibleAlertDialog.IsShowing)
                    _noDisponibleAlertDialog.Hide();
                MostrarMensaje();
            }
            
            //Call proc_ActualizaEstadoPaquetesPistola(sRepresentate, x_BLT_CODIGO_BARRA, x_CON_CODIGOCur)
        }

        public void LimpiarCodigo()
        {
            txtCodigo.Text = "";
        }
        public void MostrarMensaje()
        {
            using (var builder = new Android.App.AlertDialog.Builder(this.Context))
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
    }
}