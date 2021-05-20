using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Profile
  {
    [Required]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Picture { get; set; }
    [Required]
    public int Rating { get; set; }
  }
}