using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

public class Hall
{
  [Key]
  public int Id { get; set; }
  string? User {get; set;}
  
  State State;

  int AmountOfBusySeat {get; set;}
  int MaxCapacity {get; set;}

  int Nr {get; set;}

}
 enum State
 {
     playing,
     free,

 }