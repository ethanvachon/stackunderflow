using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class ChatsRepository
  {
    private readonly IDbConnection _db;

    public ChatsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Chat GetOne(int id)
    {
      string sql = "SELECT * FROM chats WHERE id = @id";
      return _db.QueryFirstOrDefault<Chat>(sql, new { id });
    }

    internal int Create(Chat newChat)
    {
      string sql = @"
      INSERT INTO chats
      (participantOne, participantTwo)
      VALUES
      (@ParticipantOne, @ParticipantTwo);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newChat);
    }

    internal IEnumerable<Chat> GetByProfile(string id)
    {
      string sql = @"
      SELECT 
      c.*,
      pr.*
      FROM chats c
      JOIN profiles pr ON c.participantTwo = pr.id
      WHERE c.participantOne = @id";
      return _db.Query<Chat, Profile, Chat>(sql, (chat, profile) => { chat.User = profile; return chat; }, new { id }, splitOn: "id");
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM chats WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

  }
}