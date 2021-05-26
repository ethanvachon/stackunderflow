using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  public class MessagesController
  {
    private readonly MessagesService _ms;

    public MessagesController(MessagesService ms)
    {
      _ms = ms;
    }
  }
}