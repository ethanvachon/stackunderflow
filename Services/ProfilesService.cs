using System;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal object GetOrCreateProfile(Profile userInfo)
    {
      throw new NotImplementedException();
    }

    internal Profile GetProfileById(string id)
    {
      throw new NotImplementedException();
    }
  }
}