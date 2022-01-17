using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using KinoProject.Data;

namespace KinoProject.Models;

public class Movie
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    [Display(Name = "Cover")]
    public string ImageURL { get; set;}
    [Display(Name = "Start")]

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set;}
    [Display(Name = "End")]
    [DataType(DataType.Date)]

    public DateTime EndDate { get ; set;}
    public MovieCategory MovieCategory { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<Hall> Halls { get; set; }
}
