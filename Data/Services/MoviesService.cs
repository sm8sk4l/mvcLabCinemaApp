using Microsoft.EntityFrameworkCore;
using KinoProject.Models;

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
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Movie>> GetAll()
    {
        var result = await _context.Movies.ToListAsync();
        return result;
    }

    public Movie GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Movie Update(int id, Movie newMovie)
    {
        throw new NotImplementedException();
    }
}