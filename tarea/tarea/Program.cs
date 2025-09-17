class CajeroAutomatico
{
    
    static string usuario = "Paolo";
    static string contrasena = "uam";
    static double saldo = 100000.00;
    static bool sesionIniciada = false;

    static void Main()
    {
        if (InicioSesion())
        {
            int opcion;
            do
            {
                opcion = MostrarMenu();
                switch (opcion)
                {
                    case 1: ConsultarSaldo(); break;
                    case 2: Retirar(); break;
                    case 3: Depositar(); break;
                    case 4: CerrarSesion(); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            } while (opcion != 4);
        }
    }

    
    static bool InicioSesion()
    {
        Console.WriteLine("=== CAJERO AUTOMÁTICO ===");
        Console.Write("Usuario: ");
        string user = Console.ReadLine();

        Console.Write("Contraseña: ");
        string pass = Console.ReadLine();

        if (user == usuario && pass == contrasena)
        {
            sesionIniciada = true;
            Console.WriteLine("\nInicio de sesión exitoso.\n");
            return true;
        }
        else
        {
            Console.WriteLine("\nUsuario o contraseña incorrectos.");
            return false;
        }
    }

    
    static int MostrarMenu()
    {
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Consultar saldo");
        Console.WriteLine("2. Retirar");
        Console.WriteLine("3. Depositar");
        Console.WriteLine("4. Cerrar sesión");
        Console.Write("Seleccione una opción: ");
        return int.Parse(Console.ReadLine());
    }

    
    static void ConsultarSaldo()
    {
        Console.WriteLine($"\nSu saldo actual es: {saldo:C}\n");
    }

    
    static void Retirar()
    {
        Console.Write("\nIngrese la cantidad a retirar: ");
        double cantidad = double.Parse(Console.ReadLine());

        if (cantidad > 0 && cantidad <= saldo)
        {
            saldo -= cantidad;
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: {saldo:C}\n");
        }
        else
        {
            Console.WriteLine("Fondos insuficientes o cantidad inválida.\n");
        }
    }

    
    static void Depositar()
    {
        Console.Write("\nIngrese la cantidad a depositar: ");
        double cantidad = double.Parse(Console.ReadLine());

        if (cantidad > 0)
        {
            saldo += cantidad;
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: {saldo:C}\n");
        }
        else
        {
            Console.WriteLine("Cantidad inválida.\n");
        }
    }

  
    static void CerrarSesion()
    {
        Console.WriteLine("\nSesión cerrada. ¡Gracias por usar el cajero!");
        sesionIniciada = false;
    }
}
