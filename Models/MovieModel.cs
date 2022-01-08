using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    int DurationMin;

    string Name { get; set; }

    string Category { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

    public ICollection<Hall> Halls { get; set; }


}