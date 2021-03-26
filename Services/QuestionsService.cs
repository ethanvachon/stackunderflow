using System;
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

    internal object Get()
    {
      return _repo.Get();
    }

    internal object Get(int id)
    {
      throw new NotImplementedException();
    }

    internal object Post()
    {
      throw new NotImplementedException();
    }

    internal object Edit(Question newQuestion, int id)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}