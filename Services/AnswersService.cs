using System;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class AnswersService
  {
    private readonly AnswersRepository _repo;

    public AnswersService(AnswersRepository repo)
    {
      _repo = repo;
    }

    internal object Get()
    {
      return _repo.Get();
    }
    internal object Get(int id)
    {
      return _repo.Get(id);
    }

    internal Answer Post(Answer newAnswer)
    {
      newAnswer.Id = _repo.Post(newAnswer);
      return newAnswer;
    }

    internal Answer Edit(Answer newAnswer, string userId)
    {
      Answer preEdit = _repo.Get(newAnswer.Id);
      if (preEdit == null)
      {
        throw new Exception("invalid id");
      }
      if (preEdit.CreatorId != userId)
      {
        throw new Exception("cannot edit keep if you aren't the creator");
      }
      return _repo.Edit(newAnswer);
    }

    internal string Delete(int id, string userId)
    {
      Answer preDelete = _repo.Get(id);
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

    internal object GetByProfile(string id)
    {
      throw new NotImplementedException();
    }

    internal object GetByQuestion(int id)
    {
      return _repo.GetByQuestion(id);
    }
  }
}