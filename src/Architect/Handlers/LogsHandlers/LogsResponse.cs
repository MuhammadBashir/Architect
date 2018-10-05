using Architect.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architect.Handlers.LogsHandlers
{
    public class LogsResponse
    {
        public List<LogsDto> Logs { get; set; } = new List<LogsDto>();
    }
}
