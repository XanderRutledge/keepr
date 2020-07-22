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


        internal Vault GetById(int vaultId)
        {
            Vault exists = _repo.GetById(vaultId);
            if(exists ==null){throw new Exception("thats not a vault");}
            return exists;
        }

        internal Vault Create(Vault newVault)
        {
            int id = _repo.Create(newVault);
            newVault.Id=id;
            return newVault;
        }

        internal Vault Delete(int id)
        {
            Vault exists = GetById(id);
            _repo.Delete(id);
            return exists;
        }
    }
}