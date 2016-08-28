namespace belepo
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kodbe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cimke_nev = new System.Windows.Forms.Label();
            this.cimke_beosztas = new System.Windows.Forms.Label();
            this.cimke_datum = new System.Windows.Forms.Label();
            this.cimke_ido = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cimke_Kell = new System.Windows.Forms.Label();
            this.cimke_hetiossz = new System.Windows.Forms.Label();
            this.Ora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(986, 73);
            this.label1.TabIndex = 2;
            this.label1.Text = "Siófoki SZC Marcali Szakképző Iskola";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(986, 73);
            this.label2.TabIndex = 3;
            this.label2.Text = "Beléptető és munkaidő nyilvántartó";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kodbe
            // 
            this.kodbe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kodbe.Location = new System.Drawing.Point(444, 280);
            this.kodbe.Name = "kodbe";
            this.kodbe.PasswordChar = '*';
            this.kodbe.Size = new System.Drawing.Size(203, 20);
            this.kodbe.TabIndex = 4;
            this.kodbe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kodbe_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vonalkód: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cimke_nev
            // 
            this.cimke_nev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cimke_nev.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimke_nev.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cimke_nev.Location = new System.Drawing.Point(5, 1);
            this.cimke_nev.Name = "cimke_nev";
            this.cimke_nev.Size = new System.Drawing.Size(984, 60);
            this.cimke_nev.TabIndex = 6;
            this.cimke_nev.Text = "x";
            this.cimke_nev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cimke_beosztas
            // 
            this.cimke_beosztas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cimke_beosztas.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimke_beosztas.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cimke_beosztas.Location = new System.Drawing.Point(5, 61);
            this.cimke_beosztas.Name = "cimke_beosztas";
            this.cimke_beosztas.Size = new System.Drawing.Size(984, 60);
            this.cimke_beosztas.TabIndex = 7;
            this.cimke_beosztas.Text = "x";
            this.cimke_beosztas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cimke_datum
            // 
            this.cimke_datum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cimke_datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimke_datum.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.cimke_datum.Location = new System.Drawing.Point(5, 121);
            this.cimke_datum.Name = "cimke_datum";
            this.cimke_datum.Size = new System.Drawing.Size(984, 60);
            this.cimke_datum.TabIndex = 8;
            this.cimke_datum.Text = "xxx:xx:xx";
            this.cimke_datum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cimke_ido
            // 
            this.cimke_ido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cimke_ido.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimke_ido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cimke_ido.Location = new System.Drawing.Point(5, 181);
            this.cimke_ido.Name = "cimke_ido";
            this.cimke_ido.Size = new System.Drawing.Size(984, 60);
            this.cimke_ido.TabIndex = 9;
            this.cimke_ido.Text = "xx:xx:xx";
            this.cimke_ido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.cimke_Kell);
            this.panel1.Controls.Add(this.cimke_hetiossz);
            this.panel1.Controls.Add(this.cimke_nev);
            this.panel1.Controls.Add(this.cimke_ido);
            this.panel1.Controls.Add(this.cimke_beosztas);
            this.panel1.Controls.Add(this.cimke_datum);
            this.panel1.Location = new System.Drawing.Point(5, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(996, 379);
            this.panel1.TabIndex = 10;
            // 
            // cimke_Kell
            // 
            this.cimke_Kell.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cimke_Kell.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimke_Kell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cimke_Kell.Location = new System.Drawing.Point(5, 301);
            this.cimke_Kell.Name = "cimke_Kell";
            this.cimke_Kell.Size = new System.Drawing.Size(984, 60);
            this.cimke_Kell.TabIndex = 11;
            this.cimke_Kell.Text = "xx:xx:xx";
            this.cimke_Kell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cimke_hetiossz
            // 
            this.cimke_hetiossz.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cimke_hetiossz.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimke_hetiossz.ForeColor = System.Drawing.Color.Red;
            this.cimke_hetiossz.Location = new System.Drawing.Point(5, 241);
            this.cimke_hetiossz.Name = "cimke_hetiossz";
            this.cimke_hetiossz.Size = new System.Drawing.Size(984, 60);
            this.cimke_hetiossz.TabIndex = 10;
            this.cimke_hetiossz.Text = "xx:xx:xx";
            this.cimke_hetiossz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ora
            // 
            this.Ora.AutoSize = true;
            this.Ora.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Ora.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Ora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Ora.Location = new System.Drawing.Point(12, 9);
            this.Ora.Name = "Ora";
            this.Ora.Size = new System.Drawing.Size(395, 108);
            this.Ora.TabIndex = 12;
            this.Ora.Text = "xx:xx:xx";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(790, 708);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "v1.160201.1 Készítette: Osvald Csaba, 2016.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Ora);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kodbe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vonalkódos beléptető rendszer - Siófoki SZC Marcali Szakképző Iskolája";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kodbe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cimke_nev;
        private System.Windows.Forms.Label cimke_beosztas;
        private System.Windows.Forms.Label cimke_datum;
        private System.Windows.Forms.Label cimke_ido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label cimke_hetiossz;
        private System.Windows.Forms.Label Ora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label cimke_Kell;
        private System.Windows.Forms.Label label5;


    }
}

