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
      throw new NotImplementedException();
    }
    internal object Get(int id)
    {
      throw new NotImplementedException();
    }

    internal object Post()
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal object Edit(Answer newAnswer, int id)
    {
      throw new NotImplementedException();
    }

    internal object GetByQuestion(int id)
    {
      throw new NotImplementedException();
    }
  }
}