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
                    // Izvoz privatnog ključa u XML
                    string privateKeyXml = rsaAlg.ToXmlString(true); // true za privatni ključ
                    File.WriteAllText("privatni_kljuc.xml", privateKeyXml);

                    // Izvoz javnog ključa u XML
                    string publicKeyXml = rsaAlg.ToXmlString(false); // false za javni ključ
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
            // Provjera je li globalna varijabla 'odabranaDatoteka' postavljena
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                // Ako nije, pitaj korisnika da odabere datoteku
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All files (*.*)|*.*"; // Filter za datoteke

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        odabranaDatoteka = openFileDialog.FileName; // Spremi putanju odabrane datoteke
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
            // Provjeravamo postoji li kriptirana datoteka
            string encryptedFilePath = "kriptirana_datoteka.bin"; // Promijeni prema tvojoj datoteci

            if (File.Exists(encryptedFilePath))
            {
                // Pozivamo funkciju za dekriptiranje s unaprijed definiranom kriptiranom datotekom
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
                    aesAlg.KeySize = 256;  // 256-bitni ključ
                    aesAlg.GenerateKey();  // Generira ključ
                    aesAlg.GenerateIV();   // Generira IV

                    using (FileStream fsOutput = new FileStream("kriptirana_datoteka.bin", FileMode.Create))
                    using (CryptoStream cs = new CryptoStream(fsOutput, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    using (FileStream fsInput = new FileStream(filePath, FileMode.Open))
                    {
                        fsInput.CopyTo(cs); // Kopira podatke iz izvornog u kriptirani stream
                    }

                    // Spremanje ključa i IV u datoteku kako bi se mogli koristiti za dekriptiranje
                    File.WriteAllText("aes_kljuc.txt", Convert.ToBase64String(aesAlg.Key));
                    File.WriteAllText("aes_iv.txt", Convert.ToBase64String(aesAlg.IV));

                    // Dodavanje sadržaja kriptirane datoteke u txtKriptirano (Base64 kodirano)
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
                // Učitaj ključ i IV iz datoteka
                byte[] key = Convert.FromBase64String(File.ReadAllText("aes_kljuc.txt"));
                byte[] iv = Convert.FromBase64String(File.ReadAllText("aes_iv.txt"));

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;

                    // Provodi dekripciju datoteke
                    using (FileStream fsInput = new FileStream(filePath, FileMode.Open))
                    using (CryptoStream cs = new CryptoStream(fsInput, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    using (FileStream fsOutput = new FileStream("dekriptirana_datoteka.txt", FileMode.Create))
                    {
                        cs.CopyTo(fsOutput); // Kopira podatke iz kriptiranog streama u izvorni format
                    }

                    // Dodavanje sadržaja dekriptirane datoteke u txtRezultat
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
                // Učitavanje datoteke
                byte[] fileBytes = File.ReadAllBytes(odabranaDatoteka);

                // Kreiranje SHA256 hash algoritma
                using (SHA256 sha256 = SHA256.Create())
                {
                    // Izračunavanje hash vrijednosti
                    byte[] hashBytes = sha256.ComputeHash(fileBytes);

                    // Konvertiranje hash-a u hexadecimalni string
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    // Prikaz sažetka u textbox-u
                    txtRezultat.Text = hashString;

                    // Pohrana sažetka u datoteku
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
                // Učitaj privatni ključ iz XML datoteke
                string privateKeyXml = File.ReadAllText("privatni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    // Učitaj privatni ključ iz XML stringa
                    rsaAlg.FromXmlString(privateKeyXml);

                    // Učitaj datoteku koju želimo potpisati
                    byte[] fileBytes = File.ReadAllBytes(odabranaDatoteka);

                    // Izračunaj sažetak datoteke
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hash = sha256.ComputeHash(fileBytes);

                        // Potpiši sažetak privatnim ključem
                        byte[] digitalSignature = rsaAlg.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));

                        // Spremi digitalni potpis u datoteku
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
                // Učitaj javni ključ iz XML datoteke
                string publicKeyXml = File.ReadAllText("javni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    // Učitaj javni ključ iz XML stringa
                    rsaAlg.FromXmlString(publicKeyXml);

                    // Učitaj datoteku koju želimo provjeriti
                    byte[] fileBytes = File.ReadAllBytes(odabranaDatoteka);

                    // Izračunaj sažetak datoteke
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hash = sha256.ComputeHash(fileBytes);

                        // Učitaj digitalni potpis iz datoteke
                        byte[] digitalSignature = File.ReadAllBytes("digitalni_potpis.bin");

                        // Provjeri potpis
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
            // Provjeri je li globalna varijabla 'odabranaDatoteka' postavljena
            if (string.IsNullOrEmpty(odabranaDatoteka) || !File.Exists(odabranaDatoteka))
            {
                // Ako nije, pitaj korisnika da odabere datoteku
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "All files (*.*)|*.*"; // Filter za datoteke

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        odabranaDatoteka = openFileDialog.FileName; // Spremi putanju odabrane datoteke
                        MessageBox.Show("Datoteka je uspješno odabrana!");
                    }
                    else
                    {
                        MessageBox.Show("Morate odabrati datoteku za kriptiranje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Nastavi s kriptiranjem datoteke
            KriptirajAsimetricnoDatoteku(odabranaDatoteka);
        }

        private void KriptirajAsimetricnoDatoteku(string filePath)
        {
            try
            {
                // Učitaj javni ključ iz XML datoteke
                string publicKeyXml = File.ReadAllText("javni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    // Importiraj javni ključ
                    rsaAlg.FromXmlString(publicKeyXml);

                    // Učitaj datoteku koju želimo kriptirati
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    // Kriptiraj datoteku pomoću javnog ključa
                    byte[] encryptedBytes = rsaAlg.Encrypt(fileBytes, false); // false znači bez OaepSHA256, standardni padding

                    // Spremi kriptirani sadržaj u datoteku s hardkodiranim imenom
                    string encryptedFilePath = "asimetricno_kriptirana_datoteka.bin"; // Hardkodirano ime datoteke
                    File.WriteAllBytes(encryptedFilePath, encryptedBytes);

                    // Dodaj sadržaj kriptirane datoteke u txtKriptirano (Base64 kodirano)
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
            // Hardkodirani naziv kriptirane datoteke
            string encryptedFilePath = "asimetricno_kriptirana_datoteka.bin"; // Hardkodirani naziv datoteke

            // Provjera postoji li kriptirana datoteka
            if (File.Exists(encryptedFilePath))
            {
                // Pozivamo funkciju za dekriptiranje s fiksnim imenom kriptirane datoteke
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
                // Učitaj privatni ključ iz XML datoteke
                string privateKeyXml = File.ReadAllText("privatni_kljuc.xml");

                using (RSACryptoServiceProvider rsaAlg = new RSACryptoServiceProvider())
                {
                    // Importiraj privatni ključ
                    rsaAlg.FromXmlString(privateKeyXml);

                    // Učitaj kriptirani sadržaj
                    byte[] encryptedBytes = File.ReadAllBytes(filePath);

                    // Dekriptiraj datoteku pomoću privatnog ključa
                    byte[] decryptedBytes = rsaAlg.Decrypt(encryptedBytes, false); // false znači bez OaepSHA256, standardni padding

                    // Spremi dekriptirani sadržaj u novu datoteku
                    string decryptedFilePath = Path.ChangeExtension(filePath, ".dekriptirani.dat");
                    File.WriteAllBytes(decryptedFilePath, decryptedBytes);

                    // Dodaj sadržaj dekriptirane datoteke u txtRezultat (TextBox)
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
