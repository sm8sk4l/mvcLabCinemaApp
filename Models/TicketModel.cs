using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;
    public class Ticket
{

    [Key]
    public int Id { get; set; }

    public string TimeStamp { get; set; }

    public string Row { get; set; }

    public int Seating { get; set; }

    public Movie Movie {get; set;}

    public User User {get;set;}

}
