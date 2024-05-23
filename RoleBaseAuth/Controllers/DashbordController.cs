using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoleBaseAuth.Controllers
{
    public class DashbordController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
