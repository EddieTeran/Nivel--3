using System;
using System.Collections.Generic;

class Program
{
    // Clase para representar un grafo
    class Graph
    {
        private Dictionary<string, List<string>> adjList;

        public Graph()
        {
            adjList = new Dictionary<string, List<string>>();
        }

        // Método para agregar un nodo
        public void AddNode(string node)
        {
            if (!adjList.ContainsKey(node))
            {
                adjList[node] = new List<string>();
            }
        }

        // Método para agregar una arista
        public void AddEdge(string from, string to)
        {
            if (adjList.ContainsKey(from) && adjList.ContainsKey(to))
            {
                adjList[from].Add(to);
                adjList[to].Add(from); // Si el grafo es no dirigido
            }
        }

        // Método para verificar si un nodo existe
        public bool ContainsNode(string node)
        {
            return adjList.ContainsKey(node);
        }

        // Método para mostrar el grafo
        public void DisplayGraph()
        {
            foreach (var node in adjList)
            {
                Console.Write($"{node.Key} -> ");
                foreach (var neighbor in node.Value)
                {
                    Console.Write($"{neighbor} ");
                }
                Console.WriteLine();
            }
        }

        // Método para encontrar una ruta (DFS) y almacenar el camino
        public bool FindRoute(string start, string end, HashSet<string> visited, List<string> path)
        {
            visited.Add(start);
            path.Add(start);

            if (start == end) return true;

            foreach (var neighbor in adjList[start])
            {
                if (!visited.Contains(neighbor))
                {
                    if (FindRoute(neighbor, end, visited, path))
                    {
                        return true;
                    }
                }
            }

            // Si no se encuentra la ruta, se elimina el nodo del camino
            path.RemoveAt(path.Count - 1);
            return false;
        }
    }

    static void Main(string[] args)
    {
        Graph graph = new Graph();

        // Agregar nodos
        string[] nodes = { "Quevedo", "Quito", "Guayaquil", "Santo Domingo", "Ambato", "Babahoyo", "El empalme", "Esmeraldas" };
        foreach (var node in nodes)
        {
            graph.AddNode(node);
        }

        // Agregar aristas
        graph.AddEdge("Quito", "Ambato");
        graph.AddEdge("Quito", "Santo Domingo");
        graph.AddEdge("Santo Domingo", "Quevedo");
        graph.AddEdge("Santo Domingo", "Esmeraldas");
        graph.AddEdge("Quevedo", "Babahoyo");
        graph.AddEdge("Quevedo", "El empalme");
        graph.AddEdge("Babahoyo", "Guayaquil");
        graph.AddEdge("El empalme", "Guayaquil");

        // Mostrar el grafo
        Console.WriteLine("Grafo de transporte:");
        graph.DisplayGraph();

        // Interacción con el usuario
        while (true)
        {
            Console.WriteLine("\nIngrese la ciudad de partida (o 'salir' para terminar):");
            string startNode = Console.ReadLine();
            if (startNode.ToLower() == "salir") break;

            Console.WriteLine("Ingrese la ciudad destino:");
            string endNode = Console.ReadLine();

            // Verificar si los nodos existen
            if (!graph.ContainsNode(startNode) || !graph.ContainsNode(endNode))
            {
                Console.WriteLine("Una o ambas ciudades no existen en la ruta.\nAsegurese de escribir con Mayuscula \nIntente de nuevo.");
                continue;
            }

            // Buscar una ruta
            HashSet<string> visited = new HashSet<string>();
            List<string> path = new List<string>();
            bool routeExists = graph.FindRoute(startNode, endNode, visited, path);

            if (routeExists)
            {
                Console.WriteLine($"Ruta encontrada de {startNode} a {endNode}: " + string.Join(" -> ", path));
            }
            else
            {
                Console.WriteLine($"Ruta no encontrada de {startNode} a {endNode}.");
            }
        }
    }
}
