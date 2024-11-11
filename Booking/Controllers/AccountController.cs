using Booking.Entities;
using Booking.Repositories.Interfaces;
using Booking.WebHost.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebHost.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AccountController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo
            {
                UserName = vm.UserName,
                Password = vm.Password,                                             
               
            };
            await _userRepo.RegisterUser(model);
            //return View(model);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserInfoViewModel vm)
        {
            var userInfo = await _userRepo.GetUserInfo(vm.UserName, vm.Password);
            HttpContext.Session.SetInt32("userId", userInfo.UserId);
            HttpContext.Session.SetString("userName", userInfo.UserName);
            return RedirectToAction("Index", "Concerts");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
