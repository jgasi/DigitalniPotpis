using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DigitalniPotpis_Projekt
{
    public partial class FrmDigitalniPotpis : Form
    {
        public FrmDigitalniPotpis()
        {
            InitializeComponent();
        }

        private void btnOdaberiDatoteku_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*",
                Title = "Odaberi datoteku za obradu"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOdabranaDatoteka.Text = openFileDialog.FileName;
            }
        }

        private void btnGenerirajKljuceve_Click(object sender, EventArgs e)
        {
            if (File.Exists("tajni_kljuc.txt") || File.Exists("privatni_kljuc.txt") || File.Exists("javni_kljuc.txt"))
            {
                var result = MessageBox.Show("Ključevi već postoje. Želite li ih zamijeniti novima?", "Upozorenje", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider(2048))
                {
                    // Izvoz privatnog ključa u Base64
                    byte[] privateKey = rsaAlg.ExportCspBlob(true);  // true za privatni ključ
                    File.WriteAllText("privatni_kljuc.txt", Convert.ToBase64String(privateKey));

                    // Izvoz javnog ključa u Base64
                    byte[] publicKey = rsaAlg.ExportCspBlob(false);  // false za javni ključ
                    File.WriteAllText("javni_kljuc.txt", Convert.ToBase64String(publicKey));
                }

                MessageBox.Show("Ključevi su uspješno generirani i pohranjeni!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom generiranja ključeva: {ex.Message}");
            }
        }
    }
}
