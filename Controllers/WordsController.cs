using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WordsController : ControllerBase
  {
    private readonly WordsService _ws;
    private readonly SentencesService _ss;
    public WordsController(WordsService ws, SentencesService ss)
    {
      _ws = ws;
      _ss = ss;
    }
    /*[HttpGet]
    public ActionResult<IEnumerable<Word>> Get()
    {
      try
      {
        return Ok(_ws.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }*/

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Word>> GetMyWords()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to see your words.");
        }
        return Ok(_ws.GetMyWords(user.Value));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<Word> GetById(int id)
    {
      var res = _ws.GetById(id);
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if ((user == null) || (user.Value != res.UserId) || res == null)
        {
          throw new Exception("You do not have access to this word.");
        }
        return Ok(_ws.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Word> Post([FromBody] Word newWord)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newWord.UserId = userId;
        return Ok(_ws.Create(newWord));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Word> Update(int id, [FromBody] Word updatedWord)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if ((user == null) || (user.Value != updatedWord.UserId))
        {
          throw new Exception("You must be logged in to put a word in a sentence.");
        }
        updatedWord.UserId = user.Value;
        updatedWord.Id = id;
        return Ok(_ws.Update(updatedWord));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    /*[HttpDelete]
        public ActionResult<string> Delete()
        {
          try
          {
            return Ok(_ws.Delete());
          }
          catch (System.Exception err)
          {
            return BadRequest(err.Message);
          }
        }*/

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to delete any words.");
        }
        return Ok(_ws.Delete(user.Value, id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{wordId}/sentences")]
    public ActionResult<SentenceWordSentenceViewModel> GetSentencesByWordId(int wordId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ss.GetSentencesByWordId(wordId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}