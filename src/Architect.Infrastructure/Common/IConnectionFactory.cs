using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Architect.Infrastructure.Common
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
        IDbConnection CreateConnection(string connectionString);
        Task<IDbConnection> CreateConnectionAysnc();

    }
}
