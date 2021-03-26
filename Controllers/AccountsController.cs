using System.Collections.Generic;
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
  [Route("[controller]")]
  [Authorize]
  public class AccountController : ControllerBase
  {

    private readonly ProfilesService _ps;

    public AccountController(ProfilesService ps)
    {
      _ps = ps;
    }

    [HttpGet]
    public async Task<ActionResult<Profile>> GetAccount()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}