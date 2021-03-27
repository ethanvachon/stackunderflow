using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class AnswersRepository
  {
    private readonly IDbConnection _db;

    public AnswersRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Answer> Get()
    {
      string sql = @"
      SELECT
      a.*,
      pr.*
      FROM answers a 
      JOIN profiles pr ON a.creatorId = pr.id;";
      return _db.Query<Answer, Profile, Answer>(sql, (answer, profile) => { answer.Creator = profile; return answer; }, splitOn: "id");
    }

    internal Answer Get(int id)
    {
      string sql = @"
      SELECT 
      a.*,
      pr.*
      FROM answers a
      JOIN profiles pr ON a.creatorId = pr.id
      WHERE a.Id = @id";
      return _db.Query<Answer, Profile, Answer>(sql, (answer, profile) => { answer.Creator = profile; return answer; }, new { id }, splitOn: "id").FirstOrDefault();
    }

    internal int Post(Answer newAnswer)
    {
      string sql = @"
      INSERT INTO answers
      (creatorId, rating, posted, body)
      VALUES
      (@CreatorId, @Rating, @Posted, @Body);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newAnswer);
    }

    internal Answer Edit(Answer newAnswer)
    {
      string sql = @"
      UPDATE answers
      SET
      body = @body
      WHERE id = @id;";
      _db.Execute(sql, newAnswer);
      return newAnswer;
    }

    internal IEnumerable<Answer> GetByProfile(string id)
    {
      string sql = @"
      SELECT
      a.*,
      pr.*
      FROM answers a
      JOIN profiles pr ON a.creatorId = pr.id
      WHERE a.creatorId = @id;";
      return _db.Query<Answer, Profile, Answer>(sql, (answer, profile) => { answer.Creator = profile; return answer; }, new { id }, splitOn: "id");
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM answers WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Answer> GetByQuestion(int id)
    {
      string sql = @"
      SELECT
      a.*,
      q.*
      FROM answers a
      JOIN questions q ON a.questionId = q.id
      WHERE questionId = @id;";
      return _db.Query<Answer, Question, Answer>(sql, (answer, question) => { answer.Question = question; return answer; }, new { id }, splitOn: "id");
    }
  }
}