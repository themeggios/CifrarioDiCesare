using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string targetHash = "5d41402abc4b2a76b9719d911017c592";
        string password = FindPassword(targetHash);
        
        if (password != null)
        {
            Console.WriteLine("La password originale è: " + password);
        }
        else
        {
            Console.WriteLine("Password non trovata.");
        }
    }

    static string FindPassword(string targetHash)
    {
        char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        int length = 5;

        // Genera tutte le combinazioni di 5 lettere
        return GenerateCombinations(letters, new char[length], 0, targetHash);
    }

    static string GenerateCombinations(char[] letters, char[] current, int position, string targetHash)
    {
        if (position == current.Length)
        {
            string candidate = new string(current);
            if (ComputeMD5(candidate) == targetHash)
            {
                return candidate;
            }
            return null;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            current[position] = letters[i];
            string result = GenerateCombinations(letters, current, position + 1, targetHash);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    static string ComputeMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Converti l'array di byte in una stringa esadecimale
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}