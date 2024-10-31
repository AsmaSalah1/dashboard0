using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asmaa.Pl.Areas.DashBord.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]

    [Area("DashBord")]
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
