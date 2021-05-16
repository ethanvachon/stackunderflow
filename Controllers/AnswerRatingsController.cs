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

  public class AnswerRatingsController : ControllerBase
  {
    private readonly AnswerRatingsService _ars;

    public AnswerRatingsController(AnswerRatingsService ars)
    {
      _ars = ars;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<AnswerRating>> Create([FromBody] AnswerRating newRating)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newRating.ProfileId = userInfo.Id;
        return _ars.Create(newRating);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //   [HttpDelete]
    //   [Authorize]
    //   public async Task<ActionResult<string>> Delete(int ratingId)
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     _ars.Delete(ratingId, userInfo.Id);
    //     return Ok("success");
    //   }
  }
}