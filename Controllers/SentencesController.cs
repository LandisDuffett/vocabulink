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
  public class SentencesController : ControllerBase
  {
    private readonly SentencesService _ss;
    private readonly WordsService _ws;
    public SentencesController(SentencesService ss, WordsService ws)
    {
      _ss = ss;
      _ws = ws;
    }

    /*[HttpGet]
        public ActionResult<IEnumerable<Sentence>> Get()
        {
          try
          {
            return Ok(_ss.Get());
          }
          catch (Exception e)
          {
            return BadRequest(e.Message);
          };
        }*/

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Sentence>> GetMySentencess()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("You must be logged in to see your words.");
        }
        return Ok(_ss.GetMySentences(user.Value));
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
      var res = _ss.GetById(id);
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if ((user == null) || (user.Value != res.UserId) || res == null)
        {
          throw new Exception("You do not have access to this sentence.");
        }
        return Ok(_ss.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Sentence> Post([FromBody] Sentence newSentence)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newSentence.UserId = userId;
        return Ok(_ss.Create(newSentence));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Sentence> Update(int id, [FromBody] Sentence updatedSentence)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if ((user == null) || (user.Value != updatedSentence.UserId))
        {
          throw new Exception("You must be logged in to edit a sentence.");
        }
        updatedSentence.UserId = user.Value;
        updatedSentence.Id = id;
        return Ok(_ss.Update(updatedSentence));
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
        return Ok(_ss.Delete());
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
          throw new Exception("You must be logged in to delete any sentences.");
        }
        return Ok(_ss.Delete(user.Value, id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{sentenceId}/words")]
    public ActionResult<SentenceWordWordViewModel> GetWordsBySentenceId(int sentenceId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ws.GetWordsBySentenceId(sentenceId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}