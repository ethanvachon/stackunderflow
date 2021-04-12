using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class FollowingsService
  {
    private readonly FollowingsRepository _repo;

    public FollowingsService(FollowingsRepository repo)
    {
      _repo = repo;
    }
  }
}