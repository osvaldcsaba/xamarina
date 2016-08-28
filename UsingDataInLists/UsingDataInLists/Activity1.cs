using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Data;
using Mono.Data.Sqlite;
using Mono.Data.Tds;

namespace UsingDataInLists
{
    [Activity(Label = "SQLiteAdatbazisLista", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            PopulateCustomersList();
        }

        private void PopulateCustomersList()
        {
            ListView listCustomers = FindViewById<ListView>(Resource.Id.listCustomers);
            // Adatbázis létrehozása
            vtcDatabase vtcDatabase = new vtcDatabase("ListData");
            Android.Database.ICursor cursor = vtcDatabase.GetRecordCursor();
            if (cursor != null)
            {
                cursor.MoveToFirst();
                string[] from = new string[] { "_id", "Nev", "Email", "Telefon" };
                int[] to = new int[] {
                    Resource.Id.CustomerID,
                    Resource.Id.CustomerName,
                    Resource.Id.CustomerEmail,
                    Resource.Id.CustomerPhone
                };
                // 
                SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, Resource.Layout.CustomerItem, cursor, from, to);
                listCustomers.Adapter = adapter;
            }
        }


    }
}

