using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_Prog.Clases
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public Rubro Rubro { get; set; }

        public Libro(string titulo, string autor, int stock, decimal precio, Rubro rubro)
        {
            Titulo = titulo;
            Autor = autor;
            Stock = stock;
            Precio = precio;
            Rubro = rubro;
        }
    }
}
