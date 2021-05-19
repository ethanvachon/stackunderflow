using System;
using System.Data;
using Dapper;
using stackunderflow.Models;

namespace stackunderflow.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"
      INSERT INTO profiles
      (name, picture, email, id)
      VALUES
      (@Name, @Picture, @Email, @Id)
      ;";
      _db.Execute(sql, userInfo);
      return userInfo;
    }

    internal object GetAll()
    {
      string sql = "SELECT * FROM profiles";
      return _db.Query(sql);
    }

    internal Profile Edit(Profile newProfile)
    {
      string sql = @"
      UPDATE profiles
      SET
      picture = @Picture,
      name = @Name
      WHERE id = @id;";
      _db.Execute(sql, newProfile);
      return newProfile;
    }

    internal void AddRating(Profile newProfile)
    {
      string sql = @"
      UPDATE profiles
      SET
      rating = @rating
      WHERE id = @id;";
      _db.Execute(sql, newProfile);
    }
  }
}