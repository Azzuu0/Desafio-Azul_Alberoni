using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Prog.Clases
{
    public class SistemaVentas
    {
        public Inventario Inventario { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        public SistemaVentas()
        {
            Inventario = new Inventario();
            Usuarios = new List<Usuario>();
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public Usuario LoguearUsuario(string correo, string password)
        {
            for (int i = 0; i < Usuarios.Count; i++)
            {
                if (Usuarios[i].Password == password)
                {
                    return Usuarios[i];
                }
            }
            return null;
        }

        public void ProcesarCompra(Usuario usuario)
        {
            Carrito carrito = new Carrito();
            bool seguirComprando = true;

            while (seguirComprando)
            {
                Inventario.MostrarRubros();
                Console.WriteLine("Seleccione el número del rubro que desea explorar:");
                int seleccionRubro = int.Parse(Console.ReadLine()) - 1;
                Rubro rubroSeleccionado = Inventario.SeleccionarRubro(seleccionRubro);

                if (rubroSeleccionado != null)
                {
                    rubroSeleccionado.MostrarLibros();
                    Console.WriteLine("Seleccione el número del libro que desea comprar:");
                    int seleccionLibro = int.Parse(Console.ReadLine()) - 1;
                    if (seleccionLibro < 0 || seleccionLibro >= rubroSeleccionado.Libros.Count)
                    {
                        Console.WriteLine("Selección inválida.");
                        continue;
                    }

                    var libro = rubroSeleccionado.Libros[seleccionLibro];
                    Console.WriteLine("Ingrese la cantidad que desea comprar:");
                    int cantidad = int.Parse(Console.ReadLine());

                    if (Inventario.VerificarStock(libro, cantidad))
                    {
                        carrito.AgregarLibro(libro, cantidad);
                    }
                    else
                    {
                        Console.WriteLine("No hay suficiente stock. Intente con una cantidad menor o elija otro libro.");
                    }

                    Console.WriteLine("¿Desea remover algún libro del carrito? (s/n)");
                    if (Console.ReadLine().ToLower() == "s")
                    {
                        Console.WriteLine("Ingrese el título del libro que desea remover:");
                        string tituloRemover = Console.ReadLine();
                        carrito.RemoverLibro(tituloRemover);
                    }

                    Console.WriteLine("¿Desea seguir comprando? (s/n)");
                    seguirComprando = Console.ReadLine().ToLower() == "s";
                }
            }

            carrito.MostrarCarrito();

            Console.WriteLine("Confirmar compra (s/n):");
            if (Console.ReadLine().ToLower() == "s")
            {
                for (int i = 0; i < carrito.Libros.Count; i++)
                {
                    var libroEnCarrito = carrito.Libros[i];
                    if (!Inventario.VerificarStock(libroEnCarrito.libro, libroEnCarrito.cantidad))
                    {
                        Console.WriteLine($"No hay suficiente stock para el libro {libroEnCarrito.libro.Titulo}. Modifique su pedido.");
                        return;
                    }
                }

                Console.WriteLine("Ingrese número de tarjeta:");
                string numeroTarjeta = Console.ReadLine();
                Console.WriteLine("Ingrese fecha de vencimiento (MM/AA):");
                DateTime fechaVencimiento = DateTime.ParseExact(Console.ReadLine(), "MM/yy", null);
                Console.WriteLine("Ingrese código de seguridad:");
                string codigoSeguridad = Console.ReadLine();

                Venta venta = new Venta(usuario, carrito);
                if (venta.VerificarPago(numeroTarjeta, fechaVencimiento, codigoSeguridad))
                {
                    for (int i = 0; i < carrito.Libros.Count; i++)
                    {
                        var libroEnCarrito = carrito.Libros[i];
                        Inventario.ActualizarStock(libroEnCarrito.libro, libroEnCarrito.cantidad);
                    }
                    venta.ProcesarVenta();
                }
                else
                {
                    Console.WriteLine("El pago fue rechazado.");
                }
            }
            else
            {
                Console.WriteLine("Compra cancelada.");
            }
        }
    }
}
