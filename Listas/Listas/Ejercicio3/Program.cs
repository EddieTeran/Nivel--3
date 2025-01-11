using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista que almacena las asignaturas
        List<string> asignaturas = new List<string>
        {
            "Estructura De Datos",
            "Instalaciones Electricas y de Cableado Estructurado",
            "Administracion de Sistema Operativos",
            "Fundamentos de Sistemas Digitales",
            "Metodologias de la Investigacion"
        };

        // Lista que almacena las notas
        List<double> notas = new List<double>();

        // Interaccion con usuario
        Console.WriteLine("Introduce las notas para las siguientes asignaturas:");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.Write($"Introduce la nota de {asignaturas[i]}: ");
            double nota;
            while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            {
                Console.Write("Por favor, introduce una nota válida (0-10): ");
            }
            notas.Add(nota);
        }

        // Improme las asignaturas y notas
        Console.WriteLine("\nResultados:");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}");
            Console.ReadKey();
        }

        
        
    }
}