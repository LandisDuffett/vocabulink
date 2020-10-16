using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class WordsService
  {
    private readonly WordsRepository _repo;
    public WordsService(WordsRepository repo)
    {
      _repo = repo;
    }
    /*public IEnumerable<Word> Get()
    {
      return _repo.Get();
    }*/

    public IEnumerable<Word> GetMyWords(string userId)
    {

      return _repo.GetMyWords(userId);
    }

    public Word GetById(int id)
    {
      Word foundWord = _repo.GetById(id);
      if (foundWord == null)
      {
        throw new Exception("Invalid word Id");
      }
      return foundWord;
    }

    public Word Create(Word newWord)
    {
      return _repo.Create(newWord);
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

    public Word Update(Word updatedWord)
    {
      Word foundWord = GetById(updatedWord.Id);
      updatedWord.Id = foundWord.Id;
      updatedWord.UserId = foundWord.UserId;
      updatedWord.Name = updatedWord.Name == null ? foundWord.Name : updatedWord.Name;
      updatedWord.Definition = updatedWord.Definition == null ? foundWord.Definition : updatedWord.Definition;
      updatedWord.Img = updatedWord.Img == null ? foundWord.Img : updatedWord.Img;
      bool updated = _repo.Update(updatedWord);
      if (!updated)
      {
        throw new Exception("Sorry, you are not the owner of this word and cannot edit it.");
      }
      return updatedWord;
    }

    internal IEnumerable<SentenceWordWordViewModel> GetWordsBySentenceId(int wordId, string userId)
    {
      return _repo.GetWordsBySentenceId(wordId, userId);
    }
  }
}