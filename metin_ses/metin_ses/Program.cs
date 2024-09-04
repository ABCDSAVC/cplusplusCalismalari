using System;
using System.IO;
using System.Security.Cryptography;
using System.Speech.Synthesis;
using System.Text;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\cansu\OneDrive\Masaüstü\c++\metinekleme\metinekleme\bin\Debug\received_data.txt";
            string key = "12345678";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            string[] encryptedMessages = File.ReadAllLines(filePath);

            foreach (string encryptedMessage in encryptedMessages)
            {
                string decryptedMessage = Decrypt(encryptedMessage, key);
                Console.WriteLine(decryptedMessage);
                Speak(decryptedMessage);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static string Decrypt(string encryptedText, string key)
        {
            using (DES des = DES.Create())
            {
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = des.Key;

                try
                {
                    byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                    ICryptoTransform transform = des.CreateDecryptor();
                    byte[] decryptedBytes = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
                catch (FormatException ex)
                {
                    // Base64 format hatası
                    Console.WriteLine("Base64 format error: " + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    // Diğer hatalar
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }
        static void Speak(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    synthesizer.SetOutputToDefaultAudioDevice();
                    synthesizer.Speak(text);
                }
            }
        }

    }
}
