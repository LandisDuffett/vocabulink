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
    public SentencesController(SentencesService ss)
    {
      _ss = ss;
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

  }
}