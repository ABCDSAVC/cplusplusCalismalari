using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public partial class Form1 : Form
{
    private string anahtar = "ArmutAnaht"; // Anahtarınızı buraya girin

    public Form1()
    {
        InitializeComponent();
    }

    private void sifrele_Click(object sender, EventArgs e)
    {
        // Metni ASCII koduna dönüştür
        string metin = textBox1.Text;
        byte[] metinAscii = Encoding.ASCII.GetBytes(metin);

        // DES algoritması ile şifrele
        byte[] sifreliMetin = Sifrele(metinAscii, anahtar);

        // Şifreli metni textBox2'ye yaz
        textBox2.Text = Convert.ToBase64String(sifreliMetin);
    }

    private void coz_Click(object sender, EventArgs e)
    {
        // Şifreli metni Base64'ten byte dizisine dönüştür
        string sifreliMetin = textBox2.Text;
        byte[] sifreliMetinAscii = Convert.FromBase64String(sifreliMetin);

        // DES algoritması ile çöz
        byte[] cozulmusMetin = Coz(sifreliMetinAscii, anahtar);

        // Çözülmüş metni textBox1'e yaz
        textBox1.Text = Encoding.ASCII.GetString(cozulmusMetin);
    }

    private byte[] Sifrele(byte[] metin, string anahtar)
    {
        using (DES des = DES.Create())
        {
            des.Key = Encoding.ASCII.GetBytes(anahtar);
            des.IV = new byte[des.BlockSize / 8]; // Başlangıç vektörü (IV) sıfırlanabilir

            using (ICryptoTransform encryptor = des.CreateEncryptor())
            {
                return encryptor.TransformFinalBlock(metin, 0, metin.Length);
            }
        }
    }

    private byte[] Coz(byte[] sifreliMetin, string anahtar)
    {
        using (DES des = DES.Create())
        {
            des.Key = Encoding.ASCII.GetBytes(anahtar);
            des.IV = new byte[des.BlockSize / 8]; // Başlangıç vektörü (IV) sıfırlanabilir

            using (ICryptoTransform decryptor = des.CreateDecryptor())
            {
                return decryptor.TransformFinalBlock(sifreliMetin, 0, sifreliMetin.Length);
            }
        }
    }
}
