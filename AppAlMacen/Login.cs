using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Preferences;

namespace AppAlmacen
{
    [Activity(Label = "EPS", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.Material.NoActionBar")]
    public class Login : Activity
    {
        Button btnEntrar;
        EditText nombre, clave;
        string f;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                if (ActionBar != null)
                    ActionBar.Hide();
                this.Window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                bool login = prefs.GetBoolean("key_login_successfully", default);
                if (login)
                {
                    string nombreUsuario = prefs.GetString("nombre", default);
                    SaveCredentials(nombreUsuario, false);
                    Toast.MakeText(this, "Este usuario está logueado " + nombreUsuario, ToastLength.Short).Show();
                    return;
                }
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Login);
                btnEntrar = FindViewById<Button>(Resource.Id.button1);
                nombre = FindViewById<EditText>(Resource.Id.editText1);
                clave = FindViewById<EditText>(Resource.Id.editText2);


                btnEntrar.Click += BtnEntrar_Click;


            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, "Ha ocurrido un error" + ex.Message.ToString(), ToastLength.Long).Show();
            }
        }


        private async void BtnEntrar_Click(object sender, System.EventArgs e)
        {

            Intent activity2 = new Intent(this, typeof(MainActivity));
            activity2.PutExtra("user", "luis");
            StartActivity(activity2);
            Finish();
            return;

            if (ValidarUsuario(nombre.Text.Trim()))
            {
                Toast.MakeText(this, "Debe Ingresar un nombre de usuario valido.", ToastLength.Short).Show();
                return;
            }
            if (ValidarContrasena(clave.Text.Trim()))
            {
                Toast.MakeText(this, "Debe Ingresar una contrasena valida.", ToastLength.Short).Show();
                return;
            }
            f = await API.ApiClient.Autenticar(nombre.Text.Trim(), clave.Text.Trim());
            if (f == "NotConnection")
            {
                Toast.MakeText(this, "Sin conexion a internet." + f.ToString(), ToastLength.Long).Show();
                return;
            }
            if (f.ToString() == "2")
            {
                SaveCredentials(nombre.Text.Trim(), false);
            }
            else if (f.ToString() == "4")
            {
                Toast.MakeText(this, "Su cuenta ha expirado.Llamar al Departamento de Informatica." + f.ToString(), ToastLength.Long).Show();
                return;
            }
            else if (f.ToString() == "3")
            {
                Toast.MakeText(this, "Su Usuario Se encuentra inactivo. Llamar al Departamento de Informatica." + f.ToString(), ToastLength.Long).Show();
                return;
            }
            else if (f.ToString() == "5")
            {
                Toast.MakeText(this, "Su Usuario Se encuentra inactivo. Llamar al Departamento de Informatica." + f.ToString(), ToastLength.Long).Show();
                return;
            }
            else if (f.ToString() == "6")
            {
                Toast.MakeText(this, "Datos incorrectos! verifique su usuario o clave y vuelva a intentarlo." + f.ToString(), ToastLength.Long).Show();
                return;
            }
            //Toast.MakeText(this, "devolvio " + f.ToString(), ToastLength.Long).Show();
        }

        public void SaveCredentials(string userName, bool inicio)
        {
            if (!inicio)
            {
                ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = preferences.Edit();
                editor.PutBoolean("key_login_successfully", true);
                editor.PutString("nombre", userName);
                editor.Apply();
            }
            Intent activity2 = new Intent(this, typeof(MainActivity));
            activity2.PutExtra("user", userName);
            StartActivity(activity2);
            Finish();

        }
        public bool ValidarUsuario(string usuario)
        {
            return string.IsNullOrEmpty(usuario) ? false : true;
        }
        public bool ValidarContrasena(string clave)
        {
            return string.IsNullOrEmpty(clave) ? false : true;
        }
    }
}