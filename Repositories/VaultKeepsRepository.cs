using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<VaultKeepViewModel> GetByUser(string userId)
    {
      string sql = @"
      SELECT 
         k.*,
         vk.id as vaultKeepId
         FROM vaultkeeps vk
         INNER JOIN keeps k ON k.id = vk.keepId 
         WHERE (vaultId = @vaultId AND vk.userId = @userId)";
        return _db.Query<VaultKeepViewModel>(sql, new { userId });
    }

    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"
        INSERT INTO vaultkeeps
        (keepId, vaultId,userId)
        VALUES
        (@KeepId, @VaultId,@UserId);
        SELECT LAST_INSERT_ID();";
      newVaultKeep.Id= _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id";
      _db.Execute(sql, new { Id });
    }

    internal IEnumerable<VaultKeep> GetKeepsByVaultId(int id)
    {
      string sql = @"
         SELECT 
         k.*,
         vk.id as vaultKeepId
         FROM vaultkeeps vk
         INNER JOIN keeps k ON k.id = vk.keepId 
         WHERE (vaultId = @vaultId AND vk.userId = @userId)
        ";
      return _db.Query<VaultKeep>(sql, new { id });
    }
  }
}