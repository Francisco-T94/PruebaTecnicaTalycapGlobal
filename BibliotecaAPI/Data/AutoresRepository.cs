using BibliotecaAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI.Data
{
    public class AutoresRepository
    {
        private readonly string _connectionString;

        public AutoresRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Autore>> GetAutorByName(string NombreAutor1, string NombreAutor2, string NombreAutor3 )
        {
            if (string.IsNullOrEmpty(NombreAutor1))
            {
                NombreAutor1 = "";
            }

            if (string.IsNullOrEmpty(NombreAutor2))
            {
                NombreAutor2 = "";
            }
          
            if (string.IsNullOrEmpty(NombreAutor3))
            {
                NombreAutor3 = "";
            }
          
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAutorByName", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@nombreAutor1", NombreAutor1));
                    cmd.Parameters.Add(new SqlParameter("@nombreAutor2", NombreAutor2));
                    cmd.Parameters.Add(new SqlParameter("@nombreAutor3", NombreAutor3));
                    var response = new List<Autore>();
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

        private Autore MapToValue(SqlDataReader reader)
        {
            return new Autore()
            {
                IdAutor = (int)reader["id_autor"],
                NomAutor = (string)reader["nom_autor"],
                ApeAutor = (string)reader["ape_autor"],
            };
        }
    }
}
