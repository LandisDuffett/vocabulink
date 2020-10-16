using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class SentenceWordsRepository
  {
    private readonly IDbConnection _db;

    public SentenceWordsRepository(IDbConnection db)
    {
      _db = db;
    }

    /*internal IEnumerable<SentenceWord> Get()
   {
     string sql = "SELECT * FROM sentencewords;";
     return _db.Query<SentenceWord>(sql);
   }*/

    internal IEnumerable<SentenceWord> GetMySentenceWords(string userId)
    {
      string sql = "SELECT * FROM sentencewords WHERE userId = @userId;";
      return _db.Query<SentenceWord>(sql, new { userId });
    }

    internal SentenceWord GetById(int id)
    {
      string sql = "SELECT * FROM sentencewords WHERE id = @Id;";
      return _db.QueryFirstOrDefault<SentenceWord>(sql, new { id });
    }

    internal int Create(SentenceWord newSentenceWord)
    {
      string sql = @"
        INSERT INTO sentencewords
        (sentenceId, wordId, userId)
        VALUES
        (@SentenceId, @WordId, @userId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newSentenceWord);
    }

    /*public bool Delete()
    {
      string sql = "DELETE FROM sentencewords";
      int rowsAffected = _db.Execute(sql);
      return rowsAffected == 1;
    }*/

    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM sentencewords WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
      return rowsAffected == 1;
    }
  }
}