using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        // Interactuamos con el usuario
        Console.WriteLine("Ingrese una expresión matemática:");
        string expresion = Console.ReadLine();

        // Verificamos si la expresión está balanceada
        if (EstaBalanceada(expresion))
        {
            Console.WriteLine("La expresión está balanceada.");
        }
        else
        {
            Console.WriteLine("La expresión no está balanceada.");
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    /// <returns>True si está balanceada, false en caso contrario.</returns>
    static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>(); // Creamos una pila para almacenar los caracteres de apertura

        // Recorre cada carácter de la expresión
        foreach (char c in expresion)
        {
            // Si encontramos un carácter de apertura, lo agregamos a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si encontramos un carácter de cierre, verificamos la pila
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, no hay un carácter de apertura correspondiente
                if (pila.Count == 0)
                {
                    return false; 
                }

                char cima = pila.Pop(); // Sacar el carácter de apertura de la pila
                // Verificamos si el carácter de cierre corresponde al de apertura
                if (!SonPareja(cima, c))
                {
                    return false; 
                }
            }
        }

        return pila.Count == 0;
    }

    /// Verifica si un par de caracteres de apertura y cierre coinciden.
  
    static bool SonPareja(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }
}