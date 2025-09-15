using System;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> libros = new List<string>();
            int opcion;

            do
            {
                Console.WriteLine("\n--- Inventario de Libros ---");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Buscar libro");
                Console.WriteLine("3. Actualizar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese título: ");
                        libros.Add(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Título a buscar: ");
                        string buscar = Console.ReadLine();
                        Console.WriteLine(libros.Contains(buscar) ? "Libro encontrado." : "No existe.");
                        break;
                    case 3:
                        Console.Write("Título a actualizar: ");
                        string viejo = Console.ReadLine();
                        if (libros.Contains(viejo))
                        {
                            Console.Write("Nuevo título: ");
                            string nuevo = Console.ReadLine();
                            libros[libros.IndexOf(viejo)] = nuevo;
                        }
                        break;
                    case 4:
                        Console.Write("Título a eliminar: ");
                        libros.Remove(Console.ReadLine());
                        break;
                }
            } while (opcion != 5);
        }
    }
}