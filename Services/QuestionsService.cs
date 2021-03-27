using System;
using System.Collections.Generic;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class QuestionsService
  {
    private readonly QuestionsRepository _repo;

    public QuestionsService(QuestionsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Question> Get()
    {
      return _repo.Get();
    }

    internal Question Get(int id)
    {
      Question question = _repo.Get(id);
      if (question == null)
      {
        throw new Exception("invalid id");
      }
      return question;
    }

    internal Question Post(Question newQuestion)
    {
      newQuestion.Id = _repo.Create(newQuestion);
      return newQuestion;
    }

    internal object Edit(Question newQuestion, string id)
    {
      Question preEdit = _repo.Get(newQuestion.Id);
      if (preEdit == null)
      {
        throw new Exception("invalid id");
      }
      if (preEdit.CreatorId != id)
      {
        throw new Exception("cannot edit if you are not the creator");
      }
      return _repo.Edit(newQuestion);
    }

    internal IEnumerable<Question> GetByProfile(string id)
    {
      return _repo.GetByProfile(id);
    }

    internal string Delete(int id, string userId)
    {
      Question preDelete = _repo.Get(id);
      if (preDelete == null)
      {
        throw new Exception("invalid id");
      }
      if (preDelete.CreatorId != userId)
      {
        throw new Exception("cannot delete if you are not the creator");
      }
      _repo.Delete(id);
      return "deleted";
    }
  }
}