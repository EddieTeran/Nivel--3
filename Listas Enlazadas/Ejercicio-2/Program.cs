using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista 
        List<string> diasDeLaSemana = new List<string>
        {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"
        };

        // Imprime la lista 
        Console.WriteLine("Días de la semana:");
        foreach (string dia in diasDeLaSemana)
        {
            Console.WriteLine(dia);
        }

        // Calcula los elementos
        int numeroDeDias = diasDeLaSemana.Count;

        // Imprime el total
        Console.WriteLine("\nTotal días de la semana: " + numeroDeDias);
        Console.ReadKey();
    }
}