using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class VaultsController : ControllerBase
{
    private readonly VaultsService _service;

    public VaultsController(VaultsService service)
    {
        _service=service;
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
        return Ok(_service.GetById(vaultId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        return Ok(_service.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }






}


}
