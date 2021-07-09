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
    public class AutoresController : ControllerBase
    {

        private readonly AutoresRepository _repository;

        public AutoresController(AutoresRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("GetAutorByName/{NombreAutor1}/{NombreAutor2}/{NombreAutor3}")]
        public async Task<List<Autore>> Get(string NombreAutor1, string NombreAutor2, string NombreAutor3)
        {
            var response = await _repository.GetAutorByName(NombreAutor1, NombreAutor2, NombreAutor3);
            return response;
        }

        [HttpGet]
        public IEnumerable<Models.Autore> Get()
        {
            using(var db = new Models.BibliotecaDBContext())
            {
                IEnumerable<Models.Autore> autores = db.Autores.ToList();
                return autores;
            }
        }
    }
}
