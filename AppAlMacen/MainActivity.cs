using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using AppAlmacen.Actividades;

namespace AppAlmacen
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]

    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        public static List<Android.Support.V4.App.Fragment> fragment;
        public static NavigationView navigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            fragment = new List<Android.Support.V4.App.Fragment>();
            fragment.Add(new FragmentHome());
            fragment.Add(new Fragment_RecepcionPaquetes());
            fragment.Add(new Fragment_InventarioPaquetes());
            fragment.Add(new fragment_TransitoPaquetes());
            fragment.Add(new fragment_ConsultaPaquetes());
            fragment.Add(new fragment_PreparacionDespacho());
            fragment.Add(new fragment_PreparacionConduce());
            fragment.Add(new Fragment_DespachoSucursal());

            SupportFragmentManager.BeginTransaction()
                                    .Replace(Resource.Id.content_frame, fragment[0])
                                    .Commit();

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            //deshabilitar opciones dentro del menu
            //DisableItemOnMenu(0, false);

            //deshabilitar opciones dentro del submenu
            //navigationView.Menu.GetItem(5).SubMenu.GetItem(0).SetVisible(false);
        }

        public void DisableItemOnMenu(int Item, bool IsVisible)
        {
            if (IsVisible)
                navigationView.Menu.GetItem(Item).SetVisible(true);
            else
                navigationView.Menu.GetItem(Item).SetVisible(false);
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
                drawer.CloseDrawer(GravityCompat.Start);
            else
                base.OnBackPressed();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = preferences.Edit();
                editor.Remove("key_login_successfully");
                editor.Apply();

                Intent login = new Intent(this, typeof(Login));
                StartActivity(login);
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int sizeSub = navigationView.Menu.GetItem(5).SubMenu.Size();
            for (int i = 0; i < sizeSub; i++)
                navigationView.Menu.GetItem(5).SubMenu.GetItem(i).SetChecked(false);

            int id = item.ItemId;

            switch (id)
            {
                case Resource.Id.nav_camera:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[0])
                                            .Commit();
                    break;
                case Resource.Id.nav_gallery:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[1])
                                            .Commit();
                    break;
                case Resource.Id.nav_slideshow:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[2])
                                            .Commit();
                    break;
                case Resource.Id.nav_transito:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[3])
                                            .Commit();
                    break;
                case Resource.Id.nav_consulta:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[4])
                                            .Commit();
                    break;
                case Resource.Id.nav_despacho:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[5])
                                            .Commit();
                    break;
                case Resource.Id.nav_conduce:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[6])
                                            .Commit();
                    break;
                case Resource.Id.nav_despachoSucursal:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[7])
                                            .Commit();
                    break;
                default:
                    SupportFragmentManager.BeginTransaction()
                                            .Replace(Resource.Id.content_frame, fragment[0])
                                            .Commit();
                    break;
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start, true);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

