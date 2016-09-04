using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MySql.Data.MySqlClient;
using System.Data;

namespace Adatb.MySQL
{
    [Activity(Label = "Adatb.MySQL", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText VtxtNev, VtxtEmail;
        private Button VbtnFelvitel;
        private TextView VtxtRendszer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            VtxtNev      = FindViewById<EditText>(Resource.Id.txtNev);
            VtxtEmail    = FindViewById<EditText>(Resource.Id.txtEmail);
            VbtnFelvitel = FindViewById<Button>(Resource.Id.btnFelvitel);
            VtxtRendszer = FindViewById<TextView>(Resource.Id.txtRendszer);

            VbtnFelvitel.Click += VbtnFelvitel_Click;



        }

        private void VbtnFelvitel_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=192.168.1.70;Port=3306;database=teszt;User Id=root;Password=csaba73;charset=utf8");
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    //VtxtRendszer.Text = "Adatbázis kapcsolat OK!";
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tabla(nev,email) VALUES(@nev,@email)", conn);
                    cmd.Parameters.AddWithValue("@nev", VtxtNev.Text);
                    cmd.Parameters.AddWithValue("@email", VtxtEmail.Text);
                    cmd.ExecuteNonQuery();
                    VtxtRendszer.Text = "Adatfelvitel OK!";
                }
            }
            catch (MySqlException ex)
            {
                VtxtRendszer.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            
        }
    }
}

