using Microsoft.AspNetCore.Mvc;

namespace Asmaa.Pl.Areas.DashBord.Controllers
{
	[Area("DashBord")]
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
