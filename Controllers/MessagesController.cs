using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
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

    [HttpPost]
    [Authorize]
    public ActionResult<Message> Create([FromBody] Message newMessage)
    {
      try
      {
        return Ok(_ms.Create(newMessage));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}