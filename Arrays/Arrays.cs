using System;

// Definimos la clase Articulo
public class Articulo
{
    /* Definimos las propiedades de la clase
       Sap
       Nombre
       Cantidad
       Precios */
    public int Sap { get; set; }
    public string Nombre { get; set; }
    public string Cantidad { get; set; }
    public decimal[] Precios { get; set; }

    // Constructor de la clase
    public Articulo(int sap, string nombre, string cantidad, decimal[] precios)
    {
        // Asignamos los valores a los parámetros de las propiedades
        Sap = sap;
        Nombre = nombre;
        Cantidad = cantidad;
        Precios = precios;
    }
}

// Clase principal Inventario
class Inventario
{
    static void Main()
    {
        /* Se solicita al usuario que ingrese los datos para
         SAP, nombre, cantidad y precios del artículo a ingresar
         en el inventario */
        Console.WriteLine("Ingrese el SAP del artículo:");
        int sap = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el nombre del artículo:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese cantidad del artículo:");
        string cantidad = Console.ReadLine();

        /* Definimos un array para almacenar los precios de compra,
         venta al por mayor y venta al público de nuestro inventario*/
        decimal[] precios = new decimal[3];

        Console.WriteLine("Ingrese el precio de compra:");
        precios[0] = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el precio de venta por mayor:");
        precios[1] = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el precio de venta al público (PVP):");
        precios[2] = decimal.Parse(Console.ReadLine());

        // Creamos una instancia de la clase Articulo con los datos ingresados por el usuario
        Articulo articulo = new Articulo(sap, nombre, cantidad, precios);

        /* Mostramos la información del artículo en la consola
           e imprimimos los precios detallados*/
        Console.WriteLine("\nInformación del Artículo:");
        Console.WriteLine("SAP: " + articulo.Sap);
        Console.WriteLine("Nombre: " + articulo.Nombre);
        Console.WriteLine("Cantidad: " + articulo.Cantidad);
        Console.WriteLine("Precios:");
        Console.WriteLine("  Precio de compra: " + articulo.Precios[0]);
        Console.WriteLine("  Precio de venta por mayor: " + articulo.Precios[1]);
        Console.WriteLine("  Precio de venta al público (PVP): " + articulo.Precios[2]);

        // Espera a que el usuario presione una tecla antes de cerrar la consola
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
