using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rajz
{
    public partial class Form1 : Form
    {
        DateTime date1 = new DateTime(2017, 1, 1, 0, 0, 0);
        private Bitmap m_objDrawingSurface;
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > date1)
            {
                MessageBox.Show("A szoftver használati ideje lejárt!", "Munkaidő Összesítő");
                this.Close();
            }
            btnMent.Enabled = false;
            m_objDrawingSurface = new Bitmap(panel1.ClientRectangle.Width, panel1.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            InitializeSurface();
        }

        private void InitializeSurface()
        {
            Graphics objGraphics;
            Rectangle rectBounds;
            Font objFont;
            int intFontSize = 10;
            String strNev = txtNev.Text;
            String strCeg1 = "Marcali Szakképző Iskola";
            String strCeg2 = "8700 Marcali, Hősök tere 3.";

            if (strNev != "")
            {
                objGraphics = Graphics.FromImage(m_objDrawingSurface);
                objGraphics.Clear(SystemColors.Window);

                rectBounds = new Rectangle(0, 0, m_objDrawingSurface.Width, m_objDrawingSurface.Height);
                rectBounds.Inflate(-1, -1);

                objFont = new System.Drawing.Font("Tahoma", intFontSize, FontStyle.Bold);
                
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;        // horizontal alignment
                sf.LineAlignment = StringAlignment.Center;    // vertical alignment

                Rectangle r = new Rectangle(0, 100, 218, objFont.Height * 2);                
                objGraphics.DrawString(strNev, objFont, Brushes.Black, r, sf);

                intFontSize = 8;
                objFont = new System.Drawing.Font("Tahoma", intFontSize, FontStyle.Bold);
                Rectangle r1 = new Rectangle(0, 310, 218, objFont.Height * 2);
                objGraphics.DrawString(strCeg1, objFont, Brushes.Black, r1, sf);
                Rectangle r2 = new Rectangle(0, 330, 218, objFont.Height * 2);
                objGraphics.DrawString(strCeg2, objFont, Brushes.Black, r2, sf);

                objGraphics.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeSurface();
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (txtNev.Text != "")
            {
                e.Graphics.DrawImage(m_objDrawingSurface, 0, 0, m_objDrawingSurface.Width, m_objDrawingSurface.Height);
                e.Graphics.Dispose();
            }
        }

        private void btnMent_Click(object sender, EventArgs e)
        {
            this.prnDoc1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(
                this.prnDoc1_PrintPage);
            try
            {
                // Van beolvasott vonalkód kép a kártyához.
                if (pictureBox1.Image != null && txtNev.Text != "")
                {
                    // Alapért.nyomtatóra küldés.
                    prnDoc1.Print();
                }
                else MessageBox.Show("Nincs név és vonalkód a kártyán!","Hiba a myomtatásnál!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a nyomtatás során!", ex.ToString());
            }


            /*
            //SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif";
            sfd.FilterIndex = 2;
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BarcodeLib.SaveTypes savetype = BarcodeLib.SaveTypes.UNSPECIFIED;
                switch (sfd.FilterIndex)
                {
                    case 1: savetype = BarcodeLib.SaveTypes.BMP; break; // BMP
                    case 2: savetype = BarcodeLib.SaveTypes.GIF; break; // GIF
                    case 3: savetype = BarcodeLib.SaveTypes.JPG; break; // JPG
                    case 4: savetype = BarcodeLib.SaveTypes.PNG; break; // PNG
                    case 5: savetype = BarcodeLib.SaveTypes.TIFF; break; //TIFF
                    default: break;
                }//switch
                b.SaveImage(sfd.FileName, savetype);
            }//if */
        }

        private void bntMegnyit_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|TIFF (*.tif)|*.tif";
            ofd.FilterIndex = 1;
            ofd.AddExtension = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // A kép betöltése a képmezőbe
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                // Van a kártyához vonalkód, lehet menteni/nyomtatni
                btnMent.Enabled = true;
            }            
        }

        private void prnDoc1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Kártya határoló kerete
            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(0, 0, 221, 345));

            // Felső nyíl kiírása
            try
            {
                var img = System.Drawing.Image.FromFile("nyil.png");
                e.Graphics.DrawImage(img, new Point(70, 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba! Ninncs meg a nyil.png fájl!", "Hiba!" + ex.ToString());
            }
            
            Font objFont;
            int intFontSize = 10;
            String strNev = txtNev.Text;
            String strCeg1 = "Marcali Szakképző Iskola";
            String strCeg2 = "8700 Marcali, Hősök tere 3.";

            objFont = new Font("Tahoma", intFontSize, FontStyle.Bold);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;        // horizontal alignment
            sf.LineAlignment = StringAlignment.Center;    // vertical alignment

            // Név kiírása
            Rectangle r = new Rectangle(0, 90, 218, objFont.Height * 2);
            e.Graphics.DrawString(strNev, objFont, Brushes.Black, r, sf);

            // Vonalkód kiírása
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            e.Graphics.DrawImage(pictureBox1.Image, 10, 170, 200, 75);
                
            // MSZI kiírása
            intFontSize = 10;
            objFont = new Font("Tahoma", intFontSize, FontStyle.Bold);
            Rectangle r1 = new Rectangle(0, 285, 218, objFont.Height * 2);
            e.Graphics.DrawString(strCeg1, objFont, Brushes.Black, r1, sf);
            Rectangle r2 = new Rectangle(0, 305, 218, objFont.Height * 2);
            e.Graphics.DrawString(strCeg2, objFont, Brushes.Black, r2, sf);
        }
    }
}
