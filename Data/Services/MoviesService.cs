using Microsoft.EntityFrameworkCore;
using KinoProject.Models;
using KinoProject.Data;

namespace KinoProject.Data.Services;

public class MoviesService : IMoviesService
{ 
    private readonly DataContext _context;
    public MoviesService(DataContext context)
    {
        _context = context;
    }
    public void Add(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        var result = await _context.Movies.ToListAsync();
        return result;
    }

    public Movie GetById(int id)
    {
        var result = _context.Movies.FirstOrDefault(n => n.Id == id);
        return result;
    } 

    public Movie Update(int id, Movie newMovie)
    {
        _context.Update(newMovie);
        _context.SaveChanges();
        return newMovie;
    }

    public static bool ValidateMovie(Movie movie)
    {
        if (movie.Name == "" || movie.Name == null)
            return false;

        if(movie.Price < 0)
            return false;

        if (movie.Description == "" || movie.Description == null)
            return false;

        if (movie.ImageURL == "" || movie.ImageURL == null)
            return false;

        return true;
    }
}