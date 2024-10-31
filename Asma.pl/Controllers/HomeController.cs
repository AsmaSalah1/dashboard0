using Asma.DAL.Data;
using Asma.pl.Data.Migrations;
using Asma.pl.ViewModel;
using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM;
using Asmaa.Pl.Areas.DashBord.ViewModels.MainHomeVM;
using Asmaa.Pl.Areas.DashBord.ViewModels.TestimonalVM;
using Asmaa.Pl.Helper;
using Asmaa.Pl.ViewModel;
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
        public async Task<IActionResult> Index()
        {
            var Products = await dbContext.LastProducts.AsNoTracking().ToListAsync();
            var m = mapper.Map<IEnumerable<LastProductIndexVM>>(Products);
            ViewBag.Products = m;

            var fetures = await dbContext.Features.AsNoTracking().ToListAsync();
            var f = mapper.Map<IEnumerable<FeatureIndexVM>>(fetures);
            ViewBag.fetures = f;

            var Testimonals = await dbContext.Testimonals.AsNoTracking().ToListAsync();
            var ms = mapper.Map<IEnumerable<TestimonalIndexVM>>(Testimonals);
            ViewBag.Testimonals = ms;

            var firstHome = await dbContext.MainHomes.AsNoTracking().ToListAsync();
            var con = mapper.Map<IEnumerable<MainHomeIndexVM>>(firstHome);
            ViewBag.FirstHome = con;

            return View();
        }

        /*public IActionResult Index()
		{
            var Products = dbContext.LastProducts.AsNoTracking().ToList();
            var m = mapper.Map<IEnumerable<LastProductIndexVM>>(Products);
			ViewBag.Products = m;	
            var fetures = dbContext.Features.AsNoTracking().ToList();
            var f = mapper.Map<IEnumerable<FeatureIndexVM>>(fetures);
            ViewBag.fetures = f;

            var Testimonals = dbContext.Testimonals.AsNoTracking().ToList();
            var ms = mapper.Map<IEnumerable<TestimonalIndexVM>>(Testimonals);
            ViewBag.Testimonals = ms;

            var firstHome = dbContext.MainHomes.AsNoTracking().ToList();
            var con = mapper.Map<IEnumerable<MainHomeIndexVM>>(firstHome);
            ViewBag.FirstHome = con;
            //ViewData["pro"]=dbContext.LastProducts.ToList();

            return View();
		}*/
        public IActionResult AllProduct()
		{
            var Products = dbContext.LastProducts.AsNoTracking().ToList();
            var m = mapper.Map<IEnumerable<LastProductIndexVM>>(Products);
            ViewBag.Products = m;
            return View();
		}
        [HttpPost]
        public IActionResult ContactUs(ContactUsVM model)
        {
            var email = new Email()
            {
                Subject = "user message",
                Reciver =model.Email,
                Body = $"i am {model.Name} my Phone number is {model.Phone} my message is {model.Message} ",
            };
            EmailHealper.SendEmail(email);
            return RedirectToAction(nameof(Index));
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
