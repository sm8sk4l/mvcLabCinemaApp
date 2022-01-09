using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using KinoProject.Data;
using Microsoft.Extensions.Logging;
using System;
using KinoProject.Models;

namespace KinoProject.Controllers;
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddHall()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddHall(int maxCapacity, int nr)
    {
        using (DataContext context = new DataContext())
        {
            context.Halls.Add(new Hall()
            {
                MaxCapacity = maxCapacity,
                AmountOfBusySeat = 0,
                Nr = nr,
            });
            context.SaveChanges();
        }
        return View();
    }

    public IActionResult ShowHalls()
    {
        IAsyncEnumerator<KinoProject.Models.Cinema> cinema;
        using (DataContext context = new DataContext())
        {
            cinema = context.Cinemas.GetAsyncEnumerator();
        }
        return View(cinema);
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
