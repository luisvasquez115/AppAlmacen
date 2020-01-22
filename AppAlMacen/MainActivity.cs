using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using AppAlmacen.Actividades;

namespace AppAlmacen
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]

    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        List<Android.Support.V4.App.Fragment> fragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            fragment = new List<Android.Support.V4.App.Fragment>();
            fragment.Add(new FragmentHome());
            fragment.Add(new Fragment_DespachoSucursal());
            fragment.Add(new Fragment_InventarioPaquetes());
            fragment.Add(new Fragment_HistorialPaquetes());

            SupportFragmentManager.BeginTransaction()
                                    .Replace(Resource.Id.content_frame, fragment[0])
                                    .Commit();

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this); 
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
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
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        //private void FabOnClick(object sender, EventArgs eventArgs)
        //{
        //    View view = (View) sender;
        //    Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
        //        .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        //}

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                SupportFragmentManager.BeginTransaction()
                                        .Replace(Resource.Id.content_frame, fragment[0])
                                        .Commit();
                /*Intent activity2 = new Intent(this, typeof(Actividades.Activity1));
                //activity2.PutExtra("user", ;);
                StartActivity(activity2);*/
            }
            else if (id == Resource.Id.nav_gallery)
            {
                SupportFragmentManager.BeginTransaction()
                                        .Replace(Resource.Id.content_frame, fragment[1])
                                        .Commit();
            }
            else if (id == Resource.Id.nav_slideshow)
            {
                SupportFragmentManager.BeginTransaction()
                                        .Replace(Resource.Id.content_frame, fragment[2])
                                        .Commit();
            }
            //else if (id == Resource.Id.nav_manage)
            //{
            //    SupportFragmentManager.BeginTransaction()
            //                            .Replace(Resource.Id.content_frame, fragment[3])
            //                            .Commit();
            //}
            //else if (id == Resource.Id.nav_share)
            //{

            //}
            //else if (id == Resource.Id.nav_send)
            //{

            //}

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

