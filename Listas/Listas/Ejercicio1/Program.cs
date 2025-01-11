using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Lista de asignaturas
        List<string> asignaturas = new List<string>
        {
            "Estructura De Datos",
            "Instalaciones Electricas y de Cableado Estructurado",
            "Administracion de Sistema Operativos",
            "Fundamentos de Sistemas Digitales",
            "Metodologias de la Investigacion"
        };

        // Imprime en consola las asignaturas
        Console.WriteLine("Asignaturas del curso:");
        Console.WriteLine("- " + asignaturas[0]);
        Console.WriteLine("- " + asignaturas[1]);
        Console.WriteLine("- " + asignaturas[2]);
        Console.WriteLine("- " + asignaturas[3]);
        Console.WriteLine("- " + asignaturas[4]);

        Console.ReadKey();
    }
}