namespace Vonalkod
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMunkaossz = new System.Windows.Forms.Button();
            this.btnRajz = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMunkaossz);
            this.panel1.Controls.Add(this.btnRajz);
            this.panel1.Controls.Add(this.btnBarcode);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnMunkaossz
            // 
            this.btnMunkaossz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMunkaossz.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnMunkaossz.Image = ((System.Drawing.Image)(resources.GetObject("btnMunkaossz.Image")));
            this.btnMunkaossz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMunkaossz.Location = new System.Drawing.Point(463, 20);
            this.btnMunkaossz.Name = "btnMunkaossz";
            this.btnMunkaossz.Size = new System.Drawing.Size(198, 64);
            this.btnMunkaossz.TabIndex = 2;
            this.btnMunkaossz.Text = "Ö&sszesítő";
            this.btnMunkaossz.UseVisualStyleBackColor = true;
            this.btnMunkaossz.Click += new System.EventHandler(this.btnMunkaossz_Click);
            // 
            // btnRajz
            // 
            this.btnRajz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRajz.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRajz.Image = ((System.Drawing.Image)(resources.GetObject("btnRajz.Image")));
            this.btnRajz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRajz.Location = new System.Drawing.Point(233, 20);
            this.btnRajz.Name = "btnRajz";
            this.btnRajz.Size = new System.Drawing.Size(198, 64);
            this.btnRajz.TabIndex = 1;
            this.btnRajz.Text = "&Belépőkártya";
            this.btnRajz.UseVisualStyleBackColor = true;
            this.btnRajz.Click += new System.EventHandler(this.btnRajz_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBarcode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarcode.Location = new System.Drawing.Point(3, 20);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(198, 64);
            this.btnBarcode.TabIndex = 0;
            this.btnBarcode.Text = "&Vonalkód";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(665, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Siófoki SZC Munkaidő Nyilvántartó Rendszer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnMunkaossz;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(689, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Munkaidő Nyilvántartó Rendszer - 2016. Osvald Csaba";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMunkaossz;
        private System.Windows.Forms.Button btnRajz;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Label label1;
    }
}

