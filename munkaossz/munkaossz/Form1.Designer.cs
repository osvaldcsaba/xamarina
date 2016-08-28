namespace munkaossz
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RTBox1 = new System.Windows.Forms.RichTextBox();
            this.startDatum = new System.Windows.Forms.DateTimePicker();
            this.stopDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.szemelyLista = new System.Windows.Forms.ListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnMozgaslista = new System.Windows.Forms.Button();
            this.btnNyomtat = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblFeldolgoz = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTBox1
            // 
            this.RTBox1.Location = new System.Drawing.Point(12, 12);
            this.RTBox1.Name = "RTBox1";
            this.RTBox1.ReadOnly = true;
            this.RTBox1.Size = new System.Drawing.Size(511, 247);
            this.RTBox1.TabIndex = 3;
            this.RTBox1.TabStop = false;
            this.RTBox1.Text = "";
            // 
            // startDatum
            // 
            this.startDatum.Location = new System.Drawing.Point(9, 28);
            this.startDatum.Name = "startDatum";
            this.startDatum.Size = new System.Drawing.Size(200, 22);
            this.startDatum.TabIndex = 4;
            // 
            // stopDatum
            // 
            this.stopDatum.Location = new System.Drawing.Point(9, 28);
            this.stopDatum.Name = "stopDatum";
            this.stopDatum.Size = new System.Drawing.Size(200, 22);
            this.stopDatum.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startDatum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 74);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Összesítés induló dátuma";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stopDatum);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(291, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 74);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Összesítés befejező dátuma";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.szemelyLista);
            this.groupBox3.Location = new System.Drawing.Point(12, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 112);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Személy szűrő";
            // 
            // szemelyLista
            // 
            this.szemelyLista.FormattingEnabled = true;
            this.szemelyLista.Items.AddRange(new object[] {
            "Minden szemely"});
            this.szemelyLista.Location = new System.Drawing.Point(6, 19);
            this.szemelyLista.Name = "szemelyLista";
            this.szemelyLista.Size = new System.Drawing.Size(232, 82);
            this.szemelyLista.TabIndex = 11;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnMozgaslista
            // 
            this.btnMozgaslista.Image = global::munkaossz.Properties.Resources.application1;
            this.btnMozgaslista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMozgaslista.Location = new System.Drawing.Point(387, 311);
            this.btnMozgaslista.Name = "btnMozgaslista";
            this.btnMozgaslista.Size = new System.Drawing.Size(119, 55);
            this.btnMozgaslista.TabIndex = 12;
            this.btnMozgaslista.Text = "&Mozgás listája";
            this.btnMozgaslista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMozgaslista.UseVisualStyleBackColor = true;
            this.btnMozgaslista.Click += new System.EventHandler(this.btnMozgaslista_Click);
            // 
            // btnNyomtat
            // 
            this.btnNyomtat.Image = global::munkaossz.Properties.Resources.print_ico;
            this.btnNyomtat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNyomtat.Location = new System.Drawing.Point(137, 489);
            this.btnNyomtat.Name = "btnNyomtat";
            this.btnNyomtat.Size = new System.Drawing.Size(119, 55);
            this.btnNyomtat.TabIndex = 11;
            this.btnNyomtat.Text = "      &Nyomtatás";
            this.btnNyomtat.UseVisualStyleBackColor = true;
            this.btnNyomtat.Click += new System.EventHandler(this.btnNyomtat_Click);
            // 
            // button3
            // 
            this.button3.Image = global::munkaossz.Properties.Resources.button_exit;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(387, 489);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "    &Kilépés";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::munkaossz.Properties.Resources.button_cancel;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(262, 489);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 55);
            this.button2.TabIndex = 1;
            this.button2.Text = "       Lista &törlése";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Lista készítése";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFeldolgoz
            // 
            this.lblFeldolgoz.AutoSize = true;
            this.lblFeldolgoz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFeldolgoz.ForeColor = System.Drawing.Color.Red;
            this.lblFeldolgoz.Location = new System.Drawing.Point(88, 127);
            this.lblFeldolgoz.Name = "lblFeldolgoz";
            this.lblFeldolgoz.Size = new System.Drawing.Size(359, 24);
            this.lblFeldolgoz.TabIndex = 13;
            this.lblFeldolgoz.Text = "Az adatok feldologzása folyamatban...";
            this.lblFeldolgoz.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(537, 553);
            this.Controls.Add(this.lblFeldolgoz);
            this.Controls.Add(this.btnMozgaslista);
            this.Controls.Add(this.btnNyomtat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RTBox1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Munkaidő nyilvántartás összesító - Készítette: Osvald Csaba v1.160208.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RTBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker startDatum;
        private System.Windows.Forms.DateTimePicker stopDatum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox szemelyLista;
        private System.Windows.Forms.Button btnNyomtat;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnMozgaslista;
        private System.Windows.Forms.Label lblFeldolgoz;
    }
}

