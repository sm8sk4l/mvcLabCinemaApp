using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

public class User
{

    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "E-mail is required.")]
    [DataType(DataType.EmailAddress)]
    public string Mail { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public ICollection<Ticket> Tickets { get; set; }

}