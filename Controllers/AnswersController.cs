using System.Collections.Generic;
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
    public ActionResult<Answer> Post([FromBody] Answer newAnswer)
    {
      try
      {
        return Ok(_as.Post());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Answer> Edit(int id, [FromBody] Answer newAnswer)
    {
      try
      {
        return Ok(_as.Edit(newAnswer, id));
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
        _as.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}