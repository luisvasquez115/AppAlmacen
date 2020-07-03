                                                                                                                                                                                      using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace AppAlmacen.Actividades
{
    public class FragmentHome : Android.Support.V4.App.Fragment
    {
        CardView menu_recepcion, menu_inventario, menu_transito, menu_consulta, menu_despacho, menu_conduce, menu_sucursales;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_home, container, false);

            menu_recepcion = view.FindViewById<CardView>(Resource.Id.menu_recepcion);
            menu_inventario = view.FindViewById<CardView>(Resource.Id.menu_inventario);
            menu_transito = view.FindViewById<CardView>(Resource.Id.menu_transito);
            menu_consulta = view.FindViewById<CardView>(Resource.Id.menu_consulta);
            menu_despacho = view.FindViewById<CardView>(Resource.Id.menu_despacho);
            menu_conduce = view.FindViewById<CardView>(Resource.Id.menu_conduce);
            menu_sucursales = view.FindViewById<CardView>(Resource.Id.menu_sucursales);


            var kl = MainActivity.navigationView.Menu.GetItem(2);
            menu_recepcion.Click  += delegate { ReplaceFragment(MainActivity.fragment[1], itemMenu: 1); };
            menu_inventario.Click += delegate { ReplaceFragment(MainActivity.fragment[2], itemMenu: 2); };
            menu_transito.Click   += delegate { ReplaceFragment(MainActivity.fragment[3], itemMenu: 3); };
            menu_consulta.Click   += delegate { ReplaceFragment(MainActivity.fragment[4], itemMenu: 4); };
            menu_despacho.Click   += delegate { ReplaceFragment(MainActivity.fragment[5], itemSubMenu: 0); };
            menu_conduce.Click    += delegate { ReplaceFragment(MainActivity.fragment[6], itemSubMenu: 1); };
            menu_sucursales.Click += delegate { ReplaceFragment(MainActivity.fragment[7], itemSubMenu: 2); };

            return view;
        }

        public void ReplaceFragment(Android.Support.V4.App.Fragment someFragment, int itemMenu = 0, int itemSubMenu = 0)
        {
            base.FragmentManager.BeginTransaction()
                                    .Replace(Resource.Id.content_frame, someFragment)
                                    .Commit();

            int size = MainActivity.navigationView.Menu.Size();
            for (int i = 0; i < size; i++)
            {
                MainActivity.navigationView.Menu.GetItem(i).SetChecked(false);
            }

            int sizeSub =  MainActivity.navigationView.Menu.GetItem(5).SubMenu.Size();
            for (int i = 0; i < sizeSub; i++)
            {
                MainActivity.navigationView.Menu.GetItem(5).SubMenu.GetItem(i).SetChecked(false);
            }

            if (itemMenu != 0)
                MainActivity.navigationView.Menu.GetItem(itemMenu).SetChecked(true);
            else 
                MainActivity.navigationView.Menu.GetItem(5).SubMenu.GetItem(itemSubMenu).SetChecked(true);
        }

    }
}