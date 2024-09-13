using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Prog.Clases
{
    public class Venta
    {
        public Usuario Cliente { get; set; }
        public Carrito CarritoCompra { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoSeguridad { get; set; }

        public Venta(Usuario cliente, Carrito carrito)
        {
            Cliente = cliente;
            CarritoCompra = carrito;
        }

        public bool VerificarPago(string numeroTarjeta, DateTime fechaVencimiento, string codigoSeguridad)
        {
            return true; // Simulación de verificación de tarjeta
        }

        public void ProcesarVenta()
        {
            Console.WriteLine("Venta procesada exitosamente para el usuario: " + Cliente.Nombre);
            Console.WriteLine("Total de la compra: $" + CarritoCompra.CalcularTotal());
        }
    }
}
