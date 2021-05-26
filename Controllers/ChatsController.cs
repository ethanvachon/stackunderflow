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

    public ChatsController(ChatsService cs)
    {
      _cs = cs;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Chat> Create([FromBody] Chat newChat)
    {
      try
      {
        return _cs.Create(newChat);
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
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      _cs.Delete(id, userInfo.Id);
      return Ok("success");
    }
  }
}