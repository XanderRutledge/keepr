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
        public IEnumerable<Keep> GetAll()
        {
            return _repo.GetAll();
        }

        internal IEnumerable<Keep> GetByUserId(string userId)
        {
            return _repo.GetKeepsByUserId(userId);
        }

        internal Keep GetById(int id,string userId)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("Invalid Id");
            }
            if(foundKeep.IsPrivate==false){
                return foundKeep;
            }
            if(foundKeep.IsPrivate == true && foundKeep.UserId==userId)
            {
                return foundKeep;
            }
            if(foundKeep.IsPrivate == true)
            {
                throw new Exception("thats private");
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
            Keep foundKeep = GetById(keepToUpdate.Id,userId);
            if(foundKeep.UserId==userId)
            {
                if(_repo.userEdit(keepToUpdate))
                {
                    foundKeep = keepToUpdate;
                    return foundKeep;
                }
            }
            if(foundKeep.UserId!=keepToUpdate.UserId)
            {
                if(_repo.viewerEdit(keepToUpdate))
                {
                    foundKeep.Views = keepToUpdate.Views;
                    foundKeep.Keeps = keepToUpdate.Keeps;
                    return foundKeep;
                }
            }
            throw new Exception("not yo keep");
        }

        internal string Delete(int id, string userId)
        {
            Keep foundKeep = GetById(id,userId);
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