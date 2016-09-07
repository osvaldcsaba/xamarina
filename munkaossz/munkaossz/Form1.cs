using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;

using System.Runtime.InteropServices;
using System.Threading;

namespace munkaossz
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private Font printFont;
        private StreamReader streamToPrint;
        DateTime date1 = new DateTime(2017, 1, 1, 0, 0, 0);
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=vonalkod.accdb; Persist Security Info=False;";
            btnNyomtat.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > date1)
            {
                MessageBox.Show("A szoftver használati ideje lejárt!","Munkaidő Összesítő");
                this.Close();
            }
            try
            {
                connection.Open();
                // Személyek listába gyűjtése
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from szemely where aktiv=true order by nev";
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
                    // Adatok listába töltése
                    szemelyLista.Items.Add(nev+" "+azonosito);
                }
                connection.Close();
                szemelyLista.SetSelected(0,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex.Message, "Hiba!");
            }
        }

        // Kilépés gomb
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // Lista készítése gomb
        private void button1_Click(object sender, EventArgs e)
        {
            // access adatbázis összesítő
            try
            {
                // Feldolgozás indul...                
                lblFeldolgoz.Visible = true;

                // Listaablak törlése
                RTBox1.Clear();
                string azonosito = "", nev = "", beosztas = "";
                DateTime datum = new DateTime();
                
                // Heti munkaórák összeszámlálása start
                //
                // ossz.csv-be kiírjuk az összesített adatokat
                FileStream cfs = new FileStream("ossz.csv", FileMode.Create);
                StreamWriter sw = new StreamWriter(cfs, Encoding.UTF8);
                // Fejléc kiírása CSV-be
                sw.WriteLine("azonosító;név;dátum;ledolg.óra");

                // Nyomtatás gomb aktíválása.
                btnNyomtat.Enabled = true;

                DateTime startOfWeek = startDatum.Value;
                DateTime endOfWeek = stopDatum.Value.AddDays(1);
                // A hét első és utolsó napjának meghatározása
                String startOfWeekST = startOfWeek.ToString("d", DateTimeFormatInfo.InvariantInfo);
                String endOfWeekST = endOfWeek.ToString("d", DateTimeFormatInfo.InvariantInfo);                
                // Leválogatás
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;                
                connection.Open();
                
                // A listából választott személy vizsgálata
                String szemely = szemelyLista.SelectedItem.ToString();
                int szemelyhossz = szemely.Length;
                String szemelykeres;
                if (szemely != "Minden szemely")
                {
                    szemelykeres = "azonosito="+szemely.Substring(szemelyhossz - 11)+" and ";
                } else szemelykeres = "";
                
                command.CommandText = "select * from mozgas where " + szemelykeres + "(datum between #" + startOfWeekST + "# and #" + endOfWeekST + "#) order by nev, datum ASC";
                OleDbDataReader reader2 = command.ExecuteReader();
                
                int startDay=0, endDay=0;
                TimeSpan startTime = new TimeSpan();
                TimeSpan endTime = new TimeSpan();
                TimeSpan ossz_munkaora, listaossz = new TimeSpan();
                ossz_munkaora = TimeSpan.Zero;
                listaossz = TimeSpan.Zero;
                String akt_azonosito="";
                while (reader2.Read())
                {
                    // Adatok kiolvasása az adatbázisból
                    azonosito = reader2.GetValue(1).ToString();
                    nev = reader2.GetString(2);
                    beosztas = reader2.GetString(3);
                    datum = Convert.ToDateTime(reader2.GetDateTime(4));

                    if ((ossz_munkaora == TimeSpan.Zero) && (akt_azonosito != azonosito))
                    {
                        akt_azonosito = azonosito;

                        startDay = datum.Day;
                        endDay = datum.Day;
                        startTime = datum.TimeOfDay;
                        endTime = datum.TimeOfDay;

                    }
                    if (akt_azonosito == azonosito)
                    {
                        if (startDay == 0)
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
                                if (startTime == TimeSpan.Zero)
                                {
                                    startTime = datum.TimeOfDay;
                                }
                                endTime = datum.TimeOfDay;
                                if (startTime != endTime)
                                {
                                    ossz_munkaora += (endTime - startTime);
                                    startTime = TimeSpan.Zero;
                                    akt_azonosito = azonosito;

                                    RTBox1.AppendText(azonosito + " " + nev + " " + beosztas + " " + datum.ToShortDateString() + " ... ");
                                    RTBox1.AppendText(ossz_munkaora.ToString() + "\n");
                                    RTBox1.AppendText("-----------------------------------------------------------------------------------------------------------------------\n");
                                    // Adat rögzítése fájlba
                                    sw.WriteLine(azonosito + ';' + nev + ';' + datum.ToShortDateString() + ';' + ossz_munkaora.ToString());
                                    listaossz += ossz_munkaora;
                                    ossz_munkaora = TimeSpan.Zero;
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
                }
                // Az össz óraszám egész részét vesszük
                String listaosszST = listaossz.TotalHours.ToString();
                int lpoz = listaosszST.IndexOf(',');
                //
                if (lpoz > 0)
                {
                    String kiir = "Időszakban összesen = " + listaosszST.Substring(0, lpoz) + " óra " + listaossz.Minutes + " perc " + listaossz.Seconds + " másodperc\n";
                    RTBox1.AppendText(kiir);
                    //sw.WriteLine(kiir);
                }
                sw.Close();
                cfs.Close();
                connection.Close();
                // Ha van az időszakban rögzítés.
                if (listaossz.Hours > 0 || listaossz.Minutes > 0 || listaossz.Seconds > 0)
                {
                    //
                    // Heti munkaórák összeszámlálása start
                    
                    // Makró1 start
                    // A munka.xlsm makro segítségével a létrehozott csv fájlból beolvassuk az adatokat, majd részösszeget képzünk!
                    // Kimenet: ossz.xlsx állomány
                    Excel.Application objExcel = new Excel.Application();
                    Excel.Workbook objWorkBook;
                    object misValue = System.Reflection.Missing.Value;
                    objExcel = new Excel.Application();

                    objWorkBook = objExcel.Workbooks.Open(Application.StartupPath + @"\munka.xlsm");
                    objExcel.Run("Makró1");

                    objWorkBook.Close(false);
                    objExcel.Quit();
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objExcel);
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(objWorkBook);
                    GC.Collect();
                    // Makró1 stop
                }
                else MessageBox.Show("Az időszakban nincs kiértékelhető adat!", "Hiba!");
            // Feldolgozás vége               
            lblFeldolgoz.Visible = false;
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Hiba " + ex2.Message, "Hiba!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lista törlése gomb
            RTBox1.Clear();
            btnNyomtat.Enabled = false;
        }

        private void btnNyomtat_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                // Munkafüzet megnyitása:
                Excel.Workbook wb = excelApp.Workbooks.Open(
                    Application.StartupPath + @"\ossz.xlsx",
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                try
                {
                    // Első munkaterület
                    // (Excel uses base 1 indexing, not base 0.)
                    Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

                    // Nyomtatás az alapért. nyomtatóra 1 példányban:
                    ws.PrintOut(
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                    // Tisztítás:
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Marshal.FinalReleaseComObject(ws);

                    wb.Close(false, Type.Missing, Type.Missing);
                    Marshal.FinalReleaseComObject(wb);

                    excelApp.Quit();
                    Marshal.FinalReleaseComObject(excelApp);
                }
                catch (Exception pex)
                {
                    MessageBox.Show("Hiba " + pex.Message, "Hiba!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex.Message, "Hiba!");
            }

            /* CSV nyomtatása
            try
            {
                // ossz.csv-ből kiolvassuk az adatokat
                FileStream fs = new FileStream("ossz.csv", FileMode.Open);
                streamToPrint = new StreamReader(fs, Encoding.UTF8);
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();                    
                    printDialog1.AllowSomePages = true;
                    printDialog1.ShowHelp = true;
                    printDialog1.Document = pd;
                    DialogResult result = printDialog1.ShowDialog();
                    // OK gombra kattint
                    if (result == DialogResult.OK)
                    {
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        pd.Print();
                    }
                }
                catch (Exception pex)
                {
                    MessageBox.Show("Hiba " + pex.Message, "Hiba!");
                }
                finally
                {
                    streamToPrint.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba " + ex.Message, "Hiba!");
            }            
            */
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Egy lapra kerülő sorok száma
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // sorok nyomtatása fájlból 
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }
            // Ha még van adat, köv. lapra.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        private void btnMozgaslista_Click(object sender, EventArgs e)
        {
            try
            {
                string azonosito = "", nev = "", beosztas = "";
                DateTime datum = new DateTime();
                
                // Leválogatás
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                connection.Open();
                DateTime startOfWeek = startDatum.Value;
                DateTime endOfWeek = stopDatum.Value.AddDays(1);
                // A hét első és utolsó napjának meghatározása
                String startOfWeekST = startOfWeek.ToString("d", DateTimeFormatInfo.InvariantInfo);
                String endOfWeekST = endOfWeek.ToString("d", DateTimeFormatInfo.InvariantInfo); 

                // mozgas.csv-be kiírjuk a mozgás adatokat
                FileStream cfs = new FileStream("mozgas.csv", FileMode.Create);
                StreamWriter sw = new StreamWriter(cfs, Encoding.UTF8);
                
                // A listából választott személy vizsgálata
                String szemely = szemelyLista.SelectedItem.ToString();
                int szemelyhossz = szemely.Length;
                String szemelykeres;
                if (szemely != "Minden szemely")
                {
                    szemelykeres = "azonosito=" + szemely.Substring(szemelyhossz - 11) + " and ";
                }
                else szemelykeres = "";

                command.CommandText = "select * from mozgas where " + szemelykeres + "(datum between #" + startOfWeekST + "# and #" + endOfWeekST + "#) order by nev, datum ASC";
                OleDbDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    // Adatok kiolvasása az adatbázisból
                    azonosito = reader2.GetValue(1).ToString();
                    nev = reader2.GetString(2);
                    beosztas = reader2.GetString(3);
                    datum = Convert.ToDateTime(reader2.GetDateTime(4));
                    // Adat rögzítése fájlba
                    sw.WriteLine(azonosito + ';' + nev + ';' + beosztas + ';' + datum.ToString());
                }
                sw.Close();
                cfs.Close();
                connection.Close();
                MessageBox.Show("A mozgas.csv mozgáslista elkészült.","mozgas.csv");
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Hiba " + ex2.Message, "Hiba!");
            }
        }
    }
}
