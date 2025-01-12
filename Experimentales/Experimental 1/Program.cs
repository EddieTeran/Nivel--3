using System;

namespace AgendaTelefonica
{
    // Clase que representa un contacto
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroPersonal { get; set; }
        public string NumeroTrabajo { get; set; }
        public string Alias { get; set; }

        public Contacto(string nombre, string apellido, string correoElectronico, string numeroPersonal, string numeroTrabajo, string alias)
        {
            Nombre = nombre;
            Apellido = apellido;
            CorreoElectronico = correoElectronico;
            NumeroPersonal = numeroPersonal;
            NumeroTrabajo = numeroTrabajo;
            Alias = alias;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Apellido}, Alias: {Alias}, Correo: {CorreoElectronico}, Teléfono Personal: {NumeroPersonal}, Teléfono de Trabajo: {NumeroTrabajo}";
        }
    }

    // Clase que representa la agenda
    public class Agenda
    {
        private Contacto[] contactos;
        private int contador;

        public Agenda(int capacidad)
        {
            contactos = new Contacto[capacidad];
            contador = 0;
        }

        public void AgregarContacto(Contacto contacto)
        {
            if (contador < contactos.Length)
            {
                contactos[contador] = contacto;
                contador++;
                Console.WriteLine("Contacto agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("La agenda está llena.");
            }
        }

        public void MostrarContactos()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay contactos en la agenda.");
                return;
            }

            Console.WriteLine("Contactos en la agenda:");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine(contactos[i]);
            }
        }

        public Contacto BuscarContacto(string nombre, string apellido)
        {
            for (int i = 0; i < contador; i++)
            {
                if (contactos[i].Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                    contactos[i].Apellido.Equals(apellido, StringComparison.OrdinalIgnoreCase))
                {
                    return contactos[i];
                }
            }
            return null;
        }
    }

    // Clase principal para ejecutar la aplicación
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda(100); // Capacidad para 100 contactos
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de la Agenda ---");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Mostrar contactos");
                Console.WriteLine("3. Buscar contacto");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Agregar contacto
                        Console.Write("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el apellido: ");
                        string apellido = Console.ReadLine();
                        Console.Write("Ingrese el correo electrónico: ");
                        string correo = Console.ReadLine();
                        Console.Write("Ingrese el número personal: ");
                        string numeroPersonal = Console.ReadLine();
                        Console.Write("Ingrese el número de trabajo: ");
                        string numeroTrabajo = Console.ReadLine();
                        Console.Write("Ingrese el sobrenombre: ");
                        string sobrenombre = Console.ReadLine();

                        Contacto nuevoContacto = new Contacto(nombre, apellido, correo, numeroPersonal, numeroTrabajo, sobrenombre);
                        agenda.AgregarContacto(nuevoContacto);
                        break;

                    case "2":
                        // Mostrar contactos
                        agenda.MostrarContactos();
                        break;

                    case "3":
                        // Buscar contacto
                        Console.Write("Ingrese el nombre del contacto a buscar: ");
                        string nombreBuscar = Console.ReadLine();
                        Console.Write("Ingrese el apellido del contacto a buscar: ");
                        string apellidoBuscar = Console.ReadLine();
                        Contacto contactoBuscado = agenda.BuscarContacto(nombreBuscar, apellidoBuscar);
                        if (contactoBuscado != null)
                        {
                            Console.WriteLine("Contacto encontrado:");
                            Console.WriteLine(contactoBuscado);
                        }
                        else
                        {
                            Console.WriteLine("Contacto no encontrado.");
                        }
                        break;

                    case "4":
                        // Salir
                        continuar = false;
                        Console.WriteLine("Saliendo de la agenda...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                        break;
                }
            }
        }
    }
}