using Asma.DAL.Data;
using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asmaa.Pl.Areas.DashBord.Controllers
{
    [Area("DashBord")]
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public FeaturesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var fetures=dbContext.Features.AsNoTracking().ToList();
            var f = mapper.Map< IEnumerable<FeatureIndexVM>>(fetures);
            return View(f);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeaturesCreateVM model)//نوع الداتا الي عندي فيو موديل وانا بضيف ع الداتا بيس نوع غير
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var m = mapper.Map<Feature>(model);
            dbContext.Add(m);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details() {

            return View();

        }

    }
}
