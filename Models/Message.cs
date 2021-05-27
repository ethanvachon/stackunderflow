using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Message
  {
    public int Id { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    public int ChatId { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}