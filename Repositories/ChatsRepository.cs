using System;
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
      string sql = @"
      SELECT 
      c.*,
      pr.*
      FROM chats c
      JOIN profiles pr ON c.participantOne = pr.id
      JOIN profiles pr ON c.participantTwo = pr.id
      WHERE a.Id = @id";
      return _db.Query<Chat, Profile, Profile, Chat>(sql, (chat, profile, profileTwo) => { chat.UserOne = profile; chat.UserTwo = profileTwo; return chat; }, new { id }, splitOn: "id").FirstOrDefault();
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
    internal void Delete(int id)
    {
      string sql = "DELETE FROM chats WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

  }
}