using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ChatsController : ControllerBase
  {
    private readonly ChatsService _cs;
    private readonly MessagesService _ms;

    public ChatsController(ChatsService cs, MessagesService ms)
    {
      _cs = cs;
      _ms = ms;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Chat> Create([FromBody] Chat newChat)
    {
      try
      {
        return Ok(_cs.Create(newChat));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _cs.Delete(id, userInfo.Id);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpGet("{id}/messages")]
    [Authorize]
    public ActionResult<IEnumerable<Message>> GetMessages(int id)
    {
      try
      {
        return Ok(_ms.GetByChat(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}