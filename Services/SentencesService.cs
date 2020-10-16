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

    public Sentence Create(Sentence newSentence)
    {
      return _repo.Create(newSentence);
    }

  }
}