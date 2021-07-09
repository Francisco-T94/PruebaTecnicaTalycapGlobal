using System;
using System.Collections.Generic;

#nullable disable

namespace BibliotecaAPI.Models
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public int? IdAutor { get; set; }
        public string NomLibro { get; set; }
        public int CantidadPaginas { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public virtual Autore IdAutorNavigation { get; set; }
    }
}
