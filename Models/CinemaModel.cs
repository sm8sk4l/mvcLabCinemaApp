using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace KinoProject.Models;

public class Cinema
{
    KinoProject.Data.DataContext context;
    [Key]
    public int Id { get; set; }
    public ICollection<Hall> Halls { get; set; }
    public Cinema(KinoProject.Data.DataContext Context)
    {
        context = Context;
    }
    public async Task OnGetAsync()
    {
        Halls = await context.Halls
            .Include(c => c)
            .AsNoTracking()
            .ToListAsync();
    }
}