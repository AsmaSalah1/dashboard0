using Asma.DAL.Data;
using Asmaa.DAL.Model;
using Asmaa.Pl.Areas.DashBord.ViewModels;
using Asmaa.Pl.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Asmaa.Pl.Areas.DashBord.Controllers
{
    
    [Authorize(Roles ="Admin,SuperAdmin")]
    [Area("DashBord")]
    public class LastProductController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public LastProductController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            var Products = dbContext.LastProducts.AsNoTracking().ToList();
            var m=mapper.Map<IEnumerable<LastProductIndexVM>>(Products);
            return View(m);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
      //  [ValidateAntiForgeryToken]

        public IActionResult Create([FromForm] LastProductCreateVM model)//نوع الداتا الي عندي فيو موديل وانا بضيف ع الداتا بيس نوع غير
        {
            if (!ModelState.IsValid)
            {
              return View(model);
          //  return Json(new { success = false, message = "البيانات غير صالحة", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

            }
            model.ImageName = FileHelper.UplodeFile(model.Image, "Images");
            var m = mapper.Map<LastProduct>(model);
            dbContext.Add(m);
            dbContext.SaveChanges();
           //return Json(new { success = true, message = "تم إنشاء المنتج بنجاح!" }); 
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int? id) {
            if (id is null)
            {
                return BadRequest();
            }
            var prodects = dbContext.LastProducts.Find(id);

            if (prodects is null)
            {
                return NotFound();
            }
            return View(prodects);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var p=dbContext.LastProducts.Find(id);
            if (p is null)
            {
                return NotFound();
            }
            var conv = mapper.Map<LastProductCreateVM>(p);
            return View(conv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LastProductCreateVM VM)
        {

            var model = dbContext.LastProducts.Find(VM.Id);
            if(model is null)
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
            mapper.Map(VM,model); //نفس الي تحتها
/*            var conv = mapper.Map<LastProduct>(VM);
*/            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id is null)
        //    {
        //        return BadRequest();
        //    }
        //    var prodects = dbContext.LastProducts.Find(id);
        //    if (prodects is null)
        //    {
        //        return NotFound();
        //    }
        //    var m=mapper.Map< LastProductIndexVM >(prodects);
        //    return View(m);
        //}
        //[HttpPost,ActionName("Delete")]//عشان ما يجيب ايرور لانه الاكشن الي فوق كمان نفس الاسم و البراميتر
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var prodects =dbContext.LastProducts.Find(id);

            if (prodects is null)
            {
                return NotFound();
            }
            FileHelper.DeleteFile(prodects.ImageName, "Images");
            dbContext.LastProducts.Remove(prodects);
            dbContext.SaveChanges();
            return Ok(new {message="Product deleted"});
            //لو حطيت اوك لحالها برجع رقم 200 وانا بدي ارجع جيسون فبجط مسج
            //هاي المسج رد الباك ايند
        }




    }
}
