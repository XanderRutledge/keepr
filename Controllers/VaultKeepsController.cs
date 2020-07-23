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
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _service;
    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }


  // [HttpGet]
  // public ActionResult<IEnumerable<VaultKeepViewModel>> GetByUser()
  //   {
  //     try
  //     {
  //       string userId= HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;   
  //       return Ok(_service.GetByUser(userId));
          
  //     }
  //     catch (Exception e)
  //     {
  //         return BadRequest(e.Message);
  //     }
  //   }
  


    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        newVaultKeep.UserId= HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;   
        return Ok(_service.Create(newVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    
    [HttpDelete("{id}")]
    public ActionResult<VaultKeep> Delete(int id)
    {
      try
      {
        string userId= HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;   
        return Ok(_service.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}