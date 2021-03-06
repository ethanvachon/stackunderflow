using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class FollowingsRepository
  {
    private readonly IDbConnection _db;

    public FollowingsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Following newFollowing)
    {
      string sql = @"
      INSERT INTO following
      (followingId, followerId)
      VALUES
      (@FollowingId, @FollowerId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newFollowing);
    }

    internal Following Get(int id)
    {
      string sql = "SELECT * FROM following WHERE id = @id;";
      return _db.QueryFirstOrDefault<Following>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM following WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Following> GetByProfile(string id)
    {
      string sql = @"
      SELECT 
      f.*,
      pr.*
      FROM following f
      JOIN profiles pr ON f.followingId = pr.id
      WHERE f.followerId = @id";
      return _db.Query<Following, Profile, Following>(sql, (following, profile) => { following.User = profile; return following; }, new { id }, splitOn: "id");
    }
  }
}