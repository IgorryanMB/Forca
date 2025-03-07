using System;
using System.Collections.Generic;
using System.Linq;

public class JogoDaForca
{
    public static void Main(string[] args)
    {
        string[] palavras = { "programacao", "computador", "algoritmo", "desenvolvimento", "tecnologia" };
        Random random = new Random();
        string palavraSecreta = palavras[random.Next(palavras.Length)];
        List<char> letrasAdivinhadas = new List<char>();
        int tentativasRestantes = 6;

        Console.WriteLine("Bem-vindo ao Jogo da Forca!");

        while (tentativasRestantes > 0)
        {
            Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
            ExibirPalavraOculta(palavraSecreta, letrasAdivinhadas);

            Console.Write("Digite uma letra: ");
            char palpite = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (letrasAdivinhadas.Contains(palpite))
            {
                Console.WriteLine("Você já adivinhou essa letra!");
                continue;
            }

            letrasAdivinhadas.Add(palpite);

            if (!palavraSecreta.Contains(palpite))
            {
                Console.WriteLine("Letra incorreta!");
                tentativasRestantes--;
            }

            if (PalavraAdivinhada(palavraSecreta, letrasAdivinhadas))
            {
                Console.WriteLine($"Parabéns! Você adivinhou a palavra: {palavraSecreta}");
                break;
            }
        }

        if (tentativasRestantes == 0)
        {
            Console.WriteLine($"Você perdeu! A palavra era: {palavraSecreta}");
        }
    }

    public static void ExibirPalavraOculta(string palavra, List<char> letrasAdivinhadas)
    {
        foreach (char letra in palavra)
        {
            if (letrasAdivinhadas.Contains(letra))
            {
                Console.Write($"{letra} ");
            }
            else
            {
                Console.Write("_ ");
            }
        }
        Console.WriteLine();
    }

    public static bool PalavraAdivinhada(string palavra, List<char> letrasAdivinhadas)
    {
        return palavra.All(letra => letrasAdivinhadas.Contains(letra));
    }
}