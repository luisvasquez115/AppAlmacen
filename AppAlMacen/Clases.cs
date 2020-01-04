using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AppAlmacen
{
    public class MyNavigationItemSelectedListener : Java.Lang.Object, NavigationView.IOnNavigationItemSelectedListener
    {
        Context context;
        public MyNavigationItemSelectedListener(Context context)
        {
            this.context = context;
        }


        bool NavigationView.IOnNavigationItemSelectedListener.OnNavigationItemSelected(IMenuItem menuItem) 
        {
            int id = menuItem.ItemId;

            if (id == Resource.Id.nav_camera)
            {
                Intent intent = new Intent(context, typeof(Actividades.Activity1));  //the activity you want to open
                context.StartActivity(intent);

            }


            return true;
        }
    }
}