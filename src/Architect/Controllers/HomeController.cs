using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Architect.Models;
using MediatR;
using Architect.Handlers.LogsHandlers;
using Microsoft.Extensions.Logging;

namespace Architect.Controllers
{
    public class HomeController : Controller
    {
        readonly IMediator mediator;
        readonly ILogger<HomeController> logger;
        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            logger.LogInformation("Logger to check logging and monitor further steps of {0}", nameof(HomeController));
            var request = new LogsRequest();
            var response = mediator.Send(request);
            var logs = response.Result.Logs;
            return View(logs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
