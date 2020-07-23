using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
         {
             _repo = repo;
         }

         internal IEnumerable<Vault> GetByUserId(string userId)
        {
            return _repo.GetVaultsByUserId(userId);
        }

        public IEnumerable<Vault> Get()
         {
             return _repo.Get();
          }


        internal Vault GetById(int vaultId,string userId)
        {
            Vault exists = _repo.GetById(vaultId);
            if(exists ==null){throw new Exception("thats not a vault");}
            if(exists.UserId!=userId){throw new Exception("thats not yours");}
            return exists;
        }

        internal Vault Create(Vault newVault)
        {
            int id = _repo.Create(newVault);
            newVault.Id=id;
            return newVault;
        }

        internal Vault Delete(int id, string userId)
        {
            Vault exists = GetById(id,userId);
            _repo.Delete(id);
            return exists;
        }
    }
}