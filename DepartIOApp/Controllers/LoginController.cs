using DepartIOApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DepartIOApp.Controllers
{
    public class LoginController : Controller
    {
        DbDContext c = new DbDContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(Admin p)
        {
            var infos = c.Admins.FirstOrDefault(x=>x.Username == p.Username && x.Password == p.Password);
            if(infos != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, p.Username)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Login");
        }
    }
}
