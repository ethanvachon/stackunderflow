using System;
using System.Collections.Generic;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class FollowingsService
  {
    private readonly FollowingsRepository _repo;
    private readonly ProfilesRepository _prepo;

    public FollowingsService(FollowingsRepository repo, ProfilesRepository prepo)
    {
      _repo = repo;
      _prepo = prepo;
    }

    internal Following Create(Following newFollowing)
    {
      Profile profile = _prepo.GetById(newFollowing.FollowingId);
      if (profile == null)
      {
        throw new Exception("invalid profile id");
      }
      newFollowing.Id = _repo.Create(newFollowing);
      return newFollowing;
    }

    internal void Delete(int followingId, string id)
    {
      Following preDelete = _repo.Get(followingId);
      if (preDelete == null)
      {
        throw new Exception("invalid delete id");
      }
      if (preDelete.FollowerId != id)
      {
        throw new Exception("invalid creator");
      }
      _repo.Delete(followingId);
    }

    internal IEnumerable<Following> GetByProfile(string id)
    {
      return _repo.GetByProfile(id);
    }
  }
}