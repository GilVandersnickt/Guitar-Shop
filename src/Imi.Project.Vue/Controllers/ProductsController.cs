using Microsoft.AspNetCore.Mvc;

namespace Imi.Project.Vue.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
