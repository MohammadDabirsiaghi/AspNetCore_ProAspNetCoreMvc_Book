using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptime;
        private ILogger<HomeController> logger;
        public HomeController(UptimeService uptime,ILogger<HomeController> log)
        {
            this._uptime = uptime;
            this.logger = log;

        }
        public IActionResult Index(bool throwException)
        {
            if (throwException)
                throw new System.NullReferenceException();
            logger.LogDebug($"Handled {Request.Path} at uptime{_uptime.Uptime}");
            var data = new Dictionary<string, string>
            {
                ["Message"] = "This Is Test Message13",
                ["Uptime"] = $"{_uptime.Uptime}ms"
            };
            
            return View(data);
        }
        public IActionResult Error()
        {
            return View("Index");
        }
    }
}