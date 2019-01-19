using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pas_pertamina.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pas_pertamina.Controllers
{
    public class LoginController : Controller
    {
        UserDataAccessLayer objUser = new UserDataAccessLayer();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] UserDetails user)
        {
            
            if (ModelState.IsValid)
            {
                string LoginStatus = objUser.ValidateLogin(user);
                string _akses = UserDataAccessLayer._akses;
                string _idpelabuhan = UserDataAccessLayer._idpelabuhan;
                if (LoginStatus == "Success")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Namauser)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal,
                        new AuthenticationProperties
                        {
                            AllowRefresh = false
                        }
                   );
                    HttpContext.Session.SetString("Namauser", user.Namauser);
                    HttpContext.Session.SetString("Akses", _akses);
                    HttpContext.Session.SetString("Idpelabuhan", _idpelabuhan);
                    return RedirectToAction("Index", "Kapals");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
