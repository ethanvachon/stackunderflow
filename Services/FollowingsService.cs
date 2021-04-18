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
    private readonly QuestionsRepository _qrepo;
    private readonly AnswersRepository _arepo;

    public FollowingsService(FollowingsRepository repo, ProfilesRepository prepo, QuestionsRepository qrepo, AnswersRepository arepo)
    {
      _repo = repo;
      _prepo = prepo;
      _qrepo = qrepo;
      _arepo = arepo;
    }

    internal Following Create(Following newFollowing)
    {
      Profile profile = _prepo.GetById(newFollowing.FollowerId);
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

    internal List<IEnumerable<Question>> GetQuestionFeed(string id)
    {
      IEnumerable<Following> profiles = _repo.GetByProfile(id);
      List<IEnumerable<Question>> questions = new List<IEnumerable<Question>>();
      foreach (Following profile in profiles)
      {
        questions.Add(_qrepo.GetByProfile(profile.FollowingId));
      }
      return questions;
    }

    internal List<IEnumerable<Answer>> GetAnswerFeed(string id)
    {
      IEnumerable<Following> profiles = _repo.GetByProfile(id);
      List<IEnumerable<Answer>> answers = new List<IEnumerable<Answer>>();
      foreach (Following profile in profiles)
      {
        answers.Add(_arepo.GetByProfile(profile.FollowingId));
      }
      return answers;
    }
  }
}