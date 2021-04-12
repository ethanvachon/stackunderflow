using Microsoft.AspNetCore.Mvc;
using stackunderflow.Services;

namespace stackunderflow.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FollowingsController
  {
    private readonly FollowingsService _fs;

    public FollowingsController(FollowingsService fs)
    {
      _fs = fs;
    }
  }
}