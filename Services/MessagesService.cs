using System;
using System.Collections.Generic;
using System.Linq;
using stackunderflow.Models;
using stackunderflow.Repositories;

namespace stackunderflow.Services
{
  public class MessagesService
  {
    private readonly MessagesRepository _mrepo;
    private readonly ChatsRepository _crepo;

    public MessagesService(MessagesRepository mrepo, ChatsRepository crepo)
    {
      _mrepo = mrepo;
      _crepo = crepo;
    }

    internal Message Create(Message newMessage)
    {
      newMessage.Id = _mrepo.Create(newMessage);
      Chat chat = _crepo.GetOne(newMessage.ChatId);
      Chat userTwo = _crepo.GetByProfile(chat.ParticipantTwo).FirstOrDefault(c => c.ParticipantTwo.Equals(newMessage.CreatorId));
      newMessage.ChatId = userTwo.Id;
      _mrepo.Create(newMessage);
      return newMessage;
    }

    internal IEnumerable<Message> GetByChat(int id)
    {
      return _mrepo.GetByChat(id);
    }
  }
}