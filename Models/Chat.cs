using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Chat
  {
    public int Id { get; set; }
    [Required]
    public string ParticipantOne { get; set; }
    [Required]
    public string ParticipantTwo { get; set; }
    public Profile UserOne { get; set; }
    public Profile UserTwo { get; set; }
  }
}