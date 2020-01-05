using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppAlmacen.Clases;
using Newtonsoft.Json;
using System.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace AppAlmacen.Wrappers
{
    public class Bultos
    {
        ICollection<BultosApp> _bultosApp;
        BultosApp _bultosApp2;
        byte[] _byteFoto;

        public ICollection<BultosApp> ObtenerBultosClientesAEntregarPorUnCodigo(string bltCodigo, string codigoDespacho, int tipoBusqueda, string usuario)
        {
            if (CheckInternetConnection() == false)
                return _bultosApp;
            var restPay = "http://192.168.199.228:3333//app?bltCodigo=" + bltCodigo + "&codigoDespacho=" + codigoDespacho + "&tipoBusqueda=" + tipoBusqueda + "&usuario=" + usuario + "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(restPay));
            //request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);
                    _bultosApp = JsonConvert.DeserializeObject<ICollection<BultosApp>>(jsonDoc.ToString());
                }
            }

            return _bultosApp;
        }
        public BultosApp ActualizarInventarioPaquetes(string Ret_Mensaje, string RES_CODIGO, string SUC_CODIGO,
            string BLT_CODIGO_BARRA, string BLT_UBICACION, string BLT_ENTREGAR, string LOG_SESSION_ID,
            string LOG_DIRECCION_IP)
        {
            if (CheckInternetConnection() == false)
                return _bultosApp2;
            var restPay = @"http://192.168.199.228:3333//app/actualizar_inventario_paquetes?Ret_Mensaje=" + Ret_Mensaje +
                "&RES_CODIGO=" + RES_CODIGO + "&SUC_CODIGO=" + SUC_CODIGO + "&BLT_CODIGO_BARRA=" + BLT_CODIGO_BARRA +
                "&BLT_UBICACION=" + BLT_UBICACION + "&BLT_ENTREGAR=" + BLT_ENTREGAR + "&LOG_SESSION_ID=" + LOG_SESSION_ID +
                "&LOG_DIRECCION_IP=" + LOG_DIRECCION_IP + "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(restPay));
            //request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);
                    _bultosApp2 = JsonConvert.DeserializeObject<BultosApp>(jsonDoc.ToString());
                }
            }

            return _bultosApp2;
        }
        public byte[] ObtenerFotoCliente(string cedula)
        {
            if (CheckInternetConnection() == false)
                return _byteFoto;
            var restPay = "http://192.168.199.228:3333//app/ObtenerFotoCliente?cedula=" + cedula + "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(restPay));
            //request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);
                    _byteFoto = JsonConvert.DeserializeObject<byte[]>(jsonDoc.ToString());
                }
            }
            return _byteFoto;
        }
        public async Task<int> InsertarFoto(byte[] firma, string bltCodigoBarra, string cteNumeroEps, string usuario, string persona, string cedula, string codigoDespachoBulto, string codigoDespacho)
        {
            if (CheckInternetConnection() == false)
                return 8;
            var RestUrl = "http://192.168.199.228:3333/api/Insertar/InsertarFirmar?bltCodigoBarra=" + bltCodigoBarra + "&cteNumeroEps=" + cteNumeroEps + "&usuario=" + usuario + "&persona=" + persona + "&cedula=" + cedula + "&codigoDespachoBulto=" + codigoDespachoBulto + "&codigoDespacho=" + codigoDespacho + "";

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 2256000;

            var uri = new Uri(string.Format(RestUrl, string.Empty));
            var json = JsonConvert.SerializeObject(firma);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return 0;
            }
            else
            {
                return 9;
            }
        }
        public bool CheckInternetConnection()
        {
            string CheckUrl = "http://192.168.199.228:3333/api/Values";
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 200;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                // Console.WriteLine ("...connection established..." + iNetRequest.ToString ());
                iNetResponse.Close();
                return true;
            }
            catch (WebException ex)
            {
                // Console.WriteLine (".....no connection..." + ex.ToString ());
                return false;
            }
        }
    }
}