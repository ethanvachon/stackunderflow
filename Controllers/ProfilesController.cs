
using System.Collections.Generic;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
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
    private readonly RatingsService _rs;
    private readonly FollowingsService _fs;

    public ProfilesController(ProfilesService ps, QuestionsService qs, AnswersService @as, RatingsService rs, FollowingsService fs)
    {
      _ps = ps;
      _qs = qs;
      _as = @as;
      _rs = rs;
      _fs = fs;
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

    [HttpPut]
    [Authorize]
    public async System.Threading.Tasks.Task<ActionResult<Profile>> Edit([FromBody] Profile newProfile)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newProfile.Id = userInfo.Id;
        return Ok(_ps.Edit(newProfile));
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
    [HttpGet("{id}/following")]
    public ActionResult<IEnumerable<Following>> GetFollowing(string id)
    {
      try
      {
        return Ok(_fs.GetByProfile(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/ratings")]
    public ActionResult<IEnumerable<Rated>> GetRatings(string id)
    {
      try
      {
        return Ok(_rs.GetByProfile(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/questionfeed")]
    public ActionResult<IEnumerable<Rated>> GetQuestionFeed(string id)
    {
      try
      {
        return Ok(_fs.GetQuestionFeed(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/answerfeed")]
    public ActionResult<IEnumerable<Rated>> GetAnswerFeed(string id)
    {
      try
      {
        return Ok(_fs.GetAnswerFeed(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}