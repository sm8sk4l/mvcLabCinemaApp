using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

public class Hall
{
    [Key]
    public int Id { get; set; }

    public State State;

    public int AmountOfBusySeat { get; set; }
    public int MaxCapacity { get; set; }

    public int Nr { get; set; }
   
    public User User { get; set; }

    public Movie Movie { get; set; }

}
public enum State
{
    playing,
    free,

}