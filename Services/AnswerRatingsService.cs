using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class AnswerRatingsService
  {
    private readonly AnswerRatingsRepository _repo;
    private readonly AnswersRepository _arepo;

    public AnswerRatingsService(AnswerRatingsRepository repo, AnswersRepository arepo)
    {
      _repo = repo;
      _arepo = arepo;
    }

    internal AnswerRating Create(AnswerRating newRating)
    {
      Answer answer = _arepo.Get(newRating.answerId);
      if (answer == null)
      {
        throw new Exception("invalid answer id");
      }
      newRating.Id = _repo.Create(newRating);
      return newRating;
    }

    // internal void Delete(int ratingId, string id)
    // {
    //   Rated preDelete = _repo.Get(ratingId);
    //   if (preDelete.ProfileId != id)
    //   {
    //     throw new Exception("cannot delete if you are not the creator");
    //   }
    //   _repo.Delete(ratingId);
    // }

    internal IEnumerable<AnswerRating> GetByProfile(string id)
    {
      return _repo.GetByProfile(id);
    }

    internal IEnumerable<AnswerRating> GetByAnswer(int id)
    {
      return _repo.GetByAnswer(id);
    }
  }
}