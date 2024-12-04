using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DigitalniPotpis_Projekt
{
    public partial class FrmDigitalniPotpis : Form
    {
        private string odabranaDatoteka = string.Empty;


        public FrmDigitalniPotpis()
        {
            InitializeComponent();
        }


        private void btnOdaberiDatoteku_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    odabranaDatoteka = openFileDialog.FileName;
                    txtOdabranaDatoteka.Text = openFileDialog.FileName;

                    MessageBox.Show("Datoteka je uspješno odabrana!");
                }
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
                    string privateKeyXml = rsaAlg.ToXmlString(true);
                    File.WriteAllText("privatni_kljuc.xml", privateKeyXml);

                    string publicKeyXml = rsaAlg.ToXmlString(false);
                    File.WriteAllText("javni_kljuc.xml", publicKeyXml);
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
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        odabranaDatoteka = openFileDialog.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Morate odabrati datoteku za kriptiranje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            KriptirajDatoteku(odabranaDatoteka);
        }


        private void btnDekriptirajDatoteku_Click(object sender, EventArgs e)
        {
            string encryptedFilePath = "kriptirana_datoteka.bin";

            if (File.Exists(encryptedFilePath))
            {
                DekriptirajDatoteku(encryptedFilePath);
            }
            else
            {
                MessageBox.Show("Kriptirana datoteka ne postoji.");
            }
        }


        private void KriptirajDatoteku(string filePath)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.KeySize = 256;
                    aesAlg.GenerateKey();
                    aesAlg.GenerateIV();

                    using (FileStream fsOutput = new FileStream("kriptirana_datoteka.bin", FileMode.Create))
                    using (CryptoStream cs = new CryptoStream(fsOutput, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    using (FileStream fsInput = new FileStream(filePath, FileMode.Open))
                    {
                        fsInput.CopyTo(cs);
                    }

                    File.WriteAllText("aes_kljuc.txt", Convert.ToBase64String(aesAlg.Key));
                    File.WriteAllText("aes_iv.txt", Convert.ToBase64String(aesAlg.IV));

                    byte[] encryptedData = File.ReadAllBytes("kriptirana_datoteka.bin");
                    string base64EncryptedData = Convert.ToBase64String(encryptedData);
                    txtKriptirano.Text = base64EncryptedData;

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
                byte[] key = Convert.FromBase64String(File.ReadAllText("aes_kljuc.txt"));
                byte[] iv = Convert.FromBase64String(File.ReadAllText("aes_iv.txt"));

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;

                    using (FileStream fsInput = new FileStream(filePath, FileMode.Open))
                    using (CryptoStream cs = new CryptoStream(fsInput, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    using (FileStream fsOutput = new FileStream("dekriptirana_datoteka.txt", FileMode.Create))
                    {
                        cs.CopyTo(fsOutput);
                    }

                    string decryptedText = File.ReadAllText("dekriptirana_datoteka.txt");
                    txtRezultat.Text = decryptedText;

                    MessageBox.Show("Datoteka je uspješno dekriptirana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dekriptiranju datoteke: " + ex.Message);
            }
        }


        private void btnIzracunajSazetak_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                MessageBox.Show("Molimo odaberite valjanu datoteku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                byte[] fileBytes = File.ReadAllBytes(odabranaDatoteka);

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(fileBytes);

                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    txtIzracunatiSazetak.Text = hashString;

                    File.WriteAllText("sazetak.txt", hashString);

                    MessageBox.Show("Sažetak je uspješno izračunat i pohranjen!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPotpisiDatoteku_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                MessageBox.Show("Molimo odaberite valjanu datoteku za potpisivanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string privateKeyXml = File.ReadAllText("privatni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    rsaAlg.FromXmlString(privateKeyXml);

                    byte[] fileBytes = File.ReadAllBytes(odabranaDatoteka);

                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hash = sha256.ComputeHash(fileBytes);

                        byte[] digitalSignature = rsaAlg.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));

                        File.WriteAllBytes("digitalni_potpis.bin", digitalSignature);

                        MessageBox.Show("Datoteka je uspješno potpisana!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pogreška prilikom potpisivanja: " + ex.Message);
            }
        }

        private void btnProvjeriPotpis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                MessageBox.Show("Molimo odaberite valjanu datoteku za provjeru potpisa.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string publicKeyXml = File.ReadAllText("javni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    rsaAlg.FromXmlString(publicKeyXml);

                    byte[] fileBytes = File.ReadAllBytes(odabranaDatoteka);

                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hash = sha256.ComputeHash(fileBytes);

                        byte[] digitalSignature = File.ReadAllBytes("digitalni_potpis.bin");

                        bool isValid = rsaAlg.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), digitalSignature);

                        if (isValid)
                        {
                            MessageBox.Show("Digitalni potpis je valjan!");
                        }
                        else
                        {
                            MessageBox.Show("Digitalni potpis nije valjan.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pogreška prilikom provjere potpisa: " + ex.Message);
            }
        }

        private void btnKriptirajAsimetricno_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        odabranaDatoteka = openFileDialog.FileName;
                        MessageBox.Show("Datoteka je uspješno odabrana!");
                    }
                    else
                    {
                        MessageBox.Show("Morate odabrati datoteku za kriptiranje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            KriptirajAsimetricnoDatoteku(odabranaDatoteka);
        }

        private void KriptirajAsimetricnoDatoteku(string filePath)
        {
            try
            {
                string publicKeyXml = File.ReadAllText("javni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    rsaAlg.FromXmlString(publicKeyXml);

                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    byte[] encryptedBytes = rsaAlg.Encrypt(fileBytes, false);

                    string encryptedFilePath = "asimetricno_kriptirana_datoteka.bin";
                    File.WriteAllBytes(encryptedFilePath, encryptedBytes);

                    string base64EncryptedData = Convert.ToBase64String(encryptedBytes);
                    txtKriptirano.Text = base64EncryptedData;

                    MessageBox.Show("Datoteka je uspješno kriptirana!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri kriptiranju datoteke: " + ex.Message);
            }
        }


        private void btnDekriptirajAsimetricno_Click(object sender, EventArgs e)
        {
            string encryptedFilePath = "asimetricno_kriptirana_datoteka.bin";

            if (File.Exists(encryptedFilePath))
            {
                DekriptirajAsimetricno(encryptedFilePath);
            }
            else
            {
                MessageBox.Show("Kriptirana datoteka nije pronađena.");
            }
        }

        private void DekriptirajAsimetricno(string filePath)
        {
            try
            {
                string privateKeyXml = File.ReadAllText("privatni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    rsaAlg.FromXmlString(privateKeyXml);

                    byte[] encryptedBytes = File.ReadAllBytes(filePath);

                    byte[] decryptedBytes = rsaAlg.Decrypt(encryptedBytes, false);

                    string decryptedFilePath = Path.ChangeExtension(filePath, ".dekriptirani.dat");
                    File.WriteAllBytes(decryptedFilePath, decryptedBytes);

                    string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
                    txtRezultat.Text = decryptedText;

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
