using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_1
{
    using System;
    using System.Xml.Schema;

    class Nodo
    {
        public int Valor;
        public Nodo Izquierdo, Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = Derecho = null;
        }
    }

    class ArbolBinario
    {
        public Nodo Raiz;

        public void Insertar(int valor)
        {
            Raiz = InsertarRecursivo(Raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo raiz, int valor)
        {
            if (raiz == null) return new Nodo(valor);

            if (valor < raiz.Valor)
                raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, valor);
            else
                raiz.Derecho = InsertarRecursivo(raiz.Derecho, valor);

            return raiz;
        }
        public void preOrden(Nodo raiz)
        {
            if (raiz != null)
            {
                Console.Write(raiz.Valor + " ");
                preOrden(raiz.Izquierdo);
                preOrden(raiz.Derecho);
            }
        }
        public static int ContarNodos(Nodo nodo)
        {
            if (nodo == null) return 0;
            return 1 + ContarNodos(nodo.Izquierdo) + ContarNodos(nodo.Derecho);
        }


    }

    class Program
    {
        static void Main()
        {
            ArbolBinario arbol = new ArbolBinario();
            Console.WriteLine("INGRESE UN NUMERO:");
            int entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);
            Console.WriteLine("INGRESE UN NUMERO:");
            entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);
            Console.WriteLine("INGRESE UN NUMERO:");
            entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);
            Console.WriteLine("INGRESE UN NUMERO:");
            entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);
            Console.WriteLine("INGRESE UN NUMERO:");
            entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);
            Console.WriteLine("INGRESE UN NUMERO:");
            entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);
            Console.WriteLine("INGRESE UN NUMERO:");
            entrada = Convert.ToInt32(Console.ReadLine());
            arbol.Insertar(entrada);

            Console.WriteLine("Recorrido en preorden:");
            arbol.preOrden(arbol.Raiz);

            int total = ArbolBinario.ContarNodos(arbol.Raiz);
            Console.WriteLine($"\ncantidad de nodos:{total}");


            Console.ReadKey();
        }
    }

}
