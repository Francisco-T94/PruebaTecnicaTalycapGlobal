using System;
using System.Collections.Generic;

#nullable disable

namespace BibliotecaAPI.Models
{
    public partial class Autore
    {
        public Autore()
        {
            Libros = new HashSet<Libro>();
        }

        public int IdAutor { get; set; }
        public string NomAutor { get; set; }
        public string ApeAutor { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
