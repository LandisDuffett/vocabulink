using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class SentencesService
  {
    private readonly SentencesRepository _repo;
    public SentencesService(SentencesRepository repo)
    {
      _repo = repo;
    }

    /*public IEnumerable<Sentence> Get()
        {
          return _repo.Get();
        }*/

    public IEnumerable<Sentence> GetMySentences(string userId)
    {

      return _repo.GetMySentences(userId);
    }

    public Sentence GetById(int id)
    {
      Sentence foundSentence = _repo.GetById(id);
      if (foundSentence == null)
      {
        throw new Exception("Invalid sentence Id");
      }
      return foundSentence;
    }

    public Sentence Create(Sentence newSentence)
    {
      return _repo.Create(newSentence);
    }

    public Sentence Update(Sentence updatedSentence)
    {
      Sentence foundSentence = GetById(updatedSentence.Id);
      updatedSentence.Id = foundSentence.Id;
      updatedSentence.UserId = foundSentence.UserId;
      updatedSentence.Text = updatedSentence.Text == null ? foundSentence.Text : updatedSentence.Text;
      bool updated = _repo.Update(updatedSentence);
      if (!updated)
      {
        throw new Exception("Sorry, you are not the owner of this word and cannot edit it.");
      }
      return updatedSentence;
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
        throw new Exception("You are not the owner of this word.");
      }
      return "Deleted!";
    }
  }
}