using Asma.DAL.Data;
using Asma.pl.ViewModel;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM;
using Asmaa.Pl.Areas.DashBord.ViewModels.TestimonalVM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Asma.pl.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext dbContext, IMapper mapper)
		{
			_logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

		public IActionResult Index()
		{
            var Products = dbContext.LastProducts.AsNoTracking().ToList();
            var m = mapper.Map<IEnumerable<LastProductIndexVM>>(Products);
			ViewBag.Products = m;	
            var fetures = dbContext.Features.AsNoTracking().ToList();
            var f = mapper.Map<IEnumerable<FeatureIndexVM>>(fetures);
            ViewBag.fetures = f;

            var Testimonals = dbContext.Testimonals.AsNoTracking().ToList();
            var ms = mapper.Map<IEnumerable<TestimonalIndexVM>>(Testimonals);
            ViewBag.fetures = ms;

            //ViewData["pro"]=dbContext.LastProducts.ToList();

            return View();
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
