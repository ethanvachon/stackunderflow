namespace stackunderflow.Models
{
  public class AnswerRating
  {
    public int Id { get; set; }
    public string ProfileId { get; set; }
    public int answerId { get; set; }

    public bool Rating { get; set; }

  }
}