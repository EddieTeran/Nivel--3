using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Diccionario de traducciones
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "tiempo", "time" },        { "persona", "person" },       { "año", "year" },        { "camino", "way" },        { "dia", "day" },       { "cosa", "thing" },
            { "hombre", "man" },         { "mundo", "world" },          { "vida", "life" },       { "mano", "hand" },         { "parte", "part" },    { "niño/a", "child" },
            { "ojo", "eye" },            { "mujer", "woman" },          { "lugar", "place" },     { "trabajo", "work" },      { "semana", "week" },   { "caso", "case" },
            { "punto", "point" },        { "gobierno", "government" },  { "empresa", "company" },
        };

        while (true)
        {
            // Menú
            Console.WriteLine("******TRADUCTOR DE FRASES******\n");
            Console.WriteLine("******Menú:*******\n");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Traducir una frase
                    Console.WriteLine("Ingrese la frase a traducir:");
                    string frase = Console.ReadLine();
                    string[] palabras = frase.Split(' '); // Divide la frase en palabras
                    List<string> palabrasTraducidas = new List<string>();

                    foreach (string palabra in palabras)
                    {
                        if (dictionary.TryGetValue(palabra, out string traduccion))
                        {
                            palabrasTraducidas.Add(traduccion);
                        }
                        else
                        {
                            // Si no se encuentra, se agrega la palabra original
                            palabrasTraducidas.Add(palabra); 
                        }
                    }

                    string fraseTraducida = string.Join(" ", palabrasTraducidas);
                    Console.WriteLine($"La traducción es: '{fraseTraducida}'");
                    break;

                case "2":
                    // Ingresa nueva palabra
                    Console.WriteLine("Ingrese la palabra en español:");
                    string palabraEspañol = Console.ReadLine();
                    Console.WriteLine("Ingrese la traducción en inglés:");
                    string palabraIngles = Console.ReadLine();

                    // Agregar la nueva palabra al diccionario
                    if (!dictionary.ContainsKey(palabraEspañol))
                    {
                        dictionary.Add(palabraEspañol, palabraIngles);
                        dictionary.Add(palabraIngles, palabraEspañol);
                        Console.WriteLine($"Palabra añadida: '{palabraEspañol}' -> '{palabraIngles}'");
                    }
                    else
                    {
                        Console.WriteLine($"La palabra '{palabraEspañol}' ya existe en el diccionario.");
                    }
                    break;

                case "3":
                    // Salir del programa
                    Console.WriteLine("Gracias por usar el traductor. ¡Hasta luego!");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del menú.");
                    break;
            }
        }
    }
}
