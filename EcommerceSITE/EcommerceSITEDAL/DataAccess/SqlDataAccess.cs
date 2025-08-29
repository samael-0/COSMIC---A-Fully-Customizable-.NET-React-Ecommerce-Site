using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;


        public SqlDataAccess(IConfiguration config)
        {
               _config = config;
        }


        public async Task<IEnumerable<T>> GetData<T, P>(string sql ,P parameters, string connectionID= "conn")
        {
            using IDbConnection connection = new SqlConnection
                (_config.GetConnectionString(connectionID));

            return await connection.QueryAsync<T>(sql, parameters);
      
        }




        public async Task SaveData<T>(string sql, T parameters, string connectionId = "conn")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(sql, parameters);
        }



    }
}
