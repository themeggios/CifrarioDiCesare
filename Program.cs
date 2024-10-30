class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci il testo da cifrare:");
        string input = Console.ReadLine();
        
        Console.WriteLine("Numero di posizioni da spostare:");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = CifraDiCesare(input, shift);
        Console.WriteLine($"Testo cifrato: {encrypted}");
    }

    static string CifraDiCesare(string testo, int shift)
    {
        string risultato = string.Empty;

        foreach (char c in testo)
        {
            // Verifica se il carattere è una lettera maiuscola
            if (char.IsUpper(c))
            {
                char shiftedChar = (char)((((c + shift) - 'A') % 26) + 'A');
                risultato += shiftedChar;
            }
            // Verifica se il carattere è una lettera minuscola
            else if (char.IsLower(c))
            {
                char shiftedChar = (char)((((c + shift) - 'a') % 26) + 'a');
                risultato += shiftedChar;
            }
            else
            {
                // Se non è una lettera, aggiungi il carattere originale
                risultato += c;
            }
        }

        return risultato;
    }

    static string DecifraDiCesare(string testo, int shift)
    {
        string risultato = string.Empty;

        foreach (char c in testo)
        {
            // Verifica se il carattere è una lettera maiuscola
            if (char.IsUpper(c))
            {
                char shiftedChar = (char)((((c - shift) - 'A') % 26) + 'A');
                risultato += shiftedChar;
            }
            // Verifica se il carattere è una lettera minuscola
            else if (char.IsLower(c))
            {
                char shiftedChar = (char)((((c - shift) - 'a') % 26) + 'a');
                risultato += shiftedChar;
            }
            else
            {
                // Se non è una lettera, aggiungi il carattere originale
                risultato += c;
            }
        }

        return risultato;
    }
}