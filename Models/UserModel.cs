using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

public class User
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Mail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

}