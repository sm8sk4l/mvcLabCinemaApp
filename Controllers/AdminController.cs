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
using Microsoft.EntityFrameworkCore;

namespace KinoProject.Controllers;
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly DataContext _context;
    public AdminController(ILogger<AdminController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _context.Movies.ToListAsync();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, double price, string description, string imageurl, DateTime startdate, DateTime enddate, MovieCategory moviecategory)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _context.Movies.Add(new Movie()
        {
            Name = name,
            Price = price,
            Description = description,
            ImageURL = imageurl,
            StartDate = startdate,
            EndDate = enddate,
            MovieCategory = moviecategory
        });
        _context.SaveChanges();
        return RedirectToAction("Index", "Admin");
    }

    public ActionResult Edit(int id)
    {
            var data = _context.Movies.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Movie movie)
    {
        var data = _context.Movies.FirstOrDefault(x => x.Id == id);
        if (data != null)
        {
            data.Name = movie.Name;
            data.Price = movie.Price;
            data.Description = movie.Description;
            data.ImageURL = movie.ImageURL;
            data.StartDate = movie.StartDate;
            data.EndDate = movie.EndDate;
            data.MovieCategory = movie.MovieCategory;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    public ActionResult Delete(int id)
    {
        var movieDetails = _context.Movies.FirstOrDefault(n => n.Id == id);
        if (movieDetails == null)
        {
            return View("NotFound");
        }
        return View(movieDetails);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var movieDetails = _context.Movies.Where(n => n.Id == id).ToList();
        if (movieDetails == null)
        {
            return View("NotFound");
        }
        
        _context.Movies.RemoveRange(movieDetails);
        _context.SaveChanges();
        return RedirectToAction("Index", "Admin");
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
