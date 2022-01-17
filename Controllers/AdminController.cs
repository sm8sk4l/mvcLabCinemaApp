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
using KinoProject.Data.Services;

namespace KinoProject.Controllers;
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IMoviesService _service ;
    public AdminController(ILogger<AdminController> logger, IMoviesService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var data =  await _service.GetAll();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost] 
    public async Task<IActionResult> Create([Bind("Name","Price","Description","ImageURL","StartDate","EndDate","MovieCategory")] Movie movie)
    {
        if(!ModelState.IsValid)
        {
            return View(movie);
        }
        _service.Add(movie);
        return RedirectToAction(nameof(Index));

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
