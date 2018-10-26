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
        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            //var request = new LogsRequest();
            //var response = mediator.Send(request);
            //var logs = response.Result.Logs;
            return View();
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
