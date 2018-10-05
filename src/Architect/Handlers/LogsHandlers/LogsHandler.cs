using Architect.Repositories.DTOs;
using Architect.Repositories.SqlRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Architect.Handlers.LogsHandlers
{
    public class LogsHandler : IRequestHandler<LogsRequest, LogsResponse>
    {

        readonly ILogsRepository logsRepository;
        readonly ILogger<LogsHandler> logger;
        public LogsHandler(ILogsRepository logsRepository, ILogger<LogsHandler> logger)
        {
            this.logsRepository = logsRepository;
            this.logger = logger;
        }


        public async Task<LogsResponse> Handle(LogsRequest request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => new LogsResponse()
            {
                Logs = logsRepository.GetLogs() as List<LogsDto>
            });
        }
    }
}
