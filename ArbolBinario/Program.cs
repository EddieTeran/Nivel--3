using System;


class Nodo
{
    public string Titulo; // Título del nodo
    public Nodo Izquierdo, Derecho; //  Nodos hijo izquierdo y derecho

    // Constructor que inicializa el título del nodo
    public Nodo(string titulo) => Titulo = titulo;
}

// Clase que representa el árbol binario de búsqueda
class ArbolBinarioBusqueda
{
    private Nodo raiz;

    public void Insertar(string titulo) => raiz = InsertarRecursivo(raiz, titulo);

    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        // Si el nodo actual es nulo, se crea un nuevo nodo
        if (nodo == null) return new Nodo(titulo);

        // Comparar el título con el título del nodo actual
        if (string.Compare(titulo, nodo.Titulo) < 0)

            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        else if (string.Compare(titulo, nodo.Titulo) > 0)

            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);

        return nodo; // Retorna el nodo actual
    }

    // Método público para buscar un título en el árbol
    public bool Buscar(string titulo) => BuscarRecursivo(raiz, titulo);

    private bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        // Si el nodo es nulo, el título no se encuentra
        if (nodo == null) return false;

        // Si el título del nodo actual es igual al título buscado, se encuentra
        if (nodo.Titulo == titulo) return true;

        // Comparar el título buscado con el título del nodo actual
        return string.Compare(titulo, nodo.Titulo) < 0
            ? BuscarRecursivo(nodo.Izquierdo, titulo) // Buscar en el subárbol izquierdo
            : BuscarRecursivo(nodo.Derecho, titulo); // Buscar en el subárbol derecho
    }
}

// Clase principal que contiene el método Main
class Program
{
    static void Main()
    {
        var arbol = new ArbolBinarioBusqueda();
        string[] catalogo =
        {
            "Vistazo",
            "Iconos",
            "Ciencia y Tecnologia",
            "La tecnica",
            "Ecuador debate",
            "Revista Ecuatoriana de Neurología",
            "Retos", "Sophía", "Alteridad",
            "La Granja"
        };

        // Insertar cada título del catálogo en el árbol
        foreach (var titulo in catalogo) arbol.Insertar(titulo);

        // Bucle para mostrar el menú y permitir al usuario buscar títulos
        while (true)
        {
            Console.WriteLine("Menú:\n1. Buscar un título\n2. Salir\nSeleccione una opción: ");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                Console.Write("Ingrese el título de la revista a buscar: ");
                string tituloBuscado = Console.ReadLine();

                Console.WriteLine(arbol.Buscar(tituloBuscado) ? "Resultado de la búsqueda: Encontrado" : "Resultado de la búsqueda: No encontrado");
            }
            else if (opcion == "2") break;
            else Console.WriteLine("Opción no válida. Intente de nuevo.");

            Console.WriteLine();
        }
    }
}