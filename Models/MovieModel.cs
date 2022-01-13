using System.ComponentModel.DataAnnotations;
using KinoProject.Data;

namespace KinoProject.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    int DurationMin;
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set;}
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get ; set;}
    public MovieCategory MovieCategory { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<Hall> Halls { get; set; }


}