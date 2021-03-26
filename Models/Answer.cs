using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Answer
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public int Rating { get; set; }
    [Required]
    public string Posted { get; set; }
    [Required]
    public int QuestionId { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    public Question Question { get; set; }
  }
}