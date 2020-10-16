using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace Keepr.Services
{
  public class SentenceWordsService
  {

    private readonly SentenceWordsRepository _repo;

    public SentenceWordsService(SentenceWordsRepository repo)
    {
      _repo = repo;
    }

    /*public IEnumerable<SentenceWord> Get()
       {
         return _repo.Get();
       }*/

    public IEnumerable<SentenceWord> GetMySentenceWords(string userId)
    {

      return _repo.GetMySentenceWords(userId);
    }

    public SentenceWord GetById(int id)
    {
      SentenceWord foundSentenceWord = _repo.GetById(id);
      if (foundSentenceWord == null)
      {
        throw new Exception("Invalid sentenceword Id");
      }
      return foundSentenceWord;
    }

    internal SentenceWord Create(SentenceWord newSentenceWord)
    {
      int id = _repo.Create(newSentenceWord);
      newSentenceWord.Id = id;
      return newSentenceWord;
    }

    /*public string Delete()
        {
          bool deleted = _repo.Delete();
          return "All deleted!";
        }*/

    public string Delete(string userId, int id)
    {
      GetById(id);
      bool deleted = _repo.Delete(userId, id);
      if (!deleted)
      {
        throw new Exception("error");
      }
      return "Deleted!";
    }
  }
}