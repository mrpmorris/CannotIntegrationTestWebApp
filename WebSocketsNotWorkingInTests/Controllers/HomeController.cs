using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebSocketsNotWorkingInTests.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public string Index()
        {
            return "Hello";
        }
    }
}