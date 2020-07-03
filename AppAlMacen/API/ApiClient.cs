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
        static string URL_API = "http://192.168.199.228:3333";

        public static async Task<T> GetData<T>(string action,  object param)
        {
            try
            {
                var jsonRequest = param == null ? "{}" : Newtonsoft.Json.JsonConvert.SerializeObject(param);

                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new Uri(URL_API);
                    client.Timeout = new TimeSpan(0, 0, 30);

                    var content = new System.Net.Http.StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsync(action, content);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        var tp = await responseTask.Content.ReadAsStringAsync();

                        var serializerSettings = new Newtonsoft.Json.JsonSerializerSettings
                        {
                            DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat,
                            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local
                        };

                        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(tp, serializerSettings);
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static async Task<string> Autenticar(string nombre, string clave)
        {
            if (CheckInternetConnection() == false)
                return "NotConnection";
            string login;
            var restPay = $"{URL_API}//api/prueba/nombre/clave?nombre=" + nombre + "&clave=" + clave + "";
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
            string CheckUrl = $"{URL_API}/api/Values" +
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