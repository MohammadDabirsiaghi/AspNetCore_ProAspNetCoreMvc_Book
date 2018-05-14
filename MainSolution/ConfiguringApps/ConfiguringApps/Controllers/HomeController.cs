using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptime;
        public HomeController(UptimeService uptime)
        {
            this._uptime = uptime;

        }
        public IActionResult Index()
        {
            var data = new Dictionary<string, string>
            {
                ["Message"] = "This Is Test Message",
                ["Uptime"] = $"{_uptime.Uptime}ms"
            };
            
            return View(data);
        }
    }
}