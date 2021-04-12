using System.Data;

namespace stackunderflow.Repositories
{
  public class FollowingsRepository
  {
    private readonly IDbConnection _db;

    public FollowingsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}