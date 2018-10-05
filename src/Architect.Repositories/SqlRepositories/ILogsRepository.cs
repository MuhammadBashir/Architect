using Architect.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architect.Repositories.SqlRepositories
{
    public interface ILogsRepository
    {
        IEnumerable<LogsDto> GetLogs();
    }
}
