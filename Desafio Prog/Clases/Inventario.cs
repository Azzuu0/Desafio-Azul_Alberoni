using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Prog.Clases
{
    public class Inventario
    {
        public List<Rubro> Rubros { get; private set; } = new List<Rubro>();

        public void AgregarRubro(Rubro rubro)
        {
            Rubros.Add(rubro);
        }

        public void MostrarRubros()
        {
            Console.WriteLine("Rubros disponibles:");
            for (int i = 0; i < Rubros.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Rubros[i].Nombre}");
            }
        }

        public Rubro SeleccionarRubro(int indice)
        {
            if (indice >= 0 && indice < Rubros.Count)
            {
                return Rubros[indice];
            }
            else
            {
                Console.WriteLine("Selección de rubro inválida.");
                return null;
            }
        }

        public bool VerificarStock(Libro libro, int cantidad)
        {
            return libro.Stock >= cantidad;
        }

        public void ActualizarStock(Libro libro, int cantidadVendida)
        {
            libro.Stock -= cantidadVendida;
        }
    }
}
