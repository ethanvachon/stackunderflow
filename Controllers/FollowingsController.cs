using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FollowingsController : ControllerBase
  {
    private readonly FollowingsService _fs;

    public FollowingsController(FollowingsService fs)
    {
      _fs = fs;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Following>> Create([FromBody] Following newFollowing)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newFollowing.FollowerId = userInfo.Id;
        return _fs.Create(newFollowing);
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
      _fs.Delete(id, userInfo.Id);
      return Ok("success");
    }
  }
}