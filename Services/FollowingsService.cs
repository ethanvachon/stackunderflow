using System;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class FollowingsService
  {
    private readonly FollowingsRepository _repo;

    public FollowingsService(FollowingsRepository repo)
    {
      _repo = repo;
    }

    internal ActionResult<Following> Create(Following newFollowing)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int ratingId, string id)
    {
      throw new NotImplementedException();
    }
  }
}