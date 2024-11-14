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
            this.txtOdabranaDatoteka = new System.Windows.Forms.TextBox();
            this.lblOdabranaDatoteka = new System.Windows.Forms.Label();
            this.txtRezultat = new System.Windows.Forms.TextBox();
            this.lblPrikazRezultata = new System.Windows.Forms.Label();
            this.btnOdaberiDatoteku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerirajKljuceve
            // 
            this.btnGenerirajKljuceve.Location = new System.Drawing.Point(74, 45);
            this.btnGenerirajKljuceve.Name = "btnGenerirajKljuceve";
            this.btnGenerirajKljuceve.Size = new System.Drawing.Size(108, 23);
            this.btnGenerirajKljuceve.TabIndex = 0;
            this.btnGenerirajKljuceve.Text = "Generiraj ključeve";
            this.btnGenerirajKljuceve.UseVisualStyleBackColor = true;
            this.btnGenerirajKljuceve.Click += new System.EventHandler(this.btnGenerirajKljuceve_Click);
            // 
            // btnKriptirajDatoteku
            // 
            this.btnKriptirajDatoteku.Location = new System.Drawing.Point(188, 45);
            this.btnKriptirajDatoteku.Name = "btnKriptirajDatoteku";
            this.btnKriptirajDatoteku.Size = new System.Drawing.Size(97, 23);
            this.btnKriptirajDatoteku.TabIndex = 1;
            this.btnKriptirajDatoteku.Text = "Kriptiraj datoteku";
            this.btnKriptirajDatoteku.UseVisualStyleBackColor = true;
            // 
            // btnDekriptirajDatoteku
            // 
            this.btnDekriptirajDatoteku.Location = new System.Drawing.Point(291, 45);
            this.btnDekriptirajDatoteku.Name = "btnDekriptirajDatoteku";
            this.btnDekriptirajDatoteku.Size = new System.Drawing.Size(108, 23);
            this.btnDekriptirajDatoteku.TabIndex = 2;
            this.btnDekriptirajDatoteku.Text = "Dekriptiraj datoteku";
            this.btnDekriptirajDatoteku.UseVisualStyleBackColor = true;
            // 
            // btnIzracunajSazetak
            // 
            this.btnIzracunajSazetak.Location = new System.Drawing.Point(405, 45);
            this.btnIzracunajSazetak.Name = "btnIzracunajSazetak";
            this.btnIzracunajSazetak.Size = new System.Drawing.Size(106, 23);
            this.btnIzracunajSazetak.TabIndex = 3;
            this.btnIzracunajSazetak.Text = "Izračunaj sažetak";
            this.btnIzracunajSazetak.UseVisualStyleBackColor = true;
            // 
            // btnPotpisiDatoteku
            // 
            this.btnPotpisiDatoteku.Location = new System.Drawing.Point(517, 45);
            this.btnPotpisiDatoteku.Name = "btnPotpisiDatoteku";
            this.btnPotpisiDatoteku.Size = new System.Drawing.Size(94, 23);
            this.btnPotpisiDatoteku.TabIndex = 4;
            this.btnPotpisiDatoteku.Text = "Potpiši datoteku";
            this.btnPotpisiDatoteku.UseVisualStyleBackColor = true;
            // 
            // btnProvjeriPotpis
            // 
            this.btnProvjeriPotpis.Location = new System.Drawing.Point(617, 45);
            this.btnProvjeriPotpis.Name = "btnProvjeriPotpis";
            this.btnProvjeriPotpis.Size = new System.Drawing.Size(91, 23);
            this.btnProvjeriPotpis.TabIndex = 5;
            this.btnProvjeriPotpis.Text = "Provjeri potpis";
            this.btnProvjeriPotpis.UseVisualStyleBackColor = true;
            // 
            // txtOdabranaDatoteka
            // 
            this.txtOdabranaDatoteka.Location = new System.Drawing.Point(74, 167);
            this.txtOdabranaDatoteka.Name = "txtOdabranaDatoteka";
            this.txtOdabranaDatoteka.ReadOnly = true;
            this.txtOdabranaDatoteka.Size = new System.Drawing.Size(634, 20);
            this.txtOdabranaDatoteka.TabIndex = 6;
            // 
            // lblOdabranaDatoteka
            // 
            this.lblOdabranaDatoteka.AutoSize = true;
            this.lblOdabranaDatoteka.Location = new System.Drawing.Point(80, 151);
            this.lblOdabranaDatoteka.Name = "lblOdabranaDatoteka";
            this.lblOdabranaDatoteka.Size = new System.Drawing.Size(102, 13);
            this.lblOdabranaDatoteka.TabIndex = 7;
            this.lblOdabranaDatoteka.Text = "Odabrana datoteka:";
            // 
            // txtRezultat
            // 
            this.txtRezultat.Location = new System.Drawing.Point(74, 317);
            this.txtRezultat.Name = "txtRezultat";
            this.txtRezultat.ReadOnly = true;
            this.txtRezultat.Size = new System.Drawing.Size(634, 20);
            this.txtRezultat.TabIndex = 8;
            // 
            // lblPrikazRezultata
            // 
            this.lblPrikazRezultata.AutoSize = true;
            this.lblPrikazRezultata.Location = new System.Drawing.Point(80, 301);
            this.lblPrikazRezultata.Name = "lblPrikazRezultata";
            this.lblPrikazRezultata.Size = new System.Drawing.Size(82, 13);
            this.lblPrikazRezultata.TabIndex = 9;
            this.lblPrikazRezultata.Text = "Prikaz rezultata:";
            // 
            // btnOdaberiDatoteku
            // 
            this.btnOdaberiDatoteku.Location = new System.Drawing.Point(349, 107);
            this.btnOdaberiDatoteku.Name = "btnOdaberiDatoteku";
            this.btnOdaberiDatoteku.Size = new System.Drawing.Size(100, 23);
            this.btnOdaberiDatoteku.TabIndex = 10;
            this.btnOdaberiDatoteku.Text = "Odaberi datoteku";
            this.btnOdaberiDatoteku.UseVisualStyleBackColor = true;
            this.btnOdaberiDatoteku.Click += new System.EventHandler(this.btnOdaberiDatoteku_Click);
            // 
            // FrmDigitalniPotpis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOdaberiDatoteku);
            this.Controls.Add(this.lblPrikazRezultata);
            this.Controls.Add(this.txtRezultat);
            this.Controls.Add(this.lblOdabranaDatoteka);
            this.Controls.Add(this.txtOdabranaDatoteka);
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
        private System.Windows.Forms.TextBox txtOdabranaDatoteka;
        private System.Windows.Forms.Label lblOdabranaDatoteka;
        private System.Windows.Forms.TextBox txtRezultat;
        private System.Windows.Forms.Label lblPrikazRezultata;
        private System.Windows.Forms.Button btnOdaberiDatoteku;
    }
}

