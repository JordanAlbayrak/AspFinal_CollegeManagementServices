using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace College_Management_Services.Controllers
{
    public class StaffController : Controller
    {
        [Authorize(Roles = "Staff")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
