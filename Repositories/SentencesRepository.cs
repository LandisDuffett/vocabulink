using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class SentencesRepository
  {
    private readonly IDbConnection _db;

    public SentencesRepository(IDbConnection db)
    {
      _db = db;
    }

    /*internal IEnumerable<Sentence> Get()
    {
      string sql = "SELECT * FROM sentences;";
      return _db.Query<Sentence>(sql);
    }*/

    internal IEnumerable<Sentence> GetMySentences(string userId)
    {
      string sql = "SELECT * FROM sentences WHERE userId = @userId;";
      return _db.Query<Sentence>(sql, new { userId });
    }

    internal Sentence GetById(int id)
    {
      string sql = "SELECT * FROM sentences WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Sentence>(sql, new { id });
    }

    internal Sentence Create(Sentence newSentence)
    {
      string sql = @"INSERT INTO sentences
            (text, userId)
            VALUES
            (@text, @userId);
            SELECT LAST_INSERT_ID();";
      newSentence.Id = _db.ExecuteScalar<int>(sql, newSentence);
      return newSentence;
    }

    public bool Update(Sentence updatedSentence)
    {
      string sql = @"UPDATE sentences SET text = @text WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, updatedSentence);
      return rowsAffected == 1;
    }

    /*public bool Delete()
    {
      string sql = "DELETE FROM sentences";
      int rowsAffected = _db.Execute(sql);
      return rowsAffected == 1;
    }*/

    public bool Delete(string userId, int id)
    {
      string sql = "DELETE FROM sentences WHERE id = @id AND userId = @userId LIMIT 1;";
      int rowsAffected = _db.Execute(sql, new { userId, id });
      return rowsAffected == 1;
    }
    internal IEnumerable<SentenceWordSentenceViewModel> GetSentencesByWordId(int wordId, string userId)
    {
      string sql = @"
        SELECT 
        s.*,
        sw.id as sentencewordId
        FROM sentencewords sw
        INNER JOIN sentences s ON s.id = sw.sentenceId 
        WHERE(wordId = @wordId AND sw.userId = @userId);";
      return _db.Query<SentenceWordSentenceViewModel>(sql, new { wordId, userId });
    }
  }
}