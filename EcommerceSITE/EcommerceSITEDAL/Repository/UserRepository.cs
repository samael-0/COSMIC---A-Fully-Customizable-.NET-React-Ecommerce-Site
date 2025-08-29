using EcommerceSITEDAL.DataAccess;
using EcommerceSITEDAL.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSITEDAL.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ISqlDataAccess _db;

        public UserRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task AddNewUser(Users users)
        {
            string sql = @"INSERT INTO Users (Username, Email, PasswordHash, PasswordSalt, Phone, Address, Role)
                VALUES (@username, @email, @passwordhash,@passwordsalt, @phone, @address, @role) ;
                    ";

            var parameters= new { username = users.Username, email = users.Email, passwordhash = users.PasswordHash,passwordsalt = users.PasswordSalt,phone= users.Phone, address = users.Address, role = users.Role };

            await _db.SaveData(sql, parameters);

        }

        public async Task<Users?> GetUserbyID(string Username)
        {
            var sql = @"select * from Users where Username = @username";

            var parameters= new { username = Username };
            var result = await _db.GetData<Users, dynamic>(sql, parameters);
            return result.FirstOrDefault();
        }



    }
}
