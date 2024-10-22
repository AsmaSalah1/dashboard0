using Asmaa.DAL.Model;
using Asmaa.Pl.Helper;
using Asmaa.Pl.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asmaa.Pl.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly SignInManager<ApplicationUser> signInManger;

        public AccountController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManger)
        {
            this.userManger = userManger;
            this.signInManger = signInManger;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                //هنا ما بستخدم المابر لانه بصير خربشة وانما يدويا لانه سهل وفش لوب
                //بنعمل اوبجيكت من الابليكيشن يوزر عشان اعمل ماب و اضيق ع الداتا بيس
                var user = new ApplicationUser()
                {
                    //الي موجودة داخل الايدينتتي يوزر
                    UserName = model.UserName,
                    Email = model.Email,
                };
                //بدي اضيف اليوزر ع الداتا بيس
                var result = await userManger.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
            }
            return View(model);
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManger.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var check = await userManger.CheckPasswordAsync(user, model.Password);
                    if (check)
                    {
                        var result = await signInManger.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(model);
        }
        public IActionResult ForgotPassward()
        {
            return View();
        }
      
        public async Task<IActionResult> SentForPassEmail(ForgotPasswardVM model)
        {
            //اذا الداتا الي دخلها صحيحة بالنسبة للفاليديشن تبع الايمييل
            if (ModelState.IsValid) {
                //الايميل الي دخله موجود عندي بالداتا بيس
                var user = await userManger.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    //ابعث توكن عشان التشفير و اعرف الايميل لاي يوزر
                    var token = await userManger.GeneratePasswordResetTokenAsync(user);
                   //الاكشين او الصفحة الي رح يوديني عليها عشان اعمل كلمة سر جديدة -- رابط هاي الصفحة بكون بالرسالة تبعت الجيميل 
                    var resetPassURL=Url.Action("ResetPassword","Account",new {email=model.Email,token=token},"https", "localhost:7208");
                    var email = new Email()
                    {
                        Subject = "Reset Pass",
                        Reciver = model.Email,
                        Body="Hi soso",
                    };
                    EmailHealper.SendEmail(email);
                }
            }

            return View();
        }
        public IActionResult ResetPassword(string email,string token)
        {
            return View();
        }
        //هاد الاكشين داخله الايميل و التوكن و الباسوورد الجديد
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid) { 
            //افحص اذا الايميل تبعه موجود او لا
            var user=await userManger.FindByEmailAsync(model.Email);
                //اذا موجود بعمل ابديت للباسوورد - الفنكشن جاهز ما بحتاج اعمل اشي -- 
          if(user is not null)
                { 
                    var result=await userManger.ResetPasswordAsync(user,model.Token,model.NewPassword);
                    if (result.Succeeded)
                    {
                        RedirectToAction(nameof(LogIn));
                    }
                }
            }
            return View(model);
        }
    }
}
