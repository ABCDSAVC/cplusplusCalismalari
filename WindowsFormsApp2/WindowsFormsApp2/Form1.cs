using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace desdeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string en = Encrypt("munevver", textBox1.Text);
            Clipboard.SetText(en);
            textBox2.Text = en;

        }

        public string Encrypt(string key, string plaintext)
        {
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                byte[] keys = Encoding.UTF8.GetBytes(key);
                ICryptoTransform encryptor = provider.CreateEncryptor(keys, keys);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                byte[] input = Encoding.UTF8.GetBytes(plaintext);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public string Decrypt(string key, string CipherText)
        {
            byte[] buffer = Convert.FromBase64String(CipherText);
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                byte[] keys = Encoding.UTF8.GetBytes(key);
                ICryptoTransform encryptor = provider.CreateDecryptor(keys, keys);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                cs.Write(buffer, 0, buffer.Length);
                cs.FlushFinalBlock();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string de = Decrypt("munevver", textBox2.Text);
            Clipboard.SetText(de);
            textBox3.Text = de;

        }

    }
}
