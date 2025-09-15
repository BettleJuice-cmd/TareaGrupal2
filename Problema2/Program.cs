using System;
using System.Collections.Generic;

class Producto
{
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public decimal CostoParcial() => Cantidad * PrecioUnitario;
}

class Factura
{
    private List<Producto> productos = new List<Producto>();
    private decimal tasaImpuesto;

    public Factura(decimal tasaImpuesto)
    {
        this.tasaImpuesto = tasaImpuesto;
    }

    public void AgregarProducto(string nombre, int cantidad, decimal precioUnitario)
    {
        productos.Add(new Producto { Nombre = nombre, Cantidad = cantidad, PrecioUnitario = precioUnitario });
    }

    public decimal CalcularSubtotal()
    {
        decimal subtotal = 0;
        foreach (var p in productos)
            subtotal += p.CostoParcial();
        return subtotal;
    }

    public decimal CalcularImpuesto() => CalcularSubtotal() * tasaImpuesto;

    public decimal CalcularTotal() => CalcularSubtotal() + CalcularImpuesto();

    public void ImprimirFactura()
    {
        Console.WriteLine("Factura del Supermercado");
        Console.WriteLine("------------------------");
        Console.WriteLine("{0,-15} {1,10} {2,18}", "Producto", "Cantidad", "Precio Unitario");
        Console.WriteLine(new string('-', 45));

        foreach (var p in productos)
            Console.WriteLine("{0,-15} {1,10} {2,18:C}", p.Nombre, p.Cantidad, p.PrecioUnitario);

        Console.WriteLine(new string('-', 45));
        Console.WriteLine("{0,-25} {1,18:C}", "Subtotal:", CalcularSubtotal());
        Console.WriteLine("{0,-25} {1,18:C}", $"Impuesto ({tasaImpuesto:P}):", CalcularImpuesto());
        Console.WriteLine("{0,-25} {1,18:C}", "Total:", CalcularTotal());
    }
}

class Program
{
    static void Main()
    {
        decimal tasaImpuesto = 0.10m;
        Factura factura = new Factura(tasaImpuesto);

        factura.AgregarProducto("Manzanas", 3, 10.50m);
        factura.AgregarProducto("Pan", 2, 15.00m);
        factura.AgregarProducto("Leche", 1, 22.30m);

        factura.ImprimirFactura();

        Console.ReadLine();
    }
}
