using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class ChatsService
  {
    private readonly ChatsRepository _crepo;

    public ChatsService(ChatsRepository crepo)
    {
      _crepo = crepo;
    }
  }
}