namespace stackunderflow.Models
{
  public class Following
  {
    public int Id { get; set; }
    public string FollowingId { get; set; }
    public string FollowerId { get; set; }
    public Profile User { get; set; }
  }
}