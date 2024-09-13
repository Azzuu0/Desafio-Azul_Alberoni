using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Prog.Clases
{
    public class Carrito
    {
        public List<(Libro libro, int cantidad)> Libros { get; private set; } = new List<(Libro, int)>();

        public void AgregarLibro(Libro libro, int cantidad)
        {
            Libros.Add((libro, cantidad));
        }

        public void RemoverLibro(string titulo)
        {
            bool libroEncontrado = false;

            for (int i = 0; i < Libros.Count; i++)
            {
                if (Libros[i].libro.Titulo == titulo)
                {
                    Libros.RemoveAt(i);
                    libroEncontrado = true;
                    Console.WriteLine($"El libro '{titulo}' ha sido removido del carrito.");
                    break;
                }
            }

            if (!libroEncontrado)
            {
                Console.WriteLine($"El libro '{titulo}' no está en el carrito.");
            }
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var (libro, cantidad) in Libros)
            {
                total += libro.Precio * cantidad;
            }
            return total;
        }

        public void MostrarCarrito()
        {
            if (Libros.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                Console.WriteLine("Libros en el carrito:");
                foreach (var (libro, cantidad) in Libros)
                {
                    decimal subtotal = libro.Precio * cantidad;
                    Console.WriteLine($"{libro.Titulo} - Cantidad: {cantidad} - Precio: ${libro.Precio} - Subtotal: ${subtotal}");
                }
                Console.WriteLine($"Total: ${CalcularTotal()}");
            }
        }
    }
}
