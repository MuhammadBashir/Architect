using Architect.Infrastructure.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Architect.Repositories.SqlRepositories
{
    public abstract class BaseRepository
    {
        private IConnectionFactory connectionFactory;
        public BaseRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IEnumerable<T> Query<T>(string spName, object spParams = null)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                return connection.Query<T>(spName, spParams, commandType: CommandType.StoredProcedure);
            }
        }
        public T QuerySingleOrDefault<T>(string spName, object spParams = null)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                return connection.QuerySingleOrDefault<T>(spName, spParams, commandType: CommandType.StoredProcedure);
            }
        }

        public int Execute(string spName, object spParams = null)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                return connection.Execute(spName, spParams, commandType: CommandType.StoredProcedure);
            }
        }

        public T ExecuteScalar<T>(string spName, object spParams = null)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                return connection.ExecuteScalar<T>(spName, spParams, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
