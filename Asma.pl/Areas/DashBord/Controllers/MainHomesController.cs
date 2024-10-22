using Asma.DAL.Data;
using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels.MainHomeVM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Asmaa.Pl.Areas.DashBord.Controllers
{
    [Area("DashBord")]
    public class MainHomesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public MainHomesController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var home = dbContext.MainHomes.AsNoTracking().ToList();
            var conv = mapper.Map<IEnumerable< MainHomeIndexVM >>(home);
            return View(conv);
        }
    }
}
