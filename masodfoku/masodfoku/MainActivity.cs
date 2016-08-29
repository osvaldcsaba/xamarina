using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

namespace masodfoku
{
    [Activity(Label = "masodfoku", MainLauncher = true, Icon = "@drawable/icon", 
        ConfigurationChanges = ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            var Aertek = FindViewById<EditText>(Resource.Id.a_ertek);
            var Bertek = FindViewById<EditText>(Resource.Id.b_ertek);
            var Certek = FindViewById<EditText>(Resource.Id.c_ertek);
            var Szamol = FindViewById<Button>(Resource.Id.btnSzamol);
            var Eredmeny = FindViewById<TextView>(Resource.Id.txtEredmeny);

            Szamol.Click += (sender, e) =>
            {
                if (Aertek.Text == "" || Bertek.Text == "" || Certek.Text == "") {
                    Eredmeny.Text = "Hibás adat(ok)!";
                }
                else if (Double.Parse(Aertek.Text) == 0.0)
                {
                    Eredmeny.Text = "Nincs megoldása az egyenletnek!";
                }
                else
                {
                    Double D = Double.Parse(Bertek.Text) * Double.Parse(Bertek.Text) - (4 * Double.Parse(Aertek.Text) * Double.Parse(Certek.Text));

                    Double m1 = (- Double.Parse(Bertek.Text) + Math.Sqrt(D)) / 2 * Double.Parse(Aertek.Text);
                    Double m2 = (- Double.Parse(Bertek.Text) - Math.Sqrt(D)) / 2 * Double.Parse(Aertek.Text);

                    if (D > 0)  // 2 gyök van!
                    {
                        Eredmeny.Text = string.Format("1.megoldas = {0}, 2.megoldas = {1}", m1, m2);
                    }
                    else if (D == 0) //1 kettős gyök van!
                    {
                        Eredmeny.Text = string.Format("Megoldas = {0}", m1);
                    }
                    else // Nincs megoldás. 2 kopmlex gyök van!
                    {
                        Eredmeny.Text = "Nincs megoldása az egyenletnek! Két komplex gyök van!";
                    }
                        
                }
                
            };

        }
    }
}

