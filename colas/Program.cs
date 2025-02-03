using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Definimos los asientos disponibles
        const int totalAsientosNormales = 20; // Asientos normales
        const int totalAsientosPreferenciales = 10; // Asientos preferenciales

        // Colas: una regular y otra preferencial
        Queue<string> colaEspera = new Queue<string>(); // Asientos normales
        Queue<string> colaPreferencial = new Queue<string>(); // Asientos preferenciales

        // Mensaje de bienvenida
        Console.WriteLine("****BIENVENIDOS A SOMAG*****");
        Console.WriteLine("Reserva tu asiento y empieza la diversión!");

        // Bucle principal que se ejecuta mientras haya asientos disponibles
        while (colaEspera.Count < totalAsientosNormales || colaPreferencial.Count < totalAsientosPreferenciales)
        {
            // Mostramos las opciones al usuario
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Compra un asiento");
            Console.WriteLine("2. Compra un asiento preferencial");
            Console.WriteLine("3. Ver estado de la fila");
            Console.WriteLine("4. Cancelar una reserva");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción (1-5): ");
            string entrada = Console.ReadLine(); // Vemos la opción seleccionada

            // Procesamos la opción seleccionada
            switch (entrada)
            {
                case "1":
                    // Agregar asiento normal
                    AgregarASilla(colaEspera, totalAsientosNormales, "normal");
                    break;

                case "2":
                    // Agregar asiento preferencial
                    AgregarASilla(colaPreferencial, totalAsientosPreferenciales, "preferencial");
                    break;

                case "3":
                    // Mostrar el estado de las filas
                    MostrarEstadoColas(colaEspera, colaPreferencial);
                    break;

                case "4":
                    // Cancelar una reserva
                    CancelarReserva(colaEspera, colaPreferencial);
                    break;

                case "5":
                    // Salir del programa
                    Console.WriteLine("Adiós...");
                    return;

                default:
                    // Mensaje si la opción no es válida
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

        // Asientos han sido vendidos
        Console.WriteLine("\nTodos los asientos han sido vendidos. Comenzando la atracción...\n");
        Console.ReadKey(); // Esperamos a que el usuario presione una tecla

        // Atender a las personas  preferenciales
        AtenderCola(colaPreferencial, "preferencial");
        // Atender a las personas regulares
        AtenderCola(colaEspera, "normal");

        // Mensaje de despedida
        Console.WriteLine("¡Gracias por visitar SOMAG!");
    }

    // Método para agregar un asiento a la fila correspondiente
    static void AgregarASilla(Queue<string> cola, int totalAsientos, string tipo)
    {
        // Verificamos si hay asientos disponibles
        if (cola.Count < totalAsientos)
        {
            Console.Write($"Ingrese su nombre para reservar un asiento {tipo}: ");
            string nombre = Console.ReadLine(); // Leemos el nombre del usuario
            if (!string.IsNullOrWhiteSpace(nombre)) // Validamos que el nombre no esté vacío
            {
                cola.Enqueue(nombre); // Añadimos el nombre a la fila
                Console.WriteLine($"{nombre} ha comprado un asiento {tipo}. # en la Fila: {cola.Count}");
            }
            else
            {
                Console.WriteLine("El nombre no puede estar vacío."); // Error si el nombre está vacío 
            }
        }
        else
        {
            // Si no hay asientos disponibles
            Console.WriteLine($"Lo siento, no hay más asientos {tipo}s disponibles.");
            if (tipo == "preferencial")
            {
                Console.WriteLine("Por favor, considere unirse a la cola regular."); // Sugerencia para unirse a la fila regular
            }
        }
    }

    // Método para ver estado de las filas
    static void MostrarEstadoColas(Queue<string> colaEspera, Queue<string> colaPreferencial)
    {
        Console.WriteLine("Estado de la fila:");
        if (colaEspera.Count == 0 && colaPreferencial.Count == 0) // Verificamos si ambas filas están vacías
        {
            Console.WriteLine("Los asientos están vacíos."); // Mensaje si ambas filas están vacías 
        }
        else
        {
            // Mostramos las personas en la fila preferencial
            if (colaPreferencial.Count > 0)
            {
                Console.WriteLine("Personas en la fila preferencial:");
                foreach (var persona in colaPreferencial) // Iteramos sobre la fila preferencial
                {
                    Console.WriteLine($"- {persona}"); // Listamos cada persona en la fila preferencial
                }
            }

            // Muestra las personas en la fila regular
            if (colaEspera.Count > 0)
            {
                Console.WriteLine("Personas en la fila regular:");
                foreach (var persona in colaEspera) // Iteramos sobre la fila regular
                {
                    Console.WriteLine($"- {persona}"); // Listamos cada persona en la fila regular
                }
            }
        }
    }

    // Método para cancelar una reserva
    static void CancelarReserva(Queue<string> colaEspera, Queue<string> colaPreferencial)
    {
        Console.Write("Ingrese su nombre para cancelar la reserva: ");
        string nombreCancelar = Console.ReadLine(); //  usuario que desea cancelar

        // Intentamos eliminar de la cola preferencial
        if (EliminarDeCola(colaPreferencial, nombreCancelar, "preferencial") ||
            // Intentamos eliminar de la fila regular
            EliminarDeCola(colaEspera, nombreCancelar, "normal"))
        {
            Console.WriteLine($"{nombreCancelar} ha cancelado su reserva."); // Mensaje de confirmación
        }
        else
        {
            Console.WriteLine("No se encontró ninguna reserva con ese nombre."); // Mensaje si no se encuentra la reserva
        }
    }

    // Método para eliminar un nombre de una fila
    static bool EliminarDeCola(Queue<string> cola, string nombre, string tipo)
    {
        if (cola.Contains(nombre)) // Verificamos si el nombre está en la fila
        {
            Queue<string> tempQueue = new Queue<string>(); // Fila temporal para almacenar las reservas
            while (cola.Count > 0)
            {
                string persona = cola.Dequeue(); // Sacamos a la primera persona de la fila
                if (persona != nombre) // Si no es la persona que quiere cancelar
                {
                    tempQueue.Enqueue(persona); // La añadimos a la filamporal
                }
            }
            cola = tempQueue; // Actualizamos la fila
            return true; // Retornamos verdadero si se eliminó
        }
        return false; // Retornamos falso si no se encontró el nombre
    }

    // Método para atender a las personas 
    static void AtenderCola(Queue<string> cola, string tipo)
    {
        while (cola.Count > 0) // Mientras haya personas 
        {
            string persona = cola.Dequeue(); // Sacamos a la primera persona de la fila
            Console.WriteLine($"{persona} ha subido a la atracción ({tipo})."); // Mensaje de confirmación
        }
    }
}