using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace PrincePurse.Controllers
{
    public class PrincePurseController : Controller
    {
        // 
        // GET: /PrinsePurse/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /PrincePurse/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}