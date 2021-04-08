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
  public class RatingsController : ControllerBase
  {
    private readonly RatingsService _rs;

    public RatingsController(RatingsService rs)
    {
      _rs = rs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Rated>> Create([FromBody] Rated newRating)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newRating.profileId = userInfo.Id;
        return _rs.Create(newRating);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int ratingId)
    {
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      _rs.Delete(ratingId, userInfo.Id);
      return Ok("success");
    }
  }
}