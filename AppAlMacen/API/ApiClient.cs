using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppAlmacen.API
{
    public class ApiClient
    {
        public static async Task<string> Autenticar(string nombre, string clave)
        {
            if (CheckInternetConnection() == false)
                return "NotConnection";
            string login;
            var restPay = "http://192.168.199.228:3333//api/prueba/nombre/clave?nombre=" + nombre + "&clave=" + clave + "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(restPay));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);
                    login = jsonDoc.ToString();
                }
            }

            return login;
        }

        public static bool CheckInternetConnection()
        {
            string CheckUrl = "http://192.168.199.228:3333/api/Values" +
                "";
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 3000;
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