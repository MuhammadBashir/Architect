using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Architect.Infrastructure.Common
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        private string connectionString;
        private CancellationTokenSource cancellationToken;
        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public async Task<IDbConnection> CreateConnectionAysnc()
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
