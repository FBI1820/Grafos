using System;
using System.Collections.Generic;

class Nodo
{
    public string Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(string valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class Programa
{
    static Nodo ConstruirArbol(string[] valores)
    {
        if (valores.Length == 0 || valores[0] == "n") return null;

        Nodo raiz = new Nodo(valores[0]);
        Queue<Nodo> cola = new Queue<Nodo>();
        cola.Enqueue(raiz);

        int i = 1;
        while (i < valores.Length)
        {
            Nodo actual = cola.Dequeue();

            if (i < valores.Length && valores[i] != "n")
            {
                actual.Izquierdo = new Nodo(valores[i]);
                cola.Enqueue(actual.Izquierdo);
            }
            i++;

            if (i < valores.Length && valores[i] != "n")
            {
                actual.Derecho = new Nodo(valores[i]);
                cola.Enqueue(actual.Derecho);
            }
            i++;
        }

        return raiz;
    }

    static void Espejar(Nodo raiz)
    {
        if (raiz == null) return;

        Nodo temp = raiz.Izquierdo;
        raiz.Izquierdo = raiz.Derecho;
        raiz.Derecho = temp;

        Espejar(raiz.Izquierdo);
        Espejar(raiz.Derecho);
    }

    static int ContarNodos(Nodo raiz)
    {
        if (raiz == null) return 0;
        return 1 + ContarNodos(raiz.Izquierdo) + ContarNodos(raiz.Derecho);
    }

    static void Preorden(Nodo raiz)
    {
        if (raiz == null) return;
        Console.Write(raiz.Valor + " ");
        Preorden(raiz.Izquierdo);
        Preorden(raiz.Derecho);
    }

    static void Inorden(Nodo raiz)
    {
        if (raiz == null) return;
        Inorden(raiz.Izquierdo);
        Console.Write(raiz.Valor + " ");
        Inorden(raiz.Derecho);
    }

    static void Postorden(Nodo raiz)
    {
        if (raiz == null) return;
        Postorden(raiz.Izquierdo);
        Postorden(raiz.Derecho);
        Console.Write(raiz.Valor + " ");
    }

    static void Main()
    {
        Console.WriteLine("Introduce los nodos del árbol en orden por niveles (usa 'n' para vacío):");
        Console.WriteLine("Ejemplo: A B C n D n E");
        Console.Write("Entrada: ");
        string entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("Entrada vacía. Finalizando programa.");
            return;
        }

        // Filtrar espacios vacíos manualmente
        string[] valores = entrada.Split(' ');
        List<string> listaFiltrada = new List<string>();
        foreach (string v in valores)
        {
            if (!string.IsNullOrWhiteSpace(v))
                listaFiltrada.Add(v);
        }
        valores = listaFiltrada.ToArray();

        Nodo raiz = ConstruirArbol(valores);

        Console.WriteLine("\nRecorridos del árbol original:");
        Console.Write("Preorden: "); Preorden(raiz); Console.WriteLine();
        Console.Write("Inorden: "); Inorden(raiz); Console.WriteLine();
        Console.Write("Postorden: "); Postorden(raiz); Console.WriteLine();
        Console.WriteLine("Cantidad de nodos: " + ContarNodos(raiz));

        Espejar(raiz);

        Console.WriteLine("\nRecorridos del árbol espejo:");
        Console.Write("Preorden: "); Preorden(raiz); Console.WriteLine();
        Console.Write("Inorden: "); Inorden(raiz); Console.WriteLine();
        Console.Write("Postorden: "); Postorden(raiz); Console.WriteLine();
    }
}