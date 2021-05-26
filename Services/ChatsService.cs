using System;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class ChatsService
  {
    private readonly ChatsRepository _crepo;

    public ChatsService(ChatsRepository crepo)
    {
      _crepo = crepo;
    }

    internal Chat Create(Chat newChat)
    {
      newChat.Id = _crepo.Create(newChat);
      return newChat;
    }

    internal void Delete(int id, string userId)
    {
      Chat preDelete = _crepo.GetOne(id);
      if (preDelete.ParticipantOne == userId)
      {
        _crepo.Delete(id);
      }
      else if (preDelete.ParticipantTwo == userId)
      {
        _crepo.Delete(id);
      }
      else
      {
        throw new Exception("cannot end chat user is not in");
      }
    }
  }
}