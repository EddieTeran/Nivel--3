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

        //  Bucle for para imprimir las asignaturas 
        
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine("Yo estudio " + asignaturas[i]);
        }

        Console.ReadKey();
    }
}