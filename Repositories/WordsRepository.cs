using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class WordsRepository
  {
    private readonly IDbConnection _db;

    public WordsRepository(IDbConnection db)
    {
      _db = db;
    }

    /*internal IEnumerable<Word> Get()
    {
      string sql = "SELECT * FROM Words;";
      return _db.Query<Word>(sql);
    }*/

    internal IEnumerable<Word> GetMyWords(string userId)
    {
      string sql = "SELECT * FROM words WHERE userId = @userId;";
      return _db.Query<Word>(sql, new { userId });
    }

    internal Word GetById(int id)
    {
      string sql = "SELECT * FROM words WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Word>(sql, new { id });
    }

    public bool Update(Word updatedWord)
    {
      string sql = @"UPDATE words SET name = @name, definition = @definition, img = @img WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedWord);
      return rowsAffected == 1;
    }

    internal Word Create(Word newWord)
    {
      string sql = @"INSERT INTO Words
            (name, definition, userId, img)
            VALUES
            (@name, @definition, @userId, @img);
            SELECT LAST_INSERT_ID();";
      newWord.Id = _db.ExecuteScalar<int>(sql, newWord);
      return newWord;
    }

    /*public bool Delete()
    {
      string sql = "DELETE FROM words";
      int rowsAffected = _db.Execute(sql);
      return rowsAffected == 1;
    }*/

    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM words WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
      return rowsAffected == 1;
    }
  }
}