using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {

        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

          internal IEnumerable<Vault> GetVaultsByUserId(string userId)
        {
            string sql = "SELECT * FROM vaults WHERE userId = @userId";
            return _db.Query<Vault>(sql, new { userId });
        }

          internal IEnumerable<Vault> Get()
           {
        string sql = "SELECT * FROM vaults";
              return _db.Query<Vault>(sql);
          }

        internal Vault GetById(int vaultId)
        {
            string sql = "SELECT * FROM vaults WHERE id = @vaultId";
            return _db.QueryFirstOrDefault<Vault>(sql, new {vaultId});
        }

        internal int Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults
            (name,description,userId)
            VALUES
            (@Name,@Description,@userId);
            SELECT LAST_INSERT_ID();";
            return _db.ExecuteScalar<int>(sql, newVault);
        }

        internal void Delete(int Id)
        {
            string sql = @"DELETE FROM vaults WHERE id =@Id";
            _db.Execute(sql, new {Id});
        }
    }
}
