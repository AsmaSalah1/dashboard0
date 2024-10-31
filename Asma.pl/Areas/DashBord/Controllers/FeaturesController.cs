using Asma.DAL.Data;
using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Areas.DashBord.ViewModels.FeaturesVM;
using Asmaa.Pl.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;

namespace Asmaa.Pl.Areas.DashBord.Controllers
{
    [Area("DashBord")]
    [Authorize(Roles = "Admin,SuperAdmin")]
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
/*        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeaturesCreateVM model)//نوع الداتا الي عندي فيو موديل وانا بضيف ع الداتا بيس نوع غير
        {
            model.Description = HttpUtility.HtmlDecode(model.Description);//المكتبة

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.ImageName = FileHelper.UplodeFile(model.Image, "Images");
            var m = mapper.Map<Feature>(model);
            dbContext.Add(m);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }*/
        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public IActionResult Create(FeaturesCreateVM model)//نوع الداتا الي عندي فيو موديل وانا بضيف ع الداتا بيس نوع غير
        {
        //   model.Description = HttpUtility.HtmlDecode(model.Description);//المكتبة

            if (!ModelState.IsValid)
            {
                return View(model);

            }
            model.ImageName = FileHelper.UplodeFile(model.Image, "Images");
            var m = mapper.Map<Feature>(model);
            dbContext.Add(m);
            dbContext.SaveChanges();
            //return Json(new { success = true, message = "تم إنشاء المنتج بنجاح!" }); 
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var Fetures = dbContext.Features.Find(id);

            if (Fetures is null)
            {
                return NotFound();
            }
            return View(Fetures);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var f = dbContext.Features.Find(id);
            if (f is null)
            {
                return NotFound();
            }
            var conv = mapper.Map<FeaturesCreateVM>(f);
            return View(conv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FeaturesCreateVM VM)
        {

            var model = dbContext.Features.Find(VM.Id);
            if (model is null)
            {
                return NotFound();
            }
            if (VM.Image != null)
            {
                // حذف الصورة القديمة إذا كانت موجودة
                if (!string.IsNullOrEmpty(model.ImageName))
                {
                    FileHelper.DeleteFile(model.ImageName, "Images");

                }
                // رفع الصورة الجديدة وتخزين اسم الملف
                VM.ImageName = FileHelper.UplodeFile(VM.Image, "Images");
            }
            else//لما ما نغير ع الصورة 
            {
                // إذا لم يتم رفع صورة جديدة، الحفاظ على الصورة القديمة
                VM.ImageName = model.ImageName;//مش ضروري احطها لانه بالماب بتنعمل
                ModelState.Remove("Image");//ما تعمل فاليديشين للصورة 
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
        //[HttpPost,ActionName("Delete")]//عشان ما يجيب ايرور لانه الاكشن الي فوق كمان نفس الاسم و البراميتر
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var features = dbContext.Features.Find(id);

            if (features is null)
            {
                return NotFound();
            }
            FileHelper.DeleteFile(features.ImageName, "Images");
            dbContext.Features.Remove(features);
            dbContext.SaveChanges();
            return Ok(new { message = "feature deleted" });
            //لو حطيت اوك لحالها برجع رقم 200 وانا بدي ارجع جيسون فبجط مسج
            //هاي المسج رد الباك ايند
        }

    }
}
