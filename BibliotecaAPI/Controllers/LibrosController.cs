using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {

        private readonly LibrosRepository _repository;

        public LibrosController(LibrosRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("GetLibroByName/{NombreLibro1}/{NombreLibro2}/{NombreLibro3}")]
        public async Task<List<Libro>> GetGetLibroByName(string NombreLibro1, string NombreLibro2, string NombreLibro3)
        {
            var response = await _repository.GetLibroByName(NombreLibro1, NombreLibro2, NombreLibro3);
            return response;
        }

        [HttpGet("GetLibrosByRangeDate/{fechaInicio}/{fechaFin}")]
        public async Task<List<Libro>> GetLibrosByRangeDate(string fechaInicio, string fechaFin)
        {
            var response = await _repository.GetLibrosByRangeDate(fechaInicio, fechaFin);
            return response;
        }

        [HttpGet("GetLibrosByIdAutor/{IdAutor}")]
        public async Task<List<Libro>> GetLibrosByRangeDate(int IdAutor)
        {
            var response = await _repository.GetLibrosByIdAutor(IdAutor);
            return response;
        }

        [HttpGet]
        public IEnumerable<Models.Libro> Get()
        {
            using (var db = new Models.BibliotecaDBContext())
            {
                IEnumerable<Models.Libro> libros = db.Libros.ToList();
                return libros;
            }
        }

    }
}
