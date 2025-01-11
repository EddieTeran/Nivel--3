using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista de numeros
        List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Metodo reverse para invertir numeros
        numeros.Reverse();

        // Imprime los números en orden inverso
        Console.WriteLine("Numeros en orden inverso:");
        Console.WriteLine(string.Join(", ", numeros));

       
        Console.ReadKey();
    }
}