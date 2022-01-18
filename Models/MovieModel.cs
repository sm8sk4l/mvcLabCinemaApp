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
    

    [Required(ErrorMessage = "Price is required.")]
    public double Price { get; set; }


    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }


    [Required(ErrorMessage = "Cover is required.")]
    [Display(Name = "Cover")]
    public string ImageURL { get; set;}


    [Required(ErrorMessage = "Start Date is required.")]
    [Display(Name = "Start")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set;}


    [Required(ErrorMessage = "End Date is required.")]
    [Display(Name = "End")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get ; set;}


    [Required(ErrorMessage = "Genre is required.")]
    [Display(Name = "Genre")]
    public MovieCategory MovieCategory { get; set; }

    
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<Hall> Halls { get; set; }
}
