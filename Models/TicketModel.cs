using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

public class Ticket
{

  [Key]
  public int Id { get; set; }  
  string? User {get; set;}
  
  string? Movie {get; set;}

  string TimeStamp {get; set;}

  string Row {get; set;}

  int Seating {get; set;}


}
