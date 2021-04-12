using System;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class RatingsRepository
  {
    private readonly IDbConnection _db;

    internal Rated Get(int ratingId)
    {
      string sql = @"SELECT * FROM ratings WHERE id = @ratingId;";
      return _db.QueryFirstOrDefault(sql, new { ratingId });
    }
    internal int Create(Rated newRating)
    {
      string sql = @"
      INSERT INTO ratings
      (profileId, ratingId)
      VALUES
      (@profileId, @ratingId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newRating);
    }

    internal void Delete(int ratingId)
    {
      string sql = "DELETE * FROM ratings WHERE id = @ratingId LIMIT 1;";
      _db.Execute(sql, new { ratingId });
    }

  }
}