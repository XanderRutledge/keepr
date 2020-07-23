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
public class VaultsController : ControllerBase
{
    private readonly VaultsService _service;
    private  readonly VaultKeepsService _VKservice;

    public VaultsController(VaultsService service, VaultKeepsService VKservice)
    {
        _service=service;
        _VKservice=VKservice;
    }


[HttpGet("{vaultId}/keeps")]
    public ActionResult<Vault> GetKeepsByVault(int vaultId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_VKservice.GetKeepsByVault(vaultId,userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

     [HttpGet("user")]
        [Authorize]
        public ActionResult<IEnumerable<Vault>> GetVaultsByUser()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_service.GetByUserId(userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}")]
    public ActionResult<Vault> GetById(int vaultId)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        return Ok(_service.GetById(vaultId,userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVault.UserId = userId;
        return Ok(_service.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        return Ok(_service.Delete(id,userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }






}


}
