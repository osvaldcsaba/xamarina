using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace belepo
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private string old_azonosito="";
        DateTime date1 = new DateTime(2017, 1, 1, 0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Admin1\Documents\Visual Studio 2013\Projects\belepo\vonalkod.accdb; Persist Security Info=False;";
            //connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\TIOPPC-3\Documents\Visual Studio 2013\Projects\belepo\vonalkod.accdb; Persist Security Info=False;";
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vonalkod.accdb; Persist Security Info=False;";
            cimkek_urit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > date1)
            {
                MessageBox.Show("A szoftver használati ideje lejárt!", "Munkaidő Összesítő");
                this.Close();
            }
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hiba " + ex.Message);                
            }
        }

        private void cimkek_urit() 
        {
            kodbe.Text = "";
            cimke_nev.Text = "";
            cimke_beosztas.Text = "";
            cimke_datum.Text = "";
            cimke_ido.Text = "";
            cimke_hetiossz.Text = "";
            cimke_Kell.Text = "";
        }

        // 3mp-re várakozás
        private void varakoz()
        {
            DateTime dt1 = DateTime.Now;
            int diff = 0;
            while (diff < 6)
            {
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                diff = (int)ts.TotalSeconds;
                Application.DoEvents();
            }   
        }

        private void kodbe_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isKey = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);

            if (!isKey && !isControl)
            {
                e.Handled = true;
            }
            // Enter-re adatbevitel vége éa ellenőrzés!
            if (Convert.ToInt32(e.KeyChar) == 13 && kodbe.Text!="")
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select * from szemely where aktiv=true and azonosito=" + kodbe.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    string azonosito = "", nev = "", beosztas = "";
                    DateTime datum, ido = new DateTime();
                    datum = DateTime.Now;
                    ido = DateTime.Now;
                    int count = 0;
                    while (reader.Read())
                    {
                        count++;
                        // Adatok kiolvasása az adatbázisból
                        azonosito = reader.GetValue(0).ToString();
                        nev = reader.GetString(1);
                        beosztas = reader.GetString(2);
                        
                        // Adatok megjelenítése
                        cimke_nev.Text = nev;
                        cimke_beosztas.Text = beosztas;
                        cimke_datum.Text = datum.ToLongDateString();
                        cimke_ido.Text = ido.ToLongTimeString();
                    }
                    connection.Close();
                    // Van a szemely táblában találat
                    if (count == 1)
                    {
                        // Csak akkor rögzítjük ha még nem írtuk ki előzőleg (nem azonos az előző rögzítéssel)
                        if (azonosito != old_azonosito)
                        {
                            // Új rekord felvitele
                            OleDbCommand commandi = new OleDbCommand();
                            OleDbTransaction transaction = null;
                            commandi.Connection = connection;
                            try
                            {
                                connection.Open();
                                transaction = connection.BeginTransaction();
                                commandi.Connection = connection;
                                commandi.Transaction = transaction;
                                commandi.CommandText = "insert into mozgas (azonosito,nev,beosztas,datum) values('" + double.Parse(azonosito) + "','" + nev + "','" + beosztas + "','" + datum.ToString() + "')";
                                commandi.ExecuteNonQuery();
                                transaction.Commit();
                            }
                            catch (Exception ex1)
                            {
                                //MessageBox.Show("Hiba "+ex1.Message);
                                try
                                {
                                    transaction.Rollback();
                                }
                                catch (Exception)
                                {
                                    //
                                }                                
                            }
                            connection.Close();
                            old_azonosito = azonosito;
                            // Heti munkaórák összeszámlálása start
                            //
                            DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)+1);
                            DateTime endOfWeek = startOfWeek.AddDays(+6);
                            // A hét első napjának meghatározása
                            String startOfWeekST= startOfWeek.ToString("d", DateTimeFormatInfo.InvariantInfo);
                            // Az adott személy leválogatása 
                            connection.Open();
                            command.CommandText = "select * from mozgas where azonosito=" + azonosito +" and datum>=#" + startOfWeekST + "# order by datum";
                            OleDbDataReader reader2 = command.ExecuteReader();
                            int startDay=0, endDay=0;
                            TimeSpan startTime = new TimeSpan();
                            TimeSpan endTime = new TimeSpan();
                            TimeSpan ossz_munkaora = new TimeSpan();
                            ossz_munkaora = TimeSpan.Zero;
                            while (reader2.Read())
                            {
                                // Adatok kiolvasása az adatbázisból
                                azonosito = reader2.GetValue(1).ToString();
                                nev = reader2.GetString(2);
                                beosztas = reader2.GetString(3);
                                datum = Convert.ToDateTime(reader2.GetDateTime(4));
                                if (startDay==0)
                                {
                                    startDay = datum.Day;
                                    endDay = datum.Day;
                                    startTime = datum.TimeOfDay;
                                    endTime = datum.TimeOfDay;
                                }
                                else
                                {
                                    if (datum.Day == startDay)
                                    {
                                        if (startTime==TimeSpan.Zero)
                                        {
                                            startTime = datum.TimeOfDay;
                                        }
                                        endTime = datum.TimeOfDay;
                                        if (startTime != endTime)
                                        {
                                            ossz_munkaora += (endTime - startTime);
                                            startTime = TimeSpan.Zero;
                                        }                                        
                                    }
                                    else
                                    {
                                        endDay = datum.Day;
                                        startTime = datum.TimeOfDay;
                                        endTime = TimeSpan.Zero;
                                    }
                                    startDay = datum.Day;
                                }
                            }
                            // Még szükséges heti óraszám kiszámítása
                            TimeSpan kotelezo_oraszam = new TimeSpan(0,32,0,0);
                            if (beosztas!="Tanár" && beosztas!="Igazgató")
                            {
                                kotelezo_oraszam = new TimeSpan(0,40,0,0);
                            }
                            String listaosszST = ossz_munkaora.TotalHours.ToString();
                            String listaKellhST = (kotelezo_oraszam.TotalHours  - ossz_munkaora.TotalHours).ToString();
                            String listaKellmST = (kotelezo_oraszam - ossz_munkaora).Minutes.ToString();
                            //
                            int lpoz = listaosszST.IndexOf(',');
                            int lkpoz = listaKellhST.IndexOf(',');
                            if (lpoz < 1)
                            {
                                lpoz = listaosszST.Length;
                            }
                            if (lkpoz < 1)
                            {
                                lkpoz = listaKellhST.Length;
                            }
                            cimke_hetiossz.Text = "Heti óraszám = " + listaosszST.Substring(0, lpoz) + " ÓRA " + ossz_munkaora.Minutes.ToString() + " PERC";
                            int xh = Int32.Parse(listaKellhST.Substring(0, lkpoz));
                            int xm = (kotelezo_oraszam - ossz_munkaora).Minutes;
                            if (xh < 0 || xm < 0)
                            {
                                cimke_Kell.ForeColor = System.Drawing.Color.Green;
                                cimke_Kell.Text = "A heti óraszámon felül van " + listaKellhST.Substring(1, lkpoz-1) + " ÓRA " + listaKellmST.Substring(1) + " PERC";
                            }
                            else
                            {
                                cimke_Kell.ForeColor = System.Drawing.Color.Red;
                                cimke_Kell.Text = "Heti óraszámhoz még kell " + listaKellhST.Substring(0, lkpoz) + " ÓRA " + listaKellmST + " PERC";
                            }
                            connection.Close();
                            //
                            // Heti munkaórák összeszámlálása stop
                        }
                    }
                    else // Nem jó a kódolvasás!
                    {
                        cimke_nev.Text = "HIBÁS KÓDOLVASÁS!";
                    }
                    varakoz();
                    cimkek_urit();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Hiba " + ex2.Message);
                } 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
