using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCloudAPIRecap.DAL.Entities;
using TFCloudAPIRecap.DAL.Interfaces;

namespace TFCloudAPIRecap.DAL.Repositories
{
    public class Type_PokemonRepo : IType_PokemonRepo
    {
        private SqlConnection _connection;
        public Type_PokemonRepo(SqlConnection cnx)
        {
            _connection = cnx;
        }

        public void Create(int pokemonId, int typeId)
        {
            string sql = "INSERT INTO Type_Pokemon (PokemonId, TypeId) VALUES (@pokemonId, @typeId)";
            _connection.Execute(sql, new { pokemonId, typeId });
        }

        public IEnumerable<Type_Pokemon> GetAll()
        {
            string req = "SELECT P.* FROM Pokemon P " +
                "JOIN Type_Pokemon TP ON P.Id = TP.PokemonId " +
                "WHERE TP.TypeId = @id";

            string sql = "SELECT * FROM Type_Pokemon";
            return _connection.Query<Type_Pokemon>(sql);
        }
    }
}
