using System;
using System.Security.Cryptography;


namespace Parcial__1
{
    // classe cuadrado
    public class Cuadrado
    {
        // campos privados para el lado del cuadrado 
        private double Lado;

        // Constructor de la clase 
        public Cuadrado(double Lado)
        {
            this.Lado = Lado;
        }

        /* Método  que retorna un double,se utiliza
           la formula para calcular el area del cuadrado
           a = lado * lado */
        public double CalculoArea()
        {
            return Lado * Lado;
        }

        /* Método  que retorna un double,se utiliza
           la formula para calcular el preimetro del cuadrado
           P = 4 * lado */ 
        public double CalculoPerimetro()
        {
            return 4 * Lado;
        }
    }

    // Clase rectángulo
    public class Rectangulo
    {
        // Campos privados para la base y la altura del rectángulo
        private double Base;
        private double Altura;

        // Constructor que inicializa la base y la altura del rectángulo
        public Rectangulo(double Base, double Altura)
        {
            this.Base = Base;
            this.Altura = Altura;
        }

        /*Método para el calculo del área del rectangulo, retorna un double 
          con la formula a = base * altura */ 
        public double CalculoArea()
        {
            return Base * Altura;
        }

        /*Método para el calculo del perímetro del rectangulo
          retorna un double con la formula P = 2 * (base mas altura) */
        public double CalculoPerimetro()
        {
            return 2 * (Base + Altura);
        }
    }

    class FigGeom
    {
        static void Main(string[] args)
        {
            /* Interaccion con usuario ingresando los datos para 
               los respectivos calculos*/
            Console.WriteLine("\n----- Datos Cuadrado -----");
            Console.Write("Ingrese el lado del cuadrado: ");
            double Lado = Double.Parse(Console.ReadLine());

            // Instancia de la clase cuadrado con los datos ingresados por el usuario
            Cuadrado cuadrado = new Cuadrado(Lado);

            // Imprime el area y perímetro del cuadrado
            Console.WriteLine("\n----- Area del Cuadrado -----");
            Console.WriteLine($"El área del cuadrado es: {cuadrado.CalculoArea()}");

            Console.WriteLine("\n----- Perimetro del Cuadrado -----");
            Console.WriteLine($"El perímetro del cuadrado es: {cuadrado.CalculoPerimetro()}");

            // Interacción con el usuario para el rectángulo
            Console.WriteLine("\n----- Datos Rectangulo -----");
            Console.Write("Ingrese la base del rectángulo: ");
            double Base = Double.Parse(Console.ReadLine());
            Console.Write("Ingrese la altura del rectángulo: ");
            double Altura = Double.Parse(Console.ReadLine());

            // Instancia de la clase rectangulo con los datos ingrasados  usuario
            Rectangulo rectangulo = new Rectangulo(Base, Altura);

            // Imprime el area y el perimetro del rectángulo
            Console.WriteLine("\n----- Area del Rectangulo -----");
            Console.WriteLine($"El área del rectángulo es: {rectangulo.CalculoArea()}");

            Console.WriteLine("\n----- Perimetro del Rectangulo -----");
            
            Console.WriteLine($"El perímetro del rectángulo es: {rectangulo.CalculoPerimetro()}");

            Console.ReadKey();
        }
    }
}
