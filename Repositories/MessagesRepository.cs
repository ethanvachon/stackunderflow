using System;
using System.Collections.Generic;
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

    internal IEnumerable<Message> GetByChat(int id)
    {
      string sql = @"
      SELECT
      m.*,
      pr.*
      FROM messages m
      JOIN profiles pr ON m.creatorId = pr.id
      WHERE m.chatId = @id;
      ";
      return _db.Query<Message, Profile, Message>(sql, (message, profile) => { message.Creator = profile; return message; }, new { id }, splitOn: "id");
    }
  }
}