namespace Problema1
{
    using System;
    using System.Collections.Generic;


    public class Estudiante
    {
        public string Nombre { get; set; }
        public List<double> Notas { get; set; }

        public Estudiante(string nombre)
        {
            Nombre = nombre;
            Notas = new List<double>();
        }

        // Calcular promedio de las notas
        public double CalcularPromedio()
        {
            if (Notas.Count == 0) return 0;
            double suma = 0;
            foreach (var nota in Notas)
            {
                suma += nota;
            }
            return suma / Notas.Count;
        }

        // Verificar si aprueba (promedio >= 60)
        public bool EstaAprobado()
        {
            return CalcularPromedio() >= 60;
        }
    }

    // Clase que gestiona el grupo de estudiantes
    public class GestionClase
    {
        private List<Estudiante> estudiantes;

        public GestionClase()
        {
            estudiantes = new List<Estudiante>();
        }

        // Ingresar datos de los estudiantes
        public void IngresarDatos()
        {
            Console.Write("Ingrese la cantidad de estudiantes: ");
            int cantidad = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"\nNombre del estudiante {i + 1}: ");
                string nombre = Console.ReadLine();
                Estudiante estudiante = new Estudiante(nombre);

                Console.Write("¿Cuántas notas desea ingresar?: ");
                int numNotas = int.Parse(Console.ReadLine());

                for (int j = 0; j < numNotas; j++)
                {
                    Console.Write($"Ingrese la nota {j + 1}: ");
                    double nota = double.Parse(Console.ReadLine());
                    estudiante.Notas.Add(nota);
                }

                estudiantes.Add(estudiante);
            }
        }

        // Mostrar resultados
        public void MostrarResultados()
        {
            Console.WriteLine("\n--- Resultados ---");
            foreach (var est in estudiantes)
            {
                double promedio = est.CalcularPromedio();
                string estado = est.EstaAprobado() ? "APROBADO ✅" : "REPROBADO ❌";
                Console.WriteLine($"{est.Nombre} - Promedio: {promedio:F2} - {estado}");
            }
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            GestionClase gestion = new GestionClase();
            gestion.IngresarDatos();
            gestion.MostrarResultados();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
