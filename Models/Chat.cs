using System.ComponentModel.DataAnnotations;

namespace stackunderflow.Models
{
  public class Chat
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string ParticipantOne { get; set; }
    [Required]
    public string ParticipantTwo { get; set; }
  }
}