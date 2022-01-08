using System.ComponentModel.DataAnnotations;

namespace KinoProject.Models;

 public class UserModel
  {
    
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Mail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
  }