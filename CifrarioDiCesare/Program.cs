using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Cifratura di Cesare");
        Console.Write("Inserisci il testo da cifrare: ");
        string input = Console.ReadLine();

        Console.Write("Inserisci il valore di spostamento (chiave): ");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = Encrypt(input, shift);
        Console.WriteLine($"Testo cifrato: {encrypted}");

        string decrypted = Decrypt(encrypted, shift);
        Console.WriteLine($"Testo decifrato: {decrypted}");
    }

    static string Encrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            letter = (char)(letter + shift);

            // Gestione del wrap-around per le lettere maiuscole
            if (char.IsUpper(buffer[i]))
            {
                if (letter > 'Z')
                {
                    letter = (char)(letter - 26);
                }
            }
            // Gestione del wrap-around per le lettere minuscole
            else if (char.IsLower(buffer[i]))
            {
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
            }

            buffer[i] = letter;
        }

        return new string(buffer);
    }

    static string Decrypt(string text, int shift)
    {
        return Encrypt(text, -shift); // La decifratura è semplicemente la cifratura con un shift negativo
    }
}