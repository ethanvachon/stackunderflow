using System.Data;

namespace stackunderflow.Repositories
{
  public class ChatsRepository
  {
    private readonly IDbConnection _db;

    public ChatsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}