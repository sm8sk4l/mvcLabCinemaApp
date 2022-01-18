using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using KinoProject.Data;
using Microsoft.Extensions.Logging;
using System;
using KinoProject.Models;
using Microsoft.EntityFrameworkCore;
using KinoProject.Data.Services;

namespace KinoProject.Controllers;

public class HomeController : Controller
{

    private readonly IMoviesService _service ;
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger, IMoviesService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> Index()
    { 
        var data = await _service.GetAllAsync();
        return View(data);
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string name, string pass)
    {
        string adminPass = "admin";
        string adminName = "admin";
        bool isAuth = false;
        bool userExist = false;
        ClaimsIdentity identity = null;

        if (name == adminName && pass == adminPass)
        {
            identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name,name),
                    new Claim(ClaimTypes.Role,"Admin"),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Admin");
        }
        else
        {
            using (DataContext context = new DataContext())
            {
                userExist = context.Users.Any(user => (user.Name == name && user.Password == pass));

            }
            if (userExist)
            {
                identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name,name),
                    new Claim(ClaimTypes.Role,"User"),
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuth = true;
            }
            if (isAuth)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "User");
            }
            return View();

        }
    }

    public async Task<IActionResult> LogOutAsync()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string name, string mail, string pass)
    {
        if (name.Length > 0 && mail.Length > 0 && pass.Length > 0)
        {
            using (DataContext context = new DataContext())
            {
                context.Users.Add(new User()
                {
                    Name = name,
                    Mail = mail,
                    Password = pass
                });
                context.SaveChanges();
            }
            return View("AfterRegister");
        }
        else
        {

        }
        return View();
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
