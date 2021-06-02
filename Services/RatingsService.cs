using System;
using System.Collections.Generic;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class RatingsService
  {
    private readonly RatingsRepository _repo;
    private readonly QuestionsRepository _qrepo;
    private readonly AnswersRepository _arepo;

    public RatingsService(RatingsRepository repo, QuestionsRepository qrepo, AnswersRepository arepo)
    {
      _repo = repo;
      _qrepo = qrepo;
      _arepo = arepo;
    }

    internal Rated Create(Rated newRating)
    {
      Question question = _qrepo.Get(newRating.RatedId);
      if (question == null)
      {
        throw new Exception("invalid rated id");
      }
      if (_repo.SafetyGet(newRating) == null)
      {
        throw new Exception("rating already exists");
      }
      newRating.Id = _repo.Create(newRating);
      return newRating;
    }

    internal void Delete(int ratingId, string id)
    {
      Rated preDelete = _repo.Get(ratingId);
      if (preDelete.ProfileId != id)
      {
        throw new Exception("cannot delete if you are not the creator");
      }
      _repo.Delete(ratingId);
    }

    internal IEnumerable<Rated> GetByProfile(string id)
    {
      return _repo.GetByProfile(id);
    }

    internal IEnumerable<Rated> GetByQuestion(int id)
    {
      return _repo.GetByQuestion(id);
    }
  }
}