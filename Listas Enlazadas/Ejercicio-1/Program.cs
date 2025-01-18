using System;

class Nodo
{
    public string Dia; // Dato del nodo
    public Nodo Siguiente; 

    public Nodo(string dia)
    {
        Dia = dia; 
        Siguiente = null; 
    }
}

class ListaEnlazada
{
    private Nodo head; // Cabeza de la lista

    public void Agregar(string dia)
    {
        Nodo nuevoNodo = new Nodo(dia); // Nuevo nodo
        if (head == null) 
        {
            head = nuevoNodo; 
        }
        else
        {
            Nodo nodoActual = head; 
            while (nodoActual.Siguiente != null) 
            {
                nodoActual = nodoActual.Siguiente;
            }
            nodoActual.Siguiente = nuevoNodo; 
        }
    }
    // Invertir la lista
    public void Invertir()
    {
        Nodo anterior = null; 
        Nodo actual = head; 
        while (actual != null) 
        {
            Nodo siguiente = actual.Siguiente; 
            actual.Siguiente = anterior; 
            anterior = actual; 
            actual = siguiente; 
        }
        head = anterior; 
    }

    public void Mostrar()
    {
        Nodo nodoActual = head; // Empieza en la cabeza
        while (nodoActual != null) // Mientras haya nodos
        {
            Console.Write(nodoActual.Dia + " -> "); 
            nodoActual = nodoActual.Siguiente; 
        }
        Console.WriteLine(); // Muestra el final de la lista
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada(); // Lista dias de la semana
        
        lista.Agregar("Lunes");
        lista.Agregar("Martes");
        lista.Agregar("Miércoles");
        lista.Agregar("Jueves");
        lista.Agregar("Viernes");
        lista.Agregar("Sábado");
        lista.Agregar("Domingo");

        Console.WriteLine("Lista original:");
        lista.Mostrar(); // Imprime la lista original

        lista.Invertir(); // Lista invertida

        Console.WriteLine("Lista invertida:");
        lista.Mostrar(); // Imprime la lista invertida
        Console.ReadKey();
    }
}