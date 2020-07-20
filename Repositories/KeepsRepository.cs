using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Keep GetById(int id)   
        {
            string sql = "SELECT * FROM keeps WHERE id =@id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal IEnumerable<Keep> GetAll()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal Keep Create(Keep newKeep)
        {
            string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate)
            VALUES
            (@UserId,@Name,@Description,@Img,@IsPrivate);
            SELECT LAST_INSERT_ID()";
            newKeep.Id = _db.ExecuteScalar<int>(sql,newKeep);
            return newKeep;
        }

        // internal bool ViewCount(Keep keepToUpdate)
        // {
        //     string sql=@"
        //     UPDATE keeps
        //     SET
        //     views=@Views
        //     WHERE id = @Id";
        //     int affectedRows = _db.Execute(sql, keepToUpdate);
        //     return affectedRows == 1;
        // }

        //   internal bool KeepCount(Keep keepToUpdate)
        // {
        //     string sql=@"
        //     UPDATE keeps
        //     SET
        //     keeps=@Keeps,
        //     name=@Name,
        //     description=@Description,
        //     WHERE id = @Id";
        //     int affectedRows = _db.Execute(sql, keepToUpdate);
        //     return affectedRows == 1;
        // }
        internal bool userEdit(Keep keepToUpdate)
        {
            string sql=@"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            keeps= @Keeps,
            img= @Img,
            isPrivate=@IsPrivate
            WHERE id = @Id;";
            int affectedRows = _db.Execute(sql, keepToUpdate);
            return affectedRows ==1;
        }
        internal bool viewerEdit(Keep keepToUpdate)
        {
            string sql=@"
            UPDATE keeps
            SET
            keeps= @Keeps,
            WHERE id = @Id;";
            int affectedRows = _db.Execute(sql, keepToUpdate);
            return affectedRows ==1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM keeps WHERE id=@id AND userID = @userId LIMIT 1";
            int affectedRows= _db.Execute(sql, new {id,userId});
            return affectedRows==1;
        }

      
    }
}