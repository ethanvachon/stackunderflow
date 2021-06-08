using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class RatingsRepository
  {
    private readonly IDbConnection _db;

    public RatingsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Rated Get(int ratingId)
    {
      string sql = @"SELECT * FROM ratings WHERE id = @ratingId;";
      return _db.QueryFirstOrDefault(sql, new { ratingId });
    }
    internal int Create(Rated newRating)
    {
      string sql = @"
      INSERT INTO ratings
      (profileId, ratedId, rating)
      VALUES
      (@profileId, @ratedId, @rating);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newRating);
    }

    internal Rated SafetyGet(Rated rating)
    {
      string sql = @"
      SELECT *
      FROM ratings r
      WHERE r.profileId = @profileId
      AND r.ratedId = @ratedId";
      return _db.QueryFirstOrDefault<Rated>(sql, rating);
    }

    internal void Delete(int ratingId)
    {
      string sql = "DELETE * FROM ratings WHERE id = @ratingId LIMIT 1;";
      _db.Execute(sql, new { ratingId });
    }

    internal IEnumerable<Rated> GetByProfile(string id)
    {
      string sql = "SELECT * FROM ratings WHERE profileId = @id;";
      return _db.Query<Rated>(sql, new { id });
    }

    internal IEnumerable<Rated> GetByQuestion(int id)
    {
      string sql = "SELECT * FROM ratings WHERE ratedId = @id;";
      return _db.Query<Rated>(sql, new { id });
    }
  }
}