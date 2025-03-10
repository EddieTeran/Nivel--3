using System;
using System.Collections.Generic;

// Clase que representa un libro
public class Libro
{
    public string Nombre { get; set; }
    public string Autor { get; set; }
    public int AñoPublicacion { get; set; }

    public Libro(string nombre, string autor, int añoPublicacion)
    {
        Nombre = nombre;
        Autor = autor;
        AñoPublicacion = añoPublicacion;
    }

    public override string ToString()
    {
        return $"{Nombre} por {Autor} (Año: {AñoPublicacion})";
    }
}
// Clase que representa la biblioteca
public class Biblioteca
{
    private HashSet<Libro> libros; // Conjunto de libros (no permite duplicados)

    public Biblioteca()
    {
        libros = new HashSet<Libro>();
    }
    // Método para agregar un libro a la biblioteca
    public void AgregarLibro(Libro libro)
    {
        // Intenta agregar el libro al conjunto
        if (libros.Add(libro))
        {
            Console.WriteLine("Libro agregado: " + libro);
        }
        else
        {
            Console.WriteLine("El libro ya está registrado.");
        }
    }
    public void MostrarLibros()
    {
        Console.WriteLine("Libros en la biblioteca:");
        if (libros.Count == 0) // Verifica si hay libros
        {
            Console.WriteLine("No hay libros registrados.");
        }
        else
        {
            foreach (var libro in libros)
            {
                Console.WriteLine(libro);
            }
        }
    }
    // Método para buscar un libro por su nombre
    public Libro BuscarLibroPorNombre(string nombre)
    {
        foreach (var libro in libros)
        {
            if (libro.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                return libro; // Devuelve el libro encontrado
            }
        }
        return null; // Devuelve null si no se encuentra
    }
}
class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca(); // Crea una nueva biblioteca

        // Bucle para mostrar el menú y permitir al usuario interactuar
        while (true)
        {
            Console.WriteLine("\n--- BIBLIOTECA UEA ---");
            Console.WriteLine("\n--- Menú de Biblioteca ---");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar libros");
            Console.WriteLine("3. Buscar libro por nombre");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarLibro(biblioteca);
                    break;

                case "2":
                    biblioteca.MostrarLibros();
                    break;

                case "3":
                    BuscarLibro(biblioteca);
                    break;

                case "4":
                    Console.WriteLine("Saliendo de la aplicación. ¡Hasta luego!");
                    return; // Sale del programa

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú."); // Mensaje de error
                    break;
            }
        }
    }
    // Método para agregar un libro
    static void AgregarLibro(Biblioteca biblioteca)
    {
        Console.Write("Ingrese nombre del libro: ");
        string nombre = Console.ReadLine(); // Lee el nombre del libro
        Console.Write("Ingrese autor: ");
        string autor = Console.ReadLine(); // Lee el autor del libro
        Console.Write("Ingrese año de publicación: ");

        // Validar entrada de año
        int año;
        while (!int.TryParse(Console.ReadLine(), out año) || año < 0)
        {
            // Si la entrada no es válida, pide al usuario que ingrese un año válido
            Console.Write("Año no válido. Ingrese un año de publicación válido: ");
        }
        // Crea un nuevo libro con la información proporcionada
        Libro libro = new Libro(nombre, autor, año);
        // Agrega el libro a la biblioteca
        biblioteca.AgregarLibro(libro);
    }
    // Método para buscar un libro por su nombre
    static void BuscarLibro(Biblioteca biblioteca)
    {
        Console.Write("Ingrese nombre del libro a buscar: ");
        string nombreBuscar = Console.ReadLine(); // Lee el nombre que el usuario quiere buscar
        // Busca el libro en la biblioteca
        Libro libroEncontrado = biblioteca.BuscarLibroPorNombre(nombreBuscar);
        if (libroEncontrado != null) // Si se encuentra el libro
        {
            Console.WriteLine("Libro encontrado: " + libroEncontrado); // Muestra el libro encontrado
        }
        else
        {
            Console.WriteLine("Libro no encontrado."); // Mensaje si no se encuentra el libro
        }
    }
}