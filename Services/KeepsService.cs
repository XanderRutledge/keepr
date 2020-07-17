using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> GetAll(int id)
        {
            return _repo.GetAll();
        }

        internal Keep GetById(int id)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            return foundKeep;
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        
//NOTE finish this
        internal Keep Edit(Keep keepToUpdate, string userId)
        {
            Keep foundKeep = GetById(keepToUpdate.Id);
            if (foundKeep.UserId != userId && foundKeep.Keeps<keepToUpdate.Keeps)
            {
                
            }
            return foundKeep;
        }

        internal string Delete(int id, string userId)
        {
            Keep foundKeep = GetById(id);
            if(foundKeep.UserId != userId)
            {
                throw new Exception("Get outta mah keep");
            }
            if(_repo.Delete(id, userId))
            {
                return "Delorted";
            };
            throw new Exception("if you see this...seek help");
           
        }
    }
}