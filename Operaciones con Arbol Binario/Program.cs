using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}

class ArbolBinario
{
    public Nodo Raiz;

    public void Insertar(int valor)
    {
        // Si el árbol está vacío, se crea un nuevo nodo como raíz
        if (Raiz == null)
        {
            Raiz = new Nodo(valor);
        }
        else
        {
            // Si ya hay nodos, se llama a la función recursiva para insertar el nuevo valor
            InsertarRecursivo(Raiz, valor);
        }
    }

    private void InsertarRecursivo(Nodo nodo, int valor)
    {
        // Compara el valor a insertar con el nodo actual
        if (valor < nodo.Valor)
        {
            // Si el valor es menor, se intenta insertar en el subárbol izquierdo
            if (nodo.Izquierda == null)
            {
                nodo.Izquierda = new Nodo(valor);
            }
            else
            {
                InsertarRecursivo(nodo.Izquierda, valor);
            }
        }
        else
        {
            // Si el valor es mayor o igual, se intenta insertar en el subárbol derecho
            if (nodo.Derecha == null)
            {
                nodo.Derecha = new Nodo(valor);
            }
            else
            {
                InsertarRecursivo(nodo.Derecha, valor);
            }
        }
    }

    public bool Buscar(int valor)
    {
        // Inicia la búsqueda desde la raíz
        return BuscarRecursivo(Raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        // Si el nodo es nulo, el valor no se encuentra
        if (nodo == null)
        {
            return false;
        }

        // Si el valor es igual al nodo actual, se ha encontrado
        if (nodo.Valor == valor)
        {
            return true;
        }

        // Si el valor es menor, busca en el subárbol izquierdo
        if (valor < nodo.Valor)
        {
            return BuscarRecursivo(nodo.Izquierda, valor);
        }
        else
        {
            // Si el valor es mayor, busca en el subárbol derecho
            return BuscarRecursivo(nodo.Derecha, valor);
        }
    }

    public int ContarHojas()
    {
        // Inicia el conteo de hojas desde la raíz
        return ContarHojasRecursivo(Raiz);
    }

    private int ContarHojasRecursivo(Nodo nodo)
    {
        // Si el nodo es nulo, no hay hojas
        if (nodo == null)
        {
            return 0;
        }

        // Si el nodo no tiene hijos, es una hoja
        if (nodo.Izquierda == null && nodo.Derecha == null)
        {
            return 1;
        }

        // Suma las hojas de los subárboles izquierdo y derecho
        return ContarHojasRecursivo(nodo.Izquierda) + ContarHojasRecursivo(nodo.Derecha);
    }

    public void PreOrden(Nodo nodo)
    {
        // Recorrido en Pre-Orden: Procesa el nodo actual, luego el subárbol izquierdo y finalmente el subárbol derecho
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " "); // Procesa el nodo actual
            PreOrden(nodo.Izquierda);         // Recorre el subárbol izquierdo
            PreOrden(nodo.Derecha);           // Recorre el subárbol derecho
        }
    }

    public void InOrden(Nodo nodo)
    {
        // Recorrido en In-Orden: Procesa el subárbol izquierdo, luego el nodo actual y finalmente el subárbol derecho
        if (nodo != null)
        {
            InOrden(nodo.Izquierda);          // Recorre el subárbol izquierdo
            Console.Write(nodo.Valor + " "); // Procesa el nodo actual
            InOrden(nodo.Derecha);            // Recorre el subárbol derecho
        }
    }

    public void PostOrden(Nodo nodo)
    {
        // Recorrido en Post-Orden: Procesa el subárbol izquierdo, luego el subárbol derecho y finalmente el nodo actual
        if (nodo != null)
        {
            PostOrden(nodo.Izquierda);        // Recorre el subárbol izquierdo
            PostOrden(nodo.Derecha);          // Recorre el subárbol derecho
            Console.Write(nodo.Valor + " "); // Procesa el nodo actual
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Insertar un número en el árbol");
            Console.WriteLine("2. Recorrido Pre-Orden");
            Console.WriteLine("3. Recorrido In-Orden");
            Console.WriteLine("4. Recorrido Post-Orden");
            Console.WriteLine("5. Buscar un número en el árbol");
            Console.WriteLine("6. Contar el número de hojas en el árbol");
            Console.WriteLine("s. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n**********************");
                    Console.Write("Ingrese un número entero: ");
                    if (int.TryParse(Console.ReadLine(), out int valor))
                    {
                        arbol.Insertar(valor);
                        Console.WriteLine($"Número {valor} insertado en el árbol.");
                        Console.WriteLine("**********************");
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                    }
                    break;
                case "2":
                    Console.WriteLine("\n**********************");
                    Console.WriteLine("Recorrido Pre-Orden:");
                    arbol.PreOrden(arbol.Raiz);
                    Console.WriteLine("\n**********************");
                    break;
                case "3":
                    Console.WriteLine("\n**********************");
                    Console.WriteLine("Recorrido In-Orden:");
                    arbol.InOrden(arbol.Raiz);
                    Console.WriteLine("\n**********************");
                    break;
                case "4":
                    Console.WriteLine("\n**********************");
                    Console.WriteLine("Recorrido Post-Orden:");
                    arbol.PostOrden(arbol.Raiz);
                    Console.WriteLine("\n**********************");
                    break;
                case "5":
                    Console.WriteLine("\n**********************");
                    Console.Write("Ingrese un número a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out int buscarValor))
                    {
                        bool encontrado = arbol.Buscar(buscarValor);
                        if (encontrado)
                        {
                            Console.WriteLine($"Número {buscarValor} encontrado en el árbol.");
                        }
                        else
                        {
                            Console.WriteLine($"Número {buscarValor} no encontrado en el árbol.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                    }
                    Console.WriteLine("**********************");
                    break;
                case "6":
                    Console.WriteLine("\n**********************");
                    int numeroHojas = arbol.ContarHojas();
                    Console.WriteLine($"El número de hojas en el árbol es: {numeroHojas}");
                    Console.WriteLine("**********************");
                    break;
                case "s":
                    Console.WriteLine("Saliendo de la aplicación.");
                    return; // Sale del bucle y termina la aplicación
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}