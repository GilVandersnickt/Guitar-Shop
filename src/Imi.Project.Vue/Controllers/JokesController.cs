using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class JokesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
