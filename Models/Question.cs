using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Question
  {
    [Required]
    public int Id { get; set; }
    public int Rating { get; set; }
    [Required]
    public string Posted { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Body { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}