using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/answers")]
  public class AnswersController : ControllerBase
  {
    private readonly AnswersService _as;

    public AnswersController(AnswersService @as)
    {
      _as = @as;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Answer>> Get()
    {
      try
      {
        return Ok(_as.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Answer> Get(int id)
    {
      try
      {
        return Ok(_as.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Answer>> PostAsync([FromBody] Answer newAnswer)
    {
      try
      {
        newAnswer.Rating = 0;
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newAnswer.CreatorId = userInfo.Id;
        Answer answer = _as.Post(newAnswer);
        answer.Creator = userInfo;
        return answer;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Answer>> EditAsync(int id, [FromBody] Answer newAnswer)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newAnswer.Id = id;
        newAnswer.CreatorId = userInfo.Id;
        return Ok(_as.Edit(newAnswer, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<string>> DeleteAsync(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        _as.Delete(id, userInfo.Id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}