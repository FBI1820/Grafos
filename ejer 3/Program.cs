using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_3
{
    using System;

    class Nodo //Controla la estructura de cada nodo del árbol. Para que podamos añadirle elemnetos
    {
        public int valor;
        public Nodo izquierdo; //Define cada una de la ramas del árbol
        public Nodo derecho;

        public Nodo(int val)
        {
            valor = val;
            izquierdo = null;
            derecho = null;
        }
    }

    class ArbolBinarioBusqueda
    {
        public Nodo raiz;// Crea una nueva instancia del árbol binario de búsqueda con la raíz inicializada en nulo.

        public void Insertar(int val) //Metodo para insertar un nuevo valor en el árbol.
        {
            raiz = InsertarRecursivo(raiz, val); //Le decimos que la raíz es igual al dato que el usuario podría darnos
        }

        private Nodo InsertarRecursivo(Nodo nodo, int val)
        {
            if (nodo == null) return new Nodo(val); //Si el nodo es nulo, crea un nuevo nodo con el valor dado.
            if (val < nodo.valor) nodo.izquierdo = InsertarRecursivo(nodo.izquierdo, val);
            else nodo.derecho = InsertarRecursivo(nodo.derecho, val);
            return nodo;
        }

        public void PostOrden(Nodo nodo) //Mettodo para recorrer el árbol en postorden. Como es solicitado
        {
            if (nodo == null) return;
            PostOrden(nodo.izquierdo);
            PostOrden(nodo.derecho);
            Console.Write(nodo.valor + " ");
        }

        public void Analizar(Nodo nodo, ref int suma, ref int pares, ref int impares)
        {
            if (nodo == null) return; //Si e nodo es null (o sea es el finla de la rama) retorna 
            Analizar(nodo.izquierdo, ref suma, ref pares, ref impares);
            Analizar(nodo.derecho, ref suma, ref pares, ref impares);
            suma += nodo.valor;
            if (nodo.valor % 2 == 0) pares++;
            else impares++;
        }
    }

    class Programa //Clase principal, para hacer toda la carpinteria de fodo, como pedir los nodos 
    {
        static void Main()
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            Console.WriteLine("Ingrese números enteros para el árbol (0 para terminar):");

            while (true)
            {
                Console.Write("Número: ");
                int num = int.Parse(Console.ReadLine());
                if (num == 0) break;
                arbol.Insertar(num);
            }

            Console.WriteLine("\nRecorrido postorden:");
            arbol.PostOrden(arbol.raiz);

            int suma = 0, pares = 0, impares = 0; //Variables para almacenar la suma, cantidad de pares e impares
            arbol.Analizar(arbol.raiz, ref suma, ref pares, ref impares);

            Console.WriteLine($"\n\nSuma total: {suma}");
            Console.WriteLine($"Números pares: {pares}");
            Console.WriteLine($"Números impares: {impares}");
        }
    }
}
