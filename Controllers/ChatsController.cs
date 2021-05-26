using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  public class ChatsController
  {
    private readonly ChatsService _cs;

    public ChatsController(ChatsService cs)
    {
      _cs = cs;
    }
  }
}