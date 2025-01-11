using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista que almacena los ganadores
        List<int> ganadores = new List<int>();

        // Bucle for e Interaccion con usuario
        for (int i = 0; i < 6; i++)
        {
            Console.Write("Introduce un numero ganador: ");
            int numero;
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Por favor, introduce un numero válido: ");
            }
            ganadores.Add(numero);
        }

        // Metodo sort para ordenar los numeros
        ganadores.Sort();

        // Imprime los numeros
        Console.WriteLine("Los numeros ganadores son: " + string.Join(", ", ganadores));
        Console.ReadKey();
    }
}