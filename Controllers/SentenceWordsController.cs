using Microsoft.AspNetCore.Mvc;
using Keepr.Models;
using Keepr.Services;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SentenceWordsController : ControllerBase
  {
    private readonly SentenceWordsService _service;

    public SentenceWordsController(SentenceWordsService service)
    {
      _service = service;
    }

    /*[HttpGet]
       public ActionResult<IEnumerable<SentenceWord>> Get()
       {
         try
         {
           return Ok(_service.Get());
         }
         catch (Exception e)
         {
           return BadRequest(e.Message);
         };
       }*/

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<SentenceWord>> GetMySentenceWords()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("error");
        }
        return Ok(_service.GetMySentenceWords(user.Value));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<SentenceWord> GetById(int id)
    {
      var res = _service.GetById(id);
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if ((user == null) || (user.Value != res.UserId) || res == null)
        {
          throw new Exception("error");
        }
        return Ok(_service.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<SentenceWord> Post([FromBody] SentenceWord newSentenceWord)
    {

      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newSentenceWord.UserId = userId;
        return Ok(_service.Create(newSentenceWord));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    /*[HttpDelete]
            public ActionResult<string> Delete()
            {
              try
              {
                return Ok(_service.Delete());
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
          throw new Exception("error");
        }
        return Ok(_service.Delete(user.Value, id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


  }
}