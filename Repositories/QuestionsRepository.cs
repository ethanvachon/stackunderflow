using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class QuestionsRepository
  {
    private readonly IDbConnection _db;

    public QuestionsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Question> Get()
    {
      string sql = @"
      SELECT
      q.*,
      pr.*
      FROM questions q
      JOIN profiles pr ON q.creatorId = pr.id;";
      return _db.Query<Question, Profile, Question>(sql, (question, profile) => { question.Creator = profile; return question; }, splitOn: "id");
    }

    internal Question Get(int id)
    {
      string sql = @"
      SELECT 
      q.*,
      pr.*
      FROM questions q
      JOIN profiles pr ON q.creatorId = pr.id
      WHERE q.id = @id;";
      return _db.Query<Question, Profile, Question>(sql, (question, profile) => { question.Creator = profile; return question; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Create(Question newQuestion)
    {
      string sql = @"
      INSERT INTO questions
      (rating, posted, title, body, creatorId)
      VALUES 
      (@Rating, @posted, @title, @body, @creatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newQuestion);
    }

    internal IEnumerable<Question> GetByProfile(string id)
    {
      string sql = @"
      SELECT 
      q.*,
      pr.*
      FROM questions q
      JOIN profiles pr ON q.creatorId = pr.id
      WHERE q.creatorId = @id;";
      return _db.Query<Question, Profile, Question>(sql, (question, profile) => { question.Creator = profile; return question; }, new { id }, splitOn: "id");
    }

    internal object Edit(Question newQuestion)
    {
      string sql = @"
      UPDATE questions
      SET
      title = @Title,
      body = @Body
      WHERE id = @id;";
      _db.Execute(sql, newQuestion);
      return newQuestion;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM questions WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}