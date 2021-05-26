using System.Data;

namespace stackunderflow.Repositories
{
  public class MessagesRepository
  {
    private readonly IDbConnection _db;

    public MessagesRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}