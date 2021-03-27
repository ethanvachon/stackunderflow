using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/Questions")]
  public class QuestionsController : ControllerBase
  {
    private readonly QuestionsService _qs;

    private readonly AnswersService _as;

    public QuestionsController(QuestionsService qs, AnswersService @as)
    {
      _qs = qs;
      _as = @as;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Question>> Get()
    {
      try
      {
        return Ok(_qs.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Question> Get(int id)
    {
      try
      {
        return Ok(_qs.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Question>> Post([FromBody] Question newQuestion)
    {
      try
      {
        newQuestion.Rating = 0;
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newQuestion.CreatorId = userInfo.Id;
        Question question = _qs.Post(newQuestion);
        question.Creator = userInfo;
        return Ok(question);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Question>> EditAsync(int id, [FromBody] Question newQuestion)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newQuestion.Id = id;
        newQuestion.CreatorId = userInfo.Id;
        return Ok(_qs.Edit(newQuestion, userInfo.Id));
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
        return Ok(_qs.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/answers")]
    public ActionResult<IEnumerable<Answer>> GetAnswers(int id)
    {
      try
      {
        return Ok(_as.GetByQuestion(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}