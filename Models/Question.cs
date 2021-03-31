using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Question
  {
    [Required]
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Posted { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}