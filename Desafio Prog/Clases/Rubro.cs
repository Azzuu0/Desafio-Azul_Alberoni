using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Prog.Clases
{
    public class Rubro
    {
        public string Nombre { get; set; }
        public List<Libro> Libros { get; private set; } = new List<Libro>();

        public Rubro(string nombre)
        {
            Nombre = nombre;
        }

        public void AgregarLibro(Libro libro)
        {
            Libros.Add(libro);
        }

        public void MostrarLibros()
        {
            if (Libros.Count == 0)
            {
                Console.WriteLine("No hay libros en este rubro.");
            }
            else
            {
                Console.WriteLine($"Libros en el rubro '{Nombre}':");
                for (int i = 0; i < Libros.Count; i++)
                {
                    var libro = Libros[i];
                    Console.WriteLine($"{i + 1}. {libro.Titulo} - Autor: {libro.Autor} - Precio: ${libro.Precio} - Stock: {libro.Stock}");
                }
            }
        }
    }
}
