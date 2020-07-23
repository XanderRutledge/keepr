using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

 
    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }

    public VaultKeep Delete(int id,string userId)
    {
      VaultKeep exists = GetById(id);
      if(userId!=exists.UserId){throw new Exception("thats not yours");}
      _repo.Delete(id);
      return exists;
    }

    public VaultKeep GetById(int Id)
    {
      VaultKeep exists = _repo.GetById(Id);
      if (exists == null) { throw new Exception("not a vaultkeep"); }
      return exists;
    }

    public IEnumerable<VaultKeepViewModel> GetKeepsByVault(int vaultId, string userId)
    {
      return _repo.GetKeepsByVault(vaultId,userId);
    }


    

  }
}