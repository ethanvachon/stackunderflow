using System;
using Microsoft.AspNetCore.Mvc;
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

    internal ActionResult<Rated> Create(Rated newRating)
    {
      Question question = _qrepo.Get(newRating.RatedId);
      Answer answer = _arepo.Get(newRating.RatedId);
      if (question == null && answer == null)
      {
        throw new Exception("invalid rated id");
      }
      newRating.Id = _repo.Create(newRating);
      return newRating;
    }

    internal void Delete(int ratingId, string id)
    {
      Rated preDelete = _repo.Get(ratingId);
      if (preDelete.profileId != id)
      {
        throw new Exception("cannot delete if you are not the creator");
      }
      _repo.Delete(ratingId);
    }
  }
}