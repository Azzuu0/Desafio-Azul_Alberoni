using System;
using System.Collections.Generic;


namespace Desafio_Prog.Clases
{ 
public class Program
{
    public static void Main(string[] args)
    {
        SistemaVentas sistema = new SistemaVentas();

        // Crear rubros
        Rubro ficcion = new Rubro("Ficción");
        Rubro noFiccion = new Rubro("No Ficción");
        Rubro infantiles = new Rubro("Infantiles");

        // Agregar rubros al inventario
        sistema.Inventario.AgregarRubro(ficcion);
        sistema.Inventario.AgregarRubro(noFiccion);
        sistema.Inventario.AgregarRubro(infantiles);

        // Agregar libros a los rubros
        ficcion.AgregarLibro(new Libro("Cien Años de Soledad", "Gabriel García Márquez", 10, 19.99m, ficcion));
        ficcion.AgregarLibro(new Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 5, 15.99m, ficcion));
        noFiccion.AgregarLibro(new Libro("Sapiens", "Yuval Noah Harari", 8, 22.99m, noFiccion));
        infantiles.AgregarLibro(new Libro("El Principito", "Antoine de Saint-Exupéry", 20, 12.50m, infantiles));

        // Registrar usuarios
        sistema.RegistrarUsuario(new Usuario("Azzu", "1234"));
        sistema.RegistrarUsuario(new Usuario("pint", "1224"));
        sistema.RegistrarUsuario(new Usuario("ocher", "124"));

        // Loguear usuario
        Console.WriteLine("Ingrese su Usuario:");
        string correo = Console.ReadLine();
        Console.WriteLine("Ingrese su contraseña:");
        string password = Console.ReadLine();

        Usuario usuario = sistema.LoguearUsuario(correo, password);

        if (usuario != null)
        {
            Console.WriteLine("Bienvenido, " + usuario.Nombre);
            sistema.ProcesarCompra(usuario);
        }
        else
        {
            Console.WriteLine("Usuario o contraseña incorrectos.");
        }
    }
}
}