using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

namespace Adatb.MySQL
{
    [Activity(Label = "Adatb.MySQL", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText VtxtNev, VtxtEmail;
        private Button VbtnFelvitel, VbtnListaz;
        private TextView VtxtRendszerF;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            VtxtNev       = FindViewById<EditText>(Resource.Id.txtNev);
            VtxtEmail     = FindViewById<EditText>(Resource.Id.txtEmail);
            VbtnFelvitel  = FindViewById<Button>(Resource.Id.btnFelvitel);
            VbtnListaz    = FindViewById<Button>(Resource.Id.btnListaz);
            VtxtRendszerF = FindViewById<TextView>(Resource.Id.txtRendszerF);

            VbtnFelvitel.Click += VbtnFelvitel_Click;
            VbtnListaz.Click += VbtnListaz_Click;

        }
        // Adatok listázása
        private void VbtnListaz_Click(object sender, EventArgs e)
        {
            List<String> adatbazisadatok = new List<string>();

            MySqlConnection conn = new MySqlConnection("Server=db4free.net;Port=3306;database=teszt;User Id=osvald73;Password=csaba73;charset=utf8");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    DataSet adatok = new DataSet();
                    string queryString = "SELECT * FROM tabla as tabla";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, conn);
                    adapter.Fill(adatok, "tabla");
                    foreach (DataRow sor in adatok.Tables["tabla"].Rows)
                    {
                        adatbazisadatok.Add(sor[0].ToString());
                    }
                    Toast.MakeText(this, "Adatok betöltése db4free.net-ről OK!", ToastLength.Long).Show();
                }
            }
            catch (MySqlException ex)
            {
                VtxtRendszerF.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        // Adatfelvitel
        private void VbtnFelvitel_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=db4free.net;Port=3306;database=teszt;User Id=osvald73;Password=csaba73;charset=utf8");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    //VtxtRendszerF.Text = "Adatbázis kapcsolat OK!";
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tabla(nev,email) VALUES(@nev,@email)", conn);
                    cmd.Parameters.AddWithValue("@nev", VtxtNev.Text);
                    cmd.Parameters.AddWithValue("@email", VtxtEmail.Text);
                    cmd.ExecuteNonQuery();
                    Toast.MakeText(this, "Adatfelvitel db4free.net-re OK!", ToastLength.Long).Show();
                }
            }
            catch (MySqlException ex)
            {
                VtxtRendszerF.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            
        }

        
    }
}

