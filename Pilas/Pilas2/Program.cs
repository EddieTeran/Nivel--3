using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Vamos a jugar");
        Console.Write("Ingrese el número de discos: ");

        // Variable para almacenar el número de discos
        int numberOfDisks;

        // Validación de la entrada del usuario
        while (!int.TryParse(Console.ReadLine(), out numberOfDisks) || numberOfDisks <= 0)
        {
            Console.Write("Por favor, ingrese un número válido de discos: ");
        }

        // Inicialización de las torres como pilas
        Stack<int> torreA = new Stack<int>(); // Torre de origen
        Stack<int> torreB = new Stack<int>(); 
        Stack<int> torreC = new Stack<int>(); 

        // Llenar la torre de origen con discos en orden descendente
        LlenarTorre(torreA, numberOfDisks);

        // Mostrar el estado inicial de las torres
        Console.WriteLine("\nEstado inicial:");
        ImprimirTorres(torreA, torreB, torreC);

        // Resuelve el problema de las Torres 
        MoverDiscos(numberOfDisks, torreA, torreC, torreB);

        // Muestra el estado final de las torres
        Console.WriteLine("\n*******RESULTADO*******:");
        ImprimirTorres(torreA, torreB, torreC);
    }

    // Llena la torre de origen con discos en orden descendente.
  
    static void LlenarTorre(Stack<int> torre, int n)
    {
        // Caso base: si no hay más discos que agregar, salir
        if (n == 0) return;

        // Agregar el disco n a la torre
        torre.Push(n);

        // Llamada recursiva para llenar el siguiente disco
        LlenarTorre(torre, n - 1);
    }

    
   // Mueve los discos de la torre de origen a la torre de destino utilizando la torre auxiliar.
    
    static void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        // Caso base: si hay solo un disco, moverlo directamente
        if (n == 1)
        {
            // Mover un disco de la torre de origen a la torre de destino
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco 1 de la Torre A a la Torre C");
            ImprimirTorres(origen, auxiliar, destino);
            return; // Salir de la función
        }

        // Mover n-1 discos de la torre de origen a la torre auxiliar
        MoverDiscos(n - 1, origen, auxiliar, destino);

        // Mover el disco n de la torre de origen a la torre de destino
        destino.Push(origen.Pop());
        Console.WriteLine($"Mover disco {n} de la Torre A a la Torre C");
        ImprimirTorres(origen, auxiliar, destino);

        // Mover los n-1 discos de la torre auxiliar a la torre de destino
        MoverDiscos(n - 1, auxiliar, destino, origen);
    }

    // Imprime el estado actual de las tres torres.
    
    static void ImprimirTorres(Stack<int> torreA, Stack<int> torreB, Stack<int> torreC)
    {
        // Imprimir el contenido de cada torre
        Console.WriteLine("Torre A: " + string.Join(", ", torreA));
        Console.WriteLine("Torre B: " + string.Join(", ", torreB));
        Console.WriteLine("Torre C: " + string.Join(", ", torreC));
        Console.WriteLine("\nPresiona una tecla para continuar");
        Console.ReadKey();
    }
}