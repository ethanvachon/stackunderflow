using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class AnswerRatingsRepository
  {
    private readonly IDbConnection _db;

    public AnswerRatingsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal int Create(AnswerRating newRating)
    {
      string sql = @"
      INSERT INTO answerratings
      (profileId, answerId, rating)
      VALUES
      (@profileId, @answerId, @rating);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newRating);
    }

    internal IEnumerable<AnswerRating> GetByProfile(string id)
    {
      string sql = "SELECT * FROM answerratings WHERE profileId = @id;";
      return _db.Query<AnswerRating>(sql, new { id });
    }

    internal IEnumerable<AnswerRating> GetByAnswer(int id)
    {
      string sql = "SELECT * FROM answerratings WHERE answerId = @id";
      return _db.Query<AnswerRating>(sql, new { id });
    }
  }
}