using System;
using System.Collections.Generic;
using System.Linq;

// Clase que representa a un ciudadano
public class Ciudadano
{
    public int Id { get; set; } // Identificador único del ciudadano
    public string Vacuna { get; set; } = "No vacunado"; // Estado de vacunación, por defecto es "No vacunado"

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
        Console.Clear(); // Limpiar la consola
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
        // Creación inicial de conjuntos de ciudadanos
        HashSet<Ciudadano> poblacionTotal = new HashSet<Ciudadano>(
            Enumerable.Range(1, 500).Select(id => new Ciudadano { Id = id })); // Crear 500 ciudadanos

        // Crear conjuntos de vacunados asegurando que no haya duplicados
        HashSet<Ciudadano> vacunadosPfizer = new HashSet<Ciudadano>(poblacionTotal.Take(75)); //75 vacunados con Pfizer
        vacunadosPfizer.ToList().ForEach(c => c.Vacuna = "Pfizer"); // Asignar la vacuna Pfizer

        HashSet<Ciudadano> vacunadosAstraZeneca = new HashSet<Ciudadano>(poblacionTotal.Skip(75).Take(75)); // 75 vacunados con AstraZeneca
        vacunadosAstraZeneca.ToList().ForEach(c => c.Vacuna = "AstraZeneca"); // Asignar la vacuna AstraZeneca

        // Listados de vacunados y no vacunados
        HashSet<Ciudadano> noVacunados = new HashSet<Ciudadano>(poblacionTotal); // Inicialmente todos son no vacunados
        noVacunados.ExceptWith(vacunadosPfizer); // Eliminar los vacunados con Pfizer
        noVacunados.ExceptWith(vacunadosAstraZeneca); // Eliminar los vacunados con AstraZeneca

        HashSet<Ciudadano> soloPfizer = new HashSet<Ciudadano>(vacunadosPfizer); // Conjunto de solo vacunados con Pfizer
        soloPfizer.ExceptWith(vacunadosAstraZeneca); // Eliminar los vacunados con AstraZeneca

        HashSet<Ciudadano> soloAstraZeneca = new HashSet<Ciudadano>(vacunadosAstraZeneca); // Conjunto de solo vacunados con AstraZeneca
        soloAstraZeneca.ExceptWith(vacunadosPfizer); // Eliminar los vacunados con Pfizer

        // Unión de conjuntos de ambas vacunas
        HashSet<Ciudadano> vacunadosTotales = new HashSet<Ciudadano>(vacunadosPfizer); // Crear conjunto de vacunados totales
        vacunadosTotales.UnionWith(vacunadosAstraZeneca); // Unir los vacunados de ambas vacunas

        // Menú interactivo
        int opcion;
        do
        {
            MostrarMenu(); // Mostrar el menú
            int.TryParse(Console.ReadLine(), out opcion); // Leer la opción del usuario

            // Procesar la opción seleccionada
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
                    Console.WriteLine("Opción no válida. Intente nuevamente."); // Mensaje de opción no válida
                    Console.ReadKey(); // Esperar a que el usuario presione una tecla
                    break;
            }
        } while (opcion != 6); // Repetir hasta que el usuario elija salir
    }
}
