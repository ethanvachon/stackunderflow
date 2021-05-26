using Microsoft.AspNetCore.Mvc;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MessagesController : ControllerBase
  {
    private readonly MessagesService _ms;

    public MessagesController(MessagesService ms)
    {
      _ms = ms;
    }
  }
}