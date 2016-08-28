using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vonalkod
{
    public partial class Form1 : Form
    {
        DateTime date1 = new DateTime(2016, 9, 1, 0, 0, 0);
	    public Form1()
        {
            InitializeComponent();
        }

        private void btnRajz_Click(object sender, EventArgs e)
        {
            rajz.Form1 rf = new rajz.Form1();
            rf.ShowDialog();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            BarcodeLibTest.TestApp bf = new BarcodeLibTest.TestApp();
            bf.ShowDialog();
        }

        private void btnMunkaossz_Click(object sender, EventArgs e)
        {
            munkaossz.Form1 mf = new munkaossz.Form1();
            mf.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (DateTime.Now > date1)
            {
                MessageBox.Show("A szoftver használati ideje lejárt!", "Munkaidő Összesítő");
                this.Close();
            }
        }
    }
}
