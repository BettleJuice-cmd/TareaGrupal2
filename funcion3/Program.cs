using System;

namespace funcion3
{
    internal class Program
    {
        static bool[] espacios = new bool[5]; // 5 espacios de parqueo
        static DateTime[] horaEntrada = new DateTime[5];
        static decimal tarifaPorHora = 2.0m;

        static void Main(string[] args)
        {
            Console.WriteLine("----Bienvenido al sistema de parqueo----");
            while (true)
            {
                MostrarMenu();
                string opcion = Console.ReadLine()!;

                if (opcion == "1")
                {
                    EntradaVehiculo();
                }
                else if (opcion == "2")
                {
                    SalidaVehiculo();
                }
                else if (opcion == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida.");
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n1. Entrada de vehículo");
            Console.WriteLine("2. Salida de vehículo");
            Console.WriteLine("3. Salir");
            Console.Write("Elija una opción: ");
        }

        static void EntradaVehiculo()
        {
            int espacio = AsignarEspacio();
            if (espacio == -1)
            {
                Console.WriteLine("No hay espacios disponibles.");
                return;
            }

            espacios[espacio] = true;
            horaEntrada[espacio] = DateTime.Now;
            Console.WriteLine($"Vehículo asignado al espacio {espacio + 1} a las {horaEntrada[espacio]:HH:mm:ss}");
        }

        static int AsignarEspacio()
        {
            for (int i = 0; i < espacios.Length; i++)
            {
                if (!espacios[i])
                {
                    return i;
                }
            }
            return -1;
        }

        static void SalidaVehiculo()
        {
            Console.Write("Ingrese el número de espacio (1-5): ");
            if (int.TryParse(Console.ReadLine(), out int espacio))
            {
                espacio -= 1; // Ajustar a índice de arreglo
                if (espacio >= 0 && espacio < espacios.Length && espacios[espacio])
                {
                    decimal monto = CobrarPorHoras(espacio);
                    espacios[espacio] = false;
                    Console.WriteLine($"Monto a pagar: ${monto:F2}");
                }
                else
                {
                    Console.WriteLine("Espacio no ocupado o número inválido.");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }
        }

        static decimal CobrarPorHoras(int espacio)
        {
            DateTime salida = DateTime.Now;
            TimeSpan tiempo = salida - horaEntrada[espacio];
            int horas = (int)Math.Ceiling(tiempo.TotalHours);
            if (horas < 1) horas = 1;
            Console.WriteLine($"Tiempo en parqueo: {horas} hora(s).");
            return horas * tarifaPorHora;
        }
    }
}