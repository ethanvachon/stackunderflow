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

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }

    internal object GetByQuestion(int id)
    {
      return _repo.GetByQuestion(id);
    }
  }
}