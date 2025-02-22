using System;
using System.Collections.Generic;
using System.Linq;

// Clase que representa a un ciudadano
public class Ciudadano
{
    public int Id { get; set; } // Identificador único del ciudadano
    public string Vacuna { get; set; } = "No vacunado"; // Por defecto es "No vacunado"

    // Sobrescribir Equals y GetHashCode para asegurar una comparación adecuada en HashSet
    public override bool Equals(object obj)
    {
        if (obj is Ciudadano otro)
        {
            return Id == otro.Id; // Comparar solo por ID
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode(); // Usar ID para el hash
    }
}

public class Program
{
    // Método para mostrar el menú de opciones
    static void MostrarMenu()
    {
        Console.Clear(); 
        Console.WriteLine("********** MENÚ DE CONJUNTOS DE VACUNACIÓN **********");
        Console.WriteLine("1. Ciudadanos no vacunados");
        Console.WriteLine("2. Ciudadanos vacunados con Pfizer");
        Console.WriteLine("3. Ciudadanos vacunados con AstraZeneca");
        Console.WriteLine("4. Ciudadanos vacunados (Pfizer y AstraZeneca)");
        Console.WriteLine("5. Ver todos por categorias");
        Console.WriteLine("6. Salir");
        Console.Write("\nSeleccione una opción: ");
    }

    // Método para mostrar un conjunto de ciudadanos con un título
    static void MostrarConjunto(HashSet<Ciudadano> conjunto, string titulo)
    {
        // Metod count para mostrar hasta 15 ciudadanos
        Console.WriteLine($"\n=== {titulo} ({conjunto.Count} personas) ===");
        foreach (var ciudadano in conjunto.Take(15))
        {
            Console.WriteLine($"ID: {ciudadano.Id} - Vacuna: {ciudadano.Vacuna}");
        }

        // Si hay más de 15 ciudadanos, indicar que hay más
        if (conjunto.Count > 15)
            Console.WriteLine($"... y {conjunto.Count - 15} más...");

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey(); // Esperar a que el usuario presione una tecla
    }

    public static void Main()
    {
        // Crecion 500 ciudadanos
        HashSet<Ciudadano> poblacionTotal = new HashSet<Ciudadano>(
            Enumerable.Range(1, 500).Select(id => new Ciudadano { Id = id })); 

        // vacunados con Pfizer
        HashSet<Ciudadano> vacunadosPfizer = new HashSet<Ciudadano>(poblacionTotal.Take(75)); 
        vacunadosPfizer.ToList().ForEach(c => c.Vacuna = "Pfizer"); 
        
        // 75 vacunados con AstraZeneca
        HashSet<Ciudadano> vacunadosAstraZeneca = new HashSet<Ciudadano>(poblacionTotal.Skip(75).Take(75)); 
        vacunadosAstraZeneca.ToList().ForEach(c => c.Vacuna = "AstraZeneca");

        // Listados de vacunados y no vacunados
        HashSet<Ciudadano> noVacunados = new HashSet<Ciudadano>(poblacionTotal); 
        noVacunados.ExceptWith(vacunadosPfizer); 
        noVacunados.ExceptWith(vacunadosAstraZeneca); 

        // Vacunados con Pfizer
        HashSet<Ciudadano> soloPfizer = new HashSet<Ciudadano>(vacunadosPfizer); 
        soloPfizer.ExceptWith(vacunadosAstraZeneca); .
        
        // Vacunados con AstraZeneca
        HashSet<Ciudadano> soloAstraZeneca = new HashSet<Ciudadano>(vacunadosAstraZeneca); 
        soloAstraZeneca.ExceptWith(vacunadosPfizer); 

        // Unión de conjuntos de ambas vacunas
        HashSet<Ciudadano> vacunadosTotales = new HashSet<Ciudadano>(vacunadosPfizer);
        vacunadosTotales.UnionWith(vacunadosAstraZeneca); 

        // Menú interactivo
        int opcion;
        do
        {   // Mostrar el menú
            MostrarMenu(); 
            int.TryParse(Console.ReadLine(), out opcion); /

            switch (opcion)
            {
                case 1:
                    MostrarConjunto(noVacunados, "CIUDADANOS NO VACUNADOS"); // Mostrar no vacunados
                    break;
                case 2:
                    MostrarConjunto(soloPfizer, "CIUDADANOS VACUNADOS PFIZER"); // Mostrar solo vacunados con Pfizer
                    break;
                case 3:
                    MostrarConjunto(soloAstraZeneca, "CIUDADANOS VACUNADOS ASTRAZENECA"); // Mostrar solo vacunados con AstraZeneca
                    break;
                case 4:
                    MostrarConjunto(vacunadosTotales, "CIUDADANOS VACUNADOS (PFIZER Y ASTRAZENECA)"); // Mostrar todos los vacunados
                    break;
                case 5:
                    // Mostrar todos los conjuntos
                    MostrarConjunto(noVacunados, "CIUDADANOS NO VACUNADOS");
                    MostrarConjunto(soloPfizer, "CIUDADANOS VACUNADOS PFIZER");
                    MostrarConjunto(soloAstraZeneca, "CIUDADANOS VACUNADOS ASTRAZENECA");
                    MostrarConjunto(vacunadosTotales, "VACUNADOS TOTALES");
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa..."); // Mensaje de salida
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente."); 
                    Console.ReadKey();
                    break;
            }
        } while (opcion != 6); // Bucle hasta que el usuario elija salir
    }
}
