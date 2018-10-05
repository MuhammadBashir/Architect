using Architect.Infrastructure.Common;
using Architect.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architect.Repositories.SqlRepositories
{
    public class LogsRepository : BaseRepository, ILogsRepository
    {
        public LogsRepository(IConnectionFactory connectionFactory): base(connectionFactory)
        {

        }
        public IEnumerable<LogsDto> GetLogs()
        {
            return Query<LogsDto>("cms.GetLogs");
        }
    }
}
