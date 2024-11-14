namespace DigitalniPotpis_Projekt
{
    partial class FrmDigitalniPotpis
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
            this.btnGenerirajKljuceve = new System.Windows.Forms.Button();
            this.btnKriptirajDatoteku = new System.Windows.Forms.Button();
            this.btnDekriptirajDatoteku = new System.Windows.Forms.Button();
            this.btnIzracunajSazetak = new System.Windows.Forms.Button();
            this.btnPotpisiDatoteku = new System.Windows.Forms.Button();
            this.btnProvjeriPotpis = new System.Windows.Forms.Button();
            this.txtRezultat = new System.Windows.Forms.TextBox();
            this.lblPrikazRezultata = new System.Windows.Forms.Label();
            this.btnKriptirajAsimetricno = new System.Windows.Forms.Button();
            this.btnDekriptirajAsimetricno = new System.Windows.Forms.Button();
            this.txtKriptirano = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOdaberiDatoteku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerirajKljuceve
            // 
            this.btnGenerirajKljuceve.Location = new System.Drawing.Point(35, 12);
            this.btnGenerirajKljuceve.Name = "btnGenerirajKljuceve";
            this.btnGenerirajKljuceve.Size = new System.Drawing.Size(108, 23);
            this.btnGenerirajKljuceve.TabIndex = 0;
            this.btnGenerirajKljuceve.Text = "Generiraj ključeve";
            this.btnGenerirajKljuceve.UseVisualStyleBackColor = true;
            this.btnGenerirajKljuceve.Click += new System.EventHandler(this.btnGenerirajKljuceve_Click);
            // 
            // btnKriptirajDatoteku
            // 
            this.btnKriptirajDatoteku.Location = new System.Drawing.Point(149, 12);
            this.btnKriptirajDatoteku.Name = "btnKriptirajDatoteku";
            this.btnKriptirajDatoteku.Size = new System.Drawing.Size(146, 23);
            this.btnKriptirajDatoteku.TabIndex = 1;
            this.btnKriptirajDatoteku.Text = "Kriptiraj datoteku simetrično";
            this.btnKriptirajDatoteku.UseVisualStyleBackColor = true;
            this.btnKriptirajDatoteku.Click += new System.EventHandler(this.btnKriptirajDatoteku_Click);
            // 
            // btnDekriptirajDatoteku
            // 
            this.btnDekriptirajDatoteku.Location = new System.Drawing.Point(301, 12);
            this.btnDekriptirajDatoteku.Name = "btnDekriptirajDatoteku";
            this.btnDekriptirajDatoteku.Size = new System.Drawing.Size(161, 23);
            this.btnDekriptirajDatoteku.TabIndex = 2;
            this.btnDekriptirajDatoteku.Text = "Dekriptiraj datoteku simetrično";
            this.btnDekriptirajDatoteku.UseVisualStyleBackColor = true;
            this.btnDekriptirajDatoteku.Click += new System.EventHandler(this.btnDekriptirajDatoteku_Click);
            // 
            // btnIzracunajSazetak
            // 
            this.btnIzracunajSazetak.Location = new System.Drawing.Point(468, 12);
            this.btnIzracunajSazetak.Name = "btnIzracunajSazetak";
            this.btnIzracunajSazetak.Size = new System.Drawing.Size(106, 23);
            this.btnIzracunajSazetak.TabIndex = 3;
            this.btnIzracunajSazetak.Text = "Izračunaj sažetak";
            this.btnIzracunajSazetak.UseVisualStyleBackColor = true;
            this.btnIzracunajSazetak.Click += new System.EventHandler(this.btnIzracunajSazetak_Click);
            // 
            // btnPotpisiDatoteku
            // 
            this.btnPotpisiDatoteku.Location = new System.Drawing.Point(580, 12);
            this.btnPotpisiDatoteku.Name = "btnPotpisiDatoteku";
            this.btnPotpisiDatoteku.Size = new System.Drawing.Size(94, 23);
            this.btnPotpisiDatoteku.TabIndex = 4;
            this.btnPotpisiDatoteku.Text = "Potpiši datoteku";
            this.btnPotpisiDatoteku.UseVisualStyleBackColor = true;
            this.btnPotpisiDatoteku.Click += new System.EventHandler(this.btnPotpisiDatoteku_Click);
            // 
            // btnProvjeriPotpis
            // 
            this.btnProvjeriPotpis.Location = new System.Drawing.Point(680, 12);
            this.btnProvjeriPotpis.Name = "btnProvjeriPotpis";
            this.btnProvjeriPotpis.Size = new System.Drawing.Size(91, 23);
            this.btnProvjeriPotpis.TabIndex = 5;
            this.btnProvjeriPotpis.Text = "Provjeri potpis";
            this.btnProvjeriPotpis.UseVisualStyleBackColor = true;
            this.btnProvjeriPotpis.Click += new System.EventHandler(this.btnProvjeriPotpis_Click);
            // 
            // txtRezultat
            // 
            this.txtRezultat.Location = new System.Drawing.Point(80, 205);
            this.txtRezultat.Name = "txtRezultat";
            this.txtRezultat.ReadOnly = true;
            this.txtRezultat.Size = new System.Drawing.Size(634, 20);
            this.txtRezultat.TabIndex = 8;
            // 
            // lblPrikazRezultata
            // 
            this.lblPrikazRezultata.AutoSize = true;
            this.lblPrikazRezultata.Location = new System.Drawing.Point(86, 189);
            this.lblPrikazRezultata.Name = "lblPrikazRezultata";
            this.lblPrikazRezultata.Size = new System.Drawing.Size(112, 13);
            this.lblPrikazRezultata.TabIndex = 9;
            this.lblPrikazRezultata.Text = "Dekriptirana datoteka:";
            // 
            // btnKriptirajAsimetricno
            // 
            this.btnKriptirajAsimetricno.Location = new System.Drawing.Point(255, 51);
            this.btnKriptirajAsimetricno.Name = "btnKriptirajAsimetricno";
            this.btnKriptirajAsimetricno.Size = new System.Drawing.Size(150, 23);
            this.btnKriptirajAsimetricno.TabIndex = 11;
            this.btnKriptirajAsimetricno.Text = "Kriptiraj datoteku asimetrično";
            this.btnKriptirajAsimetricno.UseVisualStyleBackColor = true;
            this.btnKriptirajAsimetricno.Click += new System.EventHandler(this.btnKriptirajAsimetricno_Click);
            // 
            // btnDekriptirajAsimetricno
            // 
            this.btnDekriptirajAsimetricno.Location = new System.Drawing.Point(411, 51);
            this.btnDekriptirajAsimetricno.Name = "btnDekriptirajAsimetricno";
            this.btnDekriptirajAsimetricno.Size = new System.Drawing.Size(163, 23);
            this.btnDekriptirajAsimetricno.TabIndex = 12;
            this.btnDekriptirajAsimetricno.Text = "Dekriptiraj datoteku asimetrično";
            this.btnDekriptirajAsimetricno.UseVisualStyleBackColor = true;
            this.btnDekriptirajAsimetricno.Click += new System.EventHandler(this.btnDekriptirajAsimetricno_Click);
            // 
            // txtKriptirano
            // 
            this.txtKriptirano.Location = new System.Drawing.Point(80, 144);
            this.txtKriptirano.Name = "txtKriptirano";
            this.txtKriptirano.ReadOnly = true;
            this.txtKriptirano.Size = new System.Drawing.Size(634, 20);
            this.txtKriptirano.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Kriptirana datoteka:";
            // 
            // btnOdaberiDatoteku
            // 
            this.btnOdaberiDatoteku.Location = new System.Drawing.Point(35, 51);
            this.btnOdaberiDatoteku.Name = "btnOdaberiDatoteku";
            this.btnOdaberiDatoteku.Size = new System.Drawing.Size(108, 23);
            this.btnOdaberiDatoteku.TabIndex = 16;
            this.btnOdaberiDatoteku.Text = "Odaberi datoteku";
            this.btnOdaberiDatoteku.UseVisualStyleBackColor = true;
            this.btnOdaberiDatoteku.Click += new System.EventHandler(this.btnOdaberiDatoteku_Click);
            // 
            // FrmDigitalniPotpis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 261);
            this.Controls.Add(this.btnOdaberiDatoteku);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKriptirano);
            this.Controls.Add(this.btnDekriptirajAsimetricno);
            this.Controls.Add(this.btnKriptirajAsimetricno);
            this.Controls.Add(this.lblPrikazRezultata);
            this.Controls.Add(this.txtRezultat);
            this.Controls.Add(this.btnProvjeriPotpis);
            this.Controls.Add(this.btnPotpisiDatoteku);
            this.Controls.Add(this.btnIzracunajSazetak);
            this.Controls.Add(this.btnDekriptirajDatoteku);
            this.Controls.Add(this.btnKriptirajDatoteku);
            this.Controls.Add(this.btnGenerirajKljuceve);
            this.Name = "FrmDigitalniPotpis";
            this.Text = "Digitalni potpis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerirajKljuceve;
        private System.Windows.Forms.Button btnKriptirajDatoteku;
        private System.Windows.Forms.Button btnDekriptirajDatoteku;
        private System.Windows.Forms.Button btnIzracunajSazetak;
        private System.Windows.Forms.Button btnPotpisiDatoteku;
        private System.Windows.Forms.Button btnProvjeriPotpis;
        private System.Windows.Forms.TextBox txtRezultat;
        private System.Windows.Forms.Label lblPrikazRezultata;
        private System.Windows.Forms.Button btnKriptirajAsimetricno;
        private System.Windows.Forms.Button btnDekriptirajAsimetricno;
        private System.Windows.Forms.TextBox txtKriptirano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOdaberiDatoteku;
    }
}

