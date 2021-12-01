using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace College_Management_Services.Controllers
{
    public class StudentController : Controller
    {
        [Authorize(Roles = "Student")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
