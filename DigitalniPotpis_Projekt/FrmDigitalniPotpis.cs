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

        private void btnKriptirajDatoteku_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOdabranaDatoteka.Text))
            {
                KriptirajDatoteku(txtOdabranaDatoteka.Text);
            }
            else
            {
                MessageBox.Show("Molimo odaberite datoteku za kriptiranje.");
            }
        }

        private void btnDekriptirajDatoteku_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOdabranaDatoteka.Text))
            {
                DekriptirajDatoteku(txtOdabranaDatoteka.Text);
            }
            else
            {
                MessageBox.Show("Molimo odaberite datoteku za dekriptiranje.");
            }
        }





        private void KriptirajDatoteku(string filePath)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.KeySize = 256;  // 256-bitni ključ
                    aesAlg.GenerateKey();  // Generira ključ
                    aesAlg.GenerateIV();   // Generira IV

                    byte[] encrypted;

                    using (FileStream fsOutput = new FileStream("kriptirana_datoteka.bin", FileMode.Create))
                    using (CryptoStream cs = new CryptoStream(fsOutput, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    using (FileStream fsInput = new FileStream(filePath, FileMode.Open))
                    {
                        fsInput.CopyTo(cs); // Kopira podatke iz izvornog u kriptirani stream
                    }

                    // Spremanje ključa i IV u datoteku kako bi se mogli koristiti za dekriptiranje
                    File.WriteAllText("aes_kljuc.txt", Convert.ToBase64String(aesAlg.Key));
                    File.WriteAllText("aes_iv.txt", Convert.ToBase64String(aesAlg.IV));

                    MessageBox.Show("Datoteka je uspješno kriptirana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri kriptiranju datoteke: " + ex.Message);
            }
        }

        private void DekriptirajDatoteku(string filePath)
        {
            try
            {
                // Učitaj ključ i IV iz datoteka
                byte[] key = Convert.FromBase64String(File.ReadAllText("aes_kljuc.txt"));
                byte[] iv = Convert.FromBase64String(File.ReadAllText("aes_iv.txt"));

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;

                    byte[] decrypted;

                    using (FileStream fsInput = new FileStream(filePath, FileMode.Open))
                    using (CryptoStream cs = new CryptoStream(fsInput, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    using (FileStream fsOutput = new FileStream("dekriptirana_datoteka.txt", FileMode.Create))
                    {
                        cs.CopyTo(fsOutput); // Kopira podatke iz kriptiranog streama u izvorni format
                    }

                    MessageBox.Show("Datoteka je uspješno dekriptirana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dekriptiranju datoteke: " + ex.Message);
            }
        }
    }
}
