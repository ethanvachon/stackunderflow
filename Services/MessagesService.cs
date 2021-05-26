using System;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class MessagesService
  {
    private readonly MessagesRepository _mrepo;

    public MessagesService(MessagesRepository mrepo)
    {
      _mrepo = mrepo;
    }

    internal Message Create(Message newMessage)
    {
      newMessage.Id = _mrepo.Create(newMessage);
      return newMessage;
    }
  }
}