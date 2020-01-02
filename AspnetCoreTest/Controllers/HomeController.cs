using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreTest.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace AspnetCoreTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _sender;
        public HomeController(IEmailSender sender)
        {
            _sender = sender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            await _sender.SendEmailAsync("1013171256@qq.com", "Test", "Test");
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
