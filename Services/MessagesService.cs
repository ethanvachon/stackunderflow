using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class MessagesService
  {
    private readonly MessagesRepository _mrepo;

    public MessagesService(MessagesRepository mrepo)
    {
      _mrepo = mrepo;
    }
  }
}