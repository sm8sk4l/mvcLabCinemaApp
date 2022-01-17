using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using KinoProject.Data;

namespace KinoProject.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set;}
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set;}
    [DataType(DataType.Date)]

    public DateTime EndDate { get ; set;}
    public MovieCategory MovieCategory { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<Hall> Halls { get; set; }
}
