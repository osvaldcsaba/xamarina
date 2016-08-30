using System;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using AndroidSQLite.Resources.Model;
using AndroidSQLite.Resources.DataHelper;
using AndroidSQLite.Resources;
using Android.Util;


namespace AndroidSQLite
{
    [Activity(Label = "AndroidSQLiteAdatbazis", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView lstData;
        List<Szemely> lstSource = new List<Szemely>();
        DataBase db;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            // Adatbázis létrehozása
            db = new DataBase();
            db.createDataBase();

            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            // Log.Info("DB_PATH", folder);

            lstData = FindViewById<ListView>(Resource.Id.listView);

            var edtName  = FindViewById<EditText>(Resource.Id.edtName);
            var edtAge   = FindViewById<EditText>(Resource.Id.edtAge);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);

            var btnAdd    = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit   = FindViewById<Button>(Resource.Id.btnEdit);
            var btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

            // Adat(ok) betöltése
            LoadData();

            // Események
            // Felvitel
            btnAdd.Click += delegate
            {
                Szemely szemely = new Szemely() {
                    Name  = edtName.Text,
                    Age   = int.Parse(edtAge.Text),
                    Email = edtEmail.Text
                };
                db.insertIntoTableSzemely(szemely);
                LoadData();
            };
            // Módosítás
            btnEdit.Click += delegate {
                Szemely szemely = new Szemely()
                {
                    Id=int.Parse(edtName.Tag.ToString()),
                    Name  = edtName.Text,
                    Age   = int.Parse(edtAge.Text),
                    Email = edtEmail.Text
                };
                db.updateTableSzemely(szemely);
                LoadData();
            };
            // Törlés
            btnDelete.Click += delegate {
                Szemely szemely = new Szemely()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name  = edtName.Text,
                    Age   = int.Parse(edtAge.Text),
                    Email = edtEmail.Text
                };
                db.deleteTableSzemely(szemely);
                LoadData();
            };
            // Listaelem kiválasztás
            lstData.ItemClick += (s,e) =>{
                // Kiválasztott elem háttere
                for(int i = 0; i < lstData.Count; i++)
                {
                    if (e.Position == i)
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkGray);
                    else
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);

                }

                // Adatok beolvasása...
                var txtName  = e.View.FindViewById<TextView>(Resource.Id.textView1);
                var txtAge   = e.View.FindViewById<TextView>(Resource.Id.textView2);
                var txtEmail = e.View.FindViewById<TextView>(Resource.Id.textView3);

                edtName.Text = txtName.Text;

                edtName.Tag   = e.Id;
                edtAge.Text   = txtAge.Text;
                edtEmail.Text = txtEmail.Text;

            };

        }

        private void LoadData()
        {
            lstSource = db.selectTableSzemely();
            var adapter = new ListViewAdapter(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}