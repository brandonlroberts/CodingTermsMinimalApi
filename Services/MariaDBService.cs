﻿using CodingTermsMinimalApi.Services.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace CodingTermsMinimalApi.Services
{
    public class MariaDBService : IMariaDBService
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);
                return rows.ToList();
            }
        }

        public Task SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
