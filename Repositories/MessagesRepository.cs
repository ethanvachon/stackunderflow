using System;
using System.Data;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class MessagesRepository
  {
    private readonly IDbConnection _db;

    public MessagesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Message newMessage)
    {
      string sql = @"
      INSERT INTO chats
      (body, chatId, creatorId)
      VALUES
      (@Body, @ChatId, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newMessage);
    }
  }
}