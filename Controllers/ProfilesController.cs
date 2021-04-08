
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly QuestionsService _qs;
    private readonly AnswersService _as;

    public ProfilesController(ProfilesService ps, QuestionsService qs, AnswersService @as)
    {
      _ps = ps;
      _qs = qs;
      _as = @as;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Profile>> GetAll()
    {
      try
      {
        return Ok(_ps.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _ps.GetProfileById(id);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/questions")]
    public ActionResult<IEnumerable<Question>> GetQuestions(string id)
    {
      try
      {
        return Ok(_qs.GetByProfile(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/answers")]
    public ActionResult<IEnumerable<Answer>> GetAnswers(string id)
    {
      try
      {
        return Ok(_as.GetByProfile(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}