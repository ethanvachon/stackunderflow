using System.Collections.Generic;
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
    public ActionResult<Question> Post([FromBody] Question newQuestion)
    {
      try
      {
        return Ok(_qs.Post());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Question> Edit(int id, [FromBody] Question newQuestion)
    {
      try
      {
        return Ok(_qs.Edit(newQuestion, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _qs.Delete(id);
        return Ok("deleted");
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