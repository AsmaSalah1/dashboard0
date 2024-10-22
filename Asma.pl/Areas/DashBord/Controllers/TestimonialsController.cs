using Asma.DAL.Data;
using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asmaa.Pl.Areas.DashBord.ViewModels.TestimonalVM;

namespace Asmaa.Pl.Areas.DashBord.Controllers
{
    [Area("DashBord")]
    public class TestimonialsController : Controller
    {
    
            private readonly ApplicationDbContext dbContext;
            private readonly IMapper mapper;

            public TestimonialsController(ApplicationDbContext dbContext, IMapper mapper)
            {
                this.dbContext = dbContext;
                this.mapper = mapper;
            }


            public IActionResult Index()
            {
                var Testimonals = dbContext.Testimonals.AsNoTracking().ToList();
                var m = mapper.Map<IEnumerable<TestimonalIndexVM>>(Testimonals);
                return View(m);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            //  [ValidateAntiForgeryToken]

            public IActionResult Create(TestimonalCreateVM model)//نوع الداتا الي عندي فيو موديل وانا بضيف ع الداتا بيس نوع غير
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                    //  return Json(new { success = false, message = "البيانات غير صالحة", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

                }
                var m = mapper.Map<Testimonal>(model);
                dbContext.Add(m);
                dbContext.SaveChanges();
                //return Json(new { success = true, message = "تم إنشاء المنتج بنجاح!" }); 
                return RedirectToAction(nameof(Index));
            }
            [HttpGet]
            public IActionResult Details(int? id)
            {
                if (id is null)
                {
                    return BadRequest();
                }
                var testimonal = dbContext.Testimonals.Find(id);

                if (testimonal is null)
                {
                    return NotFound();
                }
                return View(testimonal);
            }
            [HttpGet]
            public IActionResult Edit(int? id)
            {
                if (id is null)
                {
                    return BadRequest();
                }
                var test = dbContext.Testimonals.Find(id);
                if (test is null)
                {
                    return NotFound();
                }
                var conv = mapper.Map<TestimonalCreateVM>(test);
                return View(conv);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(TestimonalCreateVM VM)
            {

                var model = dbContext.Testimonals.Find(VM.Id);
                if (model is null)
                {
                    return NotFound();
                }
            
                if (!ModelState.IsValid)
                {
                    return View(VM);
                }
                mapper.Map(VM, model); //نفس الي تحتها
                /*            var conv = mapper.Map<LastProduct>(VM);
                */
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var test = dbContext.Testimonals.Find(id);

            if (test is null)
            {
                return NotFound();
            }
            dbContext.Testimonals.Remove(test);
            dbContext.SaveChanges();
            return Ok(new { message = "Testimonal deleted" });
            //لو حطيت اوك لحالها برجع رقم 200 وانا بدي ارجع جيسون فبجط مسج
            //هاي المسج رد الباك ايند
        }
    }
}
