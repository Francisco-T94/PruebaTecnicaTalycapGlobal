using BibliotecaAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI.Data
{
    public class LibrosRepository
    {
        private readonly string _connectionString;

        public LibrosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Libro>> GetLibroByName(string NombreLibro1, string NombreLibro2, string NombreLibro3)
        {
            if (string.IsNullOrEmpty(NombreLibro1))
            {
                NombreLibro1 = "";
            }

            if (string.IsNullOrEmpty(NombreLibro2))
            {
                NombreLibro2 = "";
            }
          
            if (string.IsNullOrEmpty(NombreLibro3))
            {
                NombreLibro3 = "";
            }
          
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetLibrosByName", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@nombreLibro1", NombreLibro1));
                    cmd.Parameters.Add(new SqlParameter("@nombreLibro2", NombreLibro2));
                    cmd.Parameters.Add(new SqlParameter("@nombreLibro3", NombreLibro3));
                    var response = new List<Libro>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<List<Libro>> GetLibrosByRangeDate(string fechaInicio, string fechaFin)
        {
            if (string.IsNullOrEmpty(fechaInicio))
            {
                fechaInicio = "1900-01-01";
            }

            if (string.IsNullOrEmpty(fechaFin))
            {
                DateTime thisDay = DateTime.Today;
                fechaFin = thisDay.ToString("yyyy-MM-dd");
            }

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetLibrosByRangeDate", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
                    var response = new List<Libro>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<List<Libro>> GetLibrosByIdAutor(int idAutor)
        {
         

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetLibrosByIdAutor", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@idAutor ", idAutor));
                    var response = new List<Libro>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }


        private Libro MapToValue(SqlDataReader reader)
        {
            return new Libro()
            {
                IdLibro = (int)reader["id_libro"],
                IdAutor = (int)reader["id_autor"],
                NomLibro = (string)reader["nom_libro"],
                CantidadPaginas = (int)reader["cantidad_paginas"],
                FechaPublicacion= (DateTime)reader["fecha_publicacion"]
            };
        }
    }
}
