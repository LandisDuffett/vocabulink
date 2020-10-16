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

  }
}